using System.IO;

namespace ProjetArgent
{
    public static class Sortie
    {
        /// <summary>
        /// Initialisation du fichier de sortie
        /// </summary>
        public static void InitSorite()
        {
            File.WriteAllText("../../statut.csv", string.Empty);
        }

        /// <summary>
        /// Ecriture dans le fichier de sortie du statut d'une transaction
        /// </summary>
        /// <param name="numTransaction">identifiant de la transaction</param>
        /// <param name="statut"> statut de la transaction </param>
        public static void EcrireSortie(int numTransaction, string statut)
        {
            using (StreamWriter writer = File.AppendText("../../statut.csv"))
            {
                writer.WriteLine(numTransaction + ";" + statut);
            }
        }
    }
}
