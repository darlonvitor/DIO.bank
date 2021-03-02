using System.Collections.Generic;
using System;
using static System.Console;

namespace DIO.bank
{
    class Program
    {
        static List<Conta> ListaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario.ToUpper())
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção Inválida.");
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            WriteLine("Obrigado por usar nossos serviços!");
        }

        private static void Transferir()
        {
            WriteLine("Digite o número da conta de origem");
            int contaOrigem = int.Parse(ReadLine());

            WriteLine("Digite o número da conta de destino");
            int contaDestino = int.Parse(ReadLine());

            WriteLine("Digite o valor a ser transferido");
            double valorTrasnferencia = double.Parse(ReadLine());

            ListaContas[--contaOrigem].Transferir(valorTrasnferencia,ListaContas[--contaDestino]);
        }

        private static void Depositar()
        {
            WriteLine("Digite o número da conta");
            int numeroConta = int.Parse(ReadLine());

            WriteLine("Digite o valor a ser depositado");
            double valorDeposito = double.Parse(ReadLine());

            ListaContas[(numeroConta-1)].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            WriteLine("Digite o número da conta:");
            int numeroConta = int.Parse(ReadLine());

            WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(ReadLine());

            ListaContas[(numeroConta-1)].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            WriteLine("Listar contas\n");
            if (ListaContas.Count == 0)
            {
                WriteLine("Nenhuma conta cadastrada");
            }

            for (int i = 0; i < ListaContas.Count; i++)
            {
                WriteLine($"#{(i+1)} - {ListaContas[i]}");
            }
        }

        private static void InserirConta()
        {
            WriteLine("Inserir nova conta");

            WriteLine("Digite 1 para conta física ou 2 para conta juridica");
            int tipoconta = int.Parse(ReadLine());

            WriteLine("Digite o nome do cliente:");
            string nomecliente = ReadLine();

            WriteLine("Digite o saldo inicial:");
            double saldoinicial = double.Parse(ReadLine());

            WriteLine("Digite o crédito: ");
            double credito =double.Parse(ReadLine());

            ListaContas.Add(new Conta((TipoConta)tipoconta,saldoinicial,credito,nomecliente));
        }

        private static string ObterOpcaoUsuario()
        {
            WriteLine("\nObter a opção desejada:\n");

            WriteLine("1 - Listar contas.");
            WriteLine("2 - Inserir nova conta.");
            WriteLine("3 - Transferir.");
            WriteLine("4 - Sacar.");
            WriteLine("5 - Depositar.");
            WriteLine("C - Limpar tela.");
            WriteLine("X - Sair.");
            WriteLine();

            string resposta =  ReadLine();
            return resposta;
        }
    }
}
