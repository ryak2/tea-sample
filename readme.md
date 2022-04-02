# Database Connection String Instructions

For security purposes, the Database Connection string is not included in the source code repository.
You will need your own valid db connection string.  Edit the file appsettings.json and populate your
valid connection string.

```
  "ConnectionStrings": {
    "School": "<<insert-your-connection-string-here>>"
  },
```

# App Setup Instructions

Prerequisites:

.Net SDK version 6.  (https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

Steps to run:

- Execute the following commands:  
```
cd SchoolApi
dotnet run
```
- Wait for the application to complete launching and it will output the port it is listening on.

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7001
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5252
```

# API Usage

The API is available at the following URL:  {site-root}/api/students/

# Swagger documentation

There is Swagger documentation available for the API at the following url:  https://localhost:7001/swagger/

You can also use the Swagger UI to execute a test call to the API.