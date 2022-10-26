using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "ScriptableObject/ColorData")]
public class ColorData : ScriptableObject
{
    public EColorType eColorType;
    public Material material;
}

