using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public PlatformGenerator platformGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * platformGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            platformGenerator.GenerateNextPlatformWithGap();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}