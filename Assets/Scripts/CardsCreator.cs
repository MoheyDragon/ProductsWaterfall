using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCreator : MonoBehaviour
{
    [SerializeField] Product productsPrefab;
    [SerializeField] Transform cardsParent;
    [Space]
    [SerializeField] Sprite[] cardsSprits;
    [SerializeField] string[] productsInformation;
    CardType[] cards;
    int currentCardIndex = 0;
    private void Awake()
    {
        InitiateProperties();
        InstantiateProducts();
        CardsSpawner.Singletone.SetCards(cards);
    }
    private void InitiateProperties()
    {
        cards = new CardType[4];
        for (int i = 0; i < 4; i++)
        {
            cards[i]=new CardType();
            cards[i].cards = new List<Product>();
        }
        spacing =Vector3.up* - 1.13f;
    }
    private void InstantiateProducts()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                CreateProduct(i,j);
            }
            currentNewCardPosition = Vector3.zero;
        }    
    }
    Vector3 currentNewCardPosition;
    Vector3 spacing;
    private void CreateProduct(int cardsType,int cardIndex)
    {
        Product product = Instantiate(productsPrefab, cardsParent.GetChild(cardsType)).GetComponent<Product>();
        product.transform.localPosition = currentNewCardPosition;
        Card cardInfo = new Card(cardIndex, currentCardIndex,cardsType, GetCardName(cardIndex.ToString()),
            productsInformation[currentCardIndex], cardsSprits[currentCardIndex]);
        product.SetupCard(cardInfo);
        cards[cardsType].cards.Add(product);
        currentCardIndex++;
        currentNewCardPosition += spacing;
    }
    private string GetCardName(string index)
    {
        index = index switch
        {
            "0" => "A",
            "10" => "J",
            "11" => "Q",
            "12" => "K",
            _ => index
        };
        return index.ToString();
    }

}
