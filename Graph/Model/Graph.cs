using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Model
{
    /// <summary>
    ///Граф.
    /// </summary>
    class Graph
    {
        List<Vertex> Vertexs = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();

        public int VertexsCount => Vertexs.Count;
        public int EdgesCount => Edges.Count;

        /// <summary>
        /// Добавление вершины графа.
        /// </summary>
        public void Add(Vertex vertex)
        {
            Vertexs.Add(vertex);
        }

        /// <summary>
        /// Добавление ребра графа.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }

        /// <summary>
        /// Получение матрицы смежности.
        /// </summary>
        /// <returns></returns>
        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexs.Count, Vertexs.Count];

            foreach (var edge in Edges)
            {
                var row = edge.From.Number - 1;
                var column = edge.To.Number - 1;

                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }

        /// <summary>
        /// Получение списка смежных вершин с заданной.
        /// </summary>
        /// <param name="vertex">Данная вершина.</param>
        /// <returns>Список вершин.</returns>
        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var result = new List<Vertex>();

            //result.AddRange(Edges.FindAll(f => f.From.Number == vertex.Number).Select(s => s.To));

            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }

            return result;
        }

        /// <summary>
        /// Волновой алгоритм получения кратчайшего пути от одной вершины до другой.
        /// </summary>
        public bool Wave(Vertex start, Vertex finish)
        {
            var list = new List<Vertex>();            
            list.Add(start);

            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in GetVertexList(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                    }
                }
            }

            return list.Contains(finish);
        }
    }
}
