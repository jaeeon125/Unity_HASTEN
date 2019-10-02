using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour
{
    List<Item> item = new List<Item>();
    public Text GoldText;
    public Text WoodText;
    private int gold = 0;
    private int wood = 0;
    // Start is called before the first frame update
    void Start()
    {
        item.Add(new Item(Item.Type.Use, "파인애플", "50의 HP를 회복합니다."));
        item.Add(new Item(Item.Type.Mat, "무기", "10의 공격력이 상승합니다."));
        item.Add(new Item(Item.Type.Mat, "방어력", "10의 방어력이 상승합니다."));
    }
    public Item getItem(int number)
    {
        return item[number];
    }

    public void gainGold(int _gold = 0)
    {
        gold += _gold;
        GoldText.text = gold.ToString();
    }
    public void gainWood(int _wood = 0)
    {
        wood += _wood;
        WoodText.text = wood.ToString();
    }
}
