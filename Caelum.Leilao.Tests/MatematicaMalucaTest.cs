using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    class MatematicaMalucaTest
    {
        [Test]
        public void VerificaNumeroMaiorTrinta()
        {
            MatematicaMaluca matematicaMaluca = new MatematicaMaluca();

            Assert.AreEqual(31*4, matematicaMaluca.ContaMaluca(31));
        }

        [Test]
        public void VerificaNumeroMaiorDez()
        {
            MatematicaMaluca matematicaMaluca = new MatematicaMaluca();
            
            Assert.AreEqual(11*3, matematicaMaluca.ContaMaluca(11));
        }

        [Test]
        public void VerificaNumeroMenorDez()
        {
            MatematicaMaluca matematicaMaluca = new MatematicaMaluca();
            
            Assert.AreEqual(9*2, matematicaMaluca.ContaMaluca(9));
        }

    }
}
