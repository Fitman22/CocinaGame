using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveController : MonoBehaviour
{
    Rigidbody2D rib;
    [SerializeField] float speed;
    bool isMove;
    void Awake()
    {
        rib = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void StateMove(bool state)
    {
        isMove = state;
    }
    void Move()
    {
        if (!isMove) return;
        Vector2 position = InputController.instance.getMove();
        rib.velocity = new Vector2(position.x * speed, position.y * speed)*Time.deltaTime;
    }


   

}
