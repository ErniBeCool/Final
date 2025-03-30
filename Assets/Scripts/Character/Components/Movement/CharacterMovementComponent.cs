using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementComponent : IMovable
{
    private CharacterData characterData;
    private float speed;
    private Vector3 velocity;
    private float gravity = -9.81f;

    public float Speed { 
        get => speed; 
        set 
        {
            if (value <0)
                return;
            speed = value;
        } 
    }

    public void Initialize(CharacterData characterData)
    {
        this.characterData = characterData;
        speed = characterData.DefaultSpeed;
        velocity = Vector3.zero;
    }

    public void Move(Vector3 direction)
    {
        if (characterData == null || characterData.CharacterController == null) return;

        // Ќормализуем направление, если оно не нулевое
        Vector3 move = direction.normalized * Speed;

        // ѕримен€ем гравитацию
        if (!characterData.CharacterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f; // —брасываем скорость падени€, если на земле
        }

        // ƒобавл€ем вертикальную скорость (гравитацию) к движению
        move += velocity;

        // ¬ыполн€ем движение через CharacterController
        characterData.CharacterController.Move(move * Time.deltaTime);

    }

    public void Rotation(Vector3 direction)
    {
        if (direction == Vector3.zero || characterData == null || characterData.CharacterTransform == null) return;

        float smooth = 0.1f;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(characterData.CharacterTransform.eulerAngles.y, targetAngle, ref smooth, smooth);
        characterData.CharacterTransform.rotation = Quaternion.Euler(0, angle, 0);
    }
}