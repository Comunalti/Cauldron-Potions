using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PotionSystem
{
    [CreateAssetMenu(fileName = "new Recipe",menuName = "Recipe")]
    public class Recipe : ScriptableObject
    {
        public List<Ingredient> Ingredients = new List<Ingredient>();
        public bool OrderDependent;

        
        public List<string> GenerateCombinations()
        {
            if (OrderDependent)
            {
                var ingredientsArray = Ingredients.ToArray();
                var stringList = new List<string>();
                var keyWord = PotionManager.Instance.IngredientsToKeyWord(ingredientsArray);
                stringList.Add(keyWord);
                return stringList;
            }
            else
            {
                var ingredientsArray = Ingredients.ToArray();
                var fac = Ingredients.Count.Factorial();
                var stringList = new List<string>();
            
                for (int i = 0; i < fac ; i++)
                {
                    ingredientsArray.SwapValues(i,i+1);

                    var keyWord = PotionManager.Instance.IngredientsToKeyWord(ingredientsArray);
                    stringList.Add(keyWord);
                }

                return stringList;
            }
        }
    }
}