using System;
using System.Collections.Generic;
using System.Text;

namespace VagasCom.Domain.Models.Graphs
{
    internal class Point
    {
        IList<PointConnection> _pointsConnections;

        internal string Name { get; private set; }

        internal double DistanceFromStart { get; set; }

        internal IEnumerable<PointConnection> Connections
        {
            get { return _pointsConnections; }
        }

        internal Point(string name)
        {
            Name = name;
            _pointsConnections = new List<PointConnection>();
        }

        internal void AddConnection(Point targetNode, double distance)
        {
            _pointsConnections.Add(new PointConnection(targetNode, distance));
            
        }
    }
}
