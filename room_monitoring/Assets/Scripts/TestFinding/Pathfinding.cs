using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class Pathfinding : MonoBehaviour {

	public Transform seeker, target;
	public List<_Node> finalPath;
	public float Timer = 0.000000001f;

	Grid grid;

	void Awake() {
//		requestManager = GetComponent<PathRequestManager> ();
		grid = GetComponent<Grid> ();
	}
		
	void Update() {
		if (Input.GetKeyDown(KeyCode.D)) {
			FindPath (seeker.position, target.position);
			foreach (_Node n in finalPath) {
				print ("x: " + n.worldPosition.x + "y: " + n.worldPosition.y);
			}
		}
	}

//	public void StartFindPath(Vector3 startPos, Vector3 targetPos) {
//		StartCoroutine(FindPath(startPos, targetPos));
//	}

	void FindPath(Vector2 from, Vector2 to){
		Stopwatch sw = new Stopwatch ();
		sw.Start ();

//		Vector2[] waypoints = new Vector2[0];
//		bool pathSuccess = false;

		_Node startNode = grid.NodeFromWorldPoint (from);
		_Node targetNode = grid.NodeFromWorldPoint (to);

		Heap<_Node> openSet = new Heap<_Node>(grid.MaxSize);
		HashSet<_Node> closeSet = new HashSet<_Node> ();
		openSet.Add (startNode);

		while (openSet.Count > 0) {
			_Node currentNode = openSet.RemoveFirst();

				//using list in the first implement but change to using heap for optimization
				//			for (int i = 0; i < openSet.Count; i++) {
				//				if (openSet [i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost) {
				//					currentNode = openSet [i];
				//				}
				//			}
				//
				//			openSet.Remove (currentNode);
			closeSet.Add (currentNode);

			if (currentNode == targetNode) {
				sw.Stop ();
				print ("Path found: " + sw.ElapsedMilliseconds + " ms");
				RetracePath (startNode, targetNode);
				return;
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
	}

	void RetracePath (_Node startNode, _Node endNode) {
		List<_Node> path = new List<_Node> ();
		_Node currentNode = endNode;

		while (currentNode != startNode) {
			path.Add (currentNode);
			currentNode = currentNode.parent;
		}
//		Vector2[] waypoints = SimplifyPath (path);
//		Array.Reverse (waypoints);
//		return waypoints;
		path.Reverse();
		finalPath = path;
		grid.path = path;
	}

//	Vector2[] SimplifyPath(List<_Node> path) {
//		List<Vector2> waypoints = new List<Vector2> ();
//		Vector2 directionOld = Vector2.zero;
//
//		for (int i = 1; i < path.Count; i++) {
//			Vector2 directionNew = new Vector2 (path [i - 1].gridX - path [i].gridX, path [i - 1].gridY - path [i].gridY);
//			if (directionNew != directionOld) {
//				waypoints.Add (path [i].worldPosition);
//			}
//			directionOld = directionNew;
//		}
//		return waypoints.ToArray ();
//	}

	int GetDistance(_Node nodeA, _Node nodeB){
		int dstX = Mathf.Abs (nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs (nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);

	}

}
