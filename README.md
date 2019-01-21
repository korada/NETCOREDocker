# NETCOREDocker
## Build
- docker build -t dockerdemo .

## Deploy option 1
- docker-compose up 
- ctrl+z to stop containers

## Deploy option 2
- docker swarm init (need to be done for local. Swarm already exists in docker cluster)
- docker stack deploy -c docker-compose.yml dockerdemo
- docker stack rm dockerdemo to remove the stack and services

