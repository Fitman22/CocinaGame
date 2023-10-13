using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Recipe : MonoBehaviour
{
    public List<RecipeIngredients> ingredients;
    public int size;
    Kitchen kitchen;
    Animator anim;
    public GameObject Plato;
    bool select;
    public void start(Kitchen kichen)
    {
        anim = GetComponent<Animator>();
        this.kitchen = kichen;
       
    }
    public void selectRecipe()
    {
        kitchen.Replace(this);
        if (!kitchen.HaveIngredients(ingredients)) { return; }
        if (select)
        {
            kitchen.SelectRecipe(this);
        }   
        anim.Play("Select");
        select = true;
     
    }
    public void unselect()
    {
        select = false;
        anim.Play("UnSelect");
    }
}
