using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string GameScene;
    public GameObject uiLevelSelector;
    public GameObject uiSettings;
    public GameObject uiCredtis;

    public void Play()
    {
        SoundManager.Instance.PlaySFX("Switch");
        uiLevelSelector.SetActive(!uiLevelSelector.activeSelf);
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
    public void PlayBacktoMenu()
    {
        uiLevelSelector.SetActive(!uiLevelSelector.activeSelf);
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
