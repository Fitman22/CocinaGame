using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchDetection : MonoBehaviour
{
    MovePath player;
    Kitchen kitchen;
    public bool Spoon;
    public Spoon spoonCollider;
    void Start()
    {
        InputController.instance.getTouch().touch.started += ctr => onTouch();
        player = FindAnyObjectByType<MovePath>();
        kitchen = GetComponent<Kitchen>();
    }
    
    void onTouch()
    {
        if (Spoon && spoonCollider.onZone)
        {
            kitchen.ChechZone();
        }
            Vector2 screenPosition = InputController.instance.getTouch().touched.ReadValue<Vector2>();
        // Convierte la posición de la pantalla a una posición en el espacio del mundo
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // Realiza un raycast en 2D para detectar si el puntero está sobre un objeto
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        // Comprueba si el raycast golpea algún objeto
        if (hit.collider != null)
        {
            // Accede al objeto golpeado
            GameObject clickedObject = hit.collider.gameObject;
            if (clickedObject.GetComponent<Plant>())
            {
                clickedObject.GetComponent<Plant>().recolect();
            }
            else if (clickedObject.GetComponent<MovePosition>())
            {
                player.addPos(clickedObject.GetComponent<MovePosition>().getPos(), kitchen.startCoock);
            }
            else if (clickedObject.GetComponent<Dish>())
            {
                player.selectDish(clickedObject.GetComponent<Dish>(), clickedObject.transform.position);
            }
            else if (clickedObject.GetComponent<Custommer>())
            {
                player.orderCustomer(clickedObject.GetComponent<Custommer>());
            }
        }
        else
        {
            player.addPos(worldPosition);
        }
    }
}
