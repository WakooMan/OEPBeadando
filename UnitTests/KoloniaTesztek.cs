using Feladat11;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTests
{
    [TestClass]
    public class KoloniaTesztek
    {

        [TestMethod]
        public void InicializalosTeszt()
        {
            var koloniakeszitok = new KoloniaKeszito[6] { new LemmingKeszito(), new UrgeKeszito(), new NyulKeszito(), new SarkiRokaKeszito(), new HobagolyKeszito(), new FarkasKeszito() };
            bool l = true;
            Faj i = Faj.Lemming;
            while(l && i < Faj.Farkas)
            {
                var kolonia = koloniakeszitok[(int)i].KoloniatKeszit($"Kolonia{i+1}",((int)i+1)*10);
                l = ((kolonia.Ragadozo_e() && i >= Faj.SarkiRoka) || (!kolonia.Ragadozo_e() && i < Faj.SarkiRoka)) && kolonia.Egyedszam() == ((int)i + 1) * 10 && kolonia.Becenev() == $"Kolonia{i + 1}" && kolonia.Faj() == i;
                i++;
            }
            Assert.IsTrue(l);
        }

        [TestMethod]
        public void MegtamadosTeszt()
        {
            for (Faj i = Faj.Lemming; i < Faj.OsszesFaj;i++)
            {
                Elovilag.Current().KoloniatHozzaad($"Kolonia{i + 1}",i,(i >= Faj.SarkiRoka)?10:60);
            }
            MethodInfo ZsakmanytMegtamad = typeof(Ragadozo).GetMethod("ZsakmanytMegtamad", BindingFlags.Instance | BindingFlags.NonPublic);
            int[] ElozoEgyedszamok = new int[3];
            int[] Kivonandok = new int[3] { 40,20,20};
            for (int i = 0; i < 3; i++)
            {
                ElozoEgyedszamok[i] = Elovilag.Current().ZsakmanyKoloniak()[i].Egyedszam();
                ZsakmanytMegtamad.Invoke(Elovilag.Current().RagadozoKoloniak()[i], new object[] { Elovilag.Current().ZsakmanyKoloniak()[i] });
            }
            bool l = true;
            int j = 0;
            while (l && j < 3)
            {
                l = Elovilag.Current().ZsakmanyKoloniak()[j].Egyedszam() == ElozoEgyedszamok[j] - Kivonandok[j];
                j++;
            }
            Assert.IsTrue(l);
        }

        [TestMethod]
        public void ZsakmanyokTorlodnek()
        {
            Elovilag.Current().Clear();
            for (Faj i = Faj.Lemming; i < Faj.OsszesFaj; i++)
            {
                Elovilag.Current().KoloniatHozzaad($"Kolonia{i + 1}", i, (i >= Faj.SarkiRoka) ? 10 : 20);
            }
            Elovilag.Current().KortVegrehajt(1);
            Assert.IsTrue(Elovilag.Current().ZsakmanyKoloniak().Count == 0);
        }
        [TestMethod]
        public void RagadozokEhenHalnak()
        {
            Elovilag.Current().Clear();
            for (Faj i = Faj.SarkiRoka; i < Faj.OsszesFaj; i++)
            {
                Elovilag.Current().KoloniatHozzaad($"Kolonia{i + 1}", i, 10);
            }
            for (int i = 1; i <= 6; i++) 
            {
                Elovilag.Current().KortVegrehajt(i); 
            }
            Assert.IsTrue(Elovilag.Current().RagadozoKoloniak().Count == 0);
        }
        [TestMethod]
        public void ZsakmanyokFialnak()
        {
            Elovilag.Current().Clear();
            for (Faj i = Faj.Lemming; i < Faj.SarkiRoka; i++)
            {
                Elovilag.Current().KoloniatHozzaad($"Kolonia{i + 1}", i, 10);
            }
            foreach (Kolonia kolonia in Elovilag.Current().Koloniak())
            {
                int FialKor = (int)typeof(Kolonia).GetField("FialKor",BindingFlags.Instance | BindingFlags.NonPublic).GetValue(kolonia);
                int ElozoEgyedszam = kolonia.Egyedszam();
                kolonia.Cselekszik(FialKor);
                Assert.IsTrue(ElozoEgyedszam < kolonia.Egyedszam());
            }
        }
        [TestMethod]
        public void RagadozokFialnak()
        {
            Elovilag.Current().Clear();
            for (Faj i = Faj.Lemming; i < Faj.OsszesFaj; i++)
            {
                Elovilag.Current().KoloniatHozzaad($"Kolonia{i + 1}", i, (i >= Faj.SarkiRoka) ? 10 : 60);
            }
            foreach (Ragadozo kolonia in Elovilag.Current().RagadozoKoloniak())
            {
                int FialKor = (int)typeof(Kolonia).GetField("FialKor", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(kolonia);
                int ElozoEgyedszam = kolonia.Egyedszam();
                kolonia.Cselekszik(FialKor);
                Assert.IsTrue(ElozoEgyedszam < kolonia.Egyedszam());
            }
        }
    }
}
