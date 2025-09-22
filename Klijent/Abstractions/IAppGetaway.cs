using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;

namespace Klijent.Abstractions
{
    public interface IAppGateway
    {
        Odgovor Izvrsi(Operacija op, IEntitet param);
    }
}
