csharp-openfire-restapi
===================

csharp-openfire-restapi is an C# based Client for the Openfire REST API Plugin which provides the ability to manage Openfire instance by sending an REST/HTTP request to the server.

I write this library for my own project. Because of referring to JAVA [REST-API-CLIENT](https://github.com/igniterealtime/REST-API-Client), I release the library for users which creates website and integrate it with openfire for XMPP chat APP.

----------
Dependency
-------------
I use RestSharp for basic REST API and JSON.NET. Please refer to [RestSharp](http://restsharp.org/) and [JSON.NET](https://www.nuget.org/packages/Newtonsoft.Json/9.0.1-beta1) and install it in visual studio.

Examples
-------------
**Authentication**

 - HTTP basic Authentication
 - Secret Key Authentication
 
>// Basic HTTP Authentication
>OpenfireAuthenticator authenticator = new OpenfireAuthenticator("admin", "testPassword");
>OpenfireAPIClient client = new OpenfireAPIClient("http://45.33.57.215", 9090, authenticator);
>
>// Shared secret key
>OpenfireAuthenticator authenticator = new OpenfireAuthenticator("shared secret key");
>OpenfireAPIClient client = new OpenfireAPIClient("http://45.33.57.215", 9090, , authenticator);


**User Related Example**
>//Request All available users
>UserEntities ues = client.getUsers();
>
>//Get specific user by username
>UserEntitity ue = client.getUser("commbigo")
>
>//Create new user
>bool result = client.createUser(new UserEntity { username = "test", email = "test@gmail.com", name = "test", password = "ZAQ!2wsx"});
>


