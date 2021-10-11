using System;
using System.Collections;
using CombatSystem;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : Creature
{
    public RectTransform barra;
    public GameObject lapide;
    private bool dead = false;
    private void Update()
    {
        barra.sizeDelta = new Vector2(300 * creatureCurrentHealth / creatureMaxHealth,30);

        if (creatureCurrentHealth<creatureMinHealth && !dead)
        {
            dead = true;
            //Instantiate(lapide, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Time.timeScale = 0;
            SceneManager.LoadScene("Scenes/Fim de Jogo");
        }
    }
    
}