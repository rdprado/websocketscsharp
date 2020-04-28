# websocketscsharp

Project tested with VS2019 Community

There are some examples in this project. There are two folders, server and client.
But when running the server, there is already a chat example with a js client in it. Example from:
https://docs.microsoft.com/pt-br/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio

# To run our example:

Server project: WebApplicationSockets
Target Framework: NetCore 3.1

Client project is divided in two:
UI - exe for WPF
  Target Framework: NetCore 3.1
UIClient - dll to make client-server communication easier
  Target Framework: .NET Standard 2.0

1- Run Server
	Don't run as IIS, use WebApplicationSockets

2- Run Client
