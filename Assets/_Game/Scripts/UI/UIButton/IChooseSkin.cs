using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChooseSkin<T>
{
    T GetSkinType();
    void ChangeSkinType(T t);
}
