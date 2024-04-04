using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.Domain
{
    public interface IEntitet
    {
        string ImeTabele { get; }
        string Vrednosti { get; }
        string UslovZaWhereVratiSve { get; }
        string IzrazZaJoin { get; }
        string UslovZaDelete { get; }
        string UslovZaUpdate {  get; }  
        string UslovZaSet {  get; } 
        string UslovZaWhereSaUslovom {  get; }
        object Identifikator { get; }
        string UslovZaWhereVratiSveSaObjektom(IEntitet ent);
    }
}
