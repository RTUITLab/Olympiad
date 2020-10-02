# Olympiad

## Requirements

* [.Net Core 3.1](https://dotnet.microsoft.com/download)
* [Node.JS 12+](https://nodejs.org/en/)

## Run from docker hub images

To work using `docker-compose` you should use all docker-compose.yml files
```bash
docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml -f .\Olympiad-Back\docker-compose.yml -f .\Olympiad-Back\docker-compose.override.yml -f .\Olympiad-Front\docker-compose.yml -f .\Olympiad-Front\docker-compose.override.yml COMMAND
```
Or use alias `odc` (**o**lympiad-**d**ocker-**c**ompose)
```bash
# On Windows
. .\alias.ps1

# On Linux
. ./alias.sh
```
In the next steps, the alias will be used
#### Pull images
```bash
odc pull
```

#### Start containers
```bash
odc up -d
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