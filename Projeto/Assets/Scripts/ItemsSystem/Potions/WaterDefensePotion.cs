using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class WaterDefensePotion : Potion
    {
        public float evade = 2;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.AddEvadeChange(evade);
            yield break;
        }
    }
}