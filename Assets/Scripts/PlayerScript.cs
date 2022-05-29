using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerScript : MonoBehaviour
{

    public float JumpForce;
    public static float score;
	[SerializeField]
	bool isGrounded = false;
    bool isAlive = true;
	SpikeGenerator spikeGenerator;

    Rigidbody2D RB;

    public Text ScoreTxt;

    public int coinAmount;

    private GameInventoryScript inventory;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        Time.timeScale = 1;
		spikeGenerator = FindObjectOfType<SpikeGenerator>();

        coinAmount = 0;

        inventory = GameObject.Find("EssinManager").GetComponent<GameInventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { if(isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if(isAlive)
        {
            score += Time.deltaTime * spikeGenerator.currentSpeed * 0.4f;
            ScoreTxt.text = "SCORE: " + score.ToString("F0"); 
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }
        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
            FindObjectOfType<GameManager>().EndGame();
            GetComponent<Renderer>().enabled = false;
            inventory.AddMoney(coinAmount);
            coinAmount = 0;
        }
    }
    public void AddCoin()
    {
        coinAmount++;
    }
}
