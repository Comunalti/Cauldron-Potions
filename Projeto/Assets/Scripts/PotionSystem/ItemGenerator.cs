using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace PotionSystem
{
    public class ItemGenerator : MonoBehaviourSingleton<ItemGenerator>
    {
        public List<GameObject> ingredientList = new List<GameObject>();

        public float GenerationDelayTime = 1;

        public Vector3 SpawnPostion;
        public Vector3 FinalPosition;
        public void Start()
        {
            
        }

        public IEnumerator GenerationRoute()
        {

            while (true)
            {
                yield return new WaitForSeconds(2);

                var randomItem = ingredientList.GetRandom();

                Instantiate(randomItem, SpawnPostion, Extension.GetRandomXYQuaternion());

                //randomItem.transform.do
            }
            
            yield break;
        }

        public void CreateNewItem()
        {
            StartCoroutine(GenerationRoute());
        }

    }
}