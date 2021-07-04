var target       = Argument("target", "default");

var rootPath     = "../";
var srcPath      = rootPath + "src/";

var solution     = rootPath + "git.web.sln";
var srcProjects  = GetFiles(srcPath + "**/*.csproj");


Task("clean")
    .Description("清理项目缓存")
    .Does(() =>
{
    CleanDirectories(srcPath + "**/bin");
    CleanDirectories(srcPath + "**/obj");
});

Task("restore")
    .Description("还原项目依赖")
    .Does(() =>
{
    DotNetCoreRestore(solution);
});

Task("build")
    .Description("编译项目")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .Does(() =>
{
    var buildSetting = new DotNetCoreBuildSettings {
        NoRestore = true
    };

    DotNetCoreBuild(solution, buildSetting);
});

Task("default")
    .IsDependentOn("build");

RunTarget(target);
