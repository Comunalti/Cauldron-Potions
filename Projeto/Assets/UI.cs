using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private int Health = 5;
    public Text healthText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + Health;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health--;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Health++;
        }
    }
}
