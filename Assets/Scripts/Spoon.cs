using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
    public bool onZone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onZone = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onZone = false;
    }
}
