using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class PrecisionPotion : Potion
    {
        public float speed;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.AddPrecision(speed);
            yield break;
        }
    }
}