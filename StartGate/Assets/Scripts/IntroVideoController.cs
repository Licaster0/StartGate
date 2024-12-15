using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Video Player bile�eni
    public GameObject canvas;       // Canvas objesi
    public GameObject MenuObject;

    void Start()
    {
        // Video bitti�inde �a�r�lacak fonksiyon
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play(); // Video oynat�l�r
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Video bitti�inde Canvas'� devre d��� b�rak
        canvas.SetActive(false);
        MenuObject.SetActive(true);
    }
}
