using System;
using System.Collections.Generic;
using CoreLogic;
using CoreLogic;
using Xunit;
using Zajednicko.Domain; 

public class InvoiceRulesTests
{
    [Fact]
    public void ExistsForCurrentMonth_ReturnsTrue_WhenInvoiceForNowExists()
    {
        var now = new DateTime(2025, 9, 13);
        var invoices = new List<Racun>
        {
            new Racun { Mesec = Mesec.August,   Godina = 2025 },
            new Racun { Mesec = Mesec.September, Godina = 2025 }, // matches "now"
        };

        bool exists = InvoiceRules.ExistsForCurrentMonth(
            invoices,
            now,
            r => (int)r.Mesec,
            r => r.Godina);

        Assert.True(exists);
    }

    [Fact]
    public void ExistsForCurrentMonth_ReturnsFalse_WhenNoInvoiceForNow()
    {
        var now = new DateTime(2025, 9, 13);
        var invoices = new List<Racun>
        {
            new Racun { Mesec = Mesec.August,   Godina = 2025 },
            new Racun { Mesec = Mesec.September, Godina = 2024 },
        };

        bool exists = InvoiceRules.ExistsForCurrentMonth(
            invoices,
            now,
            r => (int)r.Mesec,
            r => r.Godina);

        Assert.False(exists);
    }
}
