using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class Pathfinding : MonoBehaviour {

	Grid grid;
	static Pathfinding instance;

	void Awake() {
//		requestManager = GetComponent<PathRequestManager> ();
		grid = GetComponent<Grid> ();
		instance = this;
	}

	public static Vector2[] RequestPath(Vector2 from, Vector2 to) {
		return instance.FindPath(from, to);
	}

	Vector2[] FindPath(Vector2 from, Vector2 to){
		Stopwatch sw = new Stopwatch ();
		sw.Start ();

		Vector2[] waypoints = new Vector2[0];
		bool pathSuccess = false;

		_Node startNode = grid.NodeFromWorldPoint (from);
		_Node targetNode = grid.NodeFromWorldPoint (to);

		Heap<_Node> openSet = new Heap<_Node>(grid.MaxSize);
		HashSet<_Node> closeSet = new HashSet<_Node> ();
		openSet.Add (startNode);

		while (openSet.Count > 0) {
			_Node currentNode = openSet.RemoveFirst();
			closeSet.Add (currentNode);

			if (currentNode == targetNode) {
				sw.Stop ();
				print ("Path found: " + sw.ElapsedMilliseconds + " ms");
				pathSuccess = true;
				break;
			}
	
			foreach (_Node neighbour in grid.GetNeighbours(currentNode)) {
				if (!neighbour.walkable || closeSet.Contains (neighbour)) {
					continue;
				}

				int newMovementCostToNeighbour = currentNode.gCost + GetDistance (currentNode, neighbour);
				if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains (neighbour)) {
					neighbour.gCost = newMovementCostToNeighbour;
					neighbour.hCost = GetDistance (neighbour, targetNode);
					neighbour.parent = currentNode;
				
					if (!openSet.Contains (neighbour))
						openSet.Add (neighbour);
				}
			}
		}

		if (pathSuccess) {
			waypoints = RetracePath(startNode,targetNode);
		}

		return waypoints;
	}

	Vector2[] RetracePath (_Node startNode, _Node endNode) {
		List<_Node> path = new List<_Node> ();
		_Node currentNode = endNode;

		while (currentNode != startNode) {
			path.Add (currentNode);
			currentNode = currentNode.parent;
		}
		Vector2[] waypoints = SimplifyPath(path);
		Array.Reverse(waypoints);
		return waypoints;
	}

	Vector2[] SimplifyPath(List<_Node> path) {
		List<Vector2> waypoints = new List<Vector2>();
	
		for (int i = 0; i < path.Count; i ++) {
			waypoints.Add (path[i].worldPosition);
		}
		return waypoints.ToArray();
	}

	int GetDistance(_Node nodeA, _Node nodeB){
		int dstX = Mathf.Abs (nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs (nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);

	}

}
