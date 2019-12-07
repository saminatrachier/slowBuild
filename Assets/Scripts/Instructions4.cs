using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Instructions4 : MonoBehaviour
{
    public int counter = 0;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI button1Txt;

    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    public Image img5;

    public Image button1img;

    public GameObject button1;
    public GameObject button2;
    // Start is called before the first frame update
    void Start()
    {
        //text1 = GetComponent<TextMeshProUGUI>();
        StartCoroutine(FadeTextToZeroAlpha(0f, text1));
        StartCoroutine(FadeTextToZeroAlpha(0f, text2));
        StartCoroutine(FadeTextToZeroAlpha(0f, text3));
        StartCoroutine(FadeTextToZeroAlpha(0f, text4));
        StartCoroutine(CrossFadeAlphaFixed_Coroutine(img1, 0, 0.01f));
        StartCoroutine(CrossFadeAlphaFixed_Coroutine(img2, 0, 0.01f));
        StartCoroutine(CrossFadeAlphaFixed_Coroutine(img3, 0, 0.01f));
        StartCoroutine(CrossFadeAlphaFixed_Coroutine(img4, 0, 0.01f));

        button1Txt.text = "Start Screen";
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void next3()
    {
        SceneManager.LoadScene(0);
    }
    
    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
    
    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
    
    public static IEnumerator CrossFadeAlphaFixed_Coroutine(Graphic img, float alpha, float duration)
    {
        Color currentColor = img.color;
        Color visibleColor = img.color;
        visibleColor.a = alpha;
        float counter = 0;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            img.color = Color.Lerp(currentColor, visibleColor, counter / duration);
            yield return null;
        }
    }
}
