@echo off
set timestamp=%DATE:/=-%_%TIME::=-%
set timestamp=%timestamp: =%
dotnet ef migrations add --project DAL.App --startup-project WebApp %timestamp%
dotnet ef database update --project DAL.App --startup-project WebApp