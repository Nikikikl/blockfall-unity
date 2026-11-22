using UnityEngine;
using UnityEngine.InputSystem;

public class PieceMovement : MonoBehaviour
{
    private GameManager gameManager;
    private float fallInterval = 1f;
    private float softDropInterval = 0.1f;
    private float fallTimer = 0f;
    private bool isLocked = false;

    public bool IsLocked
    {
        get { return isLocked; }
    }
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private bool CanMove(Vector3 direction)
    {
        foreach (Transform block in transform)
        {
            Vector3 newPosition = block.position + direction;

            Vector2Int cell = new Vector2Int(
                Mathf.FloorToInt(newPosition.x + 5),
                Mathf.FloorToInt(newPosition.y + 10)
            );

            if (!gameManager.IsCellFree(cell))
            {
                return false;
            }
        }

        return true;
    }
    void Update()
    {
        if (isLocked)
        {
            return;
        }

        float currentInterval = fallInterval;

        if (Keyboard.current != null &&
            Keyboard.current.downArrowKey.isPressed)
        {
            currentInterval = softDropInterval;
        }

        fallTimer += Time.deltaTime;

        if (fallTimer >= currentInterval && CanMove(Vector3.down))
        {
            transform.position += Vector3.down;
            fallTimer = 0f;
        }

        if (!CanMove(Vector3.down))
        {
            isLocked = true;
            return;
        }

        if (Keyboard.current != null &&
            Keyboard.current.leftArrowKey.wasPressedThisFrame &&
            CanMove(Vector3.left))
        {
            transform.position += Vector3.left;
        }

        if (Keyboard.current != null &&
            Keyboard.current.rightArrowKey.wasPressedThisFrame &&
            CanMove(Vector3.right))
        {
            transform.position += Vector3.right;
        }

        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            while (CanMove(Vector3.down))
            {
                transform.position += Vector3.down;
            }

            isLocked = true;
        }
    }
}