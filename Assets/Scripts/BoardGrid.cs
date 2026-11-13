using UnityEngine;

public class BoardGrid : MonoBehaviour
{
    private const int Columns = 10;
    private const int Rows = 20;
    private const float LineWidth = 0.05f;

    private Sprite lineSprite;

    private void Start()
    {
        Debug.Assert(
            transform.position == Vector3.zero &&
            transform.rotation == Quaternion.identity &&
            transform.lossyScale == Vector3.one,
            "BoardGrid requires zero world position and rotation, and a scale of one.");

        lineSprite = Sprite.Create(
            Texture2D.whiteTexture,
            new Rect(0, 0, 1, 1),
            new Vector2(0.5f, 0.5f),
            1f,
            0,
            SpriteMeshType.FullRect);

        for (int column = 0; column <= Columns; column++)
        {
            CreateLine(
                "Vertical " + column,
                new Vector2(column - Columns / 2f, 0),
                new Vector2(LineWidth, Rows));
        }

        for (int row = 0; row <= Rows; row++)
        {
            CreateLine(
                "Horizontal " + row,
                new Vector2(0, row - Rows / 2f),
                new Vector2(Columns, LineWidth));
        }
    }

    private void CreateLine(string lineName, Vector2 position, Vector2 size)
    {
        GameObject line = new GameObject(lineName);
        line.transform.SetParent(transform, false);
        line.transform.localPosition = new Vector3(position.x, position.y, 0);
        line.transform.localScale = new Vector3(size.x, size.y, 1);

        SpriteRenderer renderer = line.AddComponent<SpriteRenderer>();
        renderer.sprite = lineSprite;
        renderer.color = Color.gray;
    }

    private void OnDestroy()
    {
        Destroy(lineSprite);
    }
}
