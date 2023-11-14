using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void PlayNextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if(CrossSceneInformation.curentLevel == "Level1") { SceneManager.LoadScene("Level2"); }
        if (CrossSceneInformation.curentLevel == "Level2") { SceneManager.LoadScene("Level3"); }
        if (CrossSceneInformation.curentLevel == "Level3") { SceneManager.LoadScene("Menu"); }
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Menu");
    }
}
