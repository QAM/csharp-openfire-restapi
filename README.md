csharp-openfire-restapi
===================

csharp-openfire-restapi is an C# based Client for the Openfire REST API Plugin which provides the ability to manage Openfire instance by sending an REST/HTTP request to the server.

I write this library for my own project. Because of referring to JAVA REST-API-CLIENT, I release the library for users which creates website and integrate it with openfire for XMPP chat APP.

----------
Dependency
-------------
I use RestSharp for basic REST API. Please refer to [RestSharp](http://restsharp.org/) and install it in visual studio.

Examples
-------------
**Authentication**

 - HTTP basic Authentication
 - Secret Key Authentication
 
>// Basic HTTP Authentication
>HttpBasicAuthenticator authenticator = new HttpBasicAuthenticator("admin", "testPassword");
>OpenfireAPIClient client = new OpenfireAPIClient("http://45.33.57.215", 9090, authenticator);
>
>// Shared secret key
>OpenfireAPIClient client = new OpenfireAPIClient("http://45.33.57.215", 9090, null, "2A98Q7sk0OEEHEz3");


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

>//create RestAPIClient with HTTP basic Authentication
>HttpBasicAuthenticator authenticator = new HttpBasicAuthenticator("admin", "testPassword");
>OpenfireAPIClient client = new OpenfireAPIClient("http://testdomain.com", 9090, authenticator);
>//create RestAPIClient with Secret Key Authentication
>OpenfireAPIClient client = new OpenfireAPIClient("http://testdomain.com", 9090, null, "2A98Q7sk0OEEHEz3");

