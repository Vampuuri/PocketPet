using System.Collections;
using UnityEngine;

[System.Serializable]
public class ArrayLayout
{
	public Grid grid;
	public rowData[] rows = new rowData[9];
	
    [System.Serializable]
	public struct rowData
	{
		public bool[] row;
	}
}
