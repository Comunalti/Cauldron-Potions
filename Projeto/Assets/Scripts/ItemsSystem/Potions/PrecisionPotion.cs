using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class PrecisionPotion : Potion
    {
        public float precisionChance = 2;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.AddPrecision(precisionChance);
            yield break;
        }
    }
}