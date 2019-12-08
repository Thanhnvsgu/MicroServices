@echo off
[92m
docker rmi iis_demo
docker rmi iisnode_demo
docker build ./dotnet -t "iis_demo"
docker build ./nodejs -t "iisnode_demo"
echo [33m___________build dockerfile hoan tat___________[0m