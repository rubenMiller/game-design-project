using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }
 
    public void RestartButton()
    {
        Debug.Log("Button restart pressed!");
        SceneManager.LoadScene(CrossSceneInformation.curentLevel);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }

}

