# Pokemon Team Builder
A desktop web app for building Pokemon teams


## Features
- An interactive site to create and edit Pokemon teams

- A backend REST API to retrieve static data for the site as well as access and persist user data

- An authentication system, so that the user can save and access their teams via an account


## Installation and Setup
### Prerequisites:
- .NET 8.0
- Node version 20
- Node Package Manager version 10


### Main Database Setup
- Set the directory with: `cd api`
- Add your database connection string to appsettings.json and appsettings.Development.json
- Run `dotnet ef database update`
- Run `dotnet run seed`

### Test Database Setup
- Set the directory with: `cd api`
- Add your test database connection string to appsettings.Test.json
- Run `dotnet ef database update --connection "your test db connection string goes here"`
- Run `dotnet run seed test`

### Front End Setup
- Set the directory with: `cd frontend`
- Run `npm install`


## Usage
### Running The API
- Set the directory with: `cd api`
- Run `dotnet watch run`
- The app is then accessible on `localhost:5110`

### Running The Site 
- Set the directory with: `cd frontend`
- Run `npm start`
- The app is then accessible on `localhost:4000`

### Running tests
- For the backend tests: `dotnet test` 
- For the frontend tests, from the frontend directory run: `npm test` 


## Technology Used
- C# + JavaScript
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet)
- [xUnit.net](https://xunit.net/) + [Moq](https://www.nuget.org/packages/Moq/)
- [React](https://react.dev/)
- [Webpack](https://webpack.js.org/) + [Babel](https://babeljs.io/)
- [Jest](https://jestjs.io/)
- [SQLServer](https://www.microsoft.com/en-gb/sql-server/sql-server-downloads)
- git + github



