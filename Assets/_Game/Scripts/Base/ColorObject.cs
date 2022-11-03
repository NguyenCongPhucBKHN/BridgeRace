using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : GameUnit
{
    [SerializeField] List<ColorData> listColorData;
    [SerializeField] GameObject go;
    public EColorType colorType;
    [SerializeField]
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;

     public override void OnInit()
    {
        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
   

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
    public void SetColor(EColorType eColorType)
    {
       foreach(ColorData data in listColorData)
       {
        if(data.eColorType == eColorType &&  this.meshRenderer!= null )
        {   
            this.meshRenderer.material = data.material;
            this.colorType = data.eColorType;
        }
        if(data.eColorType == eColorType &&  this.skinnedMeshRenderer!= null )
        {   
            this.skinnedMeshRenderer.material = data.material;
            this.colorType = data.eColorType;
        }

       } 
    }

    public EColorType GetColor()
    {
        return this.colorType;
    }

    public GameObject GetObjectByColor(EColorType eColorType)
    {
        if(this.colorType == eColorType)
        {
            return go;
        }
        return null;
    }

}
