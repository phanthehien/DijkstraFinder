using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> _bTree;

        public PriorityQueue()
        {
            _bTree = new List<T>();
        }

        public void Enqueue(T node)
        {
            _bTree.Add(node);
            int childIndex = _bTree.Count - 1; // child index; start at end

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2; // parent index
                if (_bTree[childIndex].CompareTo(_bTree[parentIndex]) >= 0)
                {
                    break; // child item is larger than (or equal) parent so we're done
                }

                //swap position between child and parent
                T tmp = _bTree[childIndex];
                _bTree[childIndex] = _bTree[parentIndex];
                _bTree[parentIndex] = tmp;

                //move up 
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            // assumes pq is not empty; up to calling code
            int lastIndex = _bTree.Count - 1; // last index (before removal)
            T frontItem = _bTree[0];   // fetch the front
            _bTree[0] = _bTree[lastIndex];
            _bTree.RemoveAt(lastIndex);

            //Start arrange binary tree again after dequeue
            --lastIndex; // last index (after removal)
            int parentIndex = 0; // parent index. start at front of pq
            while (true)
            {
                //1. Compare between left and right, which one is smaller, keep the smaller position
                int childIndex = parentIndex * 2 + 1; // left child index of parent

                if (childIndex > lastIndex)
                {
                    break;  // no children so done
                }

                int rightIndex = childIndex + 1;     // right child
                if (rightIndex <= lastIndex && _bTree[rightIndex].CompareTo(_bTree[childIndex]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                {
                    childIndex = rightIndex;
                }

                //check whether current position is bigger than parent position
                if (_bTree[parentIndex].CompareTo(_bTree[childIndex]) <= 0)
                {
                    break; // parent is smaller than (or equal to) smallest child so done
                }

                //2. swap parent and child (left or right has been known)
                T tmp = _bTree[parentIndex];
                _bTree[parentIndex] = _bTree[childIndex];
                _bTree[childIndex] = tmp;

                parentIndex = childIndex;
            }

            return frontItem;
        }

        public T Peek()
        {
            T frontItem = _bTree[0];
            return frontItem;
        }

        public int Count()
        {
            return _bTree.Count;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < _bTree.Count; ++i)
            {
                builder.AppendFormat("{0} ", _bTree[i].ToString());
            }

            builder.AppendFormat("count = {0}", _bTree.Count);
            return builder.ToString();
        }

        //public bool IsConsistent()
        //{
        //    // is the heap property true for all data?
        //    if (_data.Count == 0) return true;

        //    int li = _data.Count - 1; // last index
        //    for (int pi = 0; pi < _data.Count; ++pi) // each parent index
        //    {
        //        int lci = 2 * pi + 1; // left child index
        //        int rci = 2 * pi + 2; // right child index

        //        if (lci <= li && _data[pi].CompareTo(_data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
        //        if (rci <= li && _data[pi].CompareTo(_data[rci]) > 0) return false; // check the right child too.
        //    }
        //    return true; // passed all checks
        //} // IsConsistent
    }
}

