using System;
using System.Collections.Generic;
using ItemsSystem;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PotionSystem
{
    [CreateAssetMenu(fileName = "new PotionResult",menuName = "PotionResult")]
    public class PotionResult : ScriptableObject
    {
        public List<Recipe> Recipes = new List<Recipe>();

        public GameObject Prefab;
        //public Color color;
        //public bool isGood;
        //public Potion potion;
            
        private void OnEnable()
        {
            
        }

        

        public GameObject GetInstance(Vector3 position)//GameObject goodPrefab,GameObject badPrefab
        {
            GameObject clone = Instantiate(Prefab); //isGood?Instantiate(goodPrefab,position,Quaternion.identity):Instantiate(badPrefab,position,Quaternion.identity);
            
            //var child = clone.GetChildWithName("PotLiquido");
            //child.GetComponent<SpriteRenderer>().color = color;
            return clone;
        }
    }
}
