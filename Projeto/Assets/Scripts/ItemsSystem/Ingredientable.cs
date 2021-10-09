using DefaultNamespace;
using PotionSystem;
using UnityEngine;

namespace ItemsSystem
{
    public class Ingredientable : Draggable
    {
        public Ingredient profile;
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject == Cauldron.Instance.gameObject)
            {
                Cauldron.Instance.Insert(this);
            }else if (other.gameObject.CompareTag(TagStrings.Floor))
            {
                
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(TagStrings.Floor))
            {
                print("floor");
            }
            
        }
    }
}