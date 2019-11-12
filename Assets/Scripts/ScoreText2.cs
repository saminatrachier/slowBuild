using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//usage: create a UI score counter for player 2 when they make a correct match

public class ScoreText2 : MonoBehaviour
{
    private Text text2;

    public static int Score2;
    
    // Start is called before the first frame update
    void Start()
    {
        text2 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text2.text = Score2.ToString();
    }
}
