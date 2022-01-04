using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float JumpForce;
    float score;
	[SerializeField]
	bool isGrounded = false;
    bool isAlive = true;
	SpikeGenerator spikeGenerator;

    Rigidbody2D RB;

    public Text ScoreTxt;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        Time.timeScale = 1;
		spikeGenerator = FindObjectOfType<SpikeGenerator>();
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
			Debug.Log(spikeGenerator.currentSpeed);
            score += Time.deltaTime * spikeGenerator.currentSpeed;
            ScoreTxt.text = "SCORE : " + score.ToString("F0");
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

        }
    }
}
