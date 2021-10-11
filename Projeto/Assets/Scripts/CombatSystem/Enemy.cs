using System;
using CombatSystem;
using UnityEngine;
using Object = UnityEngine.Object;

public class Enemy : Creature
{
    public RectTransform barra;

    private void Update()
    {
        barra.sizeDelta = new Vector2(300 * creatureCurrentHealth / creatureMaxHealth,30);
        if (base.creatureCurrentHealth<=base.creatureMinHealth)
        {
            EnemySpawner.Instance.CreateNew();
            Destroy(gameObject);
            
        }
    }

   
}