using UnityEngine;
using UnityEngine.InputSystem;

public class PieceMovement : MonoBehaviour
{
    private float fallInterval = 1f;
    private float softDropInterval = 0.1f;
    private float fallTimer = 0f;
    void Update()
    {
        float currentInterval = fallInterval;

        if (Keyboard.current != null &&
            Keyboard.current.downArrowKey.isPressed)
        {
            currentInterval = softDropInterval;
        }

        fallTimer += Time.deltaTime;

        if (fallTimer >= currentInterval && transform.position.y > -10)
        {
            transform.position += Vector3.down;
            fallTimer = 0f;
        }

        if (Keyboard.current != null &&
            Keyboard.current.leftArrowKey.wasPressedThisFrame &&
            transform.position.x > -5)
        {
            transform.position += Vector3.left;
        }

        if (Keyboard.current != null &&
            Keyboard.current.rightArrowKey.wasPressedThisFrame &&
            transform.position.x < 3)
        {
            transform.position += Vector3.right;
        }

        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            while (transform.position.y > -10)
            {
                transform.position += Vector3.down;
            }
        }
    }
}