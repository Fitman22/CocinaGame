using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] float couldown;
    bool isfinish;
    Material Material;
    float fill = 220;
    private void Start()
    {
        isfinish = true;
        Material = GetComponent<SpriteRenderer>().material;
        Material.SetFloat("_Angle", 360);
        
    }

    public void recolect()
    {
        if (!isfinish) return;
        TimmerController.instance.recolect(transform.position);
        fill = 220;
        Material.SetFloat("_Angle", fill);
        StartCoroutine(coulDown());
        isfinish = false;
    }
    IEnumerator coulDown()
    {
        yield return new WaitForSeconds(couldown);
        fill += 1;
        Material.SetFloat("_Angle", fill);
        if (fill >= 360) { isfinish = true; }
        else { StartCoroutine(coulDown()); }
    }
 

}
