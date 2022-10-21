using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITypeButton : MonoBehaviour
{
    [SerializeField] private SkinID skinID;
    [SerializeField] private Image backgroundImage;
    [SerializeField] bool beingChoose;

    private void Start() 
    {
        beingChoose = false;    
    }

    public void ChoosenOne()
    {
        backgroundImage.gameObject.SetActive(false);
    }

    public void NotChoosenOne()
    {
        backgroundImage.gameObject.SetActive(true);
    }

    public SkinID GetButtonID()
    {
        return skinID;
    }
}
