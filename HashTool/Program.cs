using BCrypt.Net;

Console.WriteLine("Admin123! => " + BCrypt.Net.BCrypt.HashPassword("Admin123!"));
Console.WriteLine("Operator123! => " + BCrypt.Net.BCrypt.HashPassword("Operator123!"));
Console.WriteLine("Viewer123! => " + BCrypt.Net.BCrypt.HashPassword("Viewer123!"));

//This is a utility program to generate hashed passwords for users.
//To run this program: dotnet run --project .\HashTool