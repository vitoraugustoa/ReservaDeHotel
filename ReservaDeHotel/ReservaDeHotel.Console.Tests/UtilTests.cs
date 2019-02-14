using HotelReservadoe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HotelReservado.Tests
{
    [TestClass]
    public class UtilTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Util_paraValorVazio_Erro_Quando_Em_Branco()
        {
            Util.ValidarValorVazio("", "Valor Não pode ser vazio !");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Util_paraValorVazio_Erro_Quando_Null()
        {
            Util.ValidarValorVazio(null, "Valor Não pode ser nulo !");
        }





    }
}
