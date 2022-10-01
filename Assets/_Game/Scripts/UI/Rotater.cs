using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotateSpeed = -50f;

    private void Update() 
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);    
    }
}
