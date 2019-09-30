using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class VBTrans : MonoBehaviour, IVirtualButtonEventHandler
{
    // Start is called before the first frame update
    public GameObject origText;
    public GameObject transText;
    public GameObject authorText;
    public GameObject button;
    private int current = 1;
    public bool isActive = false;

    void Start()
    {
        origText = GameObject.Find("reviewTotal");
        transText = GameObject.Find("Translated Content");
        transText.SetActive(false);
        button = GameObject.Find("VirtualButtonTrans");
        button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(authorText.activeSelf)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (!authorText.activeSelf)
        {
            if (current == 1)
            {
                Debug.Log("setting translation active");
                origText.SetActive(false);
                transText.SetActive(true);
                current = 2;
            }
            else
            {
                Debug.Log("setting translation inactive");
                origText.SetActive(true);
                transText.SetActive(false);
                current = 1;
            }
            Debug.Log("author text is: " + isActive);
        }
        
        Debug.Log("Translation Button Pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }

}
