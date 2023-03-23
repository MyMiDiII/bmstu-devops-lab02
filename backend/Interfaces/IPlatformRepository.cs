using ServerING.Models;
using System.Collections.Generic;


namespace ServerING.Interfaces {
    public interface IPlatformRepository : IRepository<Platform> {
        Platform GetByName(string name);
    }
}
