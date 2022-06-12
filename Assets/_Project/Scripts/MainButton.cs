using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown(){
        if (SceneManager.GetActiveScene().buildIndex < 7)
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(GameState.currentGameLevel);
    }

    public void OnPointerClick()
    {
    }
}
