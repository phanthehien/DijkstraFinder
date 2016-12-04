using DijkstraAlgorithm.Common;
using DijkstraAlgorithm.Interface;
using DijkstraAlgorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm.Implementation
{
    public class PriorityDijkstraFinder : IShortestDistanceFinder
    {
        private string _fromNode;
        private Graph _graph;
        private PriorityQueue<Node> _nodesQueue;

        public PriorityDijkstraFinder(Graph graph)
        {
            _graph = graph;
        }

        public List<Node> FindShortestPathBetween(string fromNode, string toNode)
        {
            InitGraph(fromNode);
            return ProcessDijkstraForShortestPathsTo(toNode);
        }

        public Dictionary<string, List<Node>> FindShortestPathToAllDestination(string fromNode)
        {
            InitGraph(fromNode);
            return ProcessDijkstraForShortestPathsToAllNodes();
        }

        private List<Node> ProcessDijkstraForShortestPathsTo(string toNode)
        {
            var results = new List<Node>();
            while (_nodesQueue.Count() != 0)
            {
                var node = _nodesQueue.Dequeue();

                foreach (var path in node.NeighborPaths)
                {
                    if (path.Distance < double.PositiveInfinity && node.DistanceFromSource + path.Distance < path.Destination.DistanceFromSource) // don't let wrap-around negatives slip by 
                    {
                        var newDestination = path.Destination;
                        newDestination.DistanceFromSource = node.DistanceFromSource + path.Distance;
                        newDestination.PreviousNode = node;
                        _nodesQueue.Enqueue(newDestination);
                    }
                }
            }

            results = CalculateShortestPath(_graph.Nodes[toNode]);

            return results;
        }

        private Dictionary<string, List<Node>> ProcessDijkstraForShortestPathsToAllNodes()
        {
            //condition for the while loop and make sure we visit all the vertex in the Graph.
            InitStartingNodeDistance(_graph.Nodes[_fromNode]);
            var results = new Dictionary<string, List<Node>>();

            while (_nodesQueue.Count() != 0)
            {
                var node = _nodesQueue.Dequeue();

                foreach (var path in node.NeighborPaths)
                {
                    if (path.Distance < double.PositiveInfinity && node.DistanceFromSource + path.Distance < path.Destination.DistanceFromSource) // don't let wrap-around negatives slip by 
                    {
                        var newDestination = path.Destination;
                        newDestination.DistanceFromSource = node.DistanceFromSource + path.Distance;
                        newDestination.PreviousNode = node;
                        _nodesQueue.Enqueue(newDestination);
                    }
                }
            }

            foreach (var node in _graph.Nodes)
            {
                results.Add(node.Key, CalculateShortestPath(node.Value));
            }
            return results;
        }

        private List<Node> CalculateShortestPath(Node toPath)
        {
            var nodes = new List<Node>();

            while (toPath.PreviousNode != null)
            {
                nodes.Insert(0, toPath);
                toPath = toPath.PreviousNode;
            }

            nodes.Insert(0, toPath);

            return nodes;
        }

        private void InitGraph(string fromNode)
        {
            _fromNode = fromNode;
            foreach (var node in _graph.Nodes.Values)
            {
                node.DistanceFromSource = double.PositiveInfinity;
            }

            _graph.Nodes[fromNode].DistanceFromSource = 0;
            _nodesQueue = new PriorityQueue<Node>();
        }

        private  void InitStartingNodeDistance(Node currentNode)
        {
            var neighborPaths = currentNode.NeighborPaths.Where(a => _graph.Nodes.Values.Contains(a.Destination));

            foreach (var neighborPath in neighborPaths)
            { 
                neighborPath.Destination.DistanceFromSource = neighborPath.Distance;
                neighborPath.Destination.PreviousNode = currentNode;
            }

            foreach (var node in _graph.Nodes.Values)
            {
                _nodesQueue.Enqueue(node);
            }
        }
        
    }
}
