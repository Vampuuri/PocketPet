using UnityEngine;

public class MoneyGenerator : MonoBehaviour
{
    public GameObject money;

    public float MinSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateMoney();
    }

    public void GenerateNextMoneyWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateMoney", randomWait);
    }

    void generateMoney()
    {
        GameObject PlatformIns = Instantiate(money, transform.position, transform.rotation);

        PlatformIns.GetComponent<MoneyScript>().moneyGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += SpeedMultiplier;
    }
}
