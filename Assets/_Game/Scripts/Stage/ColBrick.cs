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
    Vector3[] directions = new Vector3[]{Vector3.right, Vector3.left, Vector3.forward, Vector3.back};

    int random = Random.Range(0, 4);
    rd.AddForce(Vector3.up*100 + directions[random]*200);
    isHitGround=false;

   }


//    private void OnCollisionEnter(Collision other) {
//     if(other.collider.CompareTag("ground"))
//     {
//         if(!isHitGround){
//             StartCoroutine(DisbalePhysic());
//         }
//         isHitGround=true;
//     }
    
//    }

//    IEnumerator DisbalePhysic(){
//     while(true){
//         // if(rd.velocity.magnitude<0.01f&&rd.angularVelocity.magnitude<0.001f){
//         if(rd.velocity.magnitude<0.01f&&rd.angularVelocity.magnitude<0.001f){
//             break;
//         }
//         yield return null;
//     }
        
//         rd.isKinematic=true;
//         collider.isTrigger= true;

//    }
}
