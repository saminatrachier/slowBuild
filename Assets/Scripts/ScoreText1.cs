using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//usage: create a UI score counter for player 1 when they make a correct match

public class ScoreText1 : MonoBehaviour
{
    private Text text;

    public static int Score;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Score.ToString();
    }
}
