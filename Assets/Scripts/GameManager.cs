using UnityEngine;

public class GameManager : MonoBehaviour
{
	public void HideEndGame()
	{
		Debug.Log("Hide Reset");
		GameObject resetButton = GameObject.Find("RestartButton");
		resetButton.SetActive(false);
	}
	
    public void EndGame()
    {
        Debug.Log("Game Over");
		GameObject resetButton = GameObject.Find("RestartButton");
		resetButton.transform.Translate(Vector2.down * 6f);
		Debug.Log(resetButton);
    }
}

