using System;
using System.Collections.Generic;
using UnityEngine;

namespace PotionSystem
{
    [CreateAssetMenu(fileName = "new PotionResult",menuName = "PotionResult")]
    public class PotionResult : ScriptableObject
    {
        public List<Recipe> Recipes = new List<Recipe>();
        public GameObject Prefab;
    }
}
