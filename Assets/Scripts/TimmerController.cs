using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class TimmerController : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject finishWindow,addPoints;
    [SerializeField] Text txResults;
    [SerializeField] Image timmer;
    FruitsCount fruits;
    float initialtime;
    public static TimmerController instance;
    public UnityEvent finishTimmer;
    int totalPoints=0;
    bool isStopped;
    private void Awake()
    {
        instance = this;
        initialtime = time;
        finishTimmer = new UnityEvent();
        finishTimmer.AddListener(StopTimmer);
        fruits = GetComponent<FruitsCount>();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void recolect(Vector2 posSpawn)
    {
      
      GameObject points=  Instantiate(addPoints, posSpawn, transform.rotation);
        int randomPoints = UnityEngine.Random.Range(1, 4);
        totalPoints += randomPoints;
        fruits.ingredientAdd(Ingredients.ingredientPrueba,randomPoints);
        points.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text += ""+randomPoints;
        Destroy(points, 2);
    }
    void Update()
    {
        if (isStopped) { return; }
        timmer.fillAmount = time / initialtime;
        time -= Time.deltaTime;
        if (time <= 0) {finishTimmer.Invoke(); timmer.gameObject.SetActive(false); }
    }
    public void StopTimmer()
    {
        isStopped = !isStopped;
       
    }
    private void finish()
    {
   
       // finishWindow.SetActive(true);
       // txResults.text = ""+totalPoints;
    }
}
