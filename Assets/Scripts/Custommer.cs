using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Custommer : MonoBehaviour
{
    [SerializeField] float timeWait;
    Animator anim;
    int state;
    bool sentado;
   [SerializeField] Chair chair;
    NavMeshAgent nav;
    [SerializeField] GameObject burbuja,pedido,pensamiento,dish;
    public Transform exit;
    bool Ispedido,finish;
    int chairCount=0;
    int dinero;
    private void Start()
    {
        dinero = 3000;
        anim = GetComponent<Animator>();
        state = 0;
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        nav.updateUpAxis = false;
    }
    private void FixedUpdate()
    {
        if (!chair)
        {
            Debug.Log(chairCount);
          chair = FindObjectsOfType<Chair>()[chairCount];
            if( chairCount < FindObjectsOfType<Chair>().Length - 1) chairCount++;
            if (chair.getState()) { chair = null; }
            else
            {
                nav.SetDestination((Vector2)chair.gameObject.transform.position);
              
            }
        }

        if(chair&&nav.remainingDistance <= nav.stoppingDistance && nav.pathStatus == NavMeshPathStatus.PathComplete&&!sentado)
        {
            chair.SetCustomer(true);
            sentado = true;
            StartCoroutine(TimeOrder());
        }
        if (nav.remainingDistance <= nav.stoppingDistance && nav.pathStatus == NavMeshPathStatus.PathComplete&&finish)
        {
            Destroy(gameObject);
        }
    }
    public bool isOrder()
    {
        return Ispedido;
    }
    public Vector3 platePosition() { return chair.PlatePosition.position; }
    public void Servir(GameObject dish)
    {
        burbuja.SetActive(false);
        pedido.SetActive(false);
        this.dish = dish;
        this.dish.transform.SetParent(this.transform);
        this.dish.transform.position = chair.PlatePosition.position;
        state--;
        anim.SetInteger("State", state);
        StartCoroutine(TimeEating());
    }
    IEnumerator TimeEating()
    {
        yield return new WaitForSeconds(15);
        Destroy(dish);
        float money = dinero / (state + 1);
        ShoopController.instance.addMoney(Mathf.RoundToInt(money));
        nav.SetDestination(exit.position);
        finish = true;
        chair.SetCustomer(false);
    }
        IEnumerator TimeOrder()
    {
        pensamiento.SetActive(true);
        burbuja.SetActive(true);
        yield return new WaitForSeconds(5);
        StartCoroutine(stateChange());
        pensamiento.SetActive(false);
        pedido.SetActive(true);
        Ispedido = true;
    }
        IEnumerator stateChange()
    {
        yield return new WaitForSeconds(timeWait);
        state++;
        anim.SetInteger("State", state);
        if (state > 3)
        {
            goOut();
        }     
        if (state < 4 && !dish)
        {
            StartCoroutine(stateChange());
        }
        
    }

    private void goOut()
    {
        finish = true;
        chair.SetCustomer(false);
        nav.SetDestination(exit.position);
        burbuja.SetActive(false);
        pedido.SetActive(false);
    }
}
