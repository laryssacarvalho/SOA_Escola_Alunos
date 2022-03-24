using SOA_Escola_Alunos.Models;
using SOA_Escola_Alunos.Services;
using System;
using System.Collections.Generic;

namespace SOA_Escola_Alunos
{
    internal class Program
    {
        private static StudentService _studentService = new StudentService();

        static void Main(string[] args)
        {
            MenuPrincipalAlunos();

        }
        public static void MenuPrincipalAlunos()
        {
            Console.Clear();

            Console.WriteLine("************************ Modulo Aluno ************************");
            Console.WriteLine("Escolha uma das opções:");
            Console.WriteLine("1 - Cadastrar Novo Aluno");
            Console.WriteLine("2 - Listar Alunos Cadastrados");
            Console.WriteLine("3 - Atualizar Cadastro de Aluno");
            Console.WriteLine("4 - Deletar Cadastro de Aluno");

            var opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Qual o nome do Aluno:");
                    _studentService.Create(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("**** Lista de Alunos ****");
                    _studentService.GetAll();
                    break;
                case "3":
                    Console.WriteLine("**** Informe o id do cadastro a ser alterado: ****");
                    _studentService.Update(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "4":

                    Console.WriteLine("**** Informe o id do cadastro a ser deletado: ****");
                    _studentService.Delete(Convert.ToInt32(Console.ReadLine()));
                    break;
                default:
                    Console.ReadLine();
                    return;
                    //MenuPrincipal();
                    break;
            }

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu anterior");
            Console.ReadLine();

            MenuPrincipalAlunos();
        }        
    }
}
