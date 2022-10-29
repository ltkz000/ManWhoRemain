using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/Skin Data")]

public class Skin : ScriptableObject
{
    public SkinColor color;
    public Material material;
    public Color skinColor;
}
