using System.Collections.Generic;

// A simple priority queue
public class CostedNode { 
   public Node node;
   public int cost;

   public CostedNode(Node node, int cost) {
      this.node = node;
      this.cost = cost;
   }
}

public class PriorityQueue {

   private List<CostedNode> items = new List<CostedNode>();

   public void Enqueue(Node node, int cost) {
      items.Add(new CostedNode(node, cost));
   }

   public int Count {
      get {
         return items.Count;
      }
   }

   public Node Dequeue() {
      int minIdx = findMinIndex();
      if (minIdx < 0) {
         return null;
      }
      CostedNode item = items[minIdx];
      items.RemoveAt(minIdx);
      return item.node;
   }

   private int findMinIndex() {
      CostedNode min = null;
      int idx = -1;
      for (int i = 0; i < items.Count; i++) {
         if (min == null) {
            idx = i;
            min = items [i];
         } else if (items[i].cost <= min.cost) {
            idx = i;
            min = items [i];
         }
      }
      return idx;
   }
}
