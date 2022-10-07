using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform playerObj;
    [SerializeField] Vector3 offset;
    private Vector3 ingameOffset;
    private Vector3 menuWeaponOffset;
    public float smoothSpeed = 0.125f;
    
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }    

        ingameOffset = new Vector3(0, 11, -12);
        menuWeaponOffset = new Vector3(0, 7.5f, -12);
        // offset = ingameOffset;
    }

    private void LateUpdate() 
    {
        Vector3 desiredPos = playerObj.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothPos; 
    }

    public void MoveCamera()
    {
        
    }
}
