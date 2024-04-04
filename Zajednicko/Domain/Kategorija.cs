using System;
using Zajednicko.Domain;

namespace Zajednicko
{
    [Serializable]

    public class Kategorija:IEntitet
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Popust { get; set; }

        public string ImeTabele => "Kategorija";

        public string Vrednosti => "";

        public string UslovZaWhereVratiSve => "";

        public string IzrazZaJoin => "";

        public string UslovZaDelete => "";

        public string UslovZaUpdate => "";

        public string UslovZaSet => "";

        public string UslovZaWhereSaUslovom => throw new NotImplementedException();

        public object Identifikator => throw new NotImplementedException();

        public override string ToString()
        {
            return Naziv;
        }

        public string UslovZaWhereVratiSveSaObjektom(IEntitet ent)
        {
            throw new NotImplementedException();
        }
    }
}