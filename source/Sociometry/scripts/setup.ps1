
dotnet new webapp
dotnet add package Microsoft.Azure.Mobile.Server.Authentication

@"

app.UseAppServiceAuthentication();
"@ > ProgramTemplate.cs
