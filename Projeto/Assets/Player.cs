using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Extension
{
    public static T GetRandom<T>(this IEnumerable<T> current)
    {
        return current.ElementAt(Random.Range(0, current.Count()));
    }
}


public class Player : Creature
{
    
}


public class Enemy : Creature
{
    
}


public abstract class Creature : MonoBehaviour
{
    public float CreatureMaxHealth = 0;
    public float CreatureMinHealth = 0;
    public float CreatureCurrentHealth = 0;

    public delegate void HealthChangedEventHandler();
    public event HealthChangedEventHandler HealthChangedEvent = () => {};

    public delegate void CreatureDiedEventHandler();
    public event CreatureDiedEventHandler CreatureDiedEvent = () => {};

    public Creature()
    {
        
    }
    
    public void Damage(float dmg)
    {
        CreatureCurrentHealth -= dmg;
        if (CreatureCurrentHealth<=CreatureMinHealth)
        {
            Kill();
        }
        HealthChangedEvent.Invoke();
    }

    protected virtual void Kill()
    {
        CreatureDiedEvent.Invoke();
    }

    public void Heal(float healed)
    {
        CreatureCurrentHealth += healed;
        if (CreatureCurrentHealth>=CreatureMaxHealth)
        {
            CreatureCurrentHealth = CreatureMaxHealth;
        }
        HealthChangedEvent.Invoke();
    }
}

