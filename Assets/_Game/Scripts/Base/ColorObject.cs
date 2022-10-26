using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] List<ColorData> listColorData;
    [SerializeField] GameObject go;
    public EColorType colorType;
    [SerializeField]
    public MeshRenderer meshRenderer;

    public void SetColor(EColorType eColorType)
    {
       foreach(ColorData data in listColorData)
       {
        if((int) data.eColorType ==(int) eColorType)
        {   
            // this.meshRenderer = GetComponent<MeshRenderer>()==null ? GetComponentInChildren<MeshRenderer>(): GetComponent<MeshRenderer>();
            
            
            // Debug.Log("data.material: " + data.material);
            this.meshRenderer.material = data.material;
            this.colorType = data.eColorType;
            // Debug.Log("material: " + this.meshRenderer.material);
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
