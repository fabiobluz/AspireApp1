var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");

var apiservice = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice");
var yarpgateway = builder.AddProject<Projects.Yarp_Gateway>("yarpgateway");
var productsservice = builder.AddProject<Projects.Products_Api>("productsservice");
var usersservice = builder.AddProject<Projects.Users_Api>("usersservice");

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(productsservice)
    .WithReference(usersservice)
    .WithReference(yarpgateway)
    .WithReference(apiservice);

builder.Build().Run();