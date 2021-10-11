using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class DamageFlatDeltPotion : Potion
    {
        public float DamageFlatDelt = 25;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.Heal(DamageFlatDelt);
            yield break;
        }
    }
}