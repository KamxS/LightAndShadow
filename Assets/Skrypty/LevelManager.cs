using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] Transform Player1StartPos;
    [SerializeField] Transform Player2StartPos;
    public int playersIn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playersIn==2)
        {
            Debug.Log("Win");
        }
    }

    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
