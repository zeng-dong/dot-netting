docker container run --rm -it -p 8080:80 nginx
docker container run -i -t --rm -p 8080:8080 jenkins/jenkins:latest

docker container list

docker container stop xyzabc
docker container rm xyzabc

I have 4.34 and I have trouble to pull images from mcr.
Googled and some say downgrade to 4.32 helps
So I downloaded 4.32 installer and go to the folder and issue this command:
	 & '.\Docker Desktop_432 Installer.exe' install --disable-version-check
	it prompts something like "do you want to replace " and I confirm


# command
docker
docker ps
docker pull
docker rm

# examples
docker pull nginx:alpine
docker images                    // see it
docker run -p 8080:80 nginx:alpine              // in vervose mode, ctrl c to exit it  
	go to localhost:8080 to see it
ctrl c
docker ps -a                  // list all the containers
docker rm [container id ...]
