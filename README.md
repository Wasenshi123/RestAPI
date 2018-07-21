# RestAPI
An example of C# projects solution for Web Rest API using EF technology

## Prerequisites
- Need to open the .solution with administrative power in order to run successfully
- Modify the connection string in web.config of WebAPI project to the correct sql database instance name on your machine
- Execute the SQL Script file in folder 'DatabaseScripts' inside the solution folder to setup the database and stored procedure

## Testing
### Use swagger
- Recommended browser for testing with swagger is chrome (the response is not correctly displayed in Microsoft edge of Windows 10)
- Run the WebAPI project locally or deploy it to web server
- Then go to its url appending with 'swagger' (Example -> localhost:61766/swagger)
or
### Use POSTman or any RESTapi testing tool
- method: POST
- url: /CreditCard/Validate
- body : 
```
{
  "Number": "4123-4567-8012-3456",
  "ExpiryDate": "2018-07-18T16:30:11.830Z"
}
```
