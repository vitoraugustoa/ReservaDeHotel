using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservado;
using HotelReservado.Model;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> dados = Dados.BuscarDadosDeEntrada();

                if (dados.Count <= 0)
                {
                    Console.WriteLine("Arquivo DadosDeEntrada.txt se encontra Vazio !!");
                    Console.ReadLine();
                    return;
                }

                string tipoDoCliente = dados.First();
                List<DateTime> listaDeDatas = new List<DateTime>(Dados.RetornarData(dados));
                List<Hotel> listaDeHoteis = Hotel.CarregarListaHoteis();

                if (listaDeHoteis.Count <= 0)
                {
                    Console.WriteLine("Arquivo RedeDeHoteis.txt se encontra Vazio !!");
                    Console.ReadLine();
                    return;
                }

                Hotel barato = HotelNegocio.CacularHotelMaisBarato(listaDeDatas, listaDeHoteis, tipoDoCliente);

                Console.WriteLine("Hotel mais barato : " + barato.NomeDoHotel);
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }

        }
    }
}
