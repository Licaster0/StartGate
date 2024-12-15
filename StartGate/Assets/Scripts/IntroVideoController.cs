using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Video Player bileþeni
    public GameObject canvas;       // Canvas objesi
    public GameObject MenuObject;

    void Start()
    {
        // Video bittiðinde çaðrýlacak fonksiyon
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play(); // Video oynatýlýr
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Video bittiðinde Canvas'ý devre dýþý býrak
        canvas.SetActive(false);
        MenuObject.SetActive(true);
    }
}
