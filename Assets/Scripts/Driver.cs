using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    public float moveSpeed = 20f;
    public float slowSpeed = 15f;
    public float boostSpeed = 30f;
    Vector3 movement;
    Vector3 rotation;

    void OnMove(InputValue value)
    {
        var moveInput = value.Get<Vector2>();
        movement.y = moveInput.y;
        rotation.z = moveInput.x * -steerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, movement.y * moveSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation * Time.deltaTime);
    }
}
