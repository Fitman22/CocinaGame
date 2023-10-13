using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] GameObject dish;
   public void SelectDish(GameObject dish)
    {
        
        this.dish = Instantiate(dish,transform);
        this.dish.transform.localPosition = Vector2.zero;
    }
    public bool haveDish()
    {
        if (dish) return true;
        else return false;
    }
    public void DestroyDish()
    {
        Destroy(dish);
    }
    public GameObject dropDish()
    {
        return dish;
    }
}
