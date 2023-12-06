using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class Program
    {
        enum Opcao { Criar = 1, Deletar, Editar, Listar };

        static List<string> users = new List<string>();
        static void Main(string[] args)
        {
            int resposta;

            do
            {
                Console.WriteLine("Selecione uma das opções abaixo: \n");
                Console.WriteLine("1 - Criar Usuário\n2 - Deletar Usuário\n3 - Editar Usuário\n4 - Listar Usuários\n");
                int index = int.Parse(Console.ReadLine());
                Opcao escolha = (Opcao)index;

                Console.Clear();

                switch (escolha)
                {
                    case Opcao.Criar:
                        CriarUsuario();
                        break;
                    case Opcao.Deletar:
                        DeletarUsuario();
                        break;
                    case Opcao.Editar:
                        EditarUsuario();
                        break;
                    case Opcao.Listar:
                        ListarUsuarios();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("\nDeseja continuar? 1 - sim | 2 - não");
                resposta = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (resposta == 1);
            Console.WriteLine("Programa finalizado com sucesso! Muito obrigado!");
            Console.ReadLine();
        }
        static void CriarUsuario()
        {
            Console.Write("Digite seu nome: ");
            string username = Console.ReadLine();
            users.Add(username);
            Console.Clear();
            Console.WriteLine($"Usuário criado!\n");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Seja Bem-vindo, {username}!");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void DeletarUsuario()
        {
            Console.WriteLine("Deseja deletar um usuário? 1 - sim | 2 - não");
            int deleteResposta = int.Parse(Console.ReadLine());
            Console.Clear();
            if (deleteResposta == 1)
            {
                Console.WriteLine("Usuários disponíveis para deleção: \n");
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {users[i]}\n");
                }
                Console.WriteLine("Qual usuário você quer deletar? Escolha de acordo com o número do usuário: \n");
                int indiceExcluir = int.Parse(Console.ReadLine());
                Console.Clear();
                if (indiceExcluir > 0 && indiceExcluir <= users.Count)
                {
                    string usuarioExcluido = users[indiceExcluir - 1];
                    users.RemoveAt(indiceExcluir - 1);
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Usuário '{usuarioExcluido}' deletado com sucesso!");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine("Número de usuário inválido!");
                }
            }
        }

        static void EditarUsuario()
        {
            Console.WriteLine("Qual usuário você gostaria de editar?\n");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i]}\n");
            }
            Console.WriteLine("Escolha de acordo com o número do usuário!\n");
            int indiceEditar = int.Parse(Console.ReadLine());
            Console.Clear();
            if (indiceEditar > 0 && indiceEditar <= users.Count)
            {
                Console.WriteLine($"Nome atual: {users[indiceEditar - 1]}");
                Console.Write("\nDigite o novo nome de usuário: ");
                string novoNome = Console.ReadLine();
                Console.Clear();
                users[indiceEditar - 1] = novoNome;
                Console.WriteLine($"Usuário editado com sucesso para '{novoNome}'!");
            }
            else
            {
                Console.WriteLine("Número de usuário inválido!");
            }
        }

        static void ListarUsuarios()
        {
            Console.WriteLine("Aqui está a lista de usuários criados: \n");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i]}");
            }
        }
    }
}
