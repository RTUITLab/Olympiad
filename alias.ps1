function OlympiadDockerCompose {
    docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml -f .\Olympiad-Back\docker-compose.yml -f .\Olympiad-Back\docker-compose.override.yml -f .\Olympiad-Front\docker-compose.yml -f .\Olympiad-Front\docker-compose.override.yml $args
}
function OlympiadDockerComposeStack {
    docker-compose -f .\docker-compose.yml -f .\Olympiad-Back\docker-compose.yml -f .\Olympiad-Back\docker-compose.prod.yml -f .\Olympiad-Front\docker-compose.yml -f .\docker-compose.prod.yml $args
}
Set-Alias -Name odc OlympiadDockerCompose
Set-Alias -Name odcs OlympiadDockerComposeStack

