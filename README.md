# Hahn-application-process

# Folder Content
 Clone the git repository from the url [https://github.com/eskye/hahn-application-process.git](https://github.com/eskye/hahn-application-process.git) to your computer

 The repository folder comprises of the following folders structure:
  - ClientApp  - This folder contains the frontend code.
  - Src - This Folder contains the asp.net core web api code.
  
     The `src` folder comprises of the following folder structure as specified the test description:

    - Hahn.ApplicationProcess.December2020.Web : This folder contain the .Net 5.0 Kestrel Host 
    - Hahn.ApplicatonProcess.December2020.Data -This folder contain the .Net 5.0 Class Library that handles the database context and entityFramework
    - Hahn.ApplicatonProcess.December2020.Domain – .Net 5.0 Class Library contain the Business Logic and Domain Models.

## Running the Web API
You will be able to run it using an In Memory database immediately.
 1. Open your terminal and navigate to the `src/Hahn.ApplicatonProcess.December2020.Web`
 2. Run the command `dotnet run`
 3. Navigate to the url [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)
 4. You will see the swagger documentation page that will enable you to test the endpoints with the clientApp.
   
  If you wish to use the sample with a persistent database, you will need to run its Entity Framework Core migrations before you will be able to run the app, and update the `ConfigureServices` method in `Startup.cs` (see below).


### Configuring the sample to use SQL Server

1. Update `Startup.cs`'s `ConfigureDevelopmentServices` method as follows:

```
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memory database
            //ConfigureTestingServices(services);

            // use real database
            ConfigureProductionServices(services);

        }
```

1. Ensure your connection strings in `appsettings.json` point to a local SQL Server instance.
1. Ensure the tool EF was already installed. You can find some help [here](https://docs.microsoft.com/ef/core/miscellaneous/cli/dotnet)

```
dotnet tool install --global dotnet-ef
```

1. Open a command prompt in the Hahn.ApplicationProcess.December2020.Web folder and execute the following commands:

```
dotnet restore
dotnet tool restore
dotnet ef database update -c ApplicationDbContext -p ../Hahn.ApplicationProcess.December2020.Data/Hahn.ApplicationProcess.December2020.Data -s Hahn.ApplicationProcess.December2020.Web.csproj 
``` 

 ## Running the Frontend App
 1. Open your terminal and navigate to the `clientApp`
 2. Run the command `npm install` to install dependencies.
 3. Run the command `npm start`
 4. If the Api Url change, you can update the `environment.json` file located inside the `config` folder
 5. Navigate to the url [http://localhost:8080](http://localhost:8080)
   

