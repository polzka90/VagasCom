using System.Collections.Generic;
using System.Linq;

namespace VagasCom.Domain.Models.Graphs
{
    internal class GraphSearch
    {
        internal IDictionary<string, double> FindAllRouteFromTheStart(Graph graph, string startingPoint)
        {
            BuildTheGraph(graph, startingPoint);
            return GetAllDistancesFromStart(graph);
        }

        private void BuildTheGraph(Graph graph, string startingPoint)
        {
            foreach (Point point in graph.Points.Values)
                point.DistanceFromStart = double.PositiveInfinity;
            graph.Points[startingPoint].DistanceFromStart = 0;

            bool finished = false;
            var queue = graph.Points.Values.ToList();
            while (!finished)
            {
                Point nextPoint = queue.OrderBy(n => n.DistanceFromStart).FirstOrDefault(n => !double.IsPositiveInfinity(n.DistanceFromStart));
                if (nextPoint != null)
                {
                    ProcessThePoint(nextPoint, queue);
                    queue.Remove(nextPoint);
                }
                else
                {
                    finished = true;
                }
            }
        }

        private void ProcessThePoint(Point point, List<Point> queue)
        {
            var pointConnections = point.Connections.Where(c => queue.Contains(c.TargetPoint));
            foreach (var connection in pointConnections)
            {
                double distance = point.DistanceFromStart + connection.Distance;
                if (distance < connection.TargetPoint.DistanceFromStart)
                    connection.TargetPoint.DistanceFromStart = distance;
            }
        }

        private IDictionary<string, double> GetAllDistancesFromStart(Graph graph)
        {
            return graph.Points.ToDictionary(n => n.Key, n => n.Value.DistanceFromStart);
        }
    }
}
