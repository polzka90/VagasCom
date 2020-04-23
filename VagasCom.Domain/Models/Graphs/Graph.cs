using System;
using System.Collections.Generic;
using System.Text;

namespace VagasCom.Domain.Models.Graphs
{
    public class Graph
    {
        internal IDictionary<string, Point> Points { get; private set; }

        public Graph()
        {
            Points = new Dictionary<string, Point>();
        }

        public void AddPoint(string name)
        {
            var point = new Point(name);
            Points.Add(name, point);
        }

        public void AddConnection(string fromNode, string toNode, int distance)
        {
            Points[fromNode].AddConnection(Points[toNode], distance);
            Points[toNode].AddConnection(Points[fromNode], distance);
        }
    }
}
