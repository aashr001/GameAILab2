class Examples {

   public static void Build(Graph graph, int g) {

      switch (g) {

         case 1:
            Example1(graph);
            break;

         case 2:
            Example2(graph);
            break;

         case 3:
            Example3(graph);
            break;

         default:
            Example0(graph);
            break;
      }
   }

   private static void AddEdge(Graph g, Node a, Node b, int cost) {
      g.AddEdge(a, b, cost);
      g.AddEdge(b, a, cost);
   }
   
   private static void AddEdge(Graph g, Node a, Node b) {
      AddEdge(g, a, b, AStar.Distance(a, b));
   }


   private static void Example0(Graph graph) {

      Node n0 = new Node(0, 0, 0);
      Node n1 = new Node(1, 1, 0);
      Node n2 = new Node(2, 2, 0);

      graph.AddNode(n0);
      graph.AddNode(n1);
      graph.AddNode(n2);

      graph.AddEdge(n0, n1, 1);
      graph.AddEdge(n1, n0, 2);
   }

   private static void Example1(Graph graph) {

      Node n0 = new Node(0, -1, 0);
      Node n1 = new Node(1, 0, -1);
      Node n2 = new Node(2, 0, 0);
      Node n3 = new Node(3, 1, 0);
      Node n4 = new Node(4, 0, 1);

      graph.AddNode(n0);
      graph.AddNode(n1);
      graph.AddNode(n2);
      graph.AddNode(n3);
      graph.AddNode(n4);

      AddEdge(graph, n0, n2, 5);
      AddEdge(graph, n1, n2, 3);
      AddEdge(graph, n2, n3, 2);
      AddEdge(graph, n2, n4, 7);
   }


   private static void Example2(Graph graph) {

      Node n0 = new Node(0, 0, 0);
      Node n1 = new Node(1, 2, 0);
      Node n2 = new Node(2, 3, 1);
      Node n3 = new Node(3, 1, 4);
      Node n4 = new Node(4, 4, 5);
      Node n5 = new Node(5, 5, 3);
      Node n6 = new Node(6, 1, 2);
      Node n7 = new Node(7, 0, 4);
      Node n8 = new Node(8, 2, 5);
      Node n9 = new Node(9, 2, 3);

      graph.AddNode(n0);
      graph.AddNode(n1);
      graph.AddNode(n2);
      graph.AddNode(n3);
      graph.AddNode(n4);
      graph.AddNode(n5);
      graph.AddNode(n6);
      graph.AddNode(n7);
      graph.AddNode(n8);
      graph.AddNode(n9);


      AddEdge(graph, n0, n1);
      AddEdge(graph, n0, n6);
      AddEdge(graph, n0, n7);

      AddEdge(graph, n1, n2);
      AddEdge(graph, n1, n6);

      AddEdge(graph, n3, n7);
      AddEdge(graph, n3, n8);
      AddEdge(graph, n3, n9);

      AddEdge(graph, n4, n5);
      AddEdge(graph, n4, n8);
      AddEdge(graph, n4, n9);

      AddEdge(graph, n5, n9);

      AddEdge(graph, n6, n7);
      AddEdge(graph, n6, n9, 8); // High cost edge
   }

   
   private static void Example3(Graph graph) {

      Node a = new Node(0, 0, 2);
      Node b = new Node(1, 2, 2);
      Node c = new Node(2, 2, 0);
      Node d = new Node(3, 4, 1);
      Node e = new Node(4, 2, 5);
      Node f = new Node(5, 4, 2);
      Node g = new Node(6, 6, 0);
      Node h = new Node(7, 5, 5);
      Node z = new Node(8, 7, 4);

      graph.AddNode(a);
      graph.AddNode(b);
      graph.AddNode(c);
      graph.AddNode(d);
      graph.AddNode(e);
      graph.AddNode(f);
      graph.AddNode(g);
      graph.AddNode(h);
      graph.AddNode(z);

      AddEdge(graph, a, b);
      AddEdge(graph, a, c);
      AddEdge(graph, a, e);

      AddEdge(graph, b, f);

      AddEdge(graph, c, d);
      AddEdge(graph, c, g);

      AddEdge(graph, d, f);
      AddEdge(graph, d, g);

      AddEdge(graph, e, f);
      AddEdge(graph, e, h);

      AddEdge(graph, f, z);
      AddEdge(graph, g, z);
      AddEdge(graph, h, z);
   }
}