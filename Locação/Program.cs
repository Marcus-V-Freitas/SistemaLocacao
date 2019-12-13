using Locação.Entidades;
using Locação.Serviços;
using System;
using System.Globalization;
using Locação.Entidades.Enum;
using Locação.Exceptions;
using System.Text.RegularExpressions;

namespace Locação
{
    class Program
    {

        static void Main(string[] args)
        {

            try {
                Cliente cliente = null;
                Console.WriteLine("Cliente fisico ou jurídico: (F/J)");
                String respostas = Console.ReadLine().ToUpper();

                    Console.WriteLine("Digite o nome do condutor: ");
                    string nomeCondutor = Console.ReadLine();

                    Console.WriteLine("Digite o email para contato: ");
                    string email = Console.ReadLine();

                    Console.WriteLine("Digite a CNH do condutor: ");
                    string cnh = Console.ReadLine();

                    Console.WriteLine("Digite a data de nascimento do condutor: Formato dd/mm/yyyy");
                    DateTime nascimentoCondutor = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    Console.WriteLine("Digite o sexo do condutor");
                    Sexo sexo = Enum.Parse<Sexo>(Console.ReadLine().ToUpper());

                    if (respostas.Equals("F"))
                    {
                    Console.WriteLine("Digite o cpf do condutor: ");
                    string cpf = Console.ReadLine();
          
                    cliente = new ClienteFisico(nomeCondutor, email, cnh,nascimentoCondutor, sexo, cpf);

                    Console.WriteLine("Digite a quantidade de números de telefone para contanto: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    if (quantidade <= 0)
                    {
                        throw new DominioException("É necessário digitar pelo menos 1 número de telefone.");
                    }
                    for (int i = 1; i <= quantidade; i++)
                    {
                        Console.WriteLine("Digite o número de telefone: Formato (00)00000-0000");
                        String numero = Console.ReadLine();
                        cliente.addTelefoneCliente(new TelefoneCliente(numero));
                    }
                }
                else if (respostas.Equals("J"))
                {
                    Console.WriteLine("Digite o nome fantasia da empresa: ");
                    string nomeFantasia = Console.ReadLine();

                    Console.WriteLine("Digite o cnpj do condutor: ");
                    string cnpj = Console.ReadLine();

          
                    cliente = new ClienteJuridico(nomeCondutor, email,cnh, nascimentoCondutor, sexo,nomeFantasia, cnpj);

                    Console.WriteLine("Digite a quantidade de números de telefone para contanto: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= quantidade; i++)
                    {
                        Console.WriteLine("Digite o número de telefone: Formato (00)00000-0000");
                        String numero = Console.ReadLine();
                    
                        cliente.addTelefoneCliente(new TelefoneCliente(numero));

                    }
                }
                else
                {
                    Console.WriteLine("Não válido.");
                }

                Console.WriteLine("Digite a placa do veículo: Formato xxx-0000");
                String placa = Console.ReadLine();

                Console.WriteLine("Digite o renavam do veículo: Formato 000.000.000.00");
                String renavam = Console.ReadLine();

                Console.WriteLine("Digite o modelo do carro: ");
                string modelo = Console.ReadLine();

                Console.WriteLine("Digite a marca do modelo: ");
                String marca = Console.ReadLine();

                Console.WriteLine("Digite uma das cores disponíveis do carro: \n");
                Console.WriteLine("Cores Disponíveis: \n Amarelo - Azul - Branco \n Cinza - Laranja - Preto \n Verde - Vermelho");
      
                Cor cor = Enum.Parse<Cor>(Console.ReadLine().ToUpper());
                

                Console.WriteLine("Digite o seguro para o carro: \n");
                Console.WriteLine("Seguros Disponíveis: \n CDW (Básico e Obrigatório) \n SLI (Completo e Opcional)");
                Seguro seguro = Enum.Parse<Seguro>(Console.ReadLine().ToUpper());
                TaxaSeguro taxaSeguro = (seguro == Seguro.SLI) ? taxaSeguro = new TaxaSeguroSLI() : taxaSeguro = new TaxaSeguroCDW();

                Console.WriteLine("Digite o combustível: \n");
                Console.WriteLine("CCombustíveis disponíveis: \n Alcool - Diesel - Etanol \n Gás - Gasolina");
                Combustível combustivel = Enum.Parse<Combustível>(Console.ReadLine().ToUpper());

                Console.WriteLine("Aluguel por Dia ou quilometragem: (D/K)");
                respostas = Console.ReadLine().ToUpper();

                AluguelVeículo aluguel = new AluguelVeículo();
                ServiçoLocação servico = new ServiçoLocação();
                double preco = 0.0;

                if (respostas.Equals("D"))
                {

                    Console.WriteLine("Digite o preço do dia: ");
                    preco = double.Parse(Console.ReadLine());


                    Console.WriteLine("Dia e hora do aluguel: Formato dd/mm/yyyy hh:mm");
                    DateTime inicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                    Console.WriteLine("Dia e hora da previsão de retorno: Formato dd/mm/yyyy hh:mm");
                    DateTime prevista = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                    Console.WriteLine("Dia e hora do retorno: Formato dd/mm/yyyy hh:mm");
                    DateTime fim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                    aluguel = new AluguelVeículo(inicio, prevista, fim, new Veículo(placa,renavam,new Modelo(modelo,new Marca(marca)), cor, seguro, combustivel),cliente);

                    servico = new ServiçoLocação(preco, new TaxaServicoDia(), taxaSeguro);

                }
                else if (respostas.Equals("K"))
                {

                    Console.WriteLine("Digite o preço da Km: ");
                    preco = double.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a Km prevista de rodagem: ");
                    double inicialKm = double.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a Km final de rodagem: ");
                    double finalKm = double.Parse(Console.ReadLine());

                    aluguel = new AluguelVeículo(inicialKm, finalKm, new Veículo(placa, renavam,new Modelo(modelo,new Marca(marca)), cor, seguro, combustivel),cliente);

                    servico = new ServiçoLocação(preco, new TaxaServiçoKm(), taxaSeguro);

                }
                else
                {
                    Console.WriteLine("Não válido");
                }
                servico.EmitirFatura(aluguel);
                Console.WriteLine(aluguel);
            } catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(DominioException e)
            {
                Console.WriteLine(e.Message);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            }

        private static int ArgumentException()
        {
            throw new NotImplementedException();
        }
    }
}
