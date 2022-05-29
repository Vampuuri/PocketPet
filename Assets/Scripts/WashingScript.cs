using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WashingScript : MonoBehaviour
{
    public bool IsHoldingDown;
    public Text WashingText;

    public bool StartedWashing;

    private PetAttributes PetHygiene;
    public GameObject PetHygieneObject;

    float boolTime = 0;

    private float timeCounter;
    public Text TimerText;



    void Awake()
    {
        PetHygiene = GetComponent<PetAttributes>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            IsHoldingDown = true;
            WashingText.text = ("Washing...");
            StartedWashing = true;
        }
        else if(StartedWashing == true)
        {
            IsHoldingDown = false;
            WashingText.text = ("Keep washing!");
        }

        if (IsHoldingDown == true)
        {
            timeCounter += Time.deltaTime;
            TimerText.text = timeCounter.ToString("0");
        }
    }

    
    void HygieneSource()
    {
        PetHygieneObject = GameObject.Find("EssinManager");

    }

}
