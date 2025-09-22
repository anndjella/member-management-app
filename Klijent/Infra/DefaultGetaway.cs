using Klijent.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;

namespace Klijent.Infra
{
    internal sealed class DefaultGateway : IAppGateway
    {
        public Odgovor Izvrsi(Operacija op, IEntitet param)
            => Komunikacija.Instance.IzvrsiFju(op, param);
    }
}
