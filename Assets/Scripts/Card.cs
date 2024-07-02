using UnityEngine;
public struct Card
{
    public int localIndex;
    public int globalIndex;
    public int typeIndex;
    public string name;
    public string information;
    public Sprite sprite;

    public Card(int localIndex, int globalIndex,int typeIndex,string name, string information, Sprite image)
    {
        this.name = name;
        this.localIndex = localIndex;
        this.globalIndex = globalIndex;
        this.typeIndex = typeIndex;
        this.information = information;
        this.sprite = image;
    }
}
