Postman - online:
Alex-netcore 
https://www.postman.com/api-evangelist/docker/request/tg4rihy/create-a-container?tab=body

https://localhost:44381/

Means: 
sqlserver will be started first, 
then depending nservice:
 
 depends_on:
      - sqlserver   
	    
	  
	  
docker stats
-- gives stream info about the runing containers:

	CONTAINER ID   
	NAME                          
	CPU %     
	MEM USAGE / LIMIT    
	MEM %     
	NET I/O       
	BLOCK I/O   
	PIDS

docker stats --help
-- https://www.youtube.com/watch?v=clP6jSIBgxUdiscover all options for the command

docker run -p 8080:80 --name container-backend image-backend

1. Docker Build Commands:

	docker build -t <image_name> .
	Build a Docker image from 
	a Dockerfile in 
	the current directory and 
	tag it with a name 

	docker build --no-cache -t <image_name> . 
	Build a Docker image without 
	using the cache 
	

	docker build -f <dockerfile_name> -t <image_name> . 
	Build a Docker image using 
	a specified Dockerfile:
		docker build --no-cache -t postman/newman
		docker run -t postman/newman run "https://www.getpostman.com/collections/8a0c9bc08f062d12dcda"


2. Docker Clean Up Commands:

	docker system prune
	
	-Remove all unused 
	Docker resources, including 
	containers, images, networks, 
	and volumes

	docker container prune
	
	-Remove all stopped containers

	docker image prune
	Remove unused images 

	docker volume prune
	Remove unused volumes

	docker network prune
	Remove unused networks	

3. Container Interaction Commands:

	docker run <image_name> 
	-Run a Docker image as a container 

	docker start <container_id> 
	-Start a stopped container 

	docker stop <container_id> 
	-Stop a running container 

	docker restart <container_id> 
	-Restart a running container 

	docker exec -it <container_id> <command>
	-Execute a command inside 
	a running container 
	interactively

4. Container Inspection Commands:

    docker ps
	-List running containers 

    docker ps -a 
	-List all containers, 
	including stopped ones 

    docker logs <container_id> 
	-Fetch the logs of a specific 
	container 

    docker inspect <container_id>
	Inspect detailed information 
	about a container

5. Image Commands:

    docker images
	List available Docker images
	
    docker pull <image_name>
	Pull a Docker image from 
	a Docker registry

    docker push <image_name>
	Push a Docker image to 
	a Docker registry 

    docker rmi <image_id>
	Remove a Docker image

6. Docker Run Commands:

    docker run -d <image_name>
	Run a Docker image as 
	a container in detached mode 

    docker run -p <host_port>:<container_port> <image_name>
	Publish container ports to the host 

    docker run -v <host_path>:<container_path> <image_name>
	Mount a host directory or 
	volume to a container 

    docker run --name <container_name> <image_name>
	Assign a custom name 
	to the container 

7. Docker Registry Commands:

    docker login
	Log in to a Docker registry

    docker logout
	Log out from a Docker registry

    docker search <term>
	Search for Docker images 
	in a Docker registry

    docker pull <registry>/<image_name>
	Pull a Docker image from 
	a specific registry

8. Docker Service Commands:

    docker service create --name <service_name> <image_name>
	Create a Docker service 
	from an image

    docker service ls
	List running Docker 
	services

    docker service scale <service_name>=<replicas>
	Scale the replicas of 
	a Docker service

    docker service logs <service_name>
	View logs of 
	a Docker service

9. Docker Network Commands:

    docker network create <network_name>
	Create a Docker network

    docker network ls
	List available Docker networks

    docker network inspect <network_name>
	Inspect detailed information 
	about a Docker network

    docker network connect <network_name> <container_name>
	Connect a container 
	to a Docker network

10. Docker Volume Commands:

    docker volume create <volume_name>
	Create a Docker volume

    docker volume ls
	List available Docker volumes

    docker volume inspect <volume_name>
	Inspect detailed information 
	about a Docker volume.

    docker volume rm <volume_name>
	Remove a Docker volume

11. Docker Swarm Commands:

    docker swarm init
	Initialize a Docker 
	swarm on the current node

    docker swarm join
	Join a Docker swarm as 
	a worker node

    docker node ls
	List the nodes in 
	a Docker swarm

    docker service create
	Create a service in 
	the Docker swarm

    docker service scale
	Scale the replicas of 
	a service in the Docker swarm

12. Docker Filesystem Commands:

    docker cp <container_id>:<container_path> <host_path>
	Copy files from 
	a container to the host

    docker cp <host_path> <container_id>:<container_path>
	Copy files from 
	the host to a container

13. Docker Environment Variables:

    -e or --env
	Set environment variables 
	when running a container

    docker run -e <variable_name>=<value> <image_name>
	Set an environment variable 
	when running a container

14. Docker Health Checks:

    HEALTHCHECK instruction: 
	Define a command to check 
	the health of a container

    docker container inspect --format='{{json .State.Health}}' <container_name>
	Check the health status 
	of a container 

15. Docker Compose Commands:

    docker-compose up
	Create and start containers 
	defined in a Docker Compose file 

    docker-compose down
	Stop and remove containers 
	defined in a Docker Compose file

    docker-compose ps
	List containers defined 
	in a Docker Compose file 

    docker-compose logs
	View logs of containers 
	defined in a Docker Compose file 

16. Docker Stats:

    docker stats
	Display a live stream of 
	resource usage by containers 

    docker stats <container_name>
	Display the resource usage 
	of a specific container
	
**********************
	Dockerfile:

	LABEL, ENV, ARG 
	 - are only set to provide 
	some metadata for the image

	WORKDIR /react-docker-example/
	 - sets the working directory 
	for any commands you add 
	in the Dockerfile.
	while building the image, 
	the commands will be executed 
	in this directory.

	COPY public/ /react-docker-example/public
	COPY src/ /react-docker-example/src
	COPY package.json /react-docker-example/
	 - copy the files we need 
	into the working directory:
	COPY <src-path> <destination-path>

	RUN npm install
	 - executes any command by 
	adding a new layer on top of 
	the current ones, thus 
	modifying the image. 
	This modified image 
	will be used for 
	the next steps.
	In this case, it installs 
	all the dependencies specified 
	in the package.json file. 
	This is why we did not copy 
	the node_modules folder into 
	the working directory. 
	The folder will be created 
	after this command gets executed
	 
	CMD ["npm", "start"]
	 - command that will be executed 
	when starting a container 
	from the image. 
	must have only be one CMD 
	instruction in the Dockerfile. 
	If there are more than one, 
	then only the last one 
	will be considered.

*********************
	How to Build the Image?
	 - Now we have written the Dockerfile!

	docker image build -t <image_name>:<tag> <path>
	 -t specifies the name and tag 
	for the image













*****************

docker pull mcr.microsoft.com/mssql/server
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password_123#" -p 1433:1433 --name sql_server_container -d mcr.microsoft.com/mssql/server

    -e 'ACCEPT_EULA=Y'
	Accept the End-User 
	Licensing Agreement
	
    -e 'SA_PASSWORD'
	Set the SA password
	
    -p 1433:1433
	Map the host port 1433 to 
	the container port 1433
	
    --name sql_server_container
	Give the container a name 
	(you can choose any name)
	
    -d
	Run the container in 
	the background

docker stop sql_server_container

docker image build -t react-example-image:latest .
 - or: docker build -t <image name> .
. at the end represents 
the current directory

docker images 
 - to see a list of 
images in your system

docker stop sql_server_container
docker start sql_server_container
docker logs sql_server_container

docker rm sql_server_container
 - To remove the container 
 (after stopping it), use
 
**************
React with Docker

npx create-react-app my-react-app
npm run build
 - Create a Dockerfile:
 
# Specify the base image
FROM node:alpine

# Set the working directory
WORKDIR /app# Copy the package.json and package-lock.json files
COPY package*.json ./# Install the dependencies
RUN npm install# Copy the app files
COPY . .# Build the app
RUN npm run build# Expose the port
EXPOSE 3000# Run the app
CMD ["npm", "start"]

docker build -t my-react-app-image .
docker run -p 3000:3000 my-react-app-image

    Create a Docker Hub account 
	if you don’t already have one.
    Log in to Docker Hub using 
	the docker login command in your terminal.
	
    Tag the Docker image with 
	your Docker Hub username and 
	the app name using the following command:

    docker tag my-react-app-image your-docker-hub-username/my-react-app-

	- Push the Docker image to 
	Docker Hub using the following command:

    docker push your-docker-hub-username/my-react-app-image:latest

*** Variant 2 for Dockerfile:

	#Stage 1
	FROM node:17-alpine as builder
	WORKDIR /app
	COPY package*.json .
	COPY yarn*.lock .
	RUN yarn install
	COPY . .
	RUN yarn build

	#Stage 2
	FROM nginx:1.19.0
	WORKDIR /usr/share/nginx/html
	RUN rm -rf ./*
	COPY --from=builder /app/build .
	ENTRYPOINT ["nginx", "-g", "daemon off;"]
	
	docker build -t docker-react-image:1.0 . 
	docker run -p 3000:3000 docker-react-image
	
*** END Variant 2 for Dockerfile 

**************************
NEXT js with Dockerfile 

	FROM node:18

	WORKDIR /app
	COPY package*.json ./
	RUN npm install
	COPY . .
	EXPOSE 3000
	CMD npm run dev
	
	docker build -t my-app .
	docker run -p 3000:3000 my-app
	
*******************
Multi-stage DockerFile

	FROM node:18-alpine as base
	RUN apk add --no-cache g++ make py3-pip libc6-compat
	WORKDIR /app
	COPY package*.json ./
	EXPOSE 3000

	FROM base as builder
	WORKDIR /app
	COPY . .
	RUN npm run build


	FROM base as production
	WORKDIR /app

	ENV NODE_ENV=production
	RUN npm ci

	RUN addgroup -g 1001 -S nodejs
	RUN adduser -S nextjs -u 1001
	USER nextjs


	COPY --from=builder --chown=nextjs:nodejs /app/.next ./.next
	COPY --from=builder /app/node_modules ./node_modules
	COPY --from=builder /app/package.json ./package.json
	COPY --from=builder /app/public ./public

	CMD npm start

	FROM base as dev
	ENV NODE_ENV=development
	RUN npm install 
	COPY . .
	CMD npm run dev
 
*******************
docker-compose.yml 

	version: '3.8'
	services:
	  app:
		image: openai-demo-app
		build:
		  context: ./
		  target: dev
		  dockerfile: Dockerfile
		volumes:
			- .:/app
			- /app/node_modules
			- /app/.next
		ports:
		  - "3000:3000"

	docker-compose build
	docker-compose up
	
*******************




