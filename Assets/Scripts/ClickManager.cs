using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] Camera bottomCamera;
    string clickableTag = "Clickable";
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = bottomCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.CompareTag(clickableTag))
                    hit.transform.GetComponent<Product>().OnClick();
            }
        }
    }
}
