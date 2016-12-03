using System;
using System.Collections.Generic;

namespace DijkstraAlgoirthm
{
	public class Dijkstra
	{
		public List<Vertex> Vertices;
		public List<Edge> edges;

		public Dijkstra()
		{
			Vertices = new List<Vertex>();
			edges = new List<Edge>();
		}

		public void Execute()
		{
			while (Vertices.Count > 0)
			{

				Vertex smallest = ExtractSmallest();
				List<Vertex> adjacentVertices = AdjacentRemainingVertices(smallest);

				int size = adjacentVertices.Count;
				for (int i = 0; i < size; ++i)
				{
					Vertex adjacent = adjacentVertices.ElementAt(i);
					float distance = Distance(smallest, adjacent) + smallest.distanceFromStart;
					if (distance < adjacent.distanceFromStart)
					{
						adjacent.distanceFromStart = distance;
						adjacent.previous = smallest;
					}
				}
			}
		}
	}
}



}
