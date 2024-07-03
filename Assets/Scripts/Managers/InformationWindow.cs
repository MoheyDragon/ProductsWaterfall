using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InformationWindow : Singletons<InformationWindow>
{
    [SerializeField] TextMeshProUGUI productName;
    [SerializeField] TextMeshProUGUI productInformation;
    [SerializeField] Image productImage;
    [Space]
    [SerializeField] Vector3 offset = new Vector3(0, 0, -1);
    [SerializeField] Range allowedAreaX,allowedAreaY;

    [Space]
    [SerializeField] float showSize = 1;
    [SerializeField] float hideSize = 0;
    [SerializeField] float scaleSpeed = 1;
    Vector3 scaleSpeedVector;
    Vector3 hideSizeVector;
    bool isScaling;
    private void Start()
    {
        scaleSpeedVector = Vector3.one * scaleSpeed;
        hideSizeVector = Vector3.one * hideSize;
    }
    private void Update()
    {
        if (isScaling)
            ScaleUp();
    }
    private void ScaleUp()
    {
        Vector3 newScale = transform.localScale;
        newScale += scaleSpeedVector * Time.deltaTime;
        transform.localScale = newScale;
        if (newScale.x >= showSize)
            isScaling = false;
    }

    public void ShowInfo(Product product)
    {
        MoveToProductPosition(product);
        SetupProductInfo(product);
        LaunchScalingUp();
    }
    private void MoveToProductPosition(Product product)
    {
        Vector3 newPosition= product.transform.position + offset;
        newPosition.x = Mathf.Clamp(newPosition.x, allowedAreaX.Min, allowedAreaX.Max);
        newPosition.y = Mathf.Clamp(newPosition.y, allowedAreaY.Min, allowedAreaY.Max);
        transform.position = newPosition;
    }
    private void SetupProductInfo(Product product)
    {
        productName.text = product.name;
        productInformation.text = product.information;
        productImage.sprite = product.sprite;
    }
    private void LaunchScalingUp()
    {
        transform.localScale = hideSizeVector;
        isScaling = true;
    }
}
