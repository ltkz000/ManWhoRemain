using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material transparentMat;
    public Material defaultMat;

    public void TransparentObject()
    {
        meshRenderer.material = transparentMat;
    }

    public void SetDefaultMat()
    {
        meshRenderer.material = defaultMat;
    }
}
