using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [SerializeField] private Transform camTrans;
    [SerializeField] private Transform playerTrans;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 ingameOffset;
    [SerializeField] private Vector3 defaultIngameOffset;
    [SerializeField] private Vector3 shopOffset;
    
    private Quaternion camRotate;
    public float smoothSpeed = 0.125f;

    //Const
    [SerializeField] private Quaternion shopRotate;
    [SerializeField] private Quaternion ingameRotate;

    private void Start() 
    {
        Init();
    }

    private void Init()
    {
        playerTrans = PlayerDataManager.Ins.GetCharacterCombat().GetCharacterTranform();
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

        if(playerTrans == null)
        {
            Init();
        }

        if(playerTrans != null) 
        {
            Vector3 desiredPos = playerTrans.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            camTrans.position = smoothPos;
            camTrans.rotation = camRotate;
        }
    }   

    public void UpdateOffset()
    {
        ingameOffset += ingameOffset * 0.1f;
        Debug.Log("Update");
    } 

    public void Restart()
    {
        Init();
        ingameOffset = defaultIngameOffset;
    }
}
