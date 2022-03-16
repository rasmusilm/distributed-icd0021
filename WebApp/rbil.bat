@echo off
cd DAL.App\Migrations 
DEL /F/Q/S *.* > NUL
cd..
RMDIR /Q/S Migrations 
dotnet ef database drop --project DAL.App --startup-project WebApp
dotnet ef migrations add --project DAL.App --startup-project WebApp InitialCreation
dotnet ef database update --project DAL.App --startup-project WebApp