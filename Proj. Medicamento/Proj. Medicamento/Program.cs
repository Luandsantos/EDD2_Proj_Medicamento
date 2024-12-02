using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Medicamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos1 = new Medicamentos();
            int opcao;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético: informar dados)");
                Console.WriteLine("3. Consultar medicamento (analítico: informar dados + lotes)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento (abater do lote mais antigo) ");
                Console.WriteLine("6. Listar medicamentos (informando dados sintéticos)");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        {
                            Console.WriteLine("Digite o id desse medicamento: ");
                            int id_medicamento = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o nome do medicamnto: ");
                            string nome_medicamento = Console.ReadLine();
                            Console.WriteLine("Digite o nome do laboratório: ");
                            string laboratorio_medicamento = Console.ReadLine();
                            Medicamento novo_medicamento = new Medicamento(id_medicamento, nome_medicamento, laboratorio_medicamento);

                            Console.WriteLine("Digite a quantidade de lotes desse remédio: ");
                            int qtde_lotes = int.Parse(Console.ReadLine());
                            for (int i = 0; i < qtde_lotes; i++)
                            {
                                Console.WriteLine("Id do lote atual: ");
                                int id_lote = int.Parse(Console.ReadLine());
                                Console.WriteLine("Qtde do lote atual: ");
                                int qtde_lote = int.Parse(Console.ReadLine());
                                Console.WriteLine("Data de Vencimento do lote atual: ");
                                string venc_lote_string = Console.ReadLine();
                                var venc_lote = DateTime.Parse(venc_lote_string);
                                Lote novo_lote = new Lote(id_lote, qtde_lote, venc_lote);
                                novo_medicamento.Lotes.Enqueue(novo_lote);
                            }
                            medicamentos1.adicionar(novo_medicamento);
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Digite o id do medicamento que deseja consultar: ");
                            int id_consulta = int.Parse(Console.ReadLine());
                            Medicamento medicamento_consultado = new Medicamento(id_consulta);
                            var medicamento_achado = medicamentos1.pesquisar(medicamento_consultado);
                            if (medicamento_achado != null)
                            {
                                Console.WriteLine(medicamento_achado.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Medicamento não encontrado");
                            }
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Digite o id do medicamento que deseja consultar: ");
                            int id_consulta = int.Parse(Console.ReadLine());
                            Medicamento medicamento_consultado = new Medicamento(id_consulta);
                            var medicamento_achado = medicamentos1.pesquisar(medicamento_consultado);
                            if (medicamento_achado != null)
                            {
                                Console.WriteLine(medicamento_achado.ToString());
                                foreach(Lote lote in medicamento_achado.Lotes)
                                {
                                    Console.WriteLine("Lote " + lote.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Medicamento não encontrado.");
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Digite o id do medicamento que deseja comprar um lote: ");
                            int id_consulta = int.Parse(Console.ReadLine());
                            Medicamento medicamento_consultado = new Medicamento(id_consulta);
                            var medicamento_achado = medicamentos1.pesquisar(medicamento_consultado);
                            if (medicamento_achado != null)
                            {
                                Console.WriteLine("Id do lote atual: ");
                                int id_lote = int.Parse(Console.ReadLine());
                                Console.WriteLine("Qtde do lote atual: ");
                                int qtde_lote = int.Parse(Console.ReadLine());
                                Lote novo_lote = new Lote(id_lote, qtde_lote, DateTime.Now);
                                medicamento_achado.Lotes.Enqueue(novo_lote);
                            } else
                            {
                                Console.WriteLine("Medicamento não encontrado.");
                            }
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("Digite o id do medicamento que deseja vender: ");
                            int id_consulta = int.Parse(Console.ReadLine());
                            Medicamento medicamento_consultado = new Medicamento(id_consulta);
                            var medicamento_achado = medicamentos1.pesquisar(medicamento_consultado);
                            if (medicamento_achado != null)
                            {
                                Console.WriteLine("Digite a quantidade a ser vendida: ");
                                int qtde_vendida = int.Parse(Console.ReadLine());
                                var medicamento_vendido = medicamento_achado.vender(qtde_vendida);
                               if (medicamento_vendido == true)
                               {
                                    Console.WriteLine("Medicamento(s) vendido(s).");
                               } else
                                {
                                    Console.WriteLine("Não foi possível vender o medicamento.");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Medicamento não encontrado.");
                            }
                            break;
                        }

                    case 6:
                        Console.WriteLine("Listando medicamentos.");
                        foreach(Medicamento medicamento in medicamentos1.ListaMedicamentos)
                        {
                            Console.WriteLine(medicamento.ToString());
                        }
                        break;

                    case 0:
                        Console.WriteLine("Encerrando o programa.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 0);
        }
    }
}
