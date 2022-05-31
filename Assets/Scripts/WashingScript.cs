using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WashingScript : MonoBehaviour
{
    public bool IsHoldingDown;
    public Text WashingText;

    public bool StartedWashing;
    public bool WashingDoneBool;
    public bool isHovered;
    public bool hittingCollider;

    private PetAttributes PetHygiene;
    public GameObject PetHygieneObject;

    private float timeCounter;
    public Text TimerText;

    public float washTime = 10.0f;

    void Awake()
    {
        PetHygiene = GetComponent<PetAttributes>();
        WashingDoneBool = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (hittingCollider == true)
            {
                IsHoldingDown = true;
                WashingText.text = ("Washing...");
                StartedWashing = true;
            }
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

        if (IsHoldingDown == true)
        {
            washTime -= Time.deltaTime;
        }

        if (washTime <= 0.0f)
        {
            timerEnded();
        }

        if (WashingDoneBool == true)
        {
            WashingDone();
            WashingDoneBool = false;
        }
    }

    
    void HygieneSource()
    {
        PetHygieneObject = GameObject.Find("EssinManager");
    }

    private void WashingDone()
    {
        PetAttributes.hygiene += 100;
        Debug.Log("hygiene raised");
    }

    void timerEnded()
    {
        WashingText.text = ("Washing's done, good job!");
        TimerText.text = timeCounter.ToString("done");
        WashingDoneBool = true;
    }
    private void OnMouseOver()
    {
        hittingCollider = true;
    }

    private void OnMouseExit()
    {
        hittingCollider = false;
    }
}
