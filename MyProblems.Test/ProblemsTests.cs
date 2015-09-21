using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyProblems.Test
{
    [TestClass]
    public class ProblemsTests
    {
        [TestMethod]
        public void PepeneTest()
        {
            var probleme = new Problems();
            string par = probleme.Pepene(12);
            string impar = probleme.Pepene(11);
            Assert.AreEqual(par, "DA");
            Assert.AreEqual(impar, "NU");
        }

        [TestMethod]
        public void SportivTest()
        {
            var probleme = new Problems();
            int sportiv_runde = probleme.Sportiv(5);
            Assert.AreEqual(sportiv_runde, 25);

        }
        [TestMethod]
        public void CapreTest()
        {
            var probleme = new Problems();
            int kg_fan = probleme.Capre(5,6);
            Assert.AreEqual(kg_fan, 1080);

        }

        [TestMethod]
        public void CiuperciTest()
        {
            var probleme = new Problems();
            var ciuperci= probleme.Ciuperci(121, 10);
            Assert.AreEqual(ciuperci[0], 11, "Numarul de Ciuperci albe");
            Assert.AreEqual(ciuperci[1], 110, "Numarul de Ciuperci rosii");
        }

        [TestMethod]
        public void ParchetTest()
        {
            var probleme = new Problems();
            var mp_parchet = probleme.Parchet(16, 20);
            Assert.AreEqual(mp_parchet, 9.2);
        }

        [TestMethod]
        public void PavajTest()
        {
            var probleme = new Problems();
            var piatra = probleme.Pavaj(6, 6);
            Assert.AreEqual(piatra, 4);
        }

        [TestMethod]
        public void RataTest()
        {
            var probleme = new Problems();
            double rata = probleme.Rata(40000, 7.67, 20);

            Assert.AreEqual(Math.Round(rata,2), 366.49);
        }

        [TestMethod]
        public void TrenTest()
        {
            var probleme = new Problems();
            float distanta_pasare = probleme.Tren(50, 10);

            Assert.AreEqual(distanta_pasare, 25);
        }
    }
}
