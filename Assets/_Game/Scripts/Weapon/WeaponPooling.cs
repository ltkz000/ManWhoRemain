using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPooling : Pooling
{
    protected override void GenerateNewObject()
    {
        base.GenerateNewObject();

    }

    public override void ReturnObject(GameObject obj)
    {
        base.ReturnObject(obj);
    }
}
