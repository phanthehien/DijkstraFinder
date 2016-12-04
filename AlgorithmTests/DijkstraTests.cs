using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DijkstraAlgorithm.Model;
using System.Collections.Generic;
using DijkstraAlgorithm.Implementation;

namespace AlgorithmTests
{
    [TestClass]
    public class DijkstraTests
    {
        [TestMethod]
        public void From_A_to_F_should_be_ADECF()
        {
            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");
            var nodeD = new Node("D");
            var nodeE = new Node("E");
            var nodeF = new Node("F");

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
                nodeA, nodeB, nodeC,
                nodeD, nodeE, nodeF, 
		    };

            var graph = new Graph(nodes);

            var shortestPathAlgorithm = new PriorityDijkstraFinder(graph);
            var routes = shortestPathAlgorithm.FindShortestPathBetween("A", "F");
            Assert.AreEqual(routes.Count, 5);
            Assert.AreEqual(routes[0].Name, "A");
            Assert.AreEqual(routes[1].Name, "D");
            Assert.AreEqual(routes[2].Name, "E");
            Assert.AreEqual(routes[3].Name, "C");
            Assert.AreEqual(routes[4].Name, "F");

        }

        [TestMethod]
        public void From_A_to_E_should_be_ADE()
        {
            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");
            var nodeD = new Node("D");
            var nodeE = new Node("E");
            var nodeF = new Node("F");

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
                nodeA, nodeB, nodeC,
                nodeD, nodeE, nodeF,
            };

            var graph = new Graph(nodes);

            var shortestPathAlgorithm = new PriorityDijkstraFinder(graph);
            var routes = shortestPathAlgorithm.FindShortestPathBetween("A", "E");
            Assert.AreEqual(routes.Count, 3);
            Assert.AreEqual(routes[0].Name, "A");
            Assert.AreEqual(routes[1].Name, "D");
            Assert.AreEqual(routes[2].Name, "E");

        }

        [TestMethod]
        public void From_A_to_B_should_be_ADB()
        {
            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");
            var nodeD = new Node("D");
            var nodeE = new Node("E");
            var nodeF = new Node("F");

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
                nodeA, nodeB, nodeC,
                nodeD, nodeE, nodeF,
            };

            var graph = new Graph(nodes);

            var shortestPathAlgorithm = new PriorityDijkstraFinder(graph);
            var routes = shortestPathAlgorithm.FindShortestPathBetween("A", "B");
            Assert.AreEqual(routes.Count, 3);
            Assert.AreEqual(routes[0].Name, "A");
            Assert.AreEqual(routes[1].Name, "D");
            Assert.AreEqual(routes[2].Name, "B");

        }
    }
}
