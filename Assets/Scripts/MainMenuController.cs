using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; //to take the input from UI button

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedCharacter = int.Parse (EventSystem.current.currentSelectedGameObject.name);
        //parse is used to convert a string with only integers in it into an integer variable

        GameManager.instance.CharIndex = selectedCharacter; //using the static variables from class GameManager
        SceneManager.LoadScene ("GamePlay");
    }
}
