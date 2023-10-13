using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class MovePath : MonoBehaviour
{
    NavMeshAgent agent;
  [SerializeField]  bool call,Enable;
   [SerializeField] UnityEvent finishPath;
    Player player;
    Dish dish;
    Custommer customer;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        finishPath = new UnityEvent();
    }
    private void FixedUpdate()
    { 
        if (agent.remainingDistance<=agent.stoppingDistance && agent.pathStatus == NavMeshPathStatus.PathComplete && !call)
        {
            call = true;
                finishPath.Invoke();      
        }
    }
    public void ChangeState(bool state)
    {
        Enable = state;
    }
    public void addPos(Vector3 pos, UnityAction eventFinish=null)
    {
        if (!Enable) return;
        finishPath.RemoveAllListeners();
        if (eventFinish != null)
        {
            finishPath.AddListener(eventFinish);
        }
        else
        {
            finishPath.AddListener(here);
        }
        agent.SetDestination(pos);
        call = false;
    }
    private void here()
    {
        Debug.Log("here");
    }
    public void selectDish(Dish dish,Vector3 pos)
    {  
        this.dish = dish;
        if (dish.Select()&&!player.haveDish())
        {
                addPos(pos,takeDish);
        }
        else if (dish.Select()==null && player.haveDish())
        {
            addPos(pos, DropDish);
        }
        else
        {
            addPos(pos);
        }
    }
    public void orderCustomer(Custommer customer)
    {
        if (customer.isOrder()&&player.haveDish())
        {
            this.customer = customer;
            addPos(customer.platePosition(), order);
        }
        else
        {
            addPos(customer.platePosition());
        }
    }
    public void order()
    {
        customer.Servir(player.dropDish());
        player.dropDish();
    }
    void DropDish()
    {
        dish.setDish(player.dropDish());
        player.DestroyDish();
    }
   void takeDish()
    {
        player.SelectDish(dish.Select());
        dish.dropDish();
    }
    
}
