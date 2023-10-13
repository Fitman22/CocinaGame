using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivation : MonoBehaviour
{
    [SerializeField] List<Transform> PosPlants;
    [SerializeField] GameObject Plants;
    int pos = 0;
    private void Start()
    {
        addPlant();
        addPlant();
    }
    void addPlant()
    {
        Instantiate(Plants,PosPlants[pos].position,transform.rotation);
            pos++;
    }
}
