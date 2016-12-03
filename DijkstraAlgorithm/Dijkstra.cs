using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraAlgoirthm
{
	public class Dijkstra
	{
		private Graph _graph;
		private string _fromNode;
		private string _toNode;

		public Dijkstra(Graph graph)
		{
			_graph = graph;

		}

		public List<Node> FindhortestPath(string fromNode, string toNode)
		{
			_fromNode = fromNode;
			_toNode = toNode;

			InitGraph();

			return ProcessDijkstra();
		}

		private List<Node> ProcessDijkstra()
		{
			//condition for the while loop and make sure we visit all the vertex in the Graph.
			bool isFinish = false;
			var checkingNodes = _graph.Nodes;
			var results = new List<Node>();

			while (!isFinish)
			{
				var currentNode = GetNearestNode();
				checkingNodes.Remove(currentNode.Name);

				//Calculate distance from start for each vertex in unvisited list.
				UpdateVertexDistance(currentNode, checkingNodes.Values.ToList());

				//Get the vertex's nearest (smallest) distance from start as a path of nearest path. 
				var smallest = checkingNodes.Where(i => i.Value != currentNode)
											.OrderBy(i => i.Value.DistanceFromSource)
											.First();

				if (_toNode == smallest.Key)
				{
					isFinish = true;
					//calculate the shortest path from the Graph
					results = CalculateShortestPath(smallest.Value);
				}
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

		private void InitGraph()
		{
			foreach (var node in _graph.Nodes.Values)
			{
				node.DistanceFromSource = double.PositiveInfinity;
			}

			_graph.Nodes[_fromNode].DistanceFromSource = 0;
		}

		private void UpdateVertexDistance(Node currentNode, List<Node> vertecies)
		{
			var neighbors = currentNode.NeighborPaths.Where(a => vertecies.Contains(a.Destination));

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

		private Node GetNearestNode()
		{
			return _graph.Nodes.OrderBy(i => i.Value.DistanceFromSource)
						 .FirstOrDefault(i => !double.IsInfinity(i.Value.DistanceFromSource))
						 .Value;

		}

	}
}
