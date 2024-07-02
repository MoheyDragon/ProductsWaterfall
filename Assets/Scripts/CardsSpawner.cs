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
    [SerializeField] Vector2 cardLifeTime;
    CardType[] m_cards;
    string spawnCardFunction;
    private void Start()
    {
        spawnCardFunction = nameof(SpawnCard);
        Invoke(spawnCardFunction, 1);
    }
    public void SpawnCard()
    {
        int typeIndex = Random.Range(0, 4);
        int cardsAvailable = m_cards[typeIndex].cards.Count;
        if(cardsAvailable>0)
        {
            Product spawnedProduct = m_cards[typeIndex].cards[Random.Range(0, cardsAvailable)];
            LaunchCard(spawnedProduct);
            m_cards[typeIndex].cards.Remove(spawnedProduct);
        }
        Invoke(spawnCardFunction, Random.Range(minSpawnWait,maxSpawnWait));
    }
    public void ReturnProductToList(int type,Product card)
    {
        m_cards[type].cards.Add(card);
    }
    private void LaunchCard(Product spawnedProduct)
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(minX, maxX);
        spawnedProduct.transform.position = newPosition;
        spawnedProduct.StartMoving(cardsSpeed);
    }
    public void SetCards(CardType[] p_cards)
    {
        m_cards = p_cards;
    }
    public Vector3 GetScalingSpeed() => Vector3.one * scalingDownSpeed;
    public Vector3 GetSizeInBottomScreen() => Vector3.one * bottomScreenSize;
    public int GetKeepChance() => cardKeepFactor;
    public Vector2 GetMinMaxLifeTime() => cardLifeTime;
}
