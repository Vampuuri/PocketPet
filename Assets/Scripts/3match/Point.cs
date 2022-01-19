using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point
{
	public int x;
	public int y;
	
	public Point(int _x, int _y)
	{
		x = _x;
		y = _y;
	}
	
	public Vector2 toVector()
	{
		return new Vector2(x, y);
	}
	
	public bool Equals(Point p)
	{
		return (x == p.x && y == p.y);
	}
	
	public static Point fromVector(Vector2 vector)
	{
		return new Point((int) vector.x, (int) vector.y);
	}
	
	public static Point fromVector(Vector3 vector)
	{
		return new Point((int) vector.x, (int) vector.y);
	}
	
	public static Point mult(Point p, int m)
	{
		return new Point(p.x * m, p.y * m);
	}
	
	public static Point add(Point p1, Point p2)
	{
		return new Point(p1.x + p2.x, p1.y + p2.y);
	}
	
	public static Point clone(Point p)
	{
		return new Point(p.x, p.y);
	}
	
	
}
