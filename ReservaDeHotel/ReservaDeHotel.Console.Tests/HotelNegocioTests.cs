using HotelReservado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaDeHotel.Console.Tests
{
    [TestClass]
    public class HotelNegocioTests
    {

        [TestMethod]
        public void HotelNegocio_para_Validar_Metodo_CacularHotelMaisBarato()
        {
            List<DateTime> listaDeDatas = new List<DateTime>();
            string tipoCliente = "reward";
            string data1 = "26Mar2009";
            string data2 = "27Mar2009";
            string data3 = "28Mar2009";

            listaDeDatas.Add(Convert.ToDateTime(data1));
            listaDeDatas.Add(Convert.ToDateTime(data2));
            listaDeDatas.Add(Convert.ToDateTime(data3));

            List<Hotel> listaDeHoteis = Hotel.CarregarListaHoteis();
            Hotel hotelAtual = HotelNegocio.CacularHotelMaisBarato(listaDeDatas, listaDeHoteis, tipoCliente);

            Assert.AreEqual("Ridgewood", hotelAtual.NomeDoHotel);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void HotelNegocio_para_Validar_Tipo_Cliente_Valido()
        {
            HotelNegocio.ValidarTipoCliente("Vitor", "Tipo de cliente errado !!");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void HotelNegocio_para_Validar_Hotel()
        {
            HotelNegocio.ValidarHotel("Lakewood", 0, 110, 80, 90, 80,"Hotel invalido !!");
        }

    }
}
