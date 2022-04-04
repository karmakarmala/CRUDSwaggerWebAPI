# ASP .Net Core API with Swagger Documentation

In this article I am going to show the steps how to configure **Swagger**  in .Net Core Web API.

The WebAPI for demosntration purpose a simple read and write CRUD project to store the device status of a printer.
You can find the complete standalone code here [CRUDSwaggerWebAPI](https://github.com/karmakarmala/CRUDSwaggerWebAPI)

## What is Swagger?

Swagger is a powerful yet easy-to-use suite of API developer tools for teams and individuals, enabling development across the entire API lifecycle, from design and documentation, to test and deployment. Check here for more info [Swagger](https://swagger.io/)

### Purpose

- Minimize the amount of work needed to connect decoupled services.
- Reduce the amount of time needed to accurately document a service.

The two main OpenAPI implementations for .NET are **Swashbuckle** and **NSwag**, here the implementation is using Swashbuckle

### Top Alternatives

1. Postman
2. Apigee
3. SoapUI


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

## Testing API
    
  **1. GetStatus/DeviceName : No Record Found**

![NotFound](/Resource/getStatus_NotFound.png)

   **2. GetStatus/DeviceName : Record Found**

![OK](/Resource/getStatus_Ok.png)

  **3. GetAllDevices**

![GetAll](/Resource/GetAllDeviceStatus.png)

  **4. AddDeviceStatus**

![Addl](/Resource/AddDevice.png)



