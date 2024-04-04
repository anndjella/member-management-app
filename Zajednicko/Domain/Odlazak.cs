using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.Domain
{
    [Serializable]
    public class Odlazak : IEntitet
    {
        public Clan Clan { get; set; }
        public GrupniProgram GrupniProgram { get; set; }
        public DateTime DatumOdlaska { get; set; }
        public bool Placeno { get; set; }
        public string ImeTabele => "Odlazak";

        public string Vrednosti => $" {Clan.IdClana}, '{DatumOdlaska}', {GrupniProgram.Id}, {(Placeno ? 1 : 0)} ";


        public string IzrazZaJoin => " o join grupniprogram g on o.id_grpr=g.IdGrPr join clan c on c.IdClana=o.id_clana " +
            "join kategorija k on c.idkat=k.idkategorije";

        public string UslovZaDelete => "";

        public string UslovZaUpdate => $" where id_clana={Clan.IdClana} and datumodlaska='{DatumOdlaska}' and id_grpr={GrupniProgram.Id}";

        public string UslovZaSet => $" set placeno={(Placeno?1:0)}";

        public string UslovZaWhereSaUslovom => "";

        public object Identifikator => 2;

        public string UslovZaWhereVratiSve => throw new NotImplementedException();

        public string UslovZaWhereVratiSveSaObjektom(IEntitet ent)
        {
            if(ent is Odlazak)
            {
                return " where id_clana=" + ((Odlazak)ent).Clan.IdClana +
                     " and " +
                    "month(o.datumOdlaska)=" + ((Odlazak)ent).DatumOdlaska.Month + " and " +
                    "year(o.datumOdlaska)=" + ((Odlazak)ent).DatumOdlaska.Year;
            }
            return "";
        }
    }
}
