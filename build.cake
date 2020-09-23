#addin nuget:?package=Cake.Npm&version=0.17.0
#addin nuget:?package=Cake.Docker&version=0.11.1


var target = Argument("target", "BuildAll");
var configuration = Argument("configuration", "Release");

var cakeSettings = new CakeSettings
{
   Arguments = new Dictionary<string, string>{
      ["configuration"] = configuration
   }
};

Task("BuildFront")
.Does(() => {
   NpmCi(settings => { settings.FromPath("Olympiad-Front"); });
   NpmRunScript("fillDefaultProdEnv", settings => { settings.FromPath("Olympiad-Front"); });
   NpmRunScript("buildToDeploy", settings => { settings.FromPath("Olympiad-Front"); });
});


Task("BuildBack")
.Does(() => {
   CakeExecuteScript("./Olympiad-Back/build.cake", cakeSettings);
});

Task("BuildAll")
   .IsDependentOn("BuildFront")
   .IsDependentOn("BuildBack")
   .Does(() =>
{
   
});


// Docker tasks

var dockerBuildTask = Task("DockerBuild");

if (HasArgument("rebuild")) 
{
   dockerBuildTask = dockerBuildTask
      .IsDependentOn("BuildAll");
}

dockerBuildTask.Does(() =>
{
   var settings = new DockerComposeBuildSettings {
      Files = new []{
         "docker-compose.yml",
         "docker-compose.override.yml",
         "Olympiad-Back/docker-compose.yml",
         "Olympiad-Back/docker-compose.override.yml",
         "Olympiad-Front/docker-compose.yml",
         "Olympiad-Front/docker-compose.override.yml" 
      }
   };
   DockerComposeBuild(settings);
});

Task("DockerUp")
   .Does(() =>
{
   var settings = new DockerComposeUpSettings {
      Files = new []{
         "docker-compose.yml",
         "Olympiad-Back/docker-compose.yml",
         "Olympiad-Back/docker-compose.override.yml",
         "Olympiad-Front/docker-compose.yml",
         "Olympiad-Front/docker-compose.override.yml" 
      },
      DetachedMode = true
   };
   DockerComposeUp(settings);
});

RunTarget(target);