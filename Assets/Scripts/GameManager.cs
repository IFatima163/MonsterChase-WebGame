using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //creating a static object "instance" for the GameManager class itself

    [SerializeField]
    private GameObject[] characters; 

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }
    
    private void Awake()
    {
        //starting singleton pattern
        
        if (instance == null) //if no "instance" static object was created
        {
            instance = this; //make an "instance" static object of "this" class
            
            DontDestroyOnLoad (gameObject); 
            //in Unity; when a new scene is loaded, all the objects from the previous scenes are destroyed.
            //this is why we need to specify when we want an object to be copied from scene to scene
            //and that is what line 27 is doing.
        }
        else //if "instance" is not null
        {
            Destroy (gameObject); //destroy the duplicate object created
        }

        //ending singleton pattern
    }
    
    //using the delegent & event concept to spawn character OnEnable and ending it at OnDisable
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading; 
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; 
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GamePlay")
        {
            Instantiate (characters[CharIndex]); 
            //if the scene we have instantiated is the "Gameplay", then spawn the character at index "CharIndex"
        }
    }
}
