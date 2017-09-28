using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            int total = 0;
            foreach (Lance l in Lances)
            {
                if (l.Usuario.Equals(lance.Usuario)) total++;
            }

            if (Lances.Count == 0 ||
                (!ultimoLanceDado().Usuario.Equals(lance.Usuario)
                    && total < 5))
            {
                Lances.Add(lance);
            }
        }

        private Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }

    }
}