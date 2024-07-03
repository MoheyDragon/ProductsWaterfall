using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsSpawner : Singletons<CardsSpawner>
{
    [SerializeField] float cardsSpeed;
    [SerializeField] float scalingDownSpeed;
    [SerializeField] float bottomScreenSize;
    [Space]
    [SerializeField] float minSpawnWait;
    [SerializeField] float maxSpawnWait;
    [Space]
    [SerializeField] float minX = -2.26f;
    [SerializeField] float maxX= 3.37f;
    [Space]
    [SerializeField] int cardKeepFactor;
    [SerializeField] Range cardLifeTime;
    [SerializeField] Vector2 life;
    CardHouse[] cardHouses;
    string spawnCardFunction;
    private void Start()
    {
        spawnCardFunction = nameof(SpawnCard);
        Invoke(spawnCardFunction, 1);
    }
    public void SpawnCard()
    {
        int houseIndex = Random.Range(0, 4);
        int cardsAvailable = cardHouses[houseIndex].cards.Count;
        if(cardsAvailable>0)
        {
            Product spawnedProduct = cardHouses[houseIndex].cards[Random.Range(0, cardsAvailable)];
            LaunchCard(spawnedProduct);
            cardHouses[houseIndex].cards.Remove(spawnedProduct);
        }
        Invoke(spawnCardFunction, Random.Range(minSpawnWait,maxSpawnWait));
    }
    public void ReturnProductToList(int type,Product card)
    {
        cardHouses[type].cards.Add(card);
    }
    private void LaunchCard(Product spawnedProduct)
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(minX, maxX);
        spawnedProduct.transform.position = newPosition;
        spawnedProduct.StartMoving(cardsSpeed);
    }
    public void SetCards(CardHouse[] p_cards)
    {
        cardHouses = p_cards;
    }
    public Vector3 GetScalingSpeed() => Vector3.one * scalingDownSpeed;
    public Vector3 GetSizeInBottomScreen() => Vector3.one * bottomScreenSize;
    public int GetKeepChance() => cardKeepFactor;
    public Range GetMinMaxLifeTime() => cardLifeTime;
}
