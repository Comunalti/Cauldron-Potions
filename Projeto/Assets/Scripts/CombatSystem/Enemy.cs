using System;
using CombatSystem;
using UnityEngine;
using Object = UnityEngine.Object;

public class Enemy : Creature
{
    public RectTransform barra;

    private void Update()
    {
        print("asdsad");
        barra.sizeDelta = new Vector2(600 * creatureCurrentHealth / creatureMaxHealth,50);
        if (base.creatureCurrentHealth<=base.creatureMinHealth)
        {
            EnemySpawner.Instance.CreateNew();
            Destroy(gameObject);
            
        }
    }

   
}