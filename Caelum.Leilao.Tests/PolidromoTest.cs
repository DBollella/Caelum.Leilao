using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    class PolidromoTest
    {
        [Test]
        public void verificaPolidromo()
        {
            var frase = "Socorram-me subi no onibus em Marrocos"; 
            Palindromo palidromo = new Palindromo();
            bool resultado = palidromo.EhPalindromo(frase);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void NaoEhPolidromo()
        {
            var frase = "Socom-me subi no onibus em Marrocos";
            Palindromo palidromo = new Palindromo();
            bool resultado = palidromo.EhPalindromo(frase);
            Assert.IsFalse(resultado);
        }
    }
}
