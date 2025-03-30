using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraSetup : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        if (virtualCamera == null)
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            if (virtualCamera == null)
            {
                Debug.LogError("CinemachineVirtualCamera не найден на объекте!");
                return;
            }
        }

        // Увеличиваем задержку до 0.5 секунд
        Invoke("SetupCamera", 0.5f);
    }

    void SetupCamera()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null!");
            return;
        }

        if (GameManager.Instance.CharacterFactory == null)
        {
            Debug.LogError("CharacterFactory is null in GameManager!");
            return;
        }

        if (GameManager.Instance.CharacterFactory.Player == null)
        {
            Debug.LogError("Player is null in CharacterFactory! Камера не может найти игрока.");
            return;
        }

        virtualCamera.Follow = GameManager.Instance.CharacterFactory.Player.transform;
        Debug.Log("Камера привязана к игроку: " + GameManager.Instance.CharacterFactory.Player.name);

        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        if (transposer == null)
        {
            transposer = virtualCamera.AddCinemachineComponent<CinemachineTransposer>();
            transposer.m_FollowOffset = new Vector3(0, 5, -10); // Смещение камеры
        }
        else
        {
            transposer.m_FollowOffset = new Vector3(0, 5, -10); // Убеждаемся, что смещение установлено
        }
    }
}