using System.Collections.Generic;

interface Pathfinder {

   void SetGraph(Graph g);
   List<Node> FindPath (Node a, Node b);
   
}