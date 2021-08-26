using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    [SerializeField] BoxCollider2D _cardCollider;

    int cardsAmount;
    Vector2 _cardSize;
    Dictionary<int, Vector2Int> _distributionColomnRow = new Dictionary<int, Vector2Int>
    {
        {8, new Vector2Int(4, 2) },
        {12, new Vector2Int(6, 2) },
        {18, new Vector2Int(6, 3) },
        {24, new Vector2Int(8, 3) },
        {30, new Vector2Int(10, 3) },
    };
    Vector2 _startOffset = Vector2.zero;
    Vector2 _offset = new Vector2(.2f, .1f);

    [SerializeField] RectTransform _uIField;

    private void Awake()
    {
        _cardSize = new Vector2(_cardCollider.size.x, _cardCollider.size.y);
    }

    public float DealCards(Card[] cards)
    {
        cardsAmount = cards.Length;

        int cols = _distributionColomnRow[cardsAmount].x;
        int rows = _distributionColomnRow[cardsAmount].y;
        float cardsScaleFactor = CalculateCardsScale(cols, rows);

        MoveCards(cards, cardsScaleFactor, cols, rows);

        return cardsScaleFactor;
    }

    private float CalculateCardsScale(int cols, int rows)
    {
        float cardsScaleFactor = 1f;

        float width = Screen.width / 100f;
        float xStep = width / cols;
        float height = (Screen.height - _uIField.rect.height) / 100f;
        float yStep = height / rows;
        
        if (yStep < _cardSize.y * cardsScaleFactor)
        {
            cardsScaleFactor = yStep / (_cardSize.y + _offset.y);
        }
        if (xStep < _cardSize.x * cardsScaleFactor)
        {
            cardsScaleFactor = xStep / (_cardSize.x + _offset.x);
        }
        _startOffset.x = (Screen.width / 100f - _cardSize.x * cardsScaleFactor * cols - _offset.x * (cols - 1)) / 2f;
        _startOffset.y = (Screen.height / 100f - _cardSize.y * cardsScaleFactor * rows - _offset.y * (rows - 1) - _uIField.rect.height / 200f) / 2f;

        return cardsScaleFactor;
    }

    private void MoveCards(Card[] cards, float cardsScaleFactor, int cols, int rows)
    {
        float z = cards[0].transform.position.z;
        int cardNumber = 0;

        for (int i = 0; i < cols; i++)
            for (int j = 0; j < rows; j++)
            {
                float posX = _startOffset.x + (_offset.x * i) + (_cardSize.x * cardsScaleFactor * i) - Screen.width / 200f;
                float posY = _startOffset.y + (_offset.y * j) + (_cardSize.y * cardsScaleFactor * j) - Screen.height / 200f;
                cards[cardNumber].transform.position = new Vector3(posX, posY, z);
                cardNumber++;
            }
    }
}
