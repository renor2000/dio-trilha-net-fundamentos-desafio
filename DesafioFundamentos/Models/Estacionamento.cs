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
            // DONE: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            string placa="";
            Console.WriteLine("Digite a placa do veículo para estacionarrr:");
            placa = Console.ReadLine();

            if (placa.Length>0)
            {
                veiculos.Add(placa);
                Console.WriteLine($"\nPlaca {placa} adicionada com sucesso!");
                Console.WriteLine($"\nO estacionamento agora está com {veiculos.Count} veículos.\n");
            }
            else
            {
                Console.WriteLine("\nComo nenhuma placa válida foi digitada, nada foi adicionado neste momento.");
            }
            
        }

        public void RemoverVeiculo()
        {
            string strLeituraTeclado="";
            string placa = "";
            decimal valorTotal = 0;       
            bool blnHorasValidas = false;
            decimal horas;


            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();

            if (placa.Length>0)
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    horas = 0;
                    while (!blnHorasValidas)
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado(Pelo menos 1 hora será cobrada, mesmo não tendo-a completado):");

                        // DONE: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                        // DONE: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                

                        strLeituraTeclado = Console.ReadLine();
                        blnHorasValidas = decimal.TryParse(strLeituraTeclado, out horas);

                        if  (horas==0)
                        {
                            horas = 1;
                        }
/*
                        if ((horas - Convert.ToInt32(horas))<0){}
                        else
                        {
                        blnHorasValidas = false;
                        }                        */

                        if (!blnHorasValidas)
                        {
                            Console.WriteLine("Quuantidade de Horas inválida. Favor digitar novamente.");
                        }
                    }

                    valorTotal = Convert.ToDecimal(precoInicial + horas*precoPorHora);
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi R$ {valorTotal}({horas} horas)");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }

        public void ListarVeiculos()
        {
            int contador=0;
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos estacionados:");
                foreach (var veiculo in veiculos)
                {   
                    Console.WriteLine($"{++contador} . {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
