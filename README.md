

# Sociometry Online tool

This tool was created to support team moderators to gain knowledge over structure the team. 


# Feature

The main idea is to create a simple application that is able to connect to shared cloud speed sheet to get the questions and the names of the team members. The team members will get a link to fill in theirs choices. Later we may also provide some analysis.


# Software technology and related articles


# Literature


# Info

https://mcr.microsoft.com/appsvc/staticsite:latest

# Feature working:

- Connecting to SignalR with managed identity: We enabled system identity on the App Service and added "SignalR Add Server" role.
- 

# Error to solve:
{"EventId":13,"LogLevel":"Error","Category":"Microsoft.AspNetCore.Server.Kestrel","Message":"Connection id \u00220HMHBNGFNU441\u0022, Request id \u00220HMHBNGFNU441:00000008\u0022: An unhandled exception was thrown by the application.","Exception":"System.InvalidOperationException: No authenticationScheme was specified, and there was no DefaultChallengeScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action\u003CAuthenticationOptions\u003E configureOptions).    at Microsoft.AspNetCore.Authentication.AuthenticationService.ChallengeAsync(HttpContext context, String scheme, AuthenticationProperties properties)    at Microsoft.AspNetCore.Authorization.Policy.AuthorizationMiddlewareResultHandler.HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)    at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)    at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication\u00601 application)","State":{"Message":"Connection id \u00220HMHBNGFNU441\u0022, Request id \u00220HMHBNGFNU441:00000008\u0022: An unhandled exception was thrown by the application.","ConnectionId":"0HMHBNGFNU441","TraceIdentifier":"0HMHBNGFNU441:00000008","{OriginalFormat}":"Connection id \u0022{ConnectionId}\u0022, Request id \u0022{TraceIdentifier}\u0022: An unhandled exception was thrown by the application."}}