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
        public void Start()
        {
           // StartCoroutine( GenerationRoute());
        }

        public IEnumerator GenerationRoute()
        {

            while (true)
            {
                yield return new WaitForSeconds(2);

                var randomItem = ingredientList.GetRandom();

                var clone = Instantiate(randomItem, SpawnPostion, Extension.GetRandomXYQuaternion());

                clone.AddComponent<ItemWaterMover>();

            }
            
            yield break;
        }

        [ContextMenu("start loop")]
        public void CreateNewItem()
        {
            StartCoroutine(GenerationRoute());
        }

    }
}