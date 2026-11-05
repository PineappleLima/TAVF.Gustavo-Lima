using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFrota
{
    internal class Veiculo
    {
        private int _quilometragem;
        private double _nivelCombustivel;

        public string Matricula { get; set; }
        public int CapacidadeDeposito { get; set; }

        public int Quilometragem
        {
            get { return _quilometragem; }
            set
            {
                if (value >= _quilometragem)
                {
                    _quilometragem = value;
                }
                else
                {
                    Console.WriteLine("Erro: A quilometragem não pode diminuir!");
                }
            }
        }

        public double NivelCombustivel
        {
            get { return _nivelCombustivel; }
            set
            {
                if (value >= 0 && value <= CapacidadeDeposito)
                {
                    _nivelCombustivel = value;

                    if (value < CapacidadeDeposito * 0.10)
                    {
                        ReservaAtingida?.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    Console.WriteLine("Erro: Nível de combustível inválido!");
                }
            }
        }

        public event EventHandler ReservaAtingida;

        public Veiculo(string matricula, int capacidadeDeposito)
        {
            Matricula = matricula;
            CapacidadeDeposito = capacidadeDeposito;
            Quilometragem = 0;
            NivelCombustivel = capacidadeDeposito;
        }

        public void Abastecer(double litros)
        {
            if (litros <= 0)
            {
                Console.WriteLine("Quantidade de combustível inválida!");
                return;
            }

            double novoNivel = NivelCombustivel + litros;

            if (novoNivel > CapacidadeDeposito)
            {
                Console.WriteLine("Aviso: O depósito ficou cheio!");
                NivelCombustivel = CapacidadeDeposito;
            }
            else
            {
                NivelCombustivel = novoNivel;
            }
        }

        public bool RealizarViagem(int kmDistancia)
        {
            if (kmDistancia <= 0)
            {
                Console.WriteLine("Distância inválida!");
                return false;
            }

            double combustivelNecessario = kmDistancia * 0.07;

            if (NivelCombustivel >= combustivelNecessario)
            {
                Quilometragem += kmDistancia;
                NivelCombustivel -= combustivelNecessario;
                return true;
            }
            else
            {
                Console.WriteLine("Combustível insuficiente!");
                return false;
            }
        }
    }
}
