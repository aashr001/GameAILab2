using System;

public class Node {

   public int Id;
   public double X;
   public double Y;

   public Node(int i) {
      Id = i;
   }

   public Node(int i, double x, double y) {
      Id = i;
      X = x;
      Y = y;
   }

   public override bool Equals(Object obj) {
      Node node = obj as Node; 
      return (node != null) && (Id == node.Id);
   }

   public override int GetHashCode() {
      return Id;      
   }

   public override string ToString() {
      return Id.ToString();
   }

   public void SetPosition(double x, double y) {
      this.X = x;
      this.Y = y;
   }

}