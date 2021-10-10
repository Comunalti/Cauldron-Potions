using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class WaterDefensePotion : Potion
    {
        public float evadePercent;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.AddEvadeChange(evadePercent);
            yield break;
        }
    }
}