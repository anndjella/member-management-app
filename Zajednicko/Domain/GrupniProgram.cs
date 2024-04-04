using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.Domain
{
    [Serializable]

    public class GrupniProgram:IEntitet
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double CenaJednog { get; set; }
        public GrupniProgram Self=>this;

        public string ImeTabele => "GrupniProgram";

        public string Vrednosti => "";

        public string UslovZaWhereVratiSve => "";

        public string IzrazZaJoin => "";

        public string UslovZaDelete => "";

        public string UslovZaUpdate => "";

        public string UslovZaSet => "";

        public string UslovZaWhereSaUslovom => throw new NotImplementedException();

        public object Identifikator => throw new NotImplementedException();

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

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
