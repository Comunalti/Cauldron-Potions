using UnityEngine;

namespace PotionSystem
{
    [CreateAssetMenu(fileName = "new Ingredient",menuName = "Ingredient")]
    public class Ingredient : ScriptableObject
    {
        public string GetFormattedName()
        {
            return name;
        }
    }
}