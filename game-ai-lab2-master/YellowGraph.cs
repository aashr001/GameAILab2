using System;
using System.Collections.Generic;

class YellowGraph : Graph {
   
   // List of nodes in this graph
   private List<Node> nodes;

   // An adjacency matrix, recording edges between nodes
   // Edge FROM node i to node j is recorded in adjMatrix[i,j]
   // Each int entry records the edge cost (> -1)
   // If entry is 0 there is no edge 
   private int[,] adjMatrix;

   public YellowGraph() {
      nodes = new List<Node>();
      adjMatrix = new int[0,0];
   }

    // Try to add the node a.
    public void AddNode(Node a)
    {
        nodes.Add(a);
    }

    // Try to add the edge a-b with cost c.
    // If it already exists, update the cost.
    // Do nothing if cost is non-positive.
    public void AddEdge(Node a, Node b, int c)
    {
        int value = adjMatrix.GetLength(0);
        if (value < nodes.Count)
        {
            adjMatrix = new int[nodes.Count, nodes.Count];
        }
        if (c > 0)
        {
            int i = a.Id;
            int j = b.Id;
            adjMatrix[i,j] = c;
        }

    }

    // Return all the nodes in this graph.
    public List<Node> Nodes()
    {
        return nodes;
    }

    // Return all the neighbours on node a.
    // i.e. nodes connected to a by an edge.
    public List<Node> Neighbours(Node a)
    {
        List<Node> NeigbhourList = new List<Node>();
        int i = a.Id;
        for (int j = 0; j < nodes.Count; j++)
        {
            if (adjMatrix[i, j] > 0)
            {
                Node node = nodes.Find(item => item.Id == j);
                NeigbhourList.Add(node);
            }

        }
        return NeigbhourList;
    }

    // Return cost of edge a-b (-1 if no such edge)
    public int Cost(Node a, Node b)
    {
        int i = a.Id;
        int j = b.Id;

        return adjMatrix[i, j];

    }

    // Write a description of the graph to System.Console
    public void Write() {
      Console.WriteLine("YellowGraph");

      for (int i = 0; i < nodes.Count; i++) {
         Console.Write(nodes[i] + ": ");

         bool first = true;
         for (int j = 0; j < nodes.Count; j++) {
            if (adjMatrix[i,j] > 0) {
               if (!first) Console.Write(", ");
               Console.Write(nodes[j] + "(" + adjMatrix[i,j] + ")");
               first = false;
            }
         }

         Console.Write("\n");
      }
   }
}

//just testing to see if GitHub works