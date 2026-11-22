using UnityEngine;
using UnityEngine.InputSystem;

public class PieceMovement : MonoBehaviour
{
    private float fallInterval = 1f;
    private float fallTimer = 0f;
    void Update()
    {
        fallTimer += Time.deltaTime;
        if (fallTimer >= fallInterval && transform.position.y > -10)
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
    }
}