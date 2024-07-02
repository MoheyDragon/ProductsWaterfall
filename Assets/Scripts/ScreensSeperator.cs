using UnityEngine;

public class ScreensSeperator : MonoBehaviour
{
    Vector3 scalingDownSpeed;
    private void Start()
    {
        scalingDownSpeed = CardsSpawner.Singletone.GetScalingSpeed();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObjectMovment movement))
        {
            movement.StartScaleDown(scalingDownSpeed);
        }
    }
}
