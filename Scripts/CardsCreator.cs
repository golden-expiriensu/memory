using System.Collections.Generic;
using UnityEngine;

public class CardsCreator : MonoBehaviour
{
    [SerializeField] Card _cardOriginal;
    [SerializeField] Sprite[] _cardSprites;
    [SerializeField] Sprite[] _cardBacks;
    int _cardsCount;
    IdArrayCreator _idArrayCreator;

    public Card[] Create()
    {
        Card[] cards = CreateCards();
        Sprite[] sprites = RandomizeSprites();
        int[] ids = _idArrayCreator.Create(_cardsCount);

        ShuffleCards(cards, sprites, ids);

        return cards;
    }

    private void Awake()
    {
        _idArrayCreator = new IdArrayCreator();
    }

    private Card[] CreateCards()
    {
        _cardsCount = CardsAmountController.Instance.Amount;
        Card[] cards = new Card[_cardsCount];
        cards[0] = _cardOriginal;

        for (int i = 1; i < _cardsCount; i++)
        {
            cards[i] = Instantiate(_cardOriginal);
        }

        return cards;
    }

    private void ShuffleCards(Card[] cards, Sprite[] sprites, int[] ids)
    {
        for (int i = 0; i < _cardsCount; i++)
        {
            int id = ids[i];
            Sprite sprite = sprites[id];

            cards[i].SetCard(sprite, id);
        }
    }

    private Sprite[] RandomizeSprites()
    {
        int spritesCount = _cardsCount / 2;
        Sprite[] sprites = new Sprite[spritesCount];
        List<int> restrictedSprites = new List<int>(spritesCount);

        for (int i = 0; i < spritesCount; i++)
        {
            int spriteId;

            do spriteId = UnityEngine.Random.Range(0, _cardSprites.Length);
            while (restrictedSprites.Contains(spriteId));

            restrictedSprites.Add(spriteId);
            sprites[i] = _cardSprites[spriteId];
        }

        return sprites;
    }
}
