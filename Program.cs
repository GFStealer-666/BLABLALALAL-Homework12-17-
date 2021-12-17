using System;
using System.Collections.Generic;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("City : ");

            int city = 0;
             city = int.Parse(Console.ReadLine());

            List<String> Cityname = new List<string>();

            Pathfinder Matrix2 = new Pathfinder();
            Matrix2.V = city;

            for (int x = 0; x < city; x++)
            {
                Console.Write("City name : ");

                string cityname = Console.ReadLine();

                Cityname.Add(cityname); 
            }

            int[,] Matrix = new int[city,city]; 
            
            for (int i = 0; i < city; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i == j)
                    {
                        Matrix[i, j] = 0;
                    }
                    else
                    {
                        Console.Write("Distance : ");

                        int di = int.Parse(Console.ReadLine());

                        int distance = di;

                        if (di == -1)
                        {
                            distance = 0;
                        }

                        Matrix[i, j] = distance;

                        Matrix[j, i] = distance;
                    }

                }
            }

            string lastcityname;

            /*for (int i = 0; i < city; i++)
            {               

                for (int j = 0; j < i; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("อ " + Matrix[i, j]);
                    }
                    else
                    {
                        Console.Write(" " + Matrix[i, j]);
                    }

                }
                Console.WriteLine();
            }*/

            int lasycityindex = 0;
            Console.Write("Last city : ");

            lastcityname = Console.ReadLine();
            
            for(int i = 0; i < Cityname.Count; i++)
            {
                if (lastcityname == Cityname[i])
                {
                     lasycityindex = i;
                }
            }
                         
            Matrix2.dijkstra(Matrix, 0 , lasycityindex); 
            
        }
    }
    class Pathfinder
    {       
        public int V ;
        int minDistance(int[] dist,bool[] sptSet)
        {           
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }               
            return min_index;
        }

        public void PrintSolution(int[] dist , int city)
        {
           
            Console.Write("{0}" , dist[city]);
            

            Console.ReadLine();
        }

        public void dijkstra(int[,] graph, int src , int cityindex)
        {
            int[] dist = new int[V];                                                                        

            bool[] sptSet = new bool[V];          
           
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }                     
            dist[src] = 0; 

            
            for (int count = 0; count < V - 1; count++)
            {                           
                            
                int u = minDistance(dist, sptSet);
                sptSet[u] = true;
                  
                for (int v = 0; v < V; v++)
                {
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                       
                }                                                                      
                    
            }

            PrintSolution(dist, cityindex);
        }
    }
}

