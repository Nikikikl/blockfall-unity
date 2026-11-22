
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject squarePiecePrefab;
    private PieceMovement activePiece;
    private bool[,] occupiedCells = new bool[10, 20];

    void Start()
    {
        SpawnPiece();
    }

    private bool CanSpawnPiece()
    {
        return IsCellFree(new Vector2Int(4, 18)) &&
               IsCellFree(new Vector2Int(5, 18)) &&
               IsCellFree(new Vector2Int(4, 19)) &&
               IsCellFree(new Vector2Int(5, 19));
    }

    private void SpawnPiece()
    {
        if (!CanSpawnPiece())
        {
            Debug.Log("Game Over!");
            return;
        }

        GameObject piece = Instantiate(
            squarePiecePrefab,
            new Vector3(-1, 8, 0),
            Quaternion.identity);

        activePiece = piece.GetComponent<PieceMovement>();
    }

    void Update()
    {
        if (activePiece != null && activePiece.IsLocked)
        {
            Debug.Log("Piece landed!");
            RegisterPiece(activePiece);
            activePiece = null;
            SpawnPiece();
        }
    }

    private Vector2Int WorldToCell(Vector3 position)
    {
        int x = Mathf.FloorToInt(position.x + 5);
        int y = Mathf.FloorToInt(position.y + 10);

        return new Vector2Int(x, y);
    }

    private void RegisterPiece(PieceMovement piece)
    {
        foreach (Transform block in piece.transform)
        {
            Vector2Int cell = WorldToCell(block.position);
            occupiedCells[cell.x, cell.y] = true;
        }
    }

    public bool IsCellFree(Vector2Int cell)
    {
        if (cell.x < 0 || cell.x >= 10 ||
            cell.y < 0 || cell.y >= 20)
        {
            return false;
        }

        return !occupiedCells[cell.x, cell.y];
    }
}
