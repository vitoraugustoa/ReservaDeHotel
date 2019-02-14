using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservado
{
    public class HotelNegocio
    {
        private const string clienteRegular = "regular";
        private const string clienteReward = "reward";

        public static void ValidarTipoCliente(string tipoDoCliente, string nomeDaPropriedade)
        {

            if (!tipoDoCliente.Equals(clienteRegular) || !tipoDoCliente.Equals(clienteReward))
                throw new Exception(nomeDaPropriedade + " Esta inválido !! ");
        }

        public static void ValidarHotel(string nomeDoHotel, int classificacaoDoHotel, double taxaSemanaNormal, double taxaSemanaFidelidade, double taxaFinalSemanaNormal, double taxaFinalSemanaFidelidade, string menssagemDeErro)
        {
            if (taxaFinalSemanaNormal <= 0 || taxaSemanaFidelidade <= 0 || taxaFinalSemanaNormal <= 0 || taxaFinalSemanaFidelidade <= 0 || classificacaoDoHotel <= 0)
                throw new Exception(menssagemDeErro);

        }

        public static Hotel CacularHotelMaisBarato(List<DateTime> listaDeDatas, List<Hotel> listaDeHoteis, string tipoDoCliente)
        {
            if (tipoDoCliente.ToLower() == clienteRegular)
            {
                foreach (Hotel hotel in listaDeHoteis)
                {
                    foreach (DateTime data in listaDeDatas)
                    {
                        if (Convert.ToString(data.DayOfWeek).Equals("Sunday") || Convert.ToString(data.DayOfWeek).Equals("Saturday") || Convert.ToString(data.DayOfWeek).Equals("Friday"))
                        {
                            hotel.CalculoPrecoDoHotel += hotel.TaxaFinalSemanaNormal;
                        }
                        else
                        {
                            hotel.CalculoPrecoDoHotel += hotel.TaxaSemanaNormal;
                        }
                    }
                }
            }
            else
            {
                foreach (Hotel hotel in listaDeHoteis)
                {
                    foreach (DateTime data in listaDeDatas)
                    {
                        if (Convert.ToString(data.DayOfWeek).Equals("Sunday") || Convert.ToString(data.DayOfWeek).Equals("Saturday") || Convert.ToString(data.DayOfWeek).Equals("Friday"))
                        {
                            hotel.CalculoPrecoDoHotel += hotel.TaxaFinalSemanaFidelidade;
                        }
                        else
                        {
                            hotel.CalculoPrecoDoHotel += hotel.TaxaFinalSemanaFidelidade;
                        }
                    }
                }
            }

            Hotel barato = listaDeHoteis.First();
            int control = 1;
            foreach (Hotel hotel in listaDeHoteis)
            {
                if (control == 0)
                {

                    if (hotel.CalculoPrecoDoHotel < barato.CalculoPrecoDoHotel)
                    {
                        barato = hotel;
                    }
                    else if (hotel.CalculoPrecoDoHotel == barato.CalculoPrecoDoHotel)
                    {
                        if (hotel.ClassificacaoDoHotel > barato.ClassificacaoDoHotel)
                        {
                            barato = hotel;
                        }
                    }
                }
                control = 0;
            }

            return barato;
        }
    }
}
