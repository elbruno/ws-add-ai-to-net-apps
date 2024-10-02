var builder = DistributedApplication.CreateBuilder(args);

var chatapi = builder.AddProject<Projects.chat_server>("chatapi");

if (OperatingSystem.IsWindows())
{
    var chatform = builder.AddProject<Projects.chat_winform>("chatform")
    .WithReference(chatapi)
    .ExcludeFromManifest(); ;
}
builder.Build().Run();
