using System;
using System.Collections.Generic;
using System.Text;

namespace TopologicalSort
{
    class Graph
    {
        int noOfVertices;
        List<int> []adjacencyList;

        public Graph(int vertices) {
            noOfVertices = vertices;
            adjacencyList = new List<int>[noOfVertices];
            for (int i = 0; i < noOfVertices; i++) {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int vertex, int adjacentVertex ) {
            adjacencyList[vertex].Add(adjacentVertex);
        }

        public int GetNoOfVertices() {
            return noOfVertices;
        }

        public void TopologicalSort(Graph graph) {
            int[] visited = new int[graph.GetNoOfVertices()];
            for (int i = 0; i < graph.GetNoOfVertices(); i++) {
                visited[i] = 0;
            }
            Stack<int> topoStack = new Stack<int>();

            for (int i = 0; i < noOfVertices; i++) {
                if (visited[i] == 0) {
                    TopologicalSortUtil(i, visited,topoStack );
                }
            }

            Console.WriteLine();
            Console.WriteLine("The Topological ordering of the given DAG is");
            while (topoStack.Count != 0) {
                Console.Write(topoStack.Pop()+"->");
            }
        }

        public List<int>[] GetAllAdjacencyList(Graph graph) {
            return graph.adjacencyList;
        }

        public List<int> GetAdjacencyList(Graph graph, int vertex) {
            List<int>[] allList = graph.GetAllAdjacencyList(graph);
            return allList[vertex];
        }

        public void TopologicalSortUtil(int startVertex, int[] visited, Stack<int> topoStack ) {
            visited[startVertex] = 1;
            List<int> list = this.GetAdjacencyList(this, startVertex);
            foreach (int element in list){
                if (visited[element] == 0) {
                    TopologicalSortUtil(element, visited, topoStack);
                }
            }
            topoStack.Push(startVertex);
        }

    }
}