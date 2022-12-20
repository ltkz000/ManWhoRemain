using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Transform holderTrans;
    public float rotateSpeed = -50f;

    private void Update() 
    {
        holderTrans.Rotate(0, rotateSpeed * Time.deltaTime, 0);    
    }
}
