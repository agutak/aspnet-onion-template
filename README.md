# ![icon](https://raw.githubusercontent.com/agutak/aspnet-onion-template/master/templates/aspnet6.onion/.template.config/icon.png) ASP.NET Onion Architecture Solution Template
[![.NET](https://github.com/agutak/aspnet-clean-template/actions/workflows/build-test-dotnet.yml/badge.svg?branch=master)](https://github.com/agutak/aspnet-clean-template/actions/workflows/build-test-dotnet.yml)
[![CodeQL](https://github.com/agutak/aspnet-clean-template/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/agutak/aspnet-clean-template/actions/workflows/codeql-analysis.yml)
[![Nuget](https://img.shields.io/nuget/vpre/AHutak.OnionArchitecture.AspNet?label=NuGet)](https://www.nuget.org/packages/AHutak.OnionArchitecture.AspNet)
[![Nuget](https://img.shields.io/nuget/dt/AHutak.OnionArchitecture.AspNet?label=Downloads)](https://www.nuget.org/packages/AHutak.OnionArchitecture.AspNet)

## Template Description
This is a solution template for creating an ASP.NET Web API application following the Onion Architecture. You can create a new solution based on this template by installing and running the associated NuGet package.

The template contains:
- Domain, Application, Persistence, Infrastructure, API projects,
- MS SQL and MongoDB persistence layer implementations wich user can choose during solution creation,
- Unit tests, Component tests and Acceptance tests template projects,
- WebAPI project with minimal API's and optionally standard controllers

## Getting Started

### Installing the template

To install this template on your system run the following command with the latest package version

``` dotnet new --install AHutak.OnionArchitecture.AspNet::<latest version> ```

You should see the message as shown below which indicates successfull installation

![image](https://user-images.githubusercontent.com/25172188/182178033-81915e64-19e4-4cec-845f-ec44d6dc1048.png)

After that you have several options, to use it either from Visual Studio 2022 or from command-line.  

#### From Visual Studio 2022:

![image](https://user-images.githubusercontent.com/25172188/182181390-03ede690-426e-49a3-85a6-f588b8edb60a.png)

![image](https://user-images.githubusercontent.com/25172188/182181727-e2fda348-8eca-4dad-8bdd-479b0e7cf428.png)

#### From command-line:

``` dotnet new oa-sln-aspnet -n Your-Project-Name ```

To view other available command-line solution parameters please run

``` dotnet new oa-sln-aspnet --help ```

At the moment this template supports two persistence layer implementations: 
- MS SQL with EF Core
- MongoDB.  

You can select one of them during solution creation.

### Launching the solution

The next step to launch the newly created solution is updating the appsettings json files in API project.  
You will need to provide the database connection information.  
Depending on selected Persistence layer implementation appsettings json files will contain one of configuration sections: 

- for MongoDB

``` 
  "MongoDbSettings": {
    "ConnectionString": "",
    "DatabaseName": ""
  }
```

- for MS SQL
``` 
  "ConnectionStrings": {
    "MyDbConnectionString": ""
  }
```

If MS SQL persistence implementation was selected during solution creation you have to run migrations on your database.
This step can be done with following commands run from the root directory of your solution (assuming you have installed the "dotnet ef" tools)

``` 
  dotnet ef database update -p src/your-solution-name.Persistence.MsSql.Migrations/ -s src/your-solution-name.Persistence.MsSql.Migrations/ --connection 'your-connection-string' 
```

For more information on Entity Framework Core tools see [Entity Framework Core tools reference](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)


After that you can launch the API project from Visual Studio or from command-line.

## Support

If you are having problems, please let us know by [raising a new issue](https://github.com/agutak/aspnet-onion-template/issues/new/choose).

## License

This project is licensed with the [MIT license](LICENSE).
