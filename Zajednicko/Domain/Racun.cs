using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.Domain
{
    [Serializable]
    public class Racun : IEntitet
    {
        public int RBRRacuna { get; set; }
        public Mesec Mesec { get; set; }
        public int Godina { get; set; }
        public double Iznos { get; set; }
        public Clan Clan { get; set; }

        public string ImeTabele => "Racun";

        public string Vrednosti => $"{(int)Mesec}, {Godina}, {Iznos}, {Clan.IdClana}";

        public string IzrazZaJoin => " r join clan c on r.id_cl=c.IdClana join Kategorija k on c.IdKat=k.IdKategorije";

        public string UslovZaDelete => "";

        public string UslovZaUpdate => $" where id_cl={Clan.IdClana} and  mesec={(int)Mesec} and godina={Godina} and rednibrac={RBRRacuna}";

        public string UslovZaSet => $" set iznos={Iznos}";

        public string UslovZaWhereSaUslovom => " where id_cl=";

        public string UslovZaWhereVratiSve => "";

        public object Identifikator => RBRRacuna;

        public string UslovZaWhereVratiSveSaObjektom(IEntitet ent)
        {
            if (ent is Racun)
            {
                return $" where id_cl={((Racun)ent).Clan.IdClana}";
            }
            return "";
        }
    }
}
