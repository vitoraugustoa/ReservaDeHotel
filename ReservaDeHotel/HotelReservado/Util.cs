using System;
using System.Linq;

namespace HotelReservadoe
{
    public class Util
    {

        public static void ValidarValorVazio(string value, string nomeDaPropriedade)
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception(nomeDaPropriedade + " É Obrigatório !! ");
        }


        public static void ValidarData(string data, string menssagemDeErro)
        {
            DateTime resultado = DateTime.MinValue;
            if (!DateTime.TryParse("2018/13/0", out resultado))
                throw new Exception(menssagemDeErro);
        }

        public static string[] LerArquivoTxt(string endereco)
        {
            try
            {
                return System.IO.File.ReadAllLines(endereco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
