using System;
using System.Threading;

namespace Banco
{
    public class Conta
    {
        string correntista;
        float saldo = 1000;
        float limiteSaque = 600;

        public void Menu()
        {

            ExibirLogo();

            Console.Write("Digite o nome do correntista: ");
            correntista = Console.ReadLine();

            int opcao;
            do
            {
                Console.WriteLine("\n╔══════════════════════════╗");
                Console.WriteLine("║       MENU BANCÁRIO      ║");
                Console.WriteLine("╠══════════════════════════╣");
                Console.WriteLine("║ 1 - Sacar                ║");
                Console.WriteLine("║ 2 - Depositar            ║");
                Console.WriteLine("║ 3 - Informações da conta ║");
                Console.WriteLine("║ 4 - Sair                 ║");
                Console.WriteLine("╚══════════════════════════╝");
                Console.Write("\nEscolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\n⚠ Opção inválida. Digite um número.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        sacar();
                        break;
                    case 2:
                        depositar();
                        break;
                    case 3:
                        info();
                        break;
                    case 4:
                        Console.WriteLine("\nObrigado por usar nosso banco! 👋");
                        break;
                    default:
                        Console.WriteLine("\n⚠ Opção inválida, tente novamente.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }

            } while (opcao != 4);
        }

        public void sacar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n💵 SAQUE 💵");
                Console.Write("Digite o valor do saque: ");

                if (!float.TryParse(Console.ReadLine(), out float valorSaque))
                {
                    Console.WriteLine("\n⚠ Valor inválido. Digite um número.");
                    Thread.Sleep(2000);
                    continue;
                }

                if (valorSaque > saldo)
                {
                    Console.WriteLine("\n❌ Saldo insuficiente! Tente novamente.");
                    Thread.Sleep(2000);
                    continue;
                }

                if (valorSaque > limiteSaque)
                {
                    Console.WriteLine("\n⚠ O valor ultrapassa o limite de saque! Tente novamente.");
                    Thread.Sleep(2000);
                    continue;
                }

                Console.WriteLine("\n⏳ Processando saque...");
                Thread.Sleep(3000);

                saldo -= valorSaque;
                Console.WriteLine("\n✅ Saque realizado com sucesso!");
                Console.WriteLine($"💰 Novo saldo: R$ {saldo:F2}");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            }
        }

        public void depositar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n💰 DEPÓSITO 💰");
                Console.Write("Digite o valor do depósito: ");

                if (!float.TryParse(Console.ReadLine(), out float valorDeposito))
                {
                    Console.WriteLine("\n⚠ Valor inválido. Digite um número.");
                    Thread.Sleep(2000);
                    continue;
                }

                if (valorDeposito <= 0)
                {
                    Console.WriteLine("\n⚠ O valor do depósito deve ser maior que zero! Tente novamente.");
                    Thread.Sleep(2000);
                    continue;
                }

                Console.WriteLine("\n⏳ Processando depósito...");
                Thread.Sleep(3000);

                saldo += valorDeposito;
                Console.WriteLine("\n✅ Depósito realizado com sucesso!");
                Console.WriteLine($"💰 Novo saldo: R$ {saldo:F2}");
                Thread.Sleep(3000);
                Console.Clear();
                break;
            }
        }

        public void info()
        {
            Console.Clear();
            Console.WriteLine("\n📜 INFORMAÇÕES DA CONTA 📜");
            Console.WriteLine($"👤 Correntista: {correntista}");
            Console.WriteLine($"💰 Saldo: R$ {saldo:F2}");
            Console.WriteLine($"🏦 Limite de saque: R$ {limiteSaque:F2}");
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }

        private void ExibirLogo()
        {
            Console.WriteLine(@"

             ██████╗ ███████╗██╗     ██╗      █████╗    
             ██╔══██╗██╔════╝██║     ██║     ██╔══██╗   
             ██████╔╝█████╗  ██║     ██║     ███████║   
             ██╔══██╗██╔══╝  ██║     ██║     ██╔══██║
             ██████╔╝███████╗███████╗███████╗██║  ██║   
             ╚════╝  ╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝       

            💳  Bem-vindo ao Banco Bella! 💳 
            Seu banco de confiança para um futuro seguro
            ");
            Thread.Sleep(4000);
            Console.Clear();
        }
    }
}
