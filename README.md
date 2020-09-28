# Olympiad

## Requirements

* [.Net Core 3.1](https://dotnet.microsoft.com/download)
* [Node.JS 12+](https://nodejs.org/en/)

## Run
### docker-compose
To work using `docker-compose` you should use all docker-compose.yml files
```bash
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml -f .\Olympiad-Back\docker-compose.yml -f .\Olympiad-Back\docker-compose.override.yml -f .\Olympiad-Front\docker-compose.yml -f .\Olympiad-Front\docker-compose.override.yml COMMAND
```

#### Pull images
```bash
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml -f .\Olympiad-Back\docker-compose.yml -f .\Olympiad-Back\docker-compose.override.yml -f .\Olympiad-Front\docker-compose.yml -f .\Olympiad-Front\docker-compose.override.yml pull
```

#### Start containers
```bash
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml -f .\Olympiad-Back\docker-compose.yml -f .\Olympiad-Back\docker-compose.override.yml -f .\Olympiad-Front\docker-compose.yml -f .\Olympiad-Front\docker-compose.override.yml up -d
```



### Using Cake wrapper

> Use `build.ps1` on Windows, and `build.sh` on Linux/MacOS

#### Pull images 
```bash
./build.ps1 -t DockerPull
```

#### Start containers
```bash
./build.ps1 -t DockerUp
```

## Build

Use Cake wrapper to build all parts

### Build all
```bash
./build.ps1
```

### Build docker images

```bash
./build.ps1 -t DockerBuild
```

### Start docker containers

```bash
./build.ps1 -t DockerUp
```