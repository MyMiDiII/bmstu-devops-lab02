﻿using ServerING.Interfaces;
using ServerING.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using ServerING.Exceptions;
using ServerING.DTO;
using ServerING.Enums;
using ServerING.ModelsBL;

namespace ServerING.Services {
    public interface IUserService {
        UserBL AddUser(UserBL user);
        UserBL UpdateUser(int id, UserBL user);
        UserBL DeleteUser(int id);

        UserBL Login(LoginDto loginDto);

        UserBL GetUserByID(int id);
        IEnumerable<UserBL> GetAllUsers();

        UserBL GetUserByLogin(string login);
        IEnumerable<UserBL> GetUsersByRole(string role);
        
        IEnumerable<ServerBL> GetUserFavoriteServers(
            int userId,
            ServerFilterDto filter, 
            ServerSortState? sortState,
            int? page,
            int? pageSize
        );
        FavoriteServerBL AddFavoriteServer(int userId, int serverId);
        FavoriteServerBL DeleteFavoriteServer(int userId, int serverId);
        FavoriteServerBL GetFavoriteByServerAndUserId(int userId, int serverId);
    }

    public class UserService : IUserService {

        private readonly IUserRepository userRepository;
        private readonly IServerService serverService;
        private readonly IMapper mapper;


        public UserService(IUserRepository userRepository, IServerService serverService, IMapper mapper) {
            this.userRepository = userRepository;
            this.serverService = serverService;
            this.mapper = mapper;
        }


        private bool IsExist(UserBL user) {
            return userRepository.GetAll()
                .Where(item => item.Id != user.Id)
                .Any(item => item.Login == user.Login);
        }


        private bool IsFavoriteExist(int userId, int serverId) {
            return userRepository.GetFavoriteServerByUserAndServerId(userId, serverId) != null;
        }


        public FavoriteServerBL GetFavoriteByServerAndUserId(int userId, int serverId) {
            return mapper.Map<FavoriteServerBL>(userRepository.GetFavoriteServerByUserAndServerId(userId, serverId));
        }


        private bool IsExistById(int id) {
            return userRepository.GetByID(id) != null;
        }

        public UserBL Login(LoginDto loginDto) {
            UserBL user = GetUserByLogin(loginDto.Login);

            if (user == null) {
                Console.WriteLine("User: no such user");
                return null;
            }

            if (user.Password == loginDto.Password) {
                return user;
            }
            else {
                Console.WriteLine("User: wrong password");
                return null;
            }
        }
        
        public UserBL AddUser(UserBL user) {
            if (IsExist(user))
                throw new UserAlreadyExistsException("User already exists");

            var transferedUser = mapper.Map<User>(user);
            return mapper.Map<UserBL>(userRepository.Add(transferedUser));
        }

        public IEnumerable<UserBL> GetAllUsers() {
            return mapper.Map<IEnumerable<UserBL>>(userRepository.GetAll());
        }

        public UserBL GetUserByID(int id) {
            return mapper.Map<UserBL>(userRepository.GetByID(id));
        }

        public UserBL GetUserByLogin(string login) {
            return mapper.Map<UserBL>(userRepository.GetByLogin(login));
        }

        public IEnumerable<UserBL> GetUsersByRole(string role) {
            return mapper.Map<IEnumerable<UserBL>>(userRepository.GetByRole(role));
        }

        public UserBL UpdateUser(int id, UserBL user) {
            if (!IsExistById(id))
                return null;

            if (IsExist(user))
                throw new UserAlreadyExistsException("User already exists");

            var transferedUser = mapper.Map<User>(user);
            return mapper.Map<UserBL>(userRepository.Update(transferedUser));
        }

        public UserBL DeleteUser(int id) {
            return mapper.Map<UserBL>(userRepository.Delete(id));
        }

        public IEnumerable<ServerBL> GetUserFavoriteServers(
            int userId,
            ServerFilterDto filter, 
            ServerSortState? sortState,
            int? page,
            int? pageSize
        ) {
            if (!IsExistById(userId))
                throw new UserNotExistsException("No user with such id");

            var servers = mapper.Map<IEnumerable<ServerBL>>(userRepository.GetFavoriteServersByUserId(userId));

            // Фильтрация
            servers = serverService.FilterServers(servers, filter);

            // Сортировка
            if (sortState != null) {
                servers = serverService.SortServersByOption(servers, sortState.Value);
            }

            // Пагинация
            if (page != null) {
                servers = serverService.PaginationServers(servers, page.Value, pageSize.Value);
            }
            

            return servers;
        }

        public FavoriteServerBL AddFavoriteServer(int userId, int serverId) {
            if (IsFavoriteExist(userId, serverId))
                throw new UserFavoriteAlreadyExistsException("Already in favorites");

            FavoriteServer favoriteServer = new FavoriteServer {
                UserID = userId,
                ServerID = serverId
            };

            serverService.UpdateServerRating(serverId, +1);

            userRepository.AddFavoriteServer(favoriteServer);

            return mapper.Map<FavoriteServerBL>(favoriteServer);
        }

        public FavoriteServerBL DeleteFavoriteServer(int userId, int serverId) {
            serverService.UpdateServerRating(serverId, -1);

            FavoriteServer favoriteServer = userRepository.GetFavoriteServerByUserAndServerId(userId, serverId);

            if (favoriteServer != null)
                userRepository.DeleteFavoriteServer(favoriteServer.Id);

            return mapper.Map<FavoriteServerBL>(favoriteServer);
        }
    }
}
