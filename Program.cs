using System;
using System.Xml;

namespace algoritomo_Floyd_Warshall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vertice = 4; // quantidade de vertice

            int[,] matrizGrafo = new int[vertice, vertice];

            matrizGrafo = GerarGrafos(matrizGrafo, vertice);
            ImprimirMatriz(matrizGrafo, 0, vertice);

            for (int k = 0; k < vertice; k++)
            {
                matrizGrafo = CalcularMatriz(matrizGrafo, k, vertice);
                ImprimirMatriz(matrizGrafo, k+1, vertice);
            }  
        }

        public static int[,] GerarGrafos(int[,] matrizGrafo, int vertice)
        {
            int infinito = 9999;

            for (int j = 0; j < vertice; j++)
            {
                Console.WriteLine(" ");
                for (int i = 0; i < vertice; i++)
                {
                    //Console.Write($" linha {i + 1} = ");  //preencher manual
                    //int valor = int.Parse(Console.ReadLine());

                    Random numAleatorio = new Random(); //preecher automatico
                    int valor = numAleatorio.Next(-9, 36);
                    Console.Write($"{valor}  ");

                    if (valor <= 0)
                        valor = infinito;

                    if (i == j)
                        valor = 0;

                    matrizGrafo[i, j] = valor; 
                }
            }
            return matrizGrafo;
        }

        public static int[,] CalcularMatriz( int[,] m, int k, int vetice)
        {
            for (int j = 0; j < vetice; j++)
            {
                for (int i = 0; i < vetice; i++)
                {
                    if (i != j)
                        if (i != k && j != k)
                            if (m[i, j] > (m[i, k] + m[k, j]))
                                m[i, j] = m[i, k] + m[k, j];
                }
            }
            return m;
        }

        public static void ImprimirMatriz(int[,] m, int k, int a)
        {
            Console.WriteLine($"\n\n---- M{k} ------");

            for (int j = 0; j < a; j++)
            {
                for (int i = 0; i < a; i++)
                {
                    Console.Write(m[i, j] + "  ");

                }
                Console.WriteLine();
            }
        }
    }
}
