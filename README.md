# Technical_Test
Simple technical test - Full stack application using WPF and SQL and (unfinished) ASP.NET core API. 

My first time using SQL, WPF (XAML) and ASP.NET Core and the MVC structure. Made in 4 days, learning as I went.

The application is made to show the stores and salesmen connected to different districts - The districts are the Danish regions, all other names were randomly generated. You can the choose a responsible salesman for each district. An assigment criteria was that a district always has ONE responsible saleman, however a salesman can be responsible for more than one district.

Districts can also have secondary salesmen, and there are no constrictions on this.

The application uses the DistrictProcessor to get data from the SQL server as JSON and uses Newtonsoft.Json to deserialize the data using the models of the DataLibrary. The DistrcitsController is used by the view to get the correct data based on user input. The WPF application features a very simple UI, that has not had much in the way of design as the aim of the test was purely functional. To change the responsible saleman simply select a name from the drop down menu. To add a secondary salesman, click on the desired salesman's name in the Available salesmen list. Removing secondary salesmen is the same, just in the secondary salesmen list.

To use the application, import Technical_test.bacpac into a SQL server as a Data-tier application, and change the connectionString variable in DataHandler.cs in the DataLibrary, so that it matches your SQL server. In Visual Studio 2017 this path can be found in the SQL Server Object Explorer, as a property of the database. 
