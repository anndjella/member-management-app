using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.Domain
{
    [Serializable]
    public class Operater : IEntitet
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string ImeTabele => "Operater";

        public string Vrednosti => "";

        public string UslovZaWhereVratiSve => $" where Email='{Email}' and Lozinka='{Lozinka}'";

        public string IzrazZaJoin => "";

        public string UslovZaDelete => "";

        public string UslovZaUpdate =>"";

        public string UslovZaSet => "";

        public string UslovZaWhereSaUslovom => throw new NotImplementedException();

        public object Identifikator => throw new NotImplementedException();

        public string UslovZaWhereVratiSveSaObjektom(IEntitet ent)
        {
            throw new NotImplementedException();
        }
    }
}
