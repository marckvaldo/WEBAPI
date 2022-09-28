using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.Helps
{
    public static class UFvsEstados
    {
        public static string EstadoToUF(string estado)
        {
            string UF;

            switch (estado.ToUpper())
            {
                case "ACRE": UF = "AC"; break;
                case "ALAGOAS": UF = "AL"; break;
                case "AMAZONAS": UF = "AM"; break;
                case "AMAPÁ": UF = "AP"; break;
                case "BAHIA": UF = "BA"; break;
                case "CEARÁ": UF = "CE"; break;
                case "DISTRITO FEDERAL": UF = "DF"; break;
                case "ESPÍRITO SANTO": UF = "ES"; break;
                case "GOIÁS": UF = "GO"; break;
                case "MARANHÃO": UF = "MA"; break;
                case "MINAS GERAIS": UF = "MG"; break;
                case "MATO GROSSO DO SUL": UF = "MS"; break;
                case "MATO GROSSO": UF = "MT"; break;
                case "PARÁ": UF = "PA"; break;
                case "PARAÍBA": UF = "PB"; break;
                case "PERNAMBUCO": UF = "PE"; break;
                case "PIAUÍ": UF = "PI"; break;
                case "PARANÁ": UF = "PR"; break;
                case "RIO DE JANEIRO": UF = "RJ"; break;
                case "RIO GRANDE DO NORTE": UF = "RN"; break;
                case "RONDÔNIA": UF = "RO"; break;
                case "RORAIMA": UF = "RR"; break;
                case "RIO GRANDE DO SUL": UF = "RS"; break;
                case "SANTA CATARINA": UF = "SC"; break;
                case "SERGIPE": UF = "SE"; break;
                case "SÃO PAULO": UF = "SP"; break;
                case "TOCANTÍNS": UF = "TO"; break;
                default: UF = ""; break;
            }

            return UF;
        }

        public static string UFtoEstado(string UF)
        {
            string estado;

            switch (UF.ToUpper())
            {
                case "AC": estado = "Acre"; break;
                case "AL": estado = "Alagoas"; break;
                case "AM": estado = "Amazonas"; break;
                case "AP": estado = "Amapá"; break;
                case "BA": estado = "Bahia"; break;
                case "CE": estado = "Ceará"; break;
                case "DF": estado = "Distrito Federal"; break;
                case "ES": estado = "Espírito Santo"; break;
                case "GO": estado = "Goiás"; break;
                case "MA": estado = "Maranhão"; break;
                case "MG": estado = "Minas Gerais"; break;
                case "MS": estado = "Mato Grosso do Sul"; break;
                case "MT": estado = "Mato Grosso"; break;
                case "PA": estado = "Pará"; break;
                case "PB": estado = "Paraíba"; break;
                case "PE": estado = "Pernambuco"; break;
                case "PI": estado = "Piauí"; break;
                case "PR": estado = "Paraná"; break;
                case "RJ": estado = "Rio de Janeiro"; break;
                case "RN": estado = "Rio Grande do Norte"; break;
                case "RO": estado = "Rondônia"; break;
                case "RR": estado = "Roraima"; break;
                case "RS": estado = "Rio Grande do Sul"; break;
                case "SC": estado = "Santa Catarina"; break;
                case "SE": estado = "Sergipe"; break;
                case "SP": estado = "São Paulo"; break;
                case "TO": estado = "Tocantíns"; break;
                default: estado = ""; break;
            }

            return estado;
        }
    }
}
