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
                var kolonia = koloniakeszitok[(int)i].KoloniatKeszit(null, $"Kolonia{i + 1}",((int)i + 1) * 10);
                l = ((kolonia.Ragadozo_e() && i >= Faj.SarkiRoka) || (!kolonia.Ragadozo_e() && i < Faj.SarkiRoka)) && kolonia.Egyedszam() == ((int)i + 1) * 10 && kolonia.Becenev() == $"Kolonia{i + 1}" && kolonia.Faj() == i;
                i++;
            }
            Assert.IsTrue(l);
        }

        [TestMethod]
        public void MegtamadosTeszt()
        {
            Tundra.Instance.Clear();
            for (Faj i = Faj.Lemming; i < Faj.OsszesFaj;i++)
            {
                Tundra.Instance.KoloniatHozzaad($"Kolonia{i + 1}",i,(i >= Faj.SarkiRoka)?10:60);
            }
            MethodInfo ZsakmanytMegtamad = typeof(Ragadozo).GetMethod("ZsakmanytMegtamad", BindingFlags.Instance | BindingFlags.NonPublic);
            int[] ElozoEgyedszamok = new int[3];
            int[] Kivonandok = new int[3] { 40,20,20};
            for (int i = 0; i < 3; i++)
            {
                ElozoEgyedszamok[i] = Tundra.Instance.ZsakmanyKoloniak()[i].Egyedszam();
                ZsakmanytMegtamad.Invoke(Tundra.Instance.RagadozoKoloniak()[i], new object[] { Tundra.Instance.ZsakmanyKoloniak()[i] });
            }
            bool l = true;
            int j = 0;
            while (l && j < 3)
            {
                l = Tundra.Instance.ZsakmanyKoloniak()[j].Egyedszam() == ElozoEgyedszamok[j] - Kivonandok[j];
                j++;
            }
            Assert.IsTrue(l);
        }

        [TestMethod]
        public void ZsakmanyokTorlodnekTeszt()
        {
            Tundra.Instance.Clear();
            for (Faj i = Faj.Lemming; i < Faj.OsszesFaj; i++)
            {
                Tundra.Instance.KoloniatHozzaad($"Kolonia{i + 1}", i, (i >= Faj.SarkiRoka) ? 10 : 20);
            }
            Tundra.Instance.KortVegrehajt();
            Tundra.Instance.KortVegrehajt();
            Assert.IsTrue(Tundra.Instance.ZsakmanyKoloniak().Count == 0);
        }
        [TestMethod]
        public void RagadozokEhenHalnakTeszt()
        {
            Tundra.Instance.Clear();
            for (Faj i = Faj.SarkiRoka; i < Faj.OsszesFaj; i++)
            {
                Tundra.Instance.KoloniatHozzaad($"Kolonia{i + 1}", i, 10);
            }
            for (int i = 0; i <= 7; i++) 
            {
                Tundra.Instance.KortVegrehajt(); 
            }
            Assert.IsTrue(Tundra.Instance.RagadozoKoloniak().Count == 0);
        }
        [TestMethod]
        public void ZsakmanyokFialnakTeszt()
        {
            Tundra.Instance.Clear();
            for (Faj i = Faj.Lemming; i < Faj.SarkiRoka; i++)
            {
                Tundra.Instance.KoloniatHozzaad($"Kolonia{i + 1}", i, 10);
            }
            foreach (Kolonia kolonia in Tundra.Instance.Koloniak())
            {
                int FialKor = (int)typeof(Kolonia).GetField("FialKor",BindingFlags.Instance | BindingFlags.NonPublic).GetValue(kolonia);
                int ElozoEgyedszam = kolonia.Egyedszam();
                kolonia.Cselekszik(FialKor);
                Assert.IsTrue(ElozoEgyedszam < kolonia.Egyedszam());
            }
        }
        [TestMethod]
        public void RagadozokFialnakTeszt()
        {
            Tundra.Instance.Clear();
            for (Faj i = Faj.Lemming; i < Faj.OsszesFaj; i++)
            {
                Tundra.Instance.KoloniatHozzaad($"Kolonia{i + 1}", i, (i >= Faj.SarkiRoka) ? 10 : 120);
            }
            foreach (Ragadozo kolonia in Tundra.Instance.RagadozoKoloniak())
            {
                int FialKor = (int)typeof(Kolonia).GetField("FialKor", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(kolonia);
                int ElozoEgyedszam = kolonia.Egyedszam();
                kolonia.Cselekszik(FialKor);
                Assert.IsTrue(ElozoEgyedszam < kolonia.Egyedszam());
            }
        }
    }
}
