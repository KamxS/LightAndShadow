using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int playersOut;
    [SerializeField] string nextSceneName;
    [SerializeField] Animator transitionAnim;
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
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextSceneName);
        transitionAnim.SetTrigger("Start");
    }

}
