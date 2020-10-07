# Olympiad

## Requirements

* [.Net Core 3.1](https://dotnet.microsoft.com/download)
* [Node.JS 12+](https://nodejs.org/en/)

## Run from docker hub images

To work using `docker-compose` you should use alias `odc` (**o**lympiad-**d**ocker-**c**ompose)
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
odc build --no-cache
```

### Start docker containers

```bash
odc up -d
```