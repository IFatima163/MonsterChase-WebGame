using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        //method 1 of getting a scene name; just ask for current scene's name
    }

    public void MainMenu()
    {
        SceneManager.LoadScene ("MainMenu");
        //method 2 of getting a scene name; simply hardcode the name
    }
}
