using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetArgent
{
    internal class Carte
    {
        private long Numero { get; set; }
        private int Plafond { get; set; }
        private List<string> Historique { get; set; }
        private List<int> numComptes;

        public Carte(long numero, int plafond)
        {
            Numero = numero;
            Plafond = plafond;
        }
    }
}
