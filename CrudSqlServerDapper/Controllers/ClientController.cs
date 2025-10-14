using CrudSqlServerDapper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSqlServerDapper.Controllers
{
    public class ClientController
    {
        public void CreateClient()
        {
            Console.WriteLine("\nCADASTRO DE CLIENTES:\n");

            var client = new Client();
            Console.Write("Informe o nome do cliente: ");
            client.Name = Console.ReadLine();
            Console.Write("Informe o email do cliente: ");
            client.Email = Console.ReadLine();
            Console.Write("Informe a data de nascimento do cliente (dd/mm/aaaa): ");
            client.BirthDate = DateTime.Parse(Console.ReadLine());
            var clientrepository = new Repositories.ClientRepository();
            clientrepository.Insert(client);
            Console.WriteLine("\nCliente cadastrado com sucesso!\n");
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
            var validator = new Validators.ClientValidator();
            var results = validator.Validate(client);
            if (!results.IsValid)
            {
                var clientrepository = new Repositories.ClientRepository();
            }
            else
            {
                Console.WriteLine("Cliente válido.");
                Console.ReadLine();

            }


    }
}
