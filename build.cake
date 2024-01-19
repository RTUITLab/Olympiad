#addin nuget:?package=Cake.Npm&version=3.0.0
#addin nuget:?package=Cake.Docker&version=1.2.3


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

RunTarget(target);