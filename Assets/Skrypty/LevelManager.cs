using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int playersOut;
    [SerializeField] string nextSceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playersOut==2)
        {
            NextLevel();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
