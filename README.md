# JsonExample Console App

This is a simple C# console application that:

- Reads JSON data from files
- Deserializes it into C# objects using Newtonsoft.Json
- Uses inheritance to handle different user types (Admin and Regular)
- Outputs user information to the console

## Files

- `user.json` – contains user data with types
- `user_types.json` – additional users with Admin and Regular types
- `Program.cs` – main program logic

## How to Run

1. Install .NET SDK and open the project in Visual Studio.
2. Install Newtonsoft.Json via NuGet.
3. Make sure both JSON files are present in the project folder and set to "Copy if newer".
4. Run the program (`Ctrl + F5`).
