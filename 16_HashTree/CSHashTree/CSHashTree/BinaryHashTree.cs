using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CSHashTree
{
	public class BinaryHashTree<T>
	{
		int nodeID;

		public void BulkCreate(List<T> dataList)
		{
			List<Node> nodeList = makeNodes(dataList);
			Node rootNode = generateTree(nodeList);
			Console.WriteLine(rootNode.ToString());
		}

		List<Node> makeNodes(List<T> dataList)
		{
			List<Node> nodeList = new List<Node>();
			dataList.ForEach((T t) => nodeList.Add(new Node(nodeID++, getHash(t.ToString()))));

			return nodeList;
		}

		Node generateTree(List<Node> nodeList)
		{
			if (nodeList.Count == 1)
			{
				return nodeList[0];
			}

			List<Node> nextLevelNodeList = new List<Node>();

			for (int i = 0; i < nodeList.Count; i += 2)
			{
				Node leftNode;
				Node rightNode;

				leftNode = nodeList[i];

				if (i == nodeList.Count - 1) // We have an odd number of elements in the list and have reached the last element
				{
					rightNode = leftNode;
				}
				else
				{
					rightNode = nodeList[i + 1];
				}

				Node combinationNode = new Node(nodeID++, getHash(leftNode.Hash + rightNode.Hash), leftNode, rightNode);

				nextLevelNodeList.Add(combinationNode);
			}

			return generateTree(nextLevelNodeList);
		}

		string getHash(string text)
		{
			SHA256 sha = SHA256.Create();
			byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
			return Encoding.UTF8.GetString(hash);
		}
	}
}
