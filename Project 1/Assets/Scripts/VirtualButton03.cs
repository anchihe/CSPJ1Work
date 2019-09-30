using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class VirtualButton03 : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject button;
    public GameObject authorText;
    public GameObject reviewText;
    public GameObject video1;
    public GameObject video2;
    VideoPlayer videoPlayer1;
    VideoPlayer videoPlayer2;

    public int current = 1;

    // Start is called before the first frame update
    void Start()
    {
        authorText = GameObject.Find("BackCoverText");
        reviewText = GameObject.Find("reviewTotal");
        button = GameObject.Find("VirtualButton3");

        reviewText.SetActive(false);

        video1 = GameObject.Find("video1");
        video2 = GameObject.Find("video2");
        videoPlayer1 = video1.GetComponent<VideoPlayer>();
        videoPlayer2 = video2.GetComponent<VideoPlayer>();
        video1.SetActive(false);
        video2.SetActive(false);

        
        button.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (current == 1 && !reviewText.activeSelf)
        {
            authorText.SetActive(false);
            reviewText.SetActive(true);

            video1.SetActive(true);
            video2.SetActive(false);

            videoPlayer1.Play();
            videoPlayer2.Stop();

            current = 2;
        }
        else if (current == 2 && reviewText.activeSelf)
        {
            authorText.SetActive(false);
            reviewText.SetActive(true);

            video1.SetActive(false);
            video2.SetActive(true);

            videoPlayer1.Stop();
            videoPlayer2.Play();

            
            
            current = 3;
        }

        else if (current == 3 && reviewText.activeSelf)
        {
            authorText.SetActive(false);
            reviewText.SetActive(true);

            videoPlayer1.Stop();
            videoPlayer2.Stop();

            video1.SetActive(false);
            video2.SetActive(false);

            current = 4;
        }

        else if (current == 4 && reviewText.activeSelf)
        {
            authorText.SetActive(true);
            reviewText.SetActive(false);

            videoPlayer1.Stop();
            videoPlayer2.Stop();

            video1.SetActive(false);
            video2.SetActive(false);

            current = 1;
        }

        else
        {

        }
        

        Debug.Log("Button Pressed");
        Debug.Log("Current is: " + current);

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
