
using System;
using System.Collections.Generic;

namespace GestaoFrota
{
    internal class Program
    {
        static void AlertaReserva(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n!!! ALERTA: RESERVA DE COMBUSTÍVEL !!!");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            List<Veiculo> frota = new List<Veiculo>();

            int opcao = 0;

            do
            {
                Console.WriteLine("\n===== GESTÃO DE FROTA =====");
                Console.WriteLine("1 - Adicionar veículo");
                Console.WriteLine("2 - Consultar veículos");
                Console.WriteLine("3 - Abastecer veículo");
                Console.WriteLine("4 - Realizar viagem");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Matrícula: ");
                        string matricula = Console.ReadLine();

                        bool existe = false;

                        foreach (Veiculo v in frota)
                        {
                            if (v.Matricula == matricula)
                            {
                                existe = true;
                            }
                        }

                        if (existe)
                        {
                            Console.WriteLine("Essa matrícula já existe!");
                        }
                        else
                        {
                            Console.Write("Capacidade do depósito: ");
                            int capacidade = Convert.ToInt32(Console.ReadLine());

                            Veiculo novo = new Veiculo(matricula, capacidade);

                            novo.ReservaAtingida += AlertaReserva;

                            frota.Add(novo);

                            Console.WriteLine("Veículo adicionado!");
                        }
                        break;

                    case 2:
                        if (frota.Count == 0)
                        {
                            Console.WriteLine("Não existem veículos registados.");
                        }
                        else
                        {
                            foreach (Veiculo v in frota)
                            {
                                Console.WriteLine("\nMatrícula: " + v.Matricula);
                                Console.WriteLine("Quilometragem: " + v.Quilometragem + " km");
                                Console.WriteLine("Combustível: " + v.NivelCombustivel + " litros");
                                Console.WriteLine("Capacidade: " + v.CapacidadeDeposito + " litros");
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Matrícula do veículo: ");
                        string matAbastecer = Console.ReadLine();

                        Veiculo encontrado1 = null;

                        foreach (Veiculo v in frota)
                        {
                            if (v.Matricula == matAbastecer)
                            {
                                encontrado1 = v;
                            }
                        }

                        if (encontrado1 == null)
                        {
                            Console.WriteLine("Veículo não encontrado!");
                        }
                        else
                        {
                            Console.Write("Litros a abastecer: ");
                            double litros = Convert.ToDouble(Console.ReadLine());

                            encontrado1.Abastecer(litros);
                        }
                        break;

                    case 4:
                        Console.Write("Matrícula do veículo: ");
                        string matViagem = Console.ReadLine();

                        Veiculo encontrado2 = null;

                        foreach (Veiculo v in frota)
                        {
                            if (v.Matricula == matViagem)
                            {
                                encontrado2 = v;
                            }
                        }

                        if (encontrado2 == null)
                        {
                            Console.WriteLine("Veículo não encontrado!");
                        }
                        else
                        {
                            Console.Write("Distância da viagem em km: ");
                            int km = Convert.ToInt32(Console.ReadLine());

                            if (encontrado2.RealizarViagem(km))
                            {
                                Console.WriteLine("Viagem realizada com sucesso!");
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("A sair do programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 5);
        }
    }
}
