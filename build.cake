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

Task("BuildFrontTeacher")
.Does(() => {
   NpmCi(settings => { settings.FromPath("Olympiad-Front-Teacher"); });
   NpmRunScript("fillDefaultProdEnv", settings => { settings.FromPath("Olympiad-Front-Teacher"); });
   NpmRunScript("buildToDeploy", settings => { settings.FromPath("Olympiad-Front-Teacher"); });
});


Task("BuildBack")
.Does(() => {
   CakeExecuteScript("./Olympiad-Back/build.cake", cakeSettings);
});

Task("BuildAll")
   .IsDependentOn("BuildFront")
   .IsDependentOn("BuildFrontTeacher")
   .IsDependentOn("BuildBack")
   .Does(() =>
{
   
});

RunTarget(target);