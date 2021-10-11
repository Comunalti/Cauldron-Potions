using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public AudioSource audioData;

    public void Exit()
    {
        Application.Quit();
    }
    
    public void StartGame()
    {
        audioData.Play();
        StartCoroutine(Espera());        
    }
    
    public void GoToMenu()
    {
        audioData.Play();
        StartCoroutine(Quit());
        
    }

    public IEnumerator Espera()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scenes/Jogo");
        
    }

    public IEnumerator Quit()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}
