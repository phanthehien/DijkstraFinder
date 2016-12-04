using DijkstraAlgorithm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm.Interface
{
    public interface IShortestDistanceFinder 
    {
        List<Node> FindShortestPathBetween(string fromNode, string toNode);

        Dictionary<string, List<Node>> FindShortestPathToAllDestination(string fromNode);
    }
}
