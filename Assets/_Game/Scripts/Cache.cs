using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Cache 
{

        static Dictionary<Collider, Character> dict_Character = new Dictionary<Collider, Character>();
        static Dictionary<Collider, Brick> dict_Brick = new Dictionary<Collider, Brick>();
        static Dictionary<Collider, Stair> dict_Stair = new Dictionary<Collider, Stair>();

        public static Character GetCharacter(Collider collider)
        {
                if(!dict_Character.ContainsKey(collider)){
                    dict_Character.Add(collider, collider.GetComponent<Character>());
                }

                return dict_Character[collider];
        }

        public static Brick GetBrick(Collider collider)
        {
                if(!dict_Brick.ContainsKey(collider)){
                    dict_Brick.Add(collider, collider.GetComponent<Brick>());
                }

                return dict_Brick[collider];
        }

         public static Stair GetStair(Collider collider)
        {
                if(!dict_Stair.ContainsKey(collider)){
                    dict_Stair.Add(collider, collider.GetComponent<Stair>());
                }

                return dict_Stair[collider];
        }

}

public class cache<T> where T:  MonoBehaviour
{
        static Dictionary<Collider, T> dict = new Dictionary<Collider, T>() ;

        public static T Get(Collider collider)
        {
                if(!dict.ContainsKey(collider)){
                    dict.Add(collider, collider.GetComponent<T>());
                }

                return dict[collider];
        }
}
