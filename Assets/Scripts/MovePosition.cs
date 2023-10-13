using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour
{
    [SerializeField] Transform PosMove;

    public Vector3 getPos()
    {
        return PosMove.position;
    }
}
