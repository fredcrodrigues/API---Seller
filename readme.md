﻿## Opportunity manager and sellers using blazor


This project is an API for managing opportunities and salespeople according to the challenge available at this [link](https://github.com/fredcrodrigues/API-VENDAS/blob/main/Desafio.txt)
the project uses the **Blazor framework** together with the **.Net framework**. You can manage all opportunities and salespeople,
deleting and updating the data. The bootstrap is used for reder the data of database MongoDB. 


## Settings

It's need install the follow depencencies in project:

```bash
	dotnet framewok => 6.0.4,
	MongoDB.Bson =  2.17.1,
        Newtonsoft.Json = 13.0.1
```

The project starts with the Blazor APP framework. You need to configure and verify the SallesDb.Shared and SalesDB.Server project dependencies.
It is necessary to configure the *Baseadress* of the *builder.Services.AddHttpClient* to find the API port with the Endpoints. This project use the door  **7001** during the compilation.



## Compilation 

For the compilation of the project use:

```
path/.../SalesDB.Server> dotnet run 
path/.../Sales.Client> dotnet run 

```

If you prefer to compile the individual project, but you can also use execution using IIS Expression, so configure the project to run all projects at once.

## Use this CNPJ for test
```
27865757000102 - Globo
14380.200000121 - Ifood
03499243000104 - free market
06990590000123 - Google
```

## Execution Completed

![Screenshot](/Prints/Index.png) 

![Screenshot](/Prints/SellerAdd.png) 

![Screenshot](/Prints/SellerList.png) 

![Screenshot](/Prints/Opportunities.png) 
