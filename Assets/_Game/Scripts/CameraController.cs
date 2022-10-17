using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform playerObj;
    private Vector3 offset;
    private Quaternion camRotate;
    [SerializeField] private Vector3 ingameOffset;
    [SerializeField] private Vector3 shopOffset;
    public float smoothSpeed = 0.125f;

    //Const
    [SerializeField] private Quaternion shopRotate;
    [SerializeField] private Quaternion ingameRotate;


    //Vector3 camSkinShopPos = new Vector3(0, 3, -18);
    //Quaternion = (22, 0, 0);
    
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }    

        // ingameOffset = new Vector3(0, 11, -12);
        // shopOffset = new Vector3(0, 5, -6);
        // offset = ingameOffset;
    }

    private void LateUpdate() 
    {
        if(GameManager.Ins.IsState(GameState.MainMenu) || GameManager.Ins.IsState(GameState.SkinShop))
        {
            offset = shopOffset;
            camRotate = shopRotate;
        }
        else
        {
            offset = ingameOffset;
            camRotate = ingameRotate;
        }   

        Vector3 desiredPos = playerObj.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        
        transform.position = smoothPos;
        transform.rotation = camRotate;
    }    
}
