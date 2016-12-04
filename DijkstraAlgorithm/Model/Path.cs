using System;
namespace DijkstraAlgorithm.Model
{
    public class Path
	{
		public Node Destination { get; private set; }

		public double Distance { get; set; }

		public Path(Node destination, double distance) 
		{
			Destination = destination;
			Distance = distance;
		}
	}
}
