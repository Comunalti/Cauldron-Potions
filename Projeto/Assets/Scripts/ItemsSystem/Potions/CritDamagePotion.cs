using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class CritRatePotion : Potion
    {
        public float critRateChange = 0.1f;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.AddCritRate(critRateChange);
            yield break;
        }
    }
}