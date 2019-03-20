using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class streamVideo : MonoBehaviour
{
    public RawImage rawimage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    void Start()
    {
        StartCoroutine(PlayVideo());
    }
IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawimage.texture = videoPlayer.texture;
        videoPlayer.Play();
        //audioSource.Play();
    }
}
