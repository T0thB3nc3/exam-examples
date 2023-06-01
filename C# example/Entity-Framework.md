## Projekthez szükséges nuget csomagok telepítése
Install-Package Pomelo.EntityFrameworkCore.MySql -version 6.0.2
Install-Package Microsoft.EntityFrameworkCore.Tools -version 6.0.7
install-package System.Configuration.ConfigurationManager -version 7.0.0 
install-package Newtonsoft.Json -Version 13.0.2 

vagy ezek helyett

install-package Jedlik.EntityFramework.Helper


# Code first megközelítés

## Adatbázis létrehozásához:

Add-Migration Init 
Script-Migration 
update-database 

# Database first megközelítés

## adatbázis táblákból modell osztályok készítse 
Scaffold-DbContext -Connection "Server=localhost;database=ostermelo;uid=root;pwd=;" -Provider Pomelo.EntityFrameworkCore.MySql -OutputDir Models 



## Példa connection string
Server=localhost;database=travels_14F;uid=root;pwd=;

## hasznos korábbi kódok/osztályok, amiket érdemes hozzáadni a projekthez
- GenericRepository  -> a dbContext típusát módosítani
- IModelWithId interface
- DeepCopy extension  (ObjectExtension.cs)
