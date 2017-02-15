using System;

namespace _BTreeCS
{
    class NodeEntry
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public NodeEntry(int val)
        {
            Value = val;
        }
    }
}
