using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

//USAGE: put this on player 2's camera to change the background color when a mutation occurs
//purpose: Player 2's visual mutation tracker (screen background color)
public class Mutation2 : MonoBehaviour

{
    public GameObject player;
    public Color color3 = new Color(255, 0, 0,255); //bright red

    public Color color2 = new Color(255, 85, 85,255);//medium red

    public Color color1 = new Color(255, 185, 185, 255); //light red
    
    public Color color4 = new Color(255, 185, 185, 255); //light red
    
    //public Color default1 = new Color(255, 185, 185, 255); //light red

    public Camera cam2;

    public GameObject gameOverText;
    
    public GameObject mutation;

    public float time;
    
    public static int Mutation = 0;
    
    public bool shakeOnlyOnce;
    
    //Reference to camerap2 parent
    public GameObject cameraParent2;
    
    // Start is called before the first frame update
    void Start()
    {
        Mutation = 0;
        //cam2 = GetComponent<Camera>();
        gameOverText.SetActive(false);
        time = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mutation == 1)
        {
            cam2.backgroundColor =color1;
            
            if (shakeOnlyOnce == false)
            {
                CameraShaker.GetInstance("Main Camerap2").ShakeOnce(5f, 5f, .1f, 1);
                FindObjectOfType<AudioManager>().Play("Wrong");
                shakeOnlyOnce = true;
            }
        }

        if (Mutation == 2)
        {
            cam2.backgroundColor = color2;
            if (shakeOnlyOnce == true)
            {
                CameraShaker.GetInstance("Main Camerap2").ShakeOnce(5f, 5f, .1f, 1);
                FindObjectOfType<AudioManager>().Play("Wrong");
                shakeOnlyOnce = false;
            }
        }

        if (Mutation == 3)
        {
            cam2.backgroundColor = color3;
            gameOverText.SetActive(true);
                

            cameraParent2.transform.position = Vector3.Lerp(cameraParent2.transform.position, player.transform.position, 2f * Time.deltaTime);
            if (cam2.transform.position.y <= 1f)
            {
                cam2.backgroundColor = color4;
                gameOverText.SetActive(false); 
                Mutation = 0;
            }
            
            if (shakeOnlyOnce == true)
            {
                CameraShaker.GetInstance("Main Camerap2").ShakeOnce(5f, 5f, .1f, 1);
                shakeOnlyOnce = false;
            }

        }
    }

}
