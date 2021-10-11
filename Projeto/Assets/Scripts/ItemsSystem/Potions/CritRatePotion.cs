using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class CritDamagePotion : Potion
    {
        public float CritDamagePotion = 10;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.AddCritDamage(CritDamagePotion);
            yield break;
        }
    }
}