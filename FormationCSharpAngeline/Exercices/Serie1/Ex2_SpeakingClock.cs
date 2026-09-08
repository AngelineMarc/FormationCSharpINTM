using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class SpeakingClock
    {
        public static string GoodDay(int heure)
        {
            string res = "Il est " + heure + " H, ";

            switch (heure)
            {
                case int n when n >= 0 && n < 6:
                    res += "Merveilleuse nuit !!";
                    break;
                case int n when n >= 6 && n < 12:
                    res += "Bonne matinée !";
                    break;
                case int n when n == 12:
                    res += "Bon appétit !";
                    break;
                case int n when n >= 13 && n < 18:
                    res += "Profitez de votre après-midi !";
                    break;
                case int n when n >= 18 && n <= 23:
                    res += "Passez une bonne soirée !";
                    break;
                default:
                    res += "L'heure est invalide";
                    break;

            }
            return res ;
        }
    }
}
