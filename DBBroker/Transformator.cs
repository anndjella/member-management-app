using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace DBBroker
{
    public class Transformator
    {
        internal IEntitet Transformisi(IEntitet argument, SqlDataReader reader)
        {
            if(argument is Operater)
            {
                Operater o = new Operater();
                o.Id = (int)reader["id"];
                o.Ime = (string)reader["ime"];
                o.Prezime = (string)reader["prezime"];
                o.Email = (string)reader["email"];
                o.Lozinka = (string)reader["lozinka"];
                return o;
            }else if(argument is Clan)
            {
                Clan c = new Clan();
                c.IdClana = (int)reader["idclana"];
                c.Ime = (string)reader["ime"];
                c.Prezime = (string)reader["prezime"];
                c.Email = (string)reader["email"];
                c.BrojTelefona = (string)reader["brtel"];

                c.Kategorija = new Kategorija();
                c.Kategorija.Id= (int)reader["idkat"];
                c.Kategorija.Popust = (double)reader["popust"];
                c.Kategorija.Naziv = (string)reader["nazivkat"];
                c.Kategorija.Opis= (string)reader["opiskat"];
                return c;
            }else if(argument is Kategorija)
            {
                Kategorija k = new Kategorija();
                k.Id = (int)reader["idkategorije"];
                k.Popust = (double)reader["popust"];
                k.Naziv = (string)reader["nazivkat"];
                k.Opis = (string)reader["opiskat"];
                return k;
            }else if (argument is GrupniProgram)
            {
                GrupniProgram gr = new GrupniProgram();
                gr.Id = (int)reader["idgrpr"];
                gr.Naziv = (string)reader["nazivgrpr"];
                gr.Opis = (string)reader["opisgrpr"];
                gr.CenaJednog = (double)reader["cenatermina"];
                return gr;
            }else if(argument is Racun)
            {
                Racun r = new Racun();
                r.RBRRacuna = (int)reader["rednibrac"];
                r.Mesec = (Mesec)reader["mesec"];
                r.Godina = (int)reader["godina"];
                r.Iznos = (double)reader["iznos"];

                r.Clan = new Clan();
                r.Clan.IdClana = (int)reader["id_cl"];
                r.Clan.Ime = (string)reader["ime"];
                r.Clan.Prezime = (string)reader["prezime"];
                r.Clan.Email = (string)reader["email"];
                r.Clan.BrojTelefona = (string)reader["brtel"];

                r.Clan.Kategorija = new Kategorija();
                r.Clan.Kategorija.Id = (int)reader["idkat"];
                r.Clan.Kategorija.Popust = (double)reader["popust"];
                r.Clan.Kategorija.Naziv = (string)reader["nazivkat"];
                r.Clan.Kategorija.Opis = (string)reader["opiskat"];
                return r;
            }else if(argument is Odlazak)
            {
                Odlazak o = new Odlazak();
                o.Clan = new Clan();
                o.Clan.IdClana = (int)reader["id_clana"];
                o.Clan.Ime = (string)reader["ime"];
                o.Clan.Prezime = (string)reader["prezime"];
                o.Clan.Email = (string)reader["Email"];
                o.Clan.BrojTelefona = (string)reader["brtel"];

                o.Clan.Kategorija = new Kategorija();
                o.Clan.Kategorija.Id = (int)reader["idkat"];
                o.Clan.Kategorija.Popust = (double)reader["popust"];
                o.Clan.Kategorija.Naziv = (string)reader["nazivkat"];
                o.Clan.Kategorija.Opis = (string)reader["opiskat"];

                o.DatumOdlaska = (DateTime)reader["datumodlaska"];

                o.GrupniProgram = new GrupniProgram();
                o.GrupniProgram.Id = (int)reader["id_grpr"];
                o.GrupniProgram.Naziv = (string)reader["nazivgrpr"];
                o.GrupniProgram.Opis = (string)reader["opisgrpr"];
                o.GrupniProgram.CenaJednog = (double)reader["cenatermina"];

                o.Placeno = (bool)reader["placeno"];

                return o;
            }
            return null;
        }
    }
}
