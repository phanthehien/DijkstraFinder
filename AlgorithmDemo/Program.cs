using System;
using System.Collections.Generic;
using DijkstraAlgoirthm;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Test DijktraAlgorithm!");

		var nodeA = new Node("A");
		var nodeB = new Node("B");
		var nodeC = new Node("C");
		var nodeD = new Node("D");
		var nodeE = new Node("E");
		//var nodeF = new Node("F");
		//var nodeG = new Node("G");
		//var nodeH = new Node("H");
		//var nodeI = new Node("I");
		//var nodeJ = new Node("J");

		nodeA.AddNeighbor(nodeB, 6);
		nodeA.AddNeighbor(nodeD, 1);

		nodeB.AddNeighbor(nodeD, 2);
		nodeB.AddNeighbor(nodeE, 2);
		nodeB.AddNeighbor(nodeC, 5);

		nodeD.AddNeighbor(nodeE, 1);

		nodeE.AddNeighbor(nodeC, 5);


		var nodes = new List<Node>
		{
			nodeA, nodeB, nodeC, nodeD, nodeE, 
			//nodeF, nodeG, nodeH, nodeI, nodeJ
		};

		var graph = new Graph(nodes);
		var shortestPathAlgorithm = new Dijkstra(graph);
		var routes = shortestPathAlgorithm.FindhortestPath("A", "C");

		for (int i = routes.Count - 1; i >= 0; i--)
		{
			Console.WriteLine(routes[i].Name);
		}	
	}
}
