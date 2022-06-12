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
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
        else
        Application.Quit();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnPointerClick()
    {
    }
}
