using UnityEngine;

public class ObjectMovment : MonoBehaviour
{
    float normalSpeed;
    float bottomSpeed;
    float speed;

    Vector3 m_scalingSpeed;
    Vector3 sizeInBottomScreen;
    bool isScalingDown;
    bool isMoving;

    Product product;
    new Rigidbody rigidbody;

    int keepChance;
    float minLifeTime;
    float maxLifeTime;
    string ResetFunction;
    private void Start()
    {
        SetupValues();
    }
    private void SetupValues()
    {
        product = GetComponent<Product>();
        rigidbody = GetComponent<Rigidbody>();
        keepChance = CardsSpawner.Singleton.GetKeepChance();
        minLifeTime = CardsSpawner.Singleton.GetMinMaxLifeTime().x;
        maxLifeTime = CardsSpawner.Singleton.GetMinMaxLifeTime().y;
        sizeInBottomScreen = CardsSpawner.Singleton.GetSizeInBottomScreen();
        ResetFunction = nameof(ResetCard);
    }
    public void StartMoving(float p_speed)
    {
        normalSpeed = p_speed;
        bottomSpeed = p_speed / 10;
        speed = normalSpeed;
        isMoving = true;
    }
    void Update()
    {
        MoveDown();
        ScaleDown();
    }
    private void MoveDown()
    {
        if (!isMoving) return;
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
            PickCardNextStep();
    }
    private void PickCardNextStep()
    {
        int random= Random.Range(0, keepChance);
        if (random == 0)
            KeepCard();
        else
            ResetCard();
    }
    private void KeepCard()
    {
        rigidbody.isKinematic = false;
        isScalingDown = false;
        transform.localScale = sizeInBottomScreen;
        speed = bottomSpeed;
        Invoke(ResetFunction, Random.Range(minLifeTime, maxLifeTime));
    }

    private void ResetCard()
    {
        rigidbody.isKinematic = true;
        isScalingDown = false;
        isMoving = false;
        transform.localScale = Vector3.one;
        transform.rotation = Quaternion.identity;
        speed = normalSpeed;
        transform.localPosition = Vector3.zero;
        product.ReturnToList();
    }

    public void StartScaleDown(Vector3 p_scalingSpeed)
    {
        isScalingDown = true;
        m_scalingSpeed = p_scalingSpeed;
    }
}
