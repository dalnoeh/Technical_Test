# Technical_Test
Simple technical test - Full stack application using WPF and SQL and (unfinished) ASP.NET core API. 

My first time using SQL, WPF (XAML) and ASP.NET Core and the MVC structure. Made in 4 days, learning as I went.

The application is made to show the stores and salesmen connected to different districts - The districts are the Danish regions, all other names are randomly generated. You can the choose a responsible salesman for each district. An assigment criteria was that a district always has ONE responsible saleman, however a salesman can be responsible for more than one district.

Districts can also have secondary salesmen, and there are no constrictions on this.

To use the application import Technical_test.bacpac into a SQL server and change the connectionString variable in DataHandler.cs in the DataLibrary, so that it matches your SQL server. In Visual Studio 2017 this can be found in the SQL Server Object Explorer, as a property of the database. 
