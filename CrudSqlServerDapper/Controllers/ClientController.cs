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

        public void Execute()
        {
            Console.WriteLine("\nSistema de controle de clientes\n");
            Console.WriteLine("(1)Cadastrar cliente");
            Console.WriteLine("(2)Listar todos os clientes");
            Console.WriteLine("(3)Atualizar cliente");
            Console.WriteLine("(4)Deletar clientes");
            Console.WriteLine("(5)Pesquisar cliente por ID");

            Console.WriteLine("\nInforme a opção desejada");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateClient();
                    break;
                case "2":
                    ReadClients();
                    break;
                case "3":
                    UpdateClient();
                    break;
                case "4":
                    DeleteClient();
                    break;
                case "5":
                    SelectClient();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;

            }
            Console.WriteLine("Deseja continuar? (S/N)");
            var resp = Console.ReadLine() ?? String.Empty;
            if (resp.Equals("S",StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Execute();
            }
            else
            {
                Console.WriteLine("Obrigado por utilizar o sistema.");
            }
        }


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
            var validator = new Validators.ClientValidator();
            var results = validator.Validate(client);
            if (!results.IsValid)
            {
                Console.WriteLine("\nOcorreram erros na validação do cadastro.");
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine($"Propriedade {failure.PropertyName} falhou na validação. Erro: {failure.ErrorMessage}");
                }                
            }
            else
            {
               
                Console.WriteLine("Cliente cadastrado com sucesso.");
            }
        }
        public void ReadClients()
        {
            var clientrepository = new Repositories.ClientRepository();
            var clients = clientrepository.GetAll();
            Console.WriteLine("\nLISTA DE CLIENTES:\n");
            foreach (var client in clients)
            {
                Console.WriteLine($"Id: {client.Id}");
                Console.WriteLine($"Nome: {client.Name}");
                Console.WriteLine($"Email: {client.Email}");
                Console.WriteLine($"Data de Nascimento: {client.BirthDate.ToShortDateString()}");
                Console.WriteLine("-------------------------------");
            }
        }
        public void UpdateClient()
        {
            Console.WriteLine("\nATUALIZAR CLIENTE:\n");
            Console.Write("Informe o Id do cliente: ");
            var id = int.Parse(Console.ReadLine());
            var clientrepository = new Repositories.ClientRepository();
            var client = clientrepository.Get(id);
            if (client != null)
            {
                Console.Write("Informe o novo nome do cliente: ");
                client.Name = Console.ReadLine();
                Console.Write("Informe o novo email do cliente: ");
                client.Email = Console.ReadLine();
                Console.Write("Informe a nova data de nascimento do cliente (dd/mm/aaaa): ");
                client.BirthDate = DateTime.Parse(Console.ReadLine());
                clientrepository.Update(client);
                Console.WriteLine("Cliente atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
        public void DeleteClient()
        {
            Console.WriteLine("\nEXCLUIR CLIENTE:\n");
            Console.Write("Informe o Id do cliente: ");
            var id = int.Parse(Console.ReadLine());
            var clientrepository = new Repositories.ClientRepository();
            var client = clientrepository.Get(id);
            if (client != null)
            {
                clientrepository.Delete(id);
                Console.WriteLine("Cliente excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
        public void SelectClient()
        {
            Console.WriteLine("\nPESQUISAR CLIENTE:\n");
            Console.Write("Informe o Id do cliente: ");
            var id = int.Parse(Console.ReadLine());
            var clientrepository = new Repositories.ClientRepository();
            var client = clientrepository.Get(id);
            if (client != null)
            {
                Console.WriteLine($"Id: {client.Id}");
                Console.WriteLine($"Nome: {client.Name}");
                Console.WriteLine($"Email: {client.Email}");
                Console.WriteLine($"Data de Nascimento: {client.BirthDate.ToShortDateString()}");
                Console.WriteLine("-------------------------------");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

    }
}
