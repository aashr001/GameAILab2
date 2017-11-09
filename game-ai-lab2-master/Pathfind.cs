using System;
using System.Collections.Generic;

/*
 * Builds graphs and finds paths via Main method:
 * - 1st argument selects the graph to create. 
 * - Optionally, tries to find path from 2nd to 3rd argument.
 *
 * For example...
 * 
 * mono Pathfind.exe 2
 * (Creates graph #2)
 * 
 * mono Pathfind.exe 2 8 3
 * (Creates graph #2 and requests a path from node 8 to node 3)
 */
class Pathfind {
   
   // Main method
   public static void Main(string[] args) {

      int g, a, b;

      if (args.Length < 1) {
         // ERROR: not enough arguments
         Console.WriteLine("Error: no arguments provided");
      
      } else {

         // Parse first argument
         if (!int.TryParse(args[0], out g)) {
            Console.WriteLine(args[0] + " is not an integer");

         } else {

            // First argument selects the graph
            Graph graph = new BrokenGraph(); // ***** CHANGE TO YOUR GRAPH CLASS *****
            Examples.Build(graph, g);
            graph.Write();

            // If more arguments, then pathfind
            if (args.Length > 2) {
               
               // Parse second argument
               if (!int.TryParse(args[1], out a)) {
                  Console.WriteLine(args[1] + " is not an integer");

               // Parse third argument
               } else if (!int.TryParse(args[2], out b)) {
                  Console.WriteLine(args[2] + " is not an integer");

               } else {
                  FindPath(graph, a, b);
               }
            }
         }
      }
   }

   // Find path a->b on graph g
   private static void FindPath(Graph g, int a, int b) {

         Node start = new Node(a);
         Node goal = new Node(b);
         
         Pathfinder finder = new AStar(); // ***** CHANGE TO YOUR SEARCH CLASS *****
         finder.SetGraph(g);
         List<Node> path = finder.FindPath(start, goal);
         if (path != null) {
            WritePath(path);
         } else {
            Console.WriteLine("No path found.");
         }
   }

   // Write path nodes to console
   private static void WritePath(List<Node> path) {

      Console.Write("Path: ");
      bool first = true;
      foreach (Node node in path) {
         if (!first) Console.Write(", ");
         Console.Write(node.ToString());
         first = false;
      }
      Console.Write("\n");
   }
}



