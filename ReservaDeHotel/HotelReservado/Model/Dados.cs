using HotelReservadoe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservado.Model
{
    public class Dados
    {
        public static List<string> BuscarDadosDeEntrada()
        {
            List<string> dados = new List<string>();
            string endereco = @"C:\temp\DadosDeEntrada.txt";
            string[] linhas = null;

            try
            {
                linhas = Util.LerArquivoTxt(endereco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            if (linhas.Length == 0)
                return dados;

            foreach (var linha in linhas)
            {
                char delimitadorTipoCliente = ':';
                string[] tipoCliente = linha.Split(delimitadorTipoCliente);

                dados.Add(tipoCliente[0]);

                char delimitadorData = ',';
                string[] datas = tipoCliente[1].Split(delimitadorData);

                foreach (var data in datas)
                {
                    dados.Add(data.Trim());
                }

            }
            return dados;
        }

        public static List<DateTime> RetornarData(List<string> datas)
        {
            DateTime dataConvertida = new DateTime();
            List<DateTime> datasConvertidas = new List<DateTime>();

            datas.RemoveAt(0);
            foreach (string data in datas)
            {

                if (DateTime.TryParse(data, out dataConvertida))
                {
                    //se for uma data válida a variável data já armazena o valor
                    datasConvertidas.Add(dataConvertida);
                }

            }

            return datasConvertidas;

        }

    }
}
