# Лабораторная работа №2

```bash
# vm1
curl -L "[https://packages.gitlab.com/install/repositories/runner/gitlab-runner/script.deb.sh](https://packages.gitlab.com/install/repositories/runner/gitlab-runner/script.deb.sh)" | sudo bash

sudo apt-get install gitlab-runner
sudo gitlab-runner register
# URL: https://git.iu7.bmstu.ru/
# токен репы
# любое описание
# Tags: build,test,deploy
# enter
# shell

# vm1 и vm2
sudo apt-get update && sudo apt-get install -y dotnet-sdk-6.0

# vm1
sudo apt install npm

# vm2 
sudo apt install nginx

# vm1
sudo apt install sshpass

# vm2
sudo mkdir /var/opt/app
sudo mkdir /var/www/site
sudo chown -R $USER /var/opt/app
sudo chown -R $USER /var/www/site
sudo chown -R $USER /etc/nginx/

# vm1
sudo sh -c "echo 1 > /proc/sys/net/ipv4/ip_forward"
sudo iptables -t nat -A PREROUTING -p tcp --dport 80 -j DNAT --to-destination <vm2_ip>:80
sudo iptables -t nat -A POSTROUTING -p tcp -d <vm2_ip> --dport 80 -j SNAT --to-source <vm1_ip>

# На своей машине в директории бекенда проекта пролить миграции
dotnet ef database update
```
