using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Model.Graph();

            var v1 = new Model.Vertex(1);
            var v2 = new Model.Vertex(2);
            var v3 = new Model.Vertex(3);
            var v4 = new Model.Vertex(4);
            var v5 = new Model.Vertex(5);
            var v6 = new Model.Vertex(6);
            var v7 = new Model.Vertex(7);

            graph.Add(v1);
            graph.Add(v2);
            graph.Add(v3);
            graph.Add(v4);
            graph.Add(v5);
            graph.Add(v6);
            graph.Add(v7);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v6, v5);
            graph.AddEdge(v5, v6);

            GetMatrix(graph);

            Console.WriteLine();
            Console.WriteLine();

            GetVertex(graph, v1);
            GetVertex(graph, v2);
            GetVertex(graph, v3);
            GetVertex(graph, v4);
            GetVertex(graph, v5);
            GetVertex(graph, v6);
            GetVertex(graph, v7);


            Console.WriteLine(graph.Wave(v1, v5));
            Console.WriteLine(graph.Wave(v2, v4));

            Console.ReadLine();
        }

        private static void GetVertex(Model.Graph graph, Model.Vertex vertex)
        {
            Console.Write($"{vertex.Number}: ");

            foreach (var v in graph.GetVertexList(vertex))
            {
                Console.Write($"{v.Number} ");
            }

            Console.WriteLine();
        }

        private static void GetMatrix(Model.Graph graph)
        {
            var matrix = graph.GetMatrix();

            for (int i = 0; i < graph.VertexsCount; i++)
            {
                Console.Write($" | {i + 1} |");
            }
            Console.WriteLine("\n_________________________________________");

            for (int i = 0; i < graph.VertexsCount; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < graph.VertexsCount; j++)
                {
                    Console.Write($"| {matrix[i, j]} | ");
                }
                Console.WriteLine();
            }
        }
    }
}
