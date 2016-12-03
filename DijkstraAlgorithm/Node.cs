using System;
using System.Collections.Generic;

namespace DijkstraAlgoirthm
{
	public class Node
	{
		public string Name { get; private set; }

		public Node PreviousNode { get; set; }

		public double DistanceFromSource { get; set; }

		public List<Path> NeighborPaths { get; private set; }

		public Node(string name)
		{
			NeighborPaths = new List<Path>();
			Name = name;
		}

		public void AddNeighbor(Node node, double distance) 
		{ 
			NeighborPaths.Add(new Path(node, distance));
		}

        public override string ToString()
        {
            return Name;
        }
    }
}
