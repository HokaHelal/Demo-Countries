# Demo Countries

ASP Core web application using entityframework code first that makes basic CRUD (Create new , Retrieve all, update, Delete) oprations in countries database.

## Getting Started
- Create empty database and update connectionstring in appsettings.json in DemoCountries.API
```sh
"ConnectionStrings": {
    "DefaultConnectionString": "Data Source=.;Initial Catalog=countries;Integrated Security=true;"
  },
```
- Run application (F5) the Swagger UI should showm 
![](api.jpg)

## Architecture Features
1. Layers separation (Model, Repository, API) each layer is encapsulated and has their responsibility  
2. Apply generic repository pattern in case of adding extra models
3. Dependincy injection for repository (ICountryRepo)
4. Using git flow process (develop, main banches) while comming to source control
5. Clean code (clear varialbles, methods,...)
6. Swagger UI for documentation and testability
7. Checking and uodating migrations every statrup (run)  