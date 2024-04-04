using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.Domain;

namespace Zajednicko
{
    [Serializable]
    public class Clan :IEntitet
    {
        public int IdClana { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public Kategorija Kategorija { get; set; }

        public string ImeTabele => "Clan";
        public string Vrednosti => $"'{Ime}','{Prezime}', '{Email}', '{BrojTelefona}', {Kategorija.Id}";


        public string UslovZaWhereVratiSve => $" where prezime='{Prezime}'";

        public string IzrazZaJoin => " c join kategorija k on c.idkat=k.idkategorije";

        public string UslovZaDelete => $" where idclana={IdClana}";

        public string UslovZaUpdate => $" where idclana={IdClana}";

        public string UslovZaSet => $"set ime='{Ime}',prezime='{Prezime}',email='{Email}',brtel='{BrojTelefona}',idkat={Kategorija.Id}";

        public string UslovZaWhereSaUslovom => "";

        public object Identifikator => IdClana;

        public string UslovZaWhereVratiSveSaObjektom(IEntitet ent)
        {
            return "";
        }
    }
}
