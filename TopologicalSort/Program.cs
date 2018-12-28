using System;

namespace TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Topological Sort!");
            Console.WriteLine("-----------------");
            try
            {
                Graph g = ConstructGraphFromInput();
                g.TopologicalSort(g);
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is " + exception.Message);
            }

            Console.ReadLine();
        }

        private static Graph ConstructGraphFromInput() {
            Graph graph = null;
            Console.WriteLine("Enter the number of vertices in the graph");
            try {
                int noOfVertices = int.Parse(Console.ReadLine());
                graph = new Graph(noOfVertices);
                for (int i = 0; i < noOfVertices; i++) {
                    Console.WriteLine("Enter the number of adjacent vertices of the vertex "+i+":");
                    int noOfAdjVertices = int.Parse(Console.ReadLine());
                    for (int j = 0; j < noOfAdjVertices; j++) {
                        Console.WriteLine("Enter the adjacency vertex of vertex"+i+":");
                        int adjVertex = int.Parse(Console.ReadLine());
                        graph.AddEdge(i,adjVertex);
                    }
                }
            }catch(Exception exception){
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
            return graph;
        }
    }
}
