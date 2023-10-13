using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField]bool ocupe=false;
    [SerializeField] public Transform PlatePosition;

    public void SetCustomer(bool state)
    {
        ocupe = state;
    }
    public bool getState() { return ocupe; }
}
