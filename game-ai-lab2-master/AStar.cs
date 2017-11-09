using System;
using System.Collections.Generic;

/*
 * An A* Pathfinder
 */
public class AStar : Pathfinder {

   private Graph                    graph;
   private PriorityQueue            frontier;
   private Dictionary<Node, Node>   previous;
   private Dictionary<Node, int>    cost;
   
   public void SetGraph(Graph g) {
      graph = g;
   }

   public List<Node> FindPath(Node start, Node goal) {

      Console.WriteLine("\nLooking for path from " + start + " to " + goal);

      // Set up data structures
      Initialise(start);

      // Search graph for goal
      if (Search(goal)) {
         return Path(start, goal); // If found, return path
      } else {
         return null; // Otherwise return nothing
      }
   }

   // Setup data structures
   private void Initialise(Node start) {
      // The frontier
      frontier = new PriorityQueue();
      frontier.Enqueue(start, 0);

      // Record of how we got to each node
      previous = new Dictionary<Node, Node>();
      previous[start] = null; // start has no previous node (we started there!)

      // Record of least known cost from start->node
      cost = new Dictionary<Node, int>();
      cost[start] = 0; // start->start costs nothing 
   }

   // A* search: returns true if path found
   private bool Search(Node goal) {

      bool found = false; // Did we find the goal yet?

      while (frontier.Count != 0) {
         // Select a current node from frontier
         Node current = (Node) frontier.Dequeue();
         Console.WriteLine("Current node: " + current);

         // Is this the goal?
         if (current.Equals(goal)) {
            found = true;
            break; // Stop at goal
         }

         // Expand current node
         List<Node> neighbours = graph.Neighbours(current);

         foreach (Node next in neighbours) {
            // Find cost to next node
            int nextCost = cost[current] + graph.Cost(current, next); 

            // Have we been here before?
            bool visitedBefore = cost.ContainsKey(next);

            // New node OR cheaper path to known node
            if (!visitedBefore ||  nextCost < cost[next]) {
               // Add it to the frontier
               frontier.Enqueue(next, nextCost + Distance(next, goal));
               // Record how we got to next and it's cost
               previous[next] = current;
               cost[next] = nextCost;
            }
         }
      }

      return found;
   }

   // Straight line distance between nodes
   public static int Distance(Node a, Node b) {
      double x2 = Math.Pow(a.X - b.X, 2);
      double y2 = Math.Pow(a.Y - b.Y, 2);

      return (int) Math.Ceiling(Math.Sqrt(x2 + y2));
   }

   // Reconstruct the path start->goal from previous data structure
   private List<Node> Path(Node start, Node goal) {

      List<Node> path = new List<Node>();
      Node current = goal;

      while (current != start) {
         path.Add(current);
         current = previous[current];
         if (path.Contains(current)) {
            Console.WriteLine("Error: path contains a loop");
            return null;
         }
      }
      path.Add(start);
      path.Reverse();

      return path;
   }

}