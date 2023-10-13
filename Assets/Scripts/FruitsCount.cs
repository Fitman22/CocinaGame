using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum Ingredients
{
    ingredientPrueba,
    // Agrega los ingredientes aqui
}
public class FruitsCount : MonoBehaviour
{
     Dictionary<Ingredients, int> IngredientsCount;
    [SerializeField] List<TextMeshProUGUI> TxIngredientsCount;
    private void Start()
    {
        IngredientsCount = new Dictionary<Ingredients, int>();
        foreach (Ingredients clave in Ingredients.GetValues(typeof(Ingredients)))
        {
            IngredientsCount[clave] = 0;
        }
    }
    public void ingredientAdd(Ingredients ingredient,int add)
    {
        IngredientsCount[ingredient] += add;
        TxIngredientsCount[(int)ingredient].text = ""+getIngredientCount(ingredient);
    }
    public int getIngredientCount(Ingredients ingredient)
    {
        return IngredientsCount[ingredient];
    }
}
