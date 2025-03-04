# NM.Backend.API

This is an API endpoint.
Run the application using https in debug mode.
It should open the swagger definition as the landing page.
Using swagger or Postman, directly try to hit the endpoint at the URI : https://localhost:7000/api/Property?top=100&skip=0

NOTE: Filtering and Sorting is not implemented as part of the solution.

The Architecture of the application is a layered one.
It has the structure:

Web API
Resources
Services : This is a blob storage service
Mapper (Models <-> Domain)
AppSettings File has the required Blob URI and SAS key. This can be further moved to a AZ KeyVault.
An Exception Middleware which takes care of throwing exceptions from the services
