using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public Slider loadingSlider; // Ползунок загрузки
    public TMP_Text loadingText;     // Текст "Загрузка"
    private static string targetScene; // Сцена, которую нужно загрузить

    void Start()
    {
        if (loadingSlider == null || loadingText == null)
        {
            Debug.LogError("Не все элементы UI назначены в LoadingScreen!");
            return;
        }

        // Если это первый запуск после интро, переходим в MainMenu
        if (string.IsNullOrEmpty(targetScene))
        {
            targetScene = "MainMenu";
        }

        // Запускаем асинхронную загрузку
        StartCoroutine(LoadSceneAsync());
    }

    // Статический метод для установки целевой сцены
    public static void LoadScene(string sceneName)
    {
        targetScene = sceneName;
        SceneManager.LoadScene("LoadingScreen");
    }

    private System.Collections.IEnumerator LoadSceneAsync()
    {
        // Асинхронная загрузка целевой сцены
        AsyncOperation operation = SceneManager.LoadSceneAsync(targetScene);
        operation.allowSceneActivation = true;

        while (!operation.isDone)
        {
            // Обновляем ползунок (progress от 0 до 1)
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // 0.9 — максимальный прогресс до активации
            loadingSlider.value = progress;
            loadingText.text = "Загрузка " + (progress * 100).ToString("F0") + "%";
            yield return null;
        }
    }
}