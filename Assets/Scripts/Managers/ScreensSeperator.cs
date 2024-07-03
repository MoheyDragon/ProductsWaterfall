using UnityEngine;

public class ScreensSeperator : MonoBehaviour
{
    Vector3 scalingDownSpeed;
    string productTag = "Product";
    private void Start()
    {
        scalingDownSpeed = CardsSpawner.Singleton.GetScalingSpeed();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(productTag))
            other.transform.GetComponent<ObjectMovment>().StartScaleDown(scalingDownSpeed);
    }
}
