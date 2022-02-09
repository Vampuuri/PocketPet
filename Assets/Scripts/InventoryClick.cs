using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryClick : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("GameInventory");
    }
}
