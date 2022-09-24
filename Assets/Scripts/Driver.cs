using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    // [SerializeField] InputManager inputManager;
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 1f;
    Vector3 movement;
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMove(InputValue value)
    {
        var moveInput = value.Get<Vector2>();
        movement.y = moveInput.y;
        rotation.z = moveInput.x * -steerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, this.movement.y * moveSpeed * Time.deltaTime, 0);
        transform.Rotate(this.rotation * Time.deltaTime);
    }
}
