using System;
using System.Collections;
using CombatSystem;
using UnityEngine;


public class Player : Creature
{
    public RectTransform barra;
    private void Update()
    {
        barra.sizeDelta = new Vector2(300 * creatureCurrentHealth / creatureMaxHealth,30);
    }
}