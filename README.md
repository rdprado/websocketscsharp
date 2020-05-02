# websocketscsharp
Small project built with VisualStudio 2019 Community, to test Asp.Net Core SignalR. 
First thing was testing the MSDN tutorial:
https://docs.microsoft.com/pt-br/aspnet/core/tutorials/signalr?view=aspne-3.1&tabs=visual-studio, which builds a simple chat App with SignalR and a js client. To run it, simply play the server solution and try it in the browser.

Secondly .Net Core client was created as a solution divided with two csprojs, one with a simple WPF interface and the other as a DLL which provides the communication layer to the server.

# Versions

Server project: WebApplicationSockets
Target Framework: NetCore 3.1

Client project is divided in two:
UI - exe for WPF
  Target Framework: NetCore 3.1
UIClient - dll to make client-server communication easier
  Target Framework: .NET Standard 2.0

# To run .net client
1- Run Server
	Don't run as IIS, use WebApplicationSockets

2- Run Client
	Currently there are two examples only, a send receive message. And a test of the time it takes for the server to send N messages, and the client to update the UI each time.
