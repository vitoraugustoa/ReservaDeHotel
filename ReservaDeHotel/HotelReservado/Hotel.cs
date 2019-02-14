using HotelReservadoe;
using System;
using System.Collections.Generic;

namespace HotelReservado
{
    public class Hotel
    {
        public double TaxaSemanaNormal { get; private set; }
        public double TaxaFinalSemanaNormal { get; private set; }
        public double TaxaSemanaFidelidade { get; private set; }
        public double TaxaFinalSemanaFidelidade { get; private set; }
        public string NomeDoHotel { get; private set; }
        public double CalculoPrecoDoHotel { get; set; }
        public int ClassificacaoDoHotel { get; private set; }

        public static List<Hotel> CarregarListaHoteis()
        {
            try
            {
                string endereco = @"C:\temp\RedeDeHoteis.txt";
                string[] linhas = Util.LerArquivoTxt(endereco);
                Hotel hotel = null;
                List<Hotel> listaDeHoteis = new List<Hotel>();

                foreach (string linha in linhas)
                {
                    hotel = new Hotel();

                    char delimitadorTipoCliente = ';';
                    string[] tipoCliente = linha.Split(delimitadorTipoCliente);

                    hotel.NomeDoHotel = tipoCliente[0].Trim();
                    hotel.ClassificacaoDoHotel = Convert.ToInt32(tipoCliente[1].Trim());
                    hotel.TaxaSemanaNormal = Convert.ToDouble(tipoCliente[2].Trim());
                    hotel.TaxaSemanaFidelidade = Convert.ToDouble(tipoCliente[3].Trim());
                    hotel.TaxaFinalSemanaNormal = Convert.ToDouble(tipoCliente[4].Trim());
                    hotel.TaxaFinalSemanaFidelidade = Convert.ToDouble(tipoCliente[5].Trim());

                    listaDeHoteis.Add(hotel);

                }

                return listaDeHoteis;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
