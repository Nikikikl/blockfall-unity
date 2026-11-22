using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject squarePiecePrefab;
    private PieceMovement activePiece;

    void Start()
    {
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
            activePiece = null;
        }
    }
}