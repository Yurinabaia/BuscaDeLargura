using System;
using System.Collections.Generic;
using System.Text;

namespace bUCAlARGURA
{
    enum LETRAS
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H
    }
    class GRAFO
    {
        private int INFINITO;
        private int V;
        private int A;
        private bool[,] adj;

    public GRAFO(int V)
        {
            this.V = V;
            this.A = 0;
            this.adj = new bool[V,V];
            this.INFINITO = V;
        }

        public void adicionaAresta(int u, int v)
        {
            if (!adj[u,v])
            {
                A++;
                adj[u,v] = adj[v,u] = true;
            }
        }

        public void removeAresta(int u, int v)
        {
            if (adj[u,v])
            {
                A--;
                adj[u,v] = adj[v,u] = false;
            }
        }

        public int TMGCaminhoMaisCurto(int s, int t)
        {
            int[] dist = new int[V];
            for (int w = 0; w < V; w++)
            {
                dist[w] = INFINITO;
            }
            buscaEmLargura(s, dist);
            return dist[t];
        }

        private void buscaEmLargura(int s, int[] dist)
        {
            Queue<int> fila = new Queue<int>();
            fila.Enqueue(s);
            LinkedList<int> my_list = new LinkedList<int>();
           my_list.AddLast(s);
            dist[s] = 0;

            while (fila.Count > 0)
            {
                int u = fila.Dequeue();
               my_list.RemoveLast();
                for (int v = 0; v < V; v++)
                {
                    if (adj[u,v] && dist[v] == INFINITO)
                    {
                        fila.Enqueue(v);
                      my_list.AddLast(v);
                        dist[v] = dist[u] + 1;
                    }
                }
            }
        }

        public List<int> CaminhoMenor(int s, int t)
        {
            int[] ant = new int[V];
            for (int j = 0; j < V; j++)
            {
                ant[j] = -1;
            }
            ant[s] = s;
            buscaEmLarguras(s, ant);

            if (ant[t] == -1) return new List<int>();

            List<int> caminho = new List<int>();
            int w = t;
            while (w != ant[w])
            {
                caminho.Add(w);
                w = ant[w];
            }
            caminho.Add(s); 
            caminho.Reverse();
            return caminho;
        }

        private void buscaEmLarguras(int s, int[] ant)
        {
            Queue<int> fila = new Queue<int>();
            LinkedList<int> my_list = new LinkedList<int>();
            my_list.AddLast(s);
            fila.Enqueue(s);
            ant[s] = s;

            while (fila.Count > 0)
            {
                int u = fila.Dequeue();
                my_list.RemoveLast();

                for (int v = 0; v < V; v++)
                {
                    if (adj[u,v] && ant[v] == -1)
                    {
                        fila.Enqueue(v);
                        my_list.AddLast(v);
                        ant[v] = u;
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Numero de vértices: " + V + "\n");
            stringBuilder.Append("Numero de arestas: " + A + "\n");
            int cont = 0;
            for (int u = 0; u < V; u++)
            {
                stringBuilder.Append(LETRA(u) + ":");
                for (int v = 0; v < V; v++)
                {
                    if (adj[u, v])
                    {
                        string a = LETRA(v);
                        stringBuilder.Append(" " + a);
                        cont++;
                    }
                }
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }

        public string LETRA(int pos) 
        {
            string palavra = "ABCDEFGHIJKLMNOPQRSTUVXWYZ";
            return palavra.ToCharArray()[pos].ToString();
        }
    }
}
