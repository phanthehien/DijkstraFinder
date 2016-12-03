using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraAlgoirthm
{
	public class Dijkstra
	{
		private Graph _graph;

		public Dijkstra(Graph graph)
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
            //condition for the while loop and make sure we visit all the vertex in the Graph.
            bool isFinish = false;
            var checkingNodes = new Dictionary<string, Node>(_graph.Nodes);
            var results = new List<Node>();

            while (!isFinish)
            {
                //get the nearest node
                var currentNode = GetNearestNode(checkingNodes);
                checkingNodes.Remove(currentNode.Name);

                //Update the distance from the currentNode to neighbor nodes
                UpdateNeighborShortestDistanceFromCurrentNode(currentNode, checkingNodes.Values.ToList());

                //Get the vertex's nearest (smallest) distance from start as a path of nearest path. 
                var smallest = checkingNodes.Where(i => i.Value != currentNode)
                                            .OrderBy(i => i.Value.DistanceFromSource)
                                            .First();

                if (toNode == smallest.Key)
                {
                    isFinish = true;
                    //calculate the shortest path from the Graph
                    results = CalculateShortestPath(smallest.Value);
                }
            }

            return results;
        }

        private Dictionary<string, List<Node>> ProcessDijkstraForShortestPathsToAllNodes()
		{
			//condition for the while loop and make sure we visit all the vertex in the Graph.
			bool isFinish = false;
			var checkingNodes = new Dictionary<string, Node>(_graph.Nodes);
			var results = new Dictionary<string, List<Node>>();

			while (!isFinish)
			{
                //get the nearest node
				var currentNode = GetNearestNode(checkingNodes);
				checkingNodes.Remove(currentNode.Name);

                //Update the distance from the currentNode to neighbor nodes
                UpdateNeighborShortestDistanceFromCurrentNode(currentNode, checkingNodes.Values.ToList());
                isFinish = checkingNodes.Count == 0;
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
			foreach (var node in _graph.Nodes.Values)
			{
				node.DistanceFromSource = double.PositiveInfinity;
			}

			_graph.Nodes[fromNode].DistanceFromSource = 0;
		}

		private void UpdateNeighborShortestDistanceFromCurrentNode(Node currentNode, List<Node> remainingNodes)
		{
			var neighbors = currentNode.NeighborPaths.Where(a => remainingNodes.Contains(a.Destination));

			foreach (var neighbor in neighbors)
			{
				double distance = currentNode.DistanceFromSource + neighbor.Distance;
				if (distance < neighbor.Destination.DistanceFromSource)
				{
					neighbor.Destination.DistanceFromSource = distance;
					neighbor.Destination.PreviousNode = currentNode;
				}
			}
		}

		private Node GetNearestNode(Dictionary<string, Node> nodes)
		{
			return nodes.OrderBy(i => i.Value.DistanceFromSource)
						 .FirstOrDefault(i => !double.IsInfinity(i.Value.DistanceFromSource))
						 .Value;
		}

	}
}
