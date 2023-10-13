using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShoopController : MonoBehaviour
{
    [SerializeField] List<int> Prices;
    [SerializeField] GameObject shoop;
    [SerializeField] Button BtSell,BtBuy,BtComplete;
    [SerializeField] TextMeshProUGUI Total, Count,TxMoney;
    public static ShoopController instance;
    FruitsCount fruits;
    int total, count, select;
    [SerializeField] int money;
    bool isBuy;
    
    private void Start()
    {
        instance = this;
        addMoney(7000);
        shoop.SetActive(false);
        fruits = GetComponent<FruitsCount>();
        UpdateChanges();
    }
    public void addMoney(int Count)
    {
        money += Count;
        TxMoney.text = "$" + money;
    }
    public void Select(int select)
    {
        isBuy = true;
        shoop.SetActive(true);
        total= Prices[select];
        count = 1;
        this.select = select;
        UpdateChanges();
    }
    public void add()
    {
        if (count <99)
        {
            count++;
            UpdateChanges();
        }
    }
    public void subtract()
    {
        if (count > 1)
        {
            count--;
            UpdateChanges();
        }
    }
    public void Buy()
    {
        isBuy = true;
        BtBuy.gameObject.GetComponent<Image>().color = Color.green;
        BtSell.gameObject.GetComponent<Image>().color = Color.white;

        UpdateChanges();
    }
    public void Sell()
    {
        isBuy = false;
        BtSell.gameObject.GetComponent<Image>().color = Color.green;
        BtBuy.gameObject.GetComponent<Image>().color = Color.white;
        UpdateChanges();
    }
    public void Complete()
    {
        if (isBuy)
        {
            addMoney(-total);
            fruits.ingredientAdd(Ingredients.ingredientPrueba, count);
        }
        else
        {
            addMoney(total);
            fruits.ingredientAdd(Ingredients.ingredientPrueba, -count);
        }
        UpdateChanges();
    }
    public void UpdateChanges()
    {
        total = Prices[select] * count;
        if ((!isBuy&&count > fruits.getIngredientCount(Ingredients.ingredientPrueba)) || (isBuy && total > money))
        {
            BtComplete.interactable = false;
        }
        else
        {
            BtComplete.interactable = true;
        }    
        if (!isBuy) {
            float t = total;
            t *= 0.7f;
            total = Mathf.RoundToInt(t); 
        }
        Count.text = "" + count;
        Total.text = "$" + total;
    }

}
