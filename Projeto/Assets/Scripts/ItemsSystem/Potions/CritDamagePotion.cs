using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class CritDamagePotion : Potion
    {
        public float critDamage = 0.1f;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.AddCritDamage(critDamage);
            yield break;
        }
    }
}