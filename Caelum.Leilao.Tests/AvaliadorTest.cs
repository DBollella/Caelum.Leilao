using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    class AvaliadorTest
    {   
        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 400;
            double medioEsperado = 316.6666666666667;
            double menorEsperado = 250;
                             

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance,0.00001);
            Assert.AreEqual(medioEsperado, leiloeiro.MedioLance, 0.00001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance,0.00001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemCrescenteComOutrosValores()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 1000.0));
            leilao.Propoe(new Lance(joao, 2000.0));
            leilao.Propoe(new Lance(jose, 3000.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(3000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("João");
            Leilao leilao = new Leilao("Playstation 3");

            leilao.Propoe(new Lance(joao, 200.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(200, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(200, leiloeiro.MaiorLance, 0.0001);
        }

        [Test]
        public void DeveEntenderLeilaoComDoisLances()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3");

            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(maria, 100.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);  

            IList<Lance> maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor, 0.0001);
            Assert.AreEqual(100, maiores[1].Valor, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.00001);
            Assert.AreEqual(300, maiores[1].Valor, 0.00001);
            Assert.AreEqual(200, maiores[2].Valor, 0.00001);
        }

        [Test]
        public void DeveEntenderLeilaoComValoresAleatorios()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playestatio 3");

            leilao.Propoe(new Lance(joao, 200));
            leilao.Propoe(new Lance(maria, 450));
            leilao.Propoe(new Lance(joao, 120));
            leilao.Propoe(new Lance(maria, 700));
            leilao.Propoe(new Lance(joao, 630));
            leilao.Propoe(new Lance(maria, 230));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(120, leiloeiro.MenorLance);
            Assert.AreEqual(700, leiloeiro.MaiorLance);
        }  

        [Test]
        public void DeveEntenderLeilaoComLancesOrdemDecrescente()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playestatio 3");

            leilao.Propoe(new Lance(joao, 400));
            leilao.Propoe(new Lance(maria, 300));
            leilao.Propoe(new Lance(joao, 200));
            leilao.Propoe(new Lance(maria, 100));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(100, leiloeiro.MenorLance);
            Assert.AreEqual(400, leiloeiro.MaiorLance);
        }

        [Test]
        public void DeveEntenderLeilaoComNenhumLance()
        {
            Usuario joao = new Usuario("João");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playestatio 3");

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            IList<Lance> maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(0, maiores.Count);
        }
    }
}
