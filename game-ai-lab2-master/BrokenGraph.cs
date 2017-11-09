using System;
using System.Collections.Generic;

class BrokenGraph : Graph {
	
	public BrokenGraph() {}

	public void AddNode(Node a) {}

	public void AddEdge(Node a, Node b, int c) {}

	public List<Node> Nodes() {
		return new List<Node>();
	}

	public List<Node> Neighbours(Node a) {
		return new List<Node>();
	}     

	public int Cost(Node a, Node b) {
		return 1;
	}

	public void Write() {
		Console.WriteLine("You need to write a graph data structure.");
	}


}