using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using EZCameraShake;


//USAGE: put this on player 1's camera to change the background color when a mutation occurs
//purpose: Player 1's visual mutation tracker (screen background color)
public class Mutation1 : MonoBehaviour
{
    public GameObject player;
    public Color color3 = new Color(255, 0, 0,255); //bright red

    public Color color2 = new Color(255, 85, 85,255);//medium red

    public Color color1 = new Color(255, 185, 185, 255); //light red
    
    public Color default1 = new Color(49, 77, 121, 0);

    public Camera cam1;

    public GameObject cameraParent;

    public static int Mutation = 0;
    public float time;
    public GameObject gameOverText;
    public bool shakeOnlyOnce;

    // Start is called before the first frame update
    void Start()
    {
        //cam1 = GetComponent<Camera>();
        gameOverText.SetActive(false);
        Mutation = 0;
        shakeOnlyOnce = false;
        time = 1f;
      //  endMarker = new Vector3(1.4f, 1f, -10f);

    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("Player 1 Mutation is at: " + Mutation);
        if (Mutation == 1)
        {
            cam1.backgroundColor =color1;
            if (shakeOnlyOnce == false)
            {
                CameraShaker.Instance.ShakeOnce(5f, 5f, .1f, 1);
                shakeOnlyOnce = true;
            }
             
        }

        if (Mutation == 2)
        {
            
            cam1.backgroundColor = color2;
            if (shakeOnlyOnce == true)
            {
                CameraShaker.Instance.ShakeOnce(5f, 5f, .1f, 1);
                shakeOnlyOnce = false;
            }

        }

        if (Mutation == 3)
        {
            cam1.backgroundColor = color3;
            gameOverText.SetActive(true);
          
                cam1.transform.position = Vector3.Lerp(cam1.transform.position, player.transform.position, 2f * Time.deltaTime);
                if (cam1.transform.position.y <= 1f)
                {
                    cam1.backgroundColor = default1;
                    gameOverText.SetActive(false); 
                    Mutation = 0;
                   
                }
            
            if (shakeOnlyOnce == false)
            {
                CameraShaker.Instance.ShakeOnce(5f, 5f, .1f, 1);
                shakeOnlyOnce = true;
            }

        }
    }
}
