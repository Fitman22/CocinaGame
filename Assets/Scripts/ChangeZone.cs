using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeZone : MonoBehaviour
{
    [SerializeField] GameObject BtShoop, BtCultivos;
   // MoveController playerMove;
    SongsController songController;
    MovePath Player;
    private void Start()
    {
        Player = FindObjectOfType<MovePath>();
        Player.ChangeState(false);
        BtCultivos.SetActive(false);
       // playerMove = FindObjectOfType<MoveController>();
        TimmerController.instance.finishTimmer.AddListener(changeRestaurant);
        songController = GetComponent<SongsController>();
    }
   public void changeRestaurant()
    {
        Player.ChangeState(true);
        CinemachineBrain.instance.changeCamera(2);
        songController.ChangeMusic(1);
       // playerMove.StateMove(true);
        BtShoop.SetActive(false);
        BtCultivos.SetActive(false);
    }
    public void ChangeKitchen()
    {
        Player.ChangeState(false);
        CinemachineBrain.instance.changeCamera(3);
    }
    public void Shoop(int n)
    {
        if (n == 0) { 
            //cambia hacia la tienda
            BtShoop.SetActive(false); BtCultivos.SetActive(true); 
            CinemachineBrain.instance.changeCamera(1);
        }
        else
        {
            //cambia hacia los cultivos
            BtShoop.SetActive(true); BtCultivos.SetActive(false);
            CinemachineBrain.instance.changeCamera(0);
        }       
        TimmerController.instance.StopTimmer();
    }
}
