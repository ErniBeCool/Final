using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer == null)
        {
            Debug.LogError("Video Player �� ������ �� �������!");
            SceneManager.LoadScene("LoadingScreen");
            return;
        }

        if (videoPlayer.clip == null)
        {
            Debug.LogError("����� �� ��������� � Video Player!");
            SceneManager.LoadScene("LoadingScreen");
            return;
        }

        Debug.Log($"�����: {videoPlayer.clip.name}, ������������: {videoPlayer.clip.length} ���, ����������: {videoPlayer.clip.width}x{videoPlayer.clip.height}");
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
        Debug.Log("����� ��������");
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("����� ���������, ������� �� LoadingScreen");
        SceneManager.LoadScene("LoadingScreen");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("����� ��������� �������������");
            videoPlayer.Stop();
            SceneManager.LoadScene("LoadingScreen");
        }
    }
}