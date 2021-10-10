using System.Collections;
using CombatSystem;

namespace ItemsSystem.Potions
{
    public class FirePotion : Potion
    {
        public float dmg = 10;
        protected override IEnumerator MainEffect(Creature creature)
        {
            print("aoba");
            //creature.Damage(dmg);
            yield break;
        }
    }
}
