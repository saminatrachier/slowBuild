using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void PlayGame() {
        SceneManager.LoadScene (1); //if the button is pressed, go to the game
    }
    public void Instructions() {
        SceneManager.LoadScene (3); //if the button is pressed, go to the instructions
    }
    public void Tutorial() {
        SceneManager.LoadScene (4); //if the button is pressed, go to the tutorial
    }
    public void Menu() {
        SceneManager.LoadScene (0); //if the button is pressed, go to the start
    }
}

