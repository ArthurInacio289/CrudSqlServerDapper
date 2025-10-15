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
            Console.WriteLine("(2)Atualizar cliente");
            Console.WriteLine("(3)Excluir cliente");
            Console.WriteLine("(4)Pesquisar clientes");

            Console.WriteLine("\nInforme a opção desejada");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateClient();
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

    }
}
