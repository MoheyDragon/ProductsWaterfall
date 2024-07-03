using UnityEngine;
public class ClickManager : MonoBehaviour
{
    [SerializeField] Camera bottomCamera;
    string productTag = "Product";
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = bottomCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.CompareTag(productTag))
                {
                    Product product = hit.transform.GetComponent<Product>();
                    InformationWindow.Singleton.ShowInfo(product);
                }
            }
        }
    }
}
