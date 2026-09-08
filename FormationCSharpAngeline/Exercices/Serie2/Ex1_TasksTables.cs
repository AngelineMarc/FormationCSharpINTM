using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    public static class TasksTables
    {
        public static int SumTab(int[] tab)
        {
            
            int res = 0;

            if(tab.Length == 0)
            {
                res = -1;
            }
            else
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    res += tab[i];
                }
            }

            return res;
        }

        public static int[] OpeTab(int[] tab, char ope, int b)
        {
            
            int[] tabRes = new int[tab.Length];
            if(tab.Length != 0) { 
                Console.WriteLine($"ope : {ope} {b}");
                switch(ope)
                {
                    case '+':
                        for(int i= 0; i < tab.Length; i++)
                        {
                            tabRes[i] = tab[i] + b;
                        }
                        break;
                    case '-':
                        for (int i = 0; i < tab.Length; i++)
                        {
                            tabRes[i] = tab[i] - b;
                        }
                        break;
                    case '*':
                        for (int i = 0; i < tab.Length; i++)
                        {
                            tabRes[i] = tab[i] * b;
                        }
                        break;
                    default:
                        break;
                }
                
            }
            return tabRes;
        }

        public static int[] ConcatTab(int[] tab1, int[] tab2)
        {
            int[] res = new int[tab1.Length + tab2.Length];
            for(int i=0; i < tab1.Length; i ++)
            {
                res[i] = tab1[i];
            }
            for(int i=0; i <tab2.Length; i++)
            {
                res[tab1.Length + i] = tab2[i];
            }
            return res;
        }

    }
}
