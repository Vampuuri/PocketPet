using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

	private GameInventoryScript inventory;
	public Text FunTxt;
	public void HideEndGame()
	{
		Debug.Log("Hide Reset");
		GameObject resetButton = GameObject.Find("RestartButton");
		GameObject backButton = GameObject.Find("BackButton");
		resetButton.SetActive(false);
		backButton.SetActive(false);
	}
	
    public void EndGame()
    {
        Debug.Log("Game Over");
		GameObject resetButton = GameObject.Find("RestartButton");
		resetButton.transform.Translate(Vector2.down * 6f);
		Debug.Log(resetButton);
		GameObject backButton = GameObject.Find("BackButton");
		backButton.transform.Translate(Vector2.down * 6f);

		//hupitesti

		GameObject player = GameObject.Find("Player");
		PlayerScript playerscript = gameObject.GetComponent<PlayerScript>();
		GameObject EssinManager = GameObject.Find("EssinManager");
		PetAttributes petattributes = gameObject.GetComponent<PetAttributes>();

		PetAttributes.fun += PlayerScript.score;
	}
}

