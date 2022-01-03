using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlCenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //proof that our scene has restarted each time we click the button
        print("this scene has been loaded");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
