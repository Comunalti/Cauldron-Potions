using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class AttackPercentPotion : Potion
    {
        public float attackPercent = 0.1f;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.addAttack(creature.baseAttack * attackPercent);
            yield break;
        }
    }
}