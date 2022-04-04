# How to use Swagger in .Net Core 

A WebAPI to read and write device status of a printer for demonstration of how **Swagger** can be configured  in .Net Core Web API.

## Configuration Steps

1. Install **Swashbuckle.AspNetCore** package from Nuget package manager.
2. Add the below code in Startup.cs 
  
  AddSwaggerGen in `ConfigureServices`
  
```sh
  public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Swagger CRUD API",
                    Description = "An ASP.NET Core Web API for managing Device Status of Printer",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
            });
        }
```

UseSwagger & UseSwaggerUI in `Configure`

```sh
                app.UseSwagger(c=>
                {
                    c.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(c=>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger CRUD API v1");
                });
```
3. Change the launchUrl in `launchSettings.json` to **swagger/index.html**

```sh
 "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger/index.html",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
```

## Exceution Steps

1. Make sure all the attributes are mentioned in Controller **HttpGet HttPost etc** nor you will receive below error

![Error](https://www.benday.com/wp-content/uploads/2020/12/image.png)

2. Run the application & to view Swagger documention of your API

![Swagger API Documentation](/Resource/AddDevice.png)

 ### Test API
    
    
  **1. GetStatus/DeviceName : No Record Found**

![NotFound](/Resource/getStatus_NotFound.png)

   **2. GetStatus/DeviceName : Record Found**

![OK](/Resource/getStatus_Ok.png)

  **3. GetAllDevices**

![GetAll](/Resource/GetAllDeviceStatus.png)

  **4. AddDeviceStatus**

![Addl](/Resource/AddDevice.png)



