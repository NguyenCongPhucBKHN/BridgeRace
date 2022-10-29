using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColBrick : Brick
{
    [SerializeField] public Rigidbody rd;
    [SerializeField] public Collider collider;

    private bool isHitGround;
   private void Start() 
   {
    SetColor(EColorType.Default);
    rd.AddForce(Vector3.up);
    isHitGround=false;

   }

   private void OnCollisionEnter(Collision other) {
    if(other.collider.CompareTag("ground"))
    {
        if(!isHitGround){
            StartCoroutine(DisbalePhysic());
        }
        isHitGround=true;
    }
    
   }

   IEnumerator DisbalePhysic(){
    while(true){
        if(rd.velocity.magnitude<0.01f&&rd.angularVelocity.magnitude<0.001f){
            break;
        }
        yield return null;
    }
        collider.isTrigger= true;
        rd.isKinematic=true;

   }
}
