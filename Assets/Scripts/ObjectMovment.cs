using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovment : MonoBehaviour
{
    float speed;
    Vector3 m_scalingSpeed=Vector3.one* 0.1f;
    bool isScalingDown;
    bool isMoving;
    Product product;
    private void Start()
    {
        product = GetComponent<Product>();
    }
    public void StartMoving(float p_speed)
    {
        speed = p_speed;
    }
    void Update()
    {
        MoveDown();
        ScaleDown();
    }
    private void MoveDown()
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= speed * Time.deltaTime;
        transform.position = newPosition;
    }
    private void ScaleDown()
    {
        if (!isScalingDown) return;
        Vector3 newScale = transform.localScale;
        newScale -= m_scalingSpeed * Time.deltaTime;
        transform.localScale = newScale;
        if (newScale.x <= 0)
            ResetCard();
    }
    private void ResetCard()
    {
        isScalingDown = false;
        isMoving = false;
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
        product.ReturnToList();
    }
    public void StartScaleDown(Vector3 p_scalingSpeed)
    {
        isScalingDown = true;
        m_scalingSpeed = p_scalingSpeed;
    }
}
