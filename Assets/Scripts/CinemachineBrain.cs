using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachineBrain : MonoBehaviour
{

    [SerializeField] List<CinemachineVirtualCamera> cameras;
    public static CinemachineBrain instance;
    int SelectCamera;
    private void Start()
    {
        instance = this;
        changeCamera(0);
    }
    public int getZone() { return SelectCamera; }
    public void changeCamera(int n)
    {
        foreach(CinemachineVirtualCamera camera in cameras){
            camera.Priority = 1;
        }
        cameras[n].Priority = 20;
        SelectCamera = n;

    }
}
