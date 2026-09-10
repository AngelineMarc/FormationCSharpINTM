using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    internal class QCM
    {
        private string question;
        private string[] answers;
        private int solution;
        private int weight;

        public QCM(string question, string[] answers, int solution, int weight)
        {
            this.question = question;
            this.answers = answers;
            this.solution = solution;
            this.weight = weight;

        }

        public bool QcmValidity(QCM qcm)
        {
            bool res = true;
            if(qcm.solution < 0 || qcm.solution > qcm.answers.Length)
            {
                res = false;
            }
            else if(qcm.weight < 0)
            {
                res = false;
            }

            return res;
        }

        public static int AskQuestion(QCM qcm)
        {
            int res = 0;

            Console.WriteLine(qcm.question);
            for(int i = 0; i < qcm.answers.Length; i++)
            {
                Console.Write(qcm.answers[i] + "   ");
            }
            Console.WriteLine();

            if (!qcm.QcmValidity(qcm)) {
                throw new ArgumentException("QCM non valide");
            }

            bool repValide = false;
            int reponse;
            do
            {
                Console.Write("Reponse : ");
                bool isParsable = int.TryParse(Console.ReadLine(), out reponse);

                if (!isParsable || reponse > qcm.answers.Length || reponse < 1)
                {
                    Console.WriteLine("Réponse invalide !");

                }
                else
                {
                    repValide = true;
                }

            } while(!repValide);

            if(reponse == qcm.solution)
            {
                res = qcm.weight;
            }
            
            return res;
        }

        public static void AskQuestions(QCM[] qcm)
        {
            int res = 0;
            foreach (QCM q in qcm) {
                Console.WriteLine(q.question);
                for (int i = 0; i < q.answers.Length; i++)
                {
                    Console.Write(q.answers[i] + "   ");
                }
                Console.WriteLine();

                if (!q.QcmValidity(q))
                {
                    throw new ArgumentException("QCM non valide");
                }

                bool repValide = false;
                int reponse;
                do
                {
                    Console.Write("Reponse : ");
                    bool isParsable = int.TryParse(Console.ReadLine(), out reponse);
                   
                    if (!isParsable || reponse > q.answers.Length || reponse < 1)
                    {
                        Console.WriteLine("Réponse invalide !");

                    }
                    else
                    {
                        repValide = true;
                    }

                } while (!repValide);

                if (reponse == q.solution)
                {
                    res ++;
                }
            }

            Console.WriteLine($"Résultats du questionnaire : {res} / {qcm.Length}");
            
        }
    }
}
