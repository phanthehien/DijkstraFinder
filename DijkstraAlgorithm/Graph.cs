using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
	public class Graph
	{
		public Dictionary<string, Node> Nodes { get; private set; }

		public Graph(List<Node> nodes)
		{
			Nodes = new Dictionary<string, Node>();

			for (int i = 0; i < nodes.Count; i++) 
			{
				Nodes.Add(nodes[i].Name, nodes[i]);
			}
		}
	}
}
