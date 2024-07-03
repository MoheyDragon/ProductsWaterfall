using UnityEngine;
public class Product : MonoBehaviour
{
    public string information;
    public Sprite sprite;

    int localIndex;
    int globalIndex;
    int typeIndex;
    ObjectMovment objectMovment;
    public void SetupCard(Card cardInfo)
    {
        localIndex = cardInfo.localIndex;
        globalIndex = cardInfo.globalIndex;
        typeIndex = cardInfo.typeIndex;

        name = cardInfo.name;
        information = cardInfo.information;
        sprite = cardInfo.sprite;
        GetComponent<SpriteRenderer>().sprite = cardInfo.sprite;
        objectMovment = GetComponent<ObjectMovment>();
    }
    public void StartMoving(float speed)
    {
        objectMovment.StartMoving(speed);
    }
    public void ReturnToList()
    {
        CardsSpawner.Singleton.ReturnProductToList(typeIndex, this);
    }
    public void OnClick()
    {
        print(information+ ", "+name);
    }
}
