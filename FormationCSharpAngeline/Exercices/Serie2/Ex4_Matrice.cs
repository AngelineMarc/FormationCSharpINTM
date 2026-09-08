using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2
{
    internal class Matrice
    {
        public static int[][] BuildingMatrix(int[] leftVector, int[] rightVector)
        {
            int[][] matrix = new int[leftVector.Length][];

            //Initialisation des colonne de la matrice
            for(int i= 0; i < leftVector.Length; i++)
            {
                matrix[i] = new int[rightVector.Length];
            }
            
            //calcul des valeurs de la matrices
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = leftVector[i] * rightVector[j];
                }
            }

            return matrix;
        }

        public static int[][] Addition(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] matrixRes = new int[leftMatrix.Length][];

            for (int i = 0; i < leftMatrix.Length; i++)
            {
                matrixRes[i] = new int[leftMatrix[i].Length];
            }


            for (int i = 0; i < matrixRes.Length; i++)
            {
                for (int j = 0; j < matrixRes[i].Length; j++)
                {
                    matrixRes[i][j] = leftMatrix[i][j] + rightMatrix[i][j];
                }
            }

            return matrixRes;

        }

        public static int[][] Soustraction(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] matrixRes = new int[leftMatrix.Length][];

            for (int i = 0; i < leftMatrix.Length; i++)
            {
                matrixRes[i] = new int[leftMatrix[i].Length];
            }


            for (int i = 0; i < matrixRes.Length; i++)
            {
                for (int j = 0; j < matrixRes[i].Length; j++)
                {
                    matrixRes[i][j] = leftMatrix[i][j] - rightMatrix[i][j];
                }
            }

            return matrixRes;

        }

        public static int[][] Multiplication(int[][] leftMatrix, int[][] rightMatrix)
        {
            int[][] matrixRes = new int[leftMatrix.Length][];

            for (int i = 0; i < leftMatrix.Length; i++)
            {
                matrixRes[i] = new int[rightMatrix[0].Length];
            }


            for (int i = 0; i < leftMatrix.Length; i++)
            {
                for (int j = 0; j < rightMatrix[0].Length; j++)
                {
                    for(int k=0; k < leftMatrix[0].Length; k++)
                    {
                        matrixRes[i][j] += leftMatrix[i][k] * rightMatrix[k][j];
                    }
                    
                }
            }

            return matrixRes;

        }
    }
}
