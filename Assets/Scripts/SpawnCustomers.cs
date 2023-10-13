 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    [SerializeField] Transform entrada;
    [SerializeField] float min, max;
    [SerializeField] int countCustomers;
    [SerializeField] List<GameObject> customers;

    private void Start()
    {
        TimmerController.instance.finishTimmer.AddListener(startSpawn);
      
    }
    public void startSpawn()
    {

        StartCoroutine(spawn(max));

    }
    IEnumerator spawn(float time)
    {
        yield return new WaitForSeconds(time);
        if (countCustomers == 0) { yield return 0; }
        float t = Random.Range(min,max);
        int c = Random.Range(0,customers.Count);
        GameObject customer= Instantiate(customers[c],entrada.position,entrada.rotation);
        customer.GetComponent<Custommer>().exit = entrada;
        countCustomers--;
        StartCoroutine(spawn(t));
    }

}
