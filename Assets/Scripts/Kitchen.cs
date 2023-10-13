using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kitchen : MonoBehaviour
{
    [SerializeField] List<GameObject> recipes, Objects;
    [SerializeField] Transform posInitial;
    [SerializeField] Animator RecipesZone;
    [SerializeField] GameObject Circle, ClickZone, spoon;
    GameObject plato;
    Player Player;
    FruitsCount fruis;
    TouchDetection touch;
    ChangeZone change;
    private void Start()
    {
        foreach (GameObject recipe in recipes)
        {
            GameObject r = Instantiate(recipe, posInitial.transform.position, transform.rotation);
            r.transform.SetParent(posInitial.parent);
            r.GetComponent<Recipe>().start(this);
            Objects.Add(r);
            posInitial.position = new Vector2(posInitial.position.x, posInitial.position.y - 11);

        }
        change = GetComponent<ChangeZone>();
        Player = FindObjectOfType<Player>();
        fruis = GetComponent<FruitsCount>();
        touch = GetComponent<TouchDetection>();
        Circle.SetActive(false);
    }
    public void startCoock()
    {
        RecipesZone.SetBool("Deselect", false);     
        Circle.SetActive(false);
        change.ChangeKitchen();
        plato = null;
    }
    public void SelectRecipe(Recipe recipe)
    {
        foreach (RecipeIngredients ingredient in recipe.ingredients)
        {
            fruis.ingredientAdd(ingredient.ingredients,-ingredient.count);
        }
        Replace();
        Circle.SetActive(true);
        RecipesZone.SetBool("Deselect",true);
        float Size = (float)recipe.size / 100;
        ClickZone.GetComponent<CircleCollider2D>().radius = 8 * Size * 10;
        ClickZone.GetComponent<CircleCollider2D>().offset = new Vector2(-25,8 * Size * 10);
        ClickZone.GetComponent<Image>().fillAmount = Size;
        touch.Spoon = true;
        touch.spoonCollider = spoon.GetComponent<Spoon>();
        plato = recipe.Plato;
    }
    public void ChechZone()
    {
        Circle.SetActive(false);
        if (plato)
        {
            Player.SelectDish(plato);
        }
        change.changeRestaurant();
    }
    public void Replace(Recipe r=null)
    {
        foreach (GameObject o in Objects)
        {
            if (o.GetComponent<Recipe>() != r)
            {
                o.GetComponent<Recipe>().unselect();
            }
        }
    }
    public bool HaveIngredients(List<RecipeIngredients> i)
    {
        bool isHave = true;
        foreach(RecipeIngredients ingredient in i)
        {
            if (ingredient.count> fruis.getIngredientCount(ingredient.ingredients))
            {
                isHave = false;
            }
        }
        return isHave;
    }

}
