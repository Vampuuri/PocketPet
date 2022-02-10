using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    Rigidbody2D RB;
    public MoneyGenerator moneyGenerator;

    void Update()
    {
        transform.Translate(Vector2.left * moneyGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            moneyGenerator.GenerateNextMoneyWithGap();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //the coin does get destroyed but sometimes it bonks the player. why?
            Destroy(this.gameObject);

        }
    }
}
