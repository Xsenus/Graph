using System;

namespace Graph.Model
{
    /// <summary>
    /// Вершина графа.
    /// </summary>
    class Vertex
    {
        public int Number { get; set; }

        public Vertex(int number)
        {
            //TODO: проверка

            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
