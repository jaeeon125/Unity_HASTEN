using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour
{
    List<Item> item;
    public Text GoldText;
    public Text WoodText;
    private int gold = 0;
    private int wood = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void gainGold(int _gold)
    {
        gold += _gold;
        GoldText.text = gold.ToString();
    }
    public void gainWood(int _wood)
    {
        wood += _wood;
        WoodText.text = wood.ToString();
    }
}
