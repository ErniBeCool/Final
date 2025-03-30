using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public Slider loadingSlider; // �������� ��������
    public TMP_Text loadingText;     // ����� "��������"
    private static string targetScene; // �����, ������� ����� ���������

    void Start()
    {
        if (loadingSlider == null || loadingText == null)
        {
            Debug.LogError("�� ��� �������� UI ��������� � LoadingScreen!");
            return;
        }

        // ���� ��� ������ ������ ����� �����, ��������� � MainMenu
        if (string.IsNullOrEmpty(targetScene))
        {
            targetScene = "MainMenu";
        }

        // ��������� ����������� ��������
        StartCoroutine(LoadSceneAsync());
    }

    // ����������� ����� ��� ��������� ������� �����
    public static void LoadScene(string sceneName)
    {
        targetScene = sceneName;
        SceneManager.LoadScene("LoadingScreen");
    }

    private System.Collections.IEnumerator LoadSceneAsync()
    {
        // ����������� �������� ������� �����
        AsyncOperation operation = SceneManager.LoadSceneAsync(targetScene);
        operation.allowSceneActivation = true;

        while (!operation.isDone)
        {
            // ��������� �������� (progress �� 0 �� 1)
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // 0.9 � ������������ �������� �� ���������
            loadingSlider.value = progress;
            loadingText.text = "�������� " + (progress * 100).ToString("F0") + "%";
            yield return null;
        }
    }
}