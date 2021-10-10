using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PotionSystem
{
    public class PotionManager : MonoBehaviourSingleton<PotionManager>
    {
        public List<PotionResult> PotionResults = new List<PotionResult>();

        public Dictionary<string, PotionResult> PotionMap = new Dictionary<string, PotionResult>();

        
        protected override void SingletonStarted()
        {
            foreach (var potionResult in PotionResults)
            {
                foreach (var recipe in potionResult.Recipes)
                {
                 foreach (var KeyWord in recipe.GenerateCombinations())
                    {
                        print(KeyWord);
                        PotionMap.Add(KeyWord,potionResult);
                    }
                }
            }
        }

        public string IngredientsToKeyWord(Ingredient[] Ingredients)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var ingredient in Ingredients)
            {
                stringBuilder.Append(ingredient.GetFormattedName());
            }
            return stringBuilder.ToString();
        }

        public PotionResult GetPotionResult(Ingredient[] Ingredients)
        {
            var keyCode = IngredientsToKeyWord(Ingredients);
            if (PotionMap.ContainsKey(keyCode))
            {
                return PotionMap[keyCode];
            }
            else
            {
                return null;
            }
        }
    }
}