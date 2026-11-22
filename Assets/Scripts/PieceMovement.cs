using UnityEngine;
using UnityEngine.InputSystem;

public class PieceMovement : MonoBehaviour
{
    void Update()
    {
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