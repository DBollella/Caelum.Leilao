using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private double valorMedio = 0.0;   
        private List<Lance> maiores;    
        

        public void Avalia(Leilao leilao)
        {
            double total = 0;
            foreach (Lance lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }             

                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }  
                total += lance.Valor;               
            }
            valorMedio = total / leilao.Lances.Count;
            pegaOsMaioresNo(leilao);
        }

        private void pegaOsMaioresNo(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            maiores = maiores.GetRange(0, maiores.Count > 3 ? 3 : maiores.Count);
        }

        public List<Lance> TresMaiores
        {
            get { return this.maiores; }
        }

        public double MaiorLance { get { return maiorDeTodos; } }

        public double MedioLance { get { return valorMedio; } }

        public double MenorLance { get { return menorDeTodos; } }

    }
}
