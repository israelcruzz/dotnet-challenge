using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string novoVeiculo = Console.ReadLine();

            bool placaValida = validarPlaca(novoVeiculo);

            if(placaValida)
            {
                veiculos.Add(novoVeiculo);
                Console.WriteLine("Veiculo Cadastrado.");
            }
            else
            {
                Console.WriteLine("A placa informada está no formato errado.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(veiculo => veiculo.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                decimal horasEstacionadas = Convert.ToDecimal(Console.ReadLine());

                decimal valorTotal = precoInicial + (precoPorHora * horasEstacionadas);

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool validarPlaca(string placa)
        {
            string rgx = @"\b(?:[A-Z]{3}-\d{4}\b|[A-Z]{3}\d{4}\b)";
            return Regex.IsMatch(placa, rgx);
        }
    }
}
