// See https://aka.ms/new-console-template for more information
using Npgsql;

Console.WriteLine("Hello, World!");

Console.WriteLine("User is ?");
var userName = Console.ReadLine();

Console.WriteLine("Password is ?");
var password = Console.ReadLine();

Console.WriteLine($"User is {userName}");
Console.WriteLine($"Password is {password}");

/* Here using a connectionString
var connectionString = $"Host=localhost;Database=sdl_ali;Username={userName};password={password}";*/

// there is model that is named NpgConnectionStringBuilder
var NpgConnectionStringBuilder = new NpgsqlConnectionStringBuilder
{
    Host="localhost",
    Database="sdl_ali",
    Username=userName,
    Password=password
};

await using var dataSource = NpgsqlDataSource.Create(NpgConnectionStringBuilder);

// Retrieve all rows
await using (var cmd = dataSource.CreateCommand("SELECT VERSION();"))
await using (var reader = await cmd.ExecuteReaderAsync())
{
    while (await reader.ReadAsync())
    {
        Console.WriteLine(reader.GetString(0));
    }
}