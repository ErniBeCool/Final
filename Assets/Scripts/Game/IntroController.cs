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
            Debug.LogError("Video Player не найден на объекте!");
            SceneManager.LoadScene("LoadingScreen");
            return;
        }

        if (videoPlayer.clip == null)
        {
            Debug.LogError("Видео не назначено в Video Player!");
            SceneManager.LoadScene("LoadingScreen");
            return;
        }

        Debug.Log($"Видео: {videoPlayer.clip.name}, Длительность: {videoPlayer.clip.length} сек, Разрешение: {videoPlayer.clip.width}x{videoPlayer.clip.height}");
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
        Debug.Log("Видео запущено");
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Видео завершено, переход на LoadingScreen");
        SceneManager.LoadScene("LoadingScreen");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("Видео пропущено пользователем");
            videoPlayer.Stop();
            SceneManager.LoadScene("LoadingScreen");
        }
    }
}