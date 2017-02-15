// Michael Koeppl
// BTree
//
// Node represents a node within the BTree. It may contain up to K values and
// therefore may have up to K+1 child references (K+1 because every value can
// have two children.

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class Node
{
    const int K = 4;

    public List<int> Values { get; set; }
    public List<Node> Children { get; set; }

    public int NumberOfElements {
        get
        {
            return Values.Count ;
        }
    }

    public bool IsFull {
        get
        {
            return Values.Count == K;
        }
    }

    public Node (int val)
    {
        Values = new List<int>(K);
        Add(val);
        Children = new List<Node>(K+1);
    }

    public Node(List<int> values)
    {
        Values = values;
        Children = new List<Node>(K+1);
    }

    public void Add(int val)
    {
        Values.Add(val);
        Values.Sort();
    }

    public int TakeMedian()
    {
        int medianIndex = (Values.Capacity-1)/2+1;
        Values.Remove(medianIndex);
        return Values[medianIndex];
    }

    override public String ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Values.Capacity; i++)
        {
            if (i == 0)
            {
                sb.Append("[");
            }
            string insert = (i < Values.Count) ? ""+Values[i] : " ";
            sb.Append($"{insert} ");
            sb.Append(i == Values.Capacity - 1 ? "]" : "| ");
        }

        for (int i = 0; i < Children.Count; i++)
        {
            if (Children[i] != null)
            {
                sb.Append(Children[i].ToString());
            }
        }
        return sb.Append("\n").ToString();
    }
}
