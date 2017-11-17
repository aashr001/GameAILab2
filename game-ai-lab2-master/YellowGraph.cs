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

    public void AddNode(Node a)
    {
        nodes.Add(a);
    }

    public void AddEdge(Node a, Node b, int c)
    {
        if (c > 0)
        {
            int i = a.Id;
            int j = b.Id;
            Console.Write(i + "and" + j);
            adjMatrix[i,j] = c;
        }

    }

    public List<Node> Nodes()
    {
        return nodes;
    }

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

    public int Cost(Node a, Node b)
    {
        int i = a.Id;
        int j = b.Id;

        return adjMatrix[i, j];

     
    }


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