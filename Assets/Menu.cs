using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string GameScene = "beta";
    public GameObject uiSettings;
    public GameObject uiCredtis;

    public void Play()
    {
        SceneManager.LoadScene(GameScene);
       SoundManager.Instance.PlaySFX("Play");
    }

    public void Settings()
    {
        uiSettings.SetActive(!uiSettings.activeSelf);
        SoundManager.Instance.PlaySFX("Switch");
    }

    public void Credtis()
    {
        Debug.Log("Credits");
        uiCredtis.SetActive(!uiCredtis.activeSelf);
        SoundManager.Instance.PlaySFX("Switch");
    }

    public void SettingsBacktoMenu()
    {
        uiSettings.SetActive(!uiSettings.activeSelf);
        SoundManager.Instance.PlaySFX("Switch");
    }

    public void cREDITSBacktoMenu()
    {
        uiCredtis.SetActive(!uiCredtis.activeSelf);
        SoundManager.Instance.PlaySFX("Switch");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
