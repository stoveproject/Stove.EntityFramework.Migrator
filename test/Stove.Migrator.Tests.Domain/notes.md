http://stackoverflow.com/questions/21537558/multiple-db-contexts-in-the-same-db-and-application-in-ef-6-and-code-first-migra
Enable-Migrations -ContextTypeName SampleDbContext2 -MigrationsDirectory Migrations\SampleDbContext2
Enable-Migrations -ContextTypeName SampleDbContext -MigrationsDirectory Migrations\SampleDbContext


Add-Migration -ConfigurationTypeName Domain.Data.Migrations.SampleDbContext.Configuration "InitialDatabaseCreation"
Add-Migration -ConfigurationTypeName Domain.Data.Migrations.SampleDbContext2.Configuration "InitialDatabaseCreation"


Update-Database -ConfigurationTypeName Domain.Data.Migrations.SampleDbContext.Configuration
Update-Database -ConfigurationTypeName WebApplication3.Migrations.SampleDbContext2.Configuration