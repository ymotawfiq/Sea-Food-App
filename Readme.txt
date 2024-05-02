The Seafood Project is designed to manage a seafood restaurant, handling various aspects of employee and customer management. It allows users to add, edit, and delete employees, including their salaries on a monthly basis. Employees can be assigned different roles such as chef, waiter, manager, or head chef. Additionally, users can update the menu by adding new dishes along with their prices and preparation times, as well as edit or delete existing dishes. Moreover, the system enables the addition of new customers who are regular visitors to the restaurant, with fields for their phone numbers and addresses. The restaurant's tables can also be managed through the system, allowing staff to assign orders to specific table numbers and clear tables once customers have finished their meals. Furthermore, the system incorporates user authentication, allowing individuals to register accounts on the website. An admin account is provided with comprehensive privileges, enabling administrators to perform any necessary tasks and oversee the entire system.

How to run project?
You must install dotnet core 8, sql server and Visual studio code or visual studio 2022
to run project in visual studio code
- first you should add migration to create database in sql server
go to (SeaFoodApp)
from terminal write (add-migration InitialCreate) if you use visual studio 2022 or (dotnet ef migrations add InitialCreate) if you use visual studio code
then write (update-database) if you use visual studio 2022 or (dotnet ef database update) if you use visual studio code

- second go to (SeaFoodApp) and use {dotnet run} command from terminal if you use visual studio code or run it from visual studio 2022

