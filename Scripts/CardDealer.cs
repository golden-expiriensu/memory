using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDealer : MonoBehaviour
{
    [SerializeField] RectTransform _card;
    [SerializeField] GridLayoutGroup _grid;
    [SerializeField] RectTransform _gameField;

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
        int numberOfCards = cards.Length;

        float cardsScaleFactor = CalculateCardsScale(numberOfCards);

        CreatePaddings(numberOfCards, cardsScaleFactor);
        TuneTheGrid(numberOfCards, cardsScaleFactor);

        return cardsScaleFactor;
    }

    private float CalculateCardsScale(int numberOfCards)
    {
        Vector2 cellSpace = DefineCellSpace(numberOfCards);
        Vector2 cell = new Vector2(
            _card.rect.width + _grid.spacing.x,
            _card.rect.height + _grid.spacing.y
            );

        float cardsScaleFactor = cellSpace.y / cell.y;
        
        if (cellSpace.x < cell.x * cardsScaleFactor)
        {
            cardsScaleFactor = cellSpace.x / cell.x;
        }
        
        return cardsScaleFactor;
    }

    private Vector2 DefineCellSpace(int numberOfCards)
    {
        float width = _gameField.rect.width;
        float height = _gameField.rect.height;
        int cols = _cardNumberToColumnNumber[numberOfCards];
        int rows = numberOfCards / cols;
        Vector2 grid = new Vector2(width / cols, height / rows);
        return grid;
    }

    private void TuneTheGrid(int numberOfCards, float cardsScaleFactor)
    {
        _grid.cellSize = new Vector2(_card.rect.width, _card.rect.height) * cardsScaleFactor;
        _grid.spacing *= cardsScaleFactor;
        _grid.constraintCount = _cardNumberToColumnNumber[numberOfCards];
    }

    private void CreatePaddings(int numberOfCards, float cardsScaleFactor)
    {
        Vector2 padding = Vector2.zero;
        int cols = _cardNumberToColumnNumber[numberOfCards];
        int rows = numberOfCards / cols;

        float cardsWidth = (_grid.spacing.x * (cols - 1) + _card.rect.width * cols) * cardsScaleFactor;
        padding.x = (_gameField.rect.width - cardsWidth) / 2f;

        float cardsHeight = (_grid.spacing.y * (rows - 1) + _card.rect.height * rows) * cardsScaleFactor;
        padding.y = (_gameField.rect.height - cardsHeight) / 2f;

        _grid.padding.left = (int)padding.x;
        _grid.padding.top = (int)padding.y;
    }
}
