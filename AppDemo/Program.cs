using DijkstraAlgorithm;
using DijkstraAlgorithm.Implementation;
using DijkstraAlgorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test DijktraAlgorithm!");

            //Define nodes and their paths to neighbors
            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");
            var nodeD = new Node("D");
            var nodeE = new Node("E");
            var nodeF = new Node("F");
            //var nodeG = new Node("G");
            //var nodeH = new Node("H");
            //var nodeI = new Node("I");
            //var nodeJ = new Node("J");
            
            //Define neighbor (Path) to other nodes
            nodeA.AddNeighbor(nodeB, 6);
            nodeA.AddNeighbor(nodeD, 1);
            nodeA.AddNeighbor(nodeF, 20);

            nodeB.AddNeighbor(nodeD, 2);
            nodeB.AddNeighbor(nodeE, 2);
            nodeB.AddNeighbor(nodeC, 5);

            nodeC.AddNeighbor(nodeF, 2);

            nodeD.AddNeighbor(nodeE, 1);
            nodeD.AddNeighbor(nodeB, 4);
            nodeD.AddNeighbor(nodeF, 21);

            nodeE.AddNeighbor(nodeC, 5);

            var nodes = new List<Node>
            {
                nodeA, nodeB, nodeC, nodeD, nodeE,
                nodeF, //nodeG, nodeH, nodeI, nodeJ
		    };

            var graph = new Graph(nodes);

            var shortestPathAlgorithm = new PriorityDijkstraFinder(graph);
            var routes = shortestPathAlgorithm.FindShortestPathBetween("A", "F");
            Console.WriteLine("\nFor shortest path between A and F");
            Console.WriteLine(string.Format("Shortest route: {0}", string.Join(" => ", routes)));

            var allRoutes = shortestPathAlgorithm.FindShortestPathToAllDestination("A");
            Console.WriteLine("\nFor all distances from A");
            foreach (var route in allRoutes)
            {
                Console.WriteLine(string.Format("Shortest route From A To {0}: {1}", route.Key, string.Join(" => ", route.Value)));
            }
        }
    }
}
