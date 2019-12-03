using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressScript : MonoBehaviour
{
    private Image progressBar;
    public float minProgress = 0f;
    private float progress;
    
    // Start is called before the first frame update
    void Start()
    {
        progressBar.GetComponent<Image>();
        progress = minProgress;
        progressBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
