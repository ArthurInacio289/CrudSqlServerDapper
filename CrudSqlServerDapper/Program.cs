using CrudSqlServerDapper.Controllers;

var clientcontroller = new ClientController();
clientcontroller.CreateClient();

Console.ReadLine();