﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;

namespace Klijent
{
    public class Komunikacija
    {
        private Socket klijentskiSoket;
        private Posiljalac posiljalac;
        private Primalac primalac;
        private static Komunikacija instance;
        public static Komunikacija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }
        private Komunikacija() { }
        public bool PoveziSaServerom(int maxTry=3,int delayMs=1000)
        {
            int attempt=0;
            while (attempt<maxTry)
            {
                try
                {
                    klijentskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    klijentskiSoket.Connect("127.0.0.1", 9999);
                    posiljalac = new Posiljalac(klijentskiSoket);
                    primalac = new Primalac(klijentskiSoket);
                    return true;
                }
                catch (SocketException)
                {
                    attempt++;
                    if (attempt == maxTry)
                        return false;
                    Task.Delay(delayMs).Wait();
                    //Debug.WriteLine(">>>" + ex.Message.ToString());
                } 
            }
            return false;
        }
        internal Odgovor IzvrsiFju(Operacija op,IEntitet argument = null)
        {
            if (posiljalac == null)
                throw new Exception("Niste povezani sa serverom!");
           
                Zahtev zahtev = new Zahtev();
                zahtev.Operacija = op;
                zahtev.Argument = argument;
                posiljalac.Posalji(zahtev);
                Odgovor odgovor = (Odgovor)primalac.Primi();
                return odgovor;
          
        }
        internal Odgovor IzvrsiFjuSacuvajVise(Operacija op, List<Odlazak> argument)
        {
            Zahtev zahtev = new Zahtev();
            zahtev.Operacija = op;
            zahtev.Argument = argument;
            posiljalac.Posalji(zahtev);
            Odgovor odgovor = (Odgovor)primalac.Primi();
            return odgovor;
        }
    }
}
