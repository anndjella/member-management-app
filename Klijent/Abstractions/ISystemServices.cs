using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Abstractions
{
    public interface ISystemServices
    {
        DateTime Now();

        bool Confirm(string text, string caption);

        void Info(string message);
    }
}
