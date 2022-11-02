using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache 
{
        static Dictionary<Collider, Character> dict_Character = new Dictionary<Collider, Character>();

        public static Character GetCharacter(Collider collider)
        {
                if(!dict_Character.ContainsKey(collider)){
                    dict_Character.Add(collider, collider.GetComponent<Character>());
                }

                return dict_Character[collider];
        }
}