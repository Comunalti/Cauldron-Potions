using System;
using CombatSystem;
using Object = UnityEngine.Object;

public class Enemy : Creature
{
    private void Update()
    {
        if (base.creatureCurrentHealth<=base.creatureMinHealth)
        {
            Kill(() =>
            {
                Destroy(gameObject);
                EnemySpawner.Instance.CreateNew();
            });
        }
    }

   
}