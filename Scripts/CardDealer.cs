using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDealer : MonoBehaviour
{
    [SerializeField] RectTransform _card;
    [SerializeField] GridLayoutGroup _grid;
    [SerializeField] RectTransform _gridSize;

    Dictionary<int, int> _cardNumberToColumnNumber = new Dictionary<int, int>
    {
        {8,  4},
        {12, 6},
        {18, 6},
        {24, 8},
        {30, 10},
    };

    public float DealCards(Card[] cards)
    {
        int cardsNumber = cards.Length;

        float cardsScaleFactor = CalculateCardsScale(cardsNumber);

        return cardsScaleFactor;
    }

    private float CalculateCardsScale(int cardsNumber)
    {
        Vector2 grid = CreateGrid(cardsNumber);

        float cardsScaleFactor = grid.y / (_card.rect.height + _grid.spacing.y);
        
        if (grid.x < (_card.rect.width * cardsScaleFactor + _grid.spacing.x))
        {
            cardsScaleFactor = (grid.x - _grid.spacing.x) / (_card.rect.width);
        }
        
        _grid.cellSize = new Vector2(_card.rect.width, _card.rect.height) * cardsScaleFactor;
        _grid.constraintCount = _cardNumberToColumnNumber[cardsNumber];
        return cardsScaleFactor;
    }

    private Vector2 CreateGrid(int cardsNumber)
    {
        float width = _gridSize.rect.width;
        float height = _gridSize.rect.height;
        int cols = _cardNumberToColumnNumber[cardsNumber];
        return new Vector2(width / cols, height / (cardsNumber / cols));
    }
}
