using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panel;

    public void SettingActive()
    {
        panel.SetActive(true);
    }
    public void SettingDeactive()
    {
        panel.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
