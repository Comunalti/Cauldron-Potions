using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Jogo");
    }
    
    public void GoToMenu()
    {
        Application.Quit();
    }
}
