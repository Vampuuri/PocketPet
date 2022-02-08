using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopClick : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Shop");
    }
}
