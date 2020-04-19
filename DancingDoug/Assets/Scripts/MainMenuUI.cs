using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
