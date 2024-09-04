# EtiqaContact

An ASP.Net Core Web API with these requirements
1. Use RESTful API
1. Attributes
   1. username
   1. email
   1. phone number
   1. skillsets
   1. hobby
1. Connected to RDBMS

# Usage information (in Postman)

1. Exposed API <br>![image](https://github.com/user-attachments/assets/c982fd52-1b44-456f-b792-84140e07da85)<br>
   1. Get contacts with paging support
   1. Get contact by id (requires user authentication)
   1. Create new contact (requires admin authentication)
   1. Update existing contact (requires admin authentication)
   1. Delete existing contact (requires admin authentication)
1. Use the Postman workspace in project folder, RESTful API Basics #blueprint.postman_collection.json
   1. Configure ip and port number <br>![image](https://github.com/user-attachments/assets/88bd7ae3-fa86-4f95-bc7d-73f21e40de35)<br>
1. Create user token
   1. Generate user token. <br>![image](https://github.com/user-attachments/assets/91200f5d-d1e4-404d-accb-daaee6992156)<br>   
1. Create admin token
   1. Generate admin token. <br>![image](https://github.com/user-attachments/assets/31c4f0e2-5ccf-44b6-b0c9-cacdfb7ba80d)<br>   
1. Get contacts with paging support
   1. By default limits to top 10 records
   1. Does not require user/admin authentication
   1. Default pageNumber and pageSize <br>![image](https://github.com/user-attachments/assets/c54db901-a501-4b07-8d89-c4a1624d5622)<br>
   1. Manually configured pageNumber and pageSize <br>![image](https://github.com/user-attachments/assets/e444a9bc-a31f-4fdf-bdda-e2ee8508fd93)<br>  
1. Get contact by id (requires user authentication)
   1. Use generated user token and set Auth Type as Bearer Token <br>![image](https://github.com/user-attachments/assets/c1d9ae4d-88f2-4e7b-86cf-b5122d5b7ba3)<br>
   1. Use valid contact id in url <br>![image](https://github.com/user-attachments/assets/0d9ba223-ec57-4d23-8e73-e07d16919309)<br>  
1. Create new contact (requires admin authentication)
   1. Use generated admin token and set Auth Type as Bearer Token <br>![image](https://github.com/user-attachments/assets/c1d9ae4d-88f2-4e7b-86cf-b5122d5b7ba3)<br>
   1. Configure valid contact information in body <br>![image](https://github.com/user-attachments/assets/9c035e83-bf9a-4e4a-81d1-f2e019d95e1a)<br>   
1. Update existing contact (requires admin authentication)
   1. Use generated admin token and set Auth Type as Bearer Token <br>![image](https://github.com/user-attachments/assets/c1d9ae4d-88f2-4e7b-86cf-b5122d5b7ba3)<br>
   1. Use valid contact id in url and configure valid contact information in body <br>![image](https://github.com/user-attachments/assets/c5cc34d1-1e8e-4bf8-b01b-2199754d5b7b)<br>
1. Delete existing contact (requires admin authentication)
   1. Use generated admin token and set Auth Type as Bearer Token <br>![image](https://github.com/user-attachments/assets/c1d9ae4d-88f2-4e7b-86cf-b5122d5b7ba3)<br>
   1. Use valid contact id in url <br>![image](https://github.com/user-attachments/assets/aae4ba57-e47e-4f4b-aae0-ef13f5a15808)<br>

# Best practices

1. [x] Follow REST principles
   1. [x] Nouns to represent resources (/contacts)
   1. [x] Stateless request
   1. [x] Uses HTTP status codes
      1. [x] GET
         1. [x] **200 OK** if the response contains data
      1. [x] POST
         1. [x] **201 Created** for successful create operation
         1. [ ] 204 No Content for successful create operation and the response contains no data
      1. [x] PUT
         1. [ ] 200 OK if the response contains data
         1. [x] **204 No Content** if the response contains no data
      1. [x] DELETE
         1. [x] **204 No Content** for successful delete operation
1. [x] Controllers
   1. [x] Naming convention (ContactController)
   1. [x] Controller contains no business logic
1. [x] Dependency injection
   1. [x] Service registration
   1. [x] Scoped services to ensure one instance per request
1. [x] Documentation
   1. [x] Swagger documentation
1. [x] Versioning
   1. [x] Versioning in routing (/api/v1/contacts)
1. [x] Error handling
   1. [x] Global exception handling
         1. [x] **404 Not Found** for invalid resource id 
         1. [x] **500 Internal Server Error** for unspecified exception
   1. [x] Standard error response
         1. [x] **404 Not Found** for invalid resource id 
         1. [x] **400 Bad Request** for invalid model state
   1. [x] Validation of input data 
         1. [x] Model state validation for create and update operations
         1. [ ] Fluent validation for create and update operations
1. [x] Authentication and authorization
   1. [x] JWT Tokens
   1. [x] Role based access control
1. [x] Data Transfer Objects
   1. [x] Use DTO to decouple API from domain models
   1. [x] Use AutoMapper to reduce risk of bugs 
1. [x] Pagination
   1. [x] Pagination with default values to improve performance
1. [ ] Filter and sorting
   1. [ ] Filter and sort data via query parameters 
1. [ ] Unit testing
   1. [x] MSTest unit testing
   1. [ ] nUnit unit testing
   1. [ ] xUnit unit testing
   1. [x] Use 3As : Arrange, Act, Asset
   1. [ ] MethodName_StateUnderTest_ExpectedBehavior
   1. [x] MethodName_ExpectedBehavior_StateUnderTest
1. [ ] Integration testing
   1. [ ] MSTest unit testing
   1. [ ] nUnit unit testing
   1. [ ] xUnit unit testing
   1. [ ] Use 3As : Arrange, Act, Asset
1. [ ] Performance
   1. [x] Asynchronous
   1. [ ] In-memory caching
   1. [ ] Distributed caching
   1. [ ] Hybrid caching
   1. [ ] Response caching
1. [ ] Secure API
   1. [ ] Rate limiting
   1. [x] HTTPS
   1. [ ] CORS: Configure Cross-Origin Resource Sharing policies to control which domain can access API
1. [x] Logging
    1. [x] Serilog
1. [ ] Monitoring
    1. [ ] Metrics collection (Prometheus)
    1. [ ] Visualization (Grafana)
    1. [ ] Tracing (OpenTelemetry)
1. [ ] Entity Framework Core
    1. [x] Use AsNoTracking for read-only queries.
    1. [ ] Select only required columns.
    1. [x] Use FindAsync for Single Primary Key Lookups.
    1. [ ] Batch queries.
    1. [ ] Use indexes for frequently queried columns using Data Annotation in entity class.
    1. [ ] Use compiled queries for repeated patterns.
    1. [x] Use connection pooling to reduce connection overhead.
    1. [ ] Optimize data loading with eager loading (.Include(e => e.RelatedEntity)) and by avoiding N+1 problems.
    1. [x] Enable detailed logging of EF Core SQL queries by configuring the logging level in appsettings.json.
1. [ ] Deployment
    1. [ ] Docker
1. [ ] CI/CD
    1. [ ] CI/CD pipeline (GitHub Actions)
    1. [ ] Deployment target (Azure App Service)
1. [x] Clean Code opinionated folder structure
   1. [x] Presentation Layer (EtiqaContact.Api)
   1. [x] Service Layer (EtiqaContact.Application)
   1. [x] Domain Layer (EtiqaContact.Domain)
   1. [x] Data Access Layer (EtiqaContact.Infrastructure)
1. [ ] Client
    1. [ ] Browser
    1. [ ] Mobile
    1. [ ] Desktop
    1. [ ] .Net Multiplatform (Blazor Hybrid, MAUI, Uno)
