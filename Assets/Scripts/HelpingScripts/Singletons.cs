using UnityEngine;

public class Singletons<T> : MonoBehaviour where T:MonoBehaviour
{
    public static T Singletone;
    private void Awake()
    {
        if (Singletone == null)
            Singletone = this as T;
        else
            Destroy(this);
    }
}
