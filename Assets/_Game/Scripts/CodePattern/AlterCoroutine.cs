using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterCoroutine : Singleton<AlterCoroutine>
{
    public void StartAlterCoroutine(IEnumerator coroutineMethod)
    {
        if(coroutineMethod == null) return;
        StartCoroutine(coroutineMethod);
    }
}
