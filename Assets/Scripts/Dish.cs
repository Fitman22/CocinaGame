using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dish : MonoBehaviour
{
    GameObject Platillo;

    public GameObject Select()
    {
        return Platillo;
    }
    public void setDish(GameObject dish)
    {
        Platillo = Instantiate(dish,transform);
    }
   
         public void dropDish()
    {
        Destroy(Platillo);
    }

}
