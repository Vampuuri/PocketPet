using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PetLoad : MonoBehaviour
{
    public static PetLoad instance;
    public GameObject pet;
    public Renderer rend;
    public Scene scene;

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;

            DontDestroyOnLoad(pet);
        }
    }

    private void Update()
    {
        rend = GetComponent<Renderer>();
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "gamescreen")
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
    }
}
