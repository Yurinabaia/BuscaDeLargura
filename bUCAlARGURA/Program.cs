using System;
using System.Collections;
using System.Collections.Generic;

namespace bUCAlARGURA
{
    class Program
    {

        static void Main(string[] args)
        {
            //Primeiro definir a quantidade de vertice vai possuir o grafo
            //COLOQUE O VALOR NO GRAFO(8)
            GRAFO G = new GRAFO(8);
            //ABAIXO TEMO O GRAFO E SUAS LIGAÇÕES
            //DEFINIR AS LIGAÇÕES DE ACORDO DO MENOR PARA O MAIOR
            //DE 0 ATE 1, DE 0 ATE 4, DE 1 ATE 5 ETC

            //***** JEITO CERTO  G.adicionaAresta(2, 5);  **********//
            //***** NÃO FACA ASSIM 5 ATE 2 VAI DAR MERDA.  G.adicionaAresta(5, 2); error **********//


            //0 == A
            //1 == B
            //2 == C
            //3 == D
            //4 == E
            //ETC

            G.adicionaAresta(0, 1);
            G.adicionaAresta(0, 4);
            G.adicionaAresta(1, 5);
            G.adicionaAresta(2, 5);
            G.adicionaAresta(2, 6);
            G.adicionaAresta(2, 3);
            G.adicionaAresta(3, 6);
            G.adicionaAresta(3, 7);
            G.adicionaAresta(5, 6);
            G.adicionaAresta(6, 7);


            Console.WriteLine(G.TMGCaminhoMaisCurto(7, 0));
            Console.WriteLine("Menor caminho");
            foreach (int item in G.CaminhoMenor(7,0))
            {
               string asd  = LETRA(item);
                Console.Write(asd + " - ");
            }
            Console.WriteLine("\n");

            Console.WriteLine(G.ToString());
        }
        public static string LETRA(int pos)
        {
            string palavra = "ABCDEFGHIJKLMNOPQRSTUVXWYZ";
            return palavra.ToCharArray()[pos].ToString();
        }
    }
}


