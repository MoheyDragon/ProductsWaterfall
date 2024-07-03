using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCreator : MonoBehaviour
{
    [SerializeField] Product productsPrefab;
    [SerializeField] Transform cardsParent;
    [Space]
    [SerializeField] Sprite[] cardsSprites;
    [SerializeField] string[] cardsNames;
    [SerializeField] string[] productsInformation;
    CardHouse[] cardHouses;

    int globalCardIndex = 0;
    
    private void Awake()
    {
        InitiateProperties();
        InstantiateProducts();
    }
    private void Start()
    {
        CardsSpawner.Singleton.SetCards(cardHouses);
    }

    private void InitiateProperties()
    {
        cardHouses = new CardHouse[4];
        for (int i = 0; i < 4; i++)
        {
            cardHouses[i] = new CardHouse();
            cardHouses[i].cards = new List<Product>();
        }
    }
    private void InstantiateProducts()
    {
        for (int houseIndex = 0; houseIndex < 4; houseIndex++)
        {
            for (int cardIndex = 0; cardIndex < 13; cardIndex++)
            {
                CreateProduct(houseIndex, cardIndex);
            }
        }
    }
    private void CreateProduct(int houseIndex, int cardIndex)
    {
        //creating and setting postion
        Product product = Instantiate(productsPrefab, cardsParent.GetChild(houseIndex)).GetComponent<Product>();

        //implementing data to my card
        string cardName = cardsNames[cardIndex]+ " of "+(House)houseIndex;
        string cardDescription = productsInformation[globalCardIndex];
        Sprite cardImageSprite = cardsSprites[globalCardIndex];
        Card cardInfo = new Card(cardIndex, globalCardIndex, houseIndex, cardName, cardDescription, cardImageSprite);

        product.SetupCard(cardInfo);
        cardHouses[houseIndex].cards.Add(product);

        globalCardIndex++;
    }
    private string GetCardName(int index)
    {
        string name = index switch
        {
            0 => "Ace",
            7 => "Lucky Seven",
            10 => "Jack",
            11 => "Queen",
            12 => "King",
            _ => index.ToString()
        };
        return name;
    }
}
public enum House { Spades, Clubs, Diamonds,Hearts}
