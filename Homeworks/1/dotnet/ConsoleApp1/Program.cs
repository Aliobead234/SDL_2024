// See https://aka.ms/new-console-template for more information
using Npgsql;

Console.WriteLine("Hello, World!");

using Npgsql;

var connectionString = "Host=localhost;Username=Ali;Password=190668;Database=sdl_ali";

await using var dataSource = NpgsqlDataSource.Create(connectionString);

// Retrieve all rows
await using (var cmd = dataSource.CreateCommand("SELECT VERSION();"))
await using (var reader = await cmd.ExecuteReaderAsync())
{
    while (await reader.ReadAsync())
    {
        Console.WriteLine(reader.GetString(0));
    }
}