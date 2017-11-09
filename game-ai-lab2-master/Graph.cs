using System.Collections.Generic;

public interface Graph {

	// Try to add the node a.
	void AddNode(Node a);

	// Try to add the edge a-b with cost c.
	// If it already exists, update the cost.
	// Do nothing if cost is non-positive.
	void AddEdge(Node a, Node b, int c);

	// Return all the nodes in this graph.
	List<Node> Nodes();

	// Return all the neighbours on node a.
	// i.e. nodes connected to a by an edge.
	List<Node> Neighbours(Node a);        

	// Return cost of edge a-b (-1 if no such edge)
	int Cost(Node a, Node b);

	// Write a description of the graph to System.Console
	void Write();
}