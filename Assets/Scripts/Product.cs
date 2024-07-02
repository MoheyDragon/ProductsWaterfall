using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    int localIndex;
    int globalIndex;
    int typeIndex;
    string information;

    ObjectMovment objectMovment;
    public void SetupCard(Card cardInfo)
    {
        localIndex = cardInfo.localIndex;
        globalIndex = cardInfo.globalIndex;
        typeIndex = cardInfo.typeIndex;

        name = cardInfo.name;
        information = cardInfo.information;
        GetComponent<SpriteRenderer>().sprite = cardInfo.sprite;
        objectMovment = GetComponent<ObjectMovment>();
    }
    public void StartMoving(float speed)
    {
        objectMovment.StartMoving(speed);
    }
    public void ReturnToList()
    {
        CardsSpawner.Singletone.ReturnProductToList(typeIndex, this);
    }
}
