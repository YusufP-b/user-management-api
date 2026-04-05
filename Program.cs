using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var users = new List<User>();

app.MapGet("/users", () => users);

app.MapPost("/users", (User user) =>
{
    users.Add(user);
    return Results.Created($"/users/{user.Id}", user);
});

app.Run();

record User(int Id, string Name, string Email);