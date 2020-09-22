#addin nuget:?package=Cake.Npm&version=0.17.0


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
   NpmRunScript("build", settings => { settings.FromPath("Olympiad-Front"); });
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