﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	//public Transform player;
	public bool onlyDisplayPathGizmos;
	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;		// adjust size of grid table
	public float nodeRadius;
	public List<_Node> path;

	_Node[,] grid;
	float nodeDiameter;
	int gridSizeX, gridSizeY;		// amount of grid box in x axis and y axis

	void Awake() {
		nodeDiameter = nodeRadius * 2;
		gridSizeX = Mathf.RoundToInt (gridWorldSize.x / nodeDiameter);
		gridSizeY = Mathf.RoundToInt (gridWorldSize.y / nodeDiameter);
		CreateGrid ();

	}

	public int MaxSize {
		get {
			return gridSizeX * gridSizeY;
		}
	}

	void CreateGrid() {
		grid = new _Node[gridSizeX, gridSizeY];
		Vector2 worldBottomLeft = (Vector2)transform.position - Vector2.right * gridWorldSize.x / 2 - Vector2.up * gridWorldSize.y / 2;

		for (int x = 0; x < gridSizeX; x++) {
			for (int y = 0; y < gridSizeY; y++) {
				Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
				bool walkable = (Physics2D.OverlapCircle (worldPoint, nodeRadius, unwalkableMask) == null); // if no collider2D is returned by overlap circle, then this node is walkable

				grid [x, y] = new _Node (walkable, worldPoint, x, y);
			}
		}
	}

	public List<_Node> GetNeighbours (_Node node) {
		List<_Node> neighbours = new List<_Node> ();

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if ((x == 0 && y == 0) || (x  == 1 && y == 1) || (x  == -1 && y == -1) || (x  == 1 && y == -1) || (x  == -1 && y == 1))
					continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
					neighbours.Add(grid[checkX, checkY]);
				}
			}
		}

		return neighbours;
	}

	public _Node NodeFromWorldPoint(Vector2 worldPosition) {
		float percentX = (worldPosition.x - 16f + gridWorldSize.x/2) / gridWorldSize.x;
		float percentY = (worldPosition.y  + 0.64f + gridWorldSize.y/2) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
		return grid[x,y];
	}

	//OnDrawGizmox = call every frame
		
	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,new Vector2(gridWorldSize.x,gridWorldSize.y));

		if (onlyDisplayPathGizmos) {
			if (path != null) {
				foreach (_Node n in path) {
					Gizmos.color = Color.black;
//					print ("x: " + n.worldPosition.x + "y: " + n.worldPosition.y);
					Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
				}
			}
		}
		else {
			if (grid != null) {
				foreach (_Node n in grid) {
					Gizmos.color = (n.walkable)?Color.white:Color.red;
					if (path != null) {
						if (path.Contains (n)) {
							Gizmos.color = Color.black;
						}
					}
					Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
				}
			}
		}
	}

}