..\packages\FluentMigrator.1.6.2\tools\Migrate.exe ^
--tag Dev ^
--tag OneAdminDatabase ^
--connection "Data Source=localhost;Initial Catalog=stove;Persist Security Info=True;User ID=sa;Password=266266;" ^
--db SqlServer ^
--target "bin\Debug\Domain.Data.FluentMigrator.dll" ^
--v true ^
--o  --of OneAdminDatabase_Migration.log"

pause