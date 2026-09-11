using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            return _open[i,j];
        }

        private bool IsFull(int i, int j)
        {
            return _full[i,j];
        }

        public bool Percolate()
        {
            _percolate = false;
            for(int i = 0; i < _size; i++)
            {
                if (_full[_size, i])
                {
                    _percolate= true;
                }
            }
            return _percolate;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> neighbors= new List<KeyValuePair<int, int>>();

            //Parcours des cases autours
            for(int k=-1; k <= 1; k++)
            {
                for(int l=-1; l <= 1; l++)
                {
                    // on ignore la case traitée
                    if(k == i && l == j)
                    {
                        break;
                    }

                    //calcul du i et j du voisin
                    int ni = i + k;
                    int nj = j + l;

                    //Si le voisin est dans la plage de valeur, on l'ajoute aux voisins
                    if(ni>=0 && nj >= 0 && ni <= _size && nj <= _size)
                    {
                        neighbors.Add(new KeyValuePair<int, int>(ni, nj));
                    }
                }
            }

            return neighbors;
        }

        public void Open(int i, int j)
        {
            //Ouverture de la cade i,j
            _open[i, j] = true;
            List<KeyValuePair<int, int>> neighbors = CloseNeighbors(i, j);

            //Parcours de ses voisins
            foreach(KeyValuePair<int ,int> kvp in neighbors) {
                //Si un des voisins de i,j est full , on remplie i,j
                if (IsFull(kvp.Key, kvp.Value) && !IsFull(i,j))
                {
                    _full[i, j] = true;
                }
                //Si i,j est full et que son voisin est vide et ouvert, on remplie le voisin
                if(IsFull(i,j) && IsOpen(kvp.Key, kvp.Value) && !IsFull(kvp.Key, kvp.Value))
                {
                    _full[kvp.Key, kvp.Value] = true;
                }
            }
        }
    }
}
