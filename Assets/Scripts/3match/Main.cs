using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public ArrayLayout boardLayout;
	public Sprite[] pieces;
	int width = 9;
	int height = 9;
	Node[,] board;
	
	System.Random random;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void StartGame()
	{	
		string seed = getRandomSeed();
		random = new System.Random(seed.GetHashCode());
		
		InitializeBoard();
	}
	
	void InitializeBoard() {
		board = new Node[width, height];
		
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				board[x,y] = new Node(boardLayout.rows[y].row[x] ? -1 : fillPiece(), new Point(x,y));
			}
		}
	}
	
	void VerifyBoard()
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				int val = getValueAtPoint(new Point(x, y));
				
				if (val <= 0) continue;
			}
		}
	}
	
	List<Point> isConnected(Point p, bool main)
	{
		List<Point> connected = new List<Point>();
		int val = getValueAtPoint(p);
		Point[] directions =
		{
			Point.up,
			Point.right,
			Point.down,
			Point.left
		};
		
		foreach(Point dir in directions)
		{
			
		}
	}
	
	int fillPiece()
	{
		int val = 1;
		val = (random.Next(0,100) / (100/pieces.Length)) + 1;
		return val;
	}
	
	int getValueAtPoint(Point p)
	{
		return board[p.x,p.y].value;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	
	string getRandomSeed()
	{
		string seed = "";
		string acceptableChars = "ABCDEFGHIJKLMNOPQRSTUWVXYZabcdefghijklmnopqrstuwvzyx0123456789";
		for (int i = 0; i < 20; i++)
		{
			seed += acceptableChars[Random.Range(0, acceptableChars.Length)];
		}
		return seed;
	}
}


[System.Serializable]
public class Node
{
	public enum Values
	{
		EMPTY = 0,
		AIR = 1,
		FIRE = 2,
		PLANT = 3,
		STONE = 4,
		WATER = 5,
		THUNDER = 6
	}
	
	public int value;
	public Point index;
	
	public Node(int v, Point i)
	{
		value = v;
		index = i;
	}
}