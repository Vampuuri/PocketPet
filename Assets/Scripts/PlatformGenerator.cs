using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;

    public float MinSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generatePlatform();
    }

    public void GenerateNextPlatformWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generatePlatform", randomWait);
    }

    void generatePlatform()
    {
        GameObject PlatformIns = Instantiate(platform, transform.position, transform.rotation);

        PlatformIns.GetComponent<PlatformScript>().platformGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += SpeedMultiplier;
    }
}
