using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(CrossSceneInformation.curentLevel);
    }

    //public void ClickLevel()
     //gameOverScreen.transform.gameObject.SetActive(true);

    

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }





public void PlayLevel1()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevel3()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Level3");
    }


}