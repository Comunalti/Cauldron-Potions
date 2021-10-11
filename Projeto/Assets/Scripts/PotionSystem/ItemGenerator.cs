using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PotionSystem
{
    public class ItemGenerator : MonoBehaviourSingleton<ItemGenerator>
    {
        public List<GameObject> ingredientList = new List<GameObject>();

        public float GenerationDelayTime = 1;

        public float Y;
        public float MinX;
        public float MaxX;
        public void Start()
        {
           StartCoroutine( GenerationRoute());
        }

        public IEnumerator GenerationRoute()
        {

            while (true)
            {
                yield return new WaitForSeconds(GenerationDelayTime);

                var randomItem = ingredientList.GetRandom();

                var clone = Instantiate(randomItem, new Vector3(Random.Range(MinX,MaxX),Y,-5), Extension.GetRandomXYQuaternion().normalized);

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