using UnityEngine;
using System.Collections;

public class ChangeSprite : MonoBehaviour
{

    SpriteRenderer spriteRenderer; //will store sprite renderer

    void Start()
    {       
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); //get sprite renderer & store it
    }

    public void change(Sprite differentSprite)
    {
        Debug.Log("change");
        Debug.Log(differentSprite);
        spriteRenderer.sprite = differentSprite; //sets sprite renderers sprite
        GameObject evolveButton = GameObject.Find("EvolveButton");
        evolveButton.transform.Translate(Vector2.up * 7f);
    }
}