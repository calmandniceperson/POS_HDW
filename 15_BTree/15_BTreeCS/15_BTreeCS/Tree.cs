// Michael Koeppl
// BTree
//
// BTree implements several methods for inserting, searching, traversing,
// deleting tree nodes.

using System;
using System.Collections.Generic;

class BTree
{
    static BTree instance = null;

    public static BTree Get()
    {
        if (instance == null)
        {
            instance = new BTree();
        }
        return instance;
    }

    private Node rootNode;

    public void Insert(int val)
    {
        insertRec(val, ref rootNode);
    }

    private void insertRec(int val, ref Node currentNode)
    {
        if (currentNode == null)
        {
            rootNode = new Node(val);
        }
        else if (currentNode.IsFull)
        {
            Node tempNode = currentNode;
            currentNode = new Node(tempNode.TakeMedian());
            tempNode.Add(val);

            List<int> leftVals = new List<int>(tempNode.Values.Capacity);
            List<int> rightVals = new List<int>(tempNode.Values.Capacity);
            for (int i = 0; i < tempNode.Values.Count; i++)
            {
                if (i <= (tempNode.Values.Capacity-1)/2)
                {
                    leftVals.Add(tempNode.Values[i]);
                }
                else
                {
                    rightVals.Add(tempNode.Values[i]);
                }
            }

            currentNode.Children[0] = new Node(leftVals);
            currentNode.Children[1] = new Node(rightVals);
        }
        else
        {
            currentNode.Add(val);
        }
        Console.WriteLine(currentNode.ToString());
    }
}
