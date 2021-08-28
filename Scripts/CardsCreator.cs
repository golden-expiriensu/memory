using System.Collections.Generic;
using UnityEngine;

public class CardsCreator : MonoBehaviour
{
    [SerializeField] Card _cardOriginal;
    [SerializeField] CardSkin[] _cardsSkins;
    [SerializeField] CardSkin _cardsGFX;
    [SerializeField] Material _background;
    int _cardsCount;
    IdArrayCreator _idArrayCreator;

    public Card[] Create()
    {
        SetDeckSkin();

        Card[] cards = CreateCards();
        Sprite[] sprites = RandomizeSprites();
        int[] ids = _idArrayCreator.Create(_cardsCount);

        SetCards(cards, sprites, ids);
        _background.color = _cardsGFX.GameFieldBackgroundColor;

        return cards;
    }

    private void Awake()
    {
        _idArrayCreator = new IdArrayCreator();
    }

    private void SetDeckSkin()
    {
        TableSkins.SkinName skin = TableSkins.Instance.GetSkin();
        foreach(CardSkin s in _cardsSkins)
        {
            if(s.SkinName == skin)
            {
                _cardsGFX = s;
                return;
            }
        }
    }

    private Card[] CreateCards()
    {
        _cardsCount = CardsAmountController.Instance.Amount;
        Card[] cards = new Card[_cardsCount];
        cards[0] = _cardOriginal;

        for (int i = 1; i < _cardsCount; i++)
        {
            cards[i] = Instantiate(_cardOriginal, _cardOriginal.transform.parent);
        }

        return cards;
    }

    private void SetCards(Card[] cards, Sprite[] sprites, int[] ids)
    {
        for (int i = 0; i < _cardsCount; i++)
        {
            int id = ids[i];
            Sprite sprite = sprites[id];
            cards[i].SetCard(sprite, _cardsGFX.CardBack, id, _cardsGFX.NeedWhiteBackground);
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

            do spriteId = Random.Range(0, _cardsGFX.CardsAmount());
            while (restrictedSprites.Contains(spriteId));

            restrictedSprites.Add(spriteId);
            sprites[i] = _cardsGFX.CardSprites[spriteId];
        }

        return sprites;
    }
}
