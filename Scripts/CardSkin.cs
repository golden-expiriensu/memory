using UnityEngine;

public class CardSkin : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] TableSkins.SkinName _nameInDB;
    [SerializeField] Sprite[] _deckPreview;

    [SerializeField] Sprite[] _cardSprites;
    [SerializeField] Sprite _cardBack;
    [SerializeField] bool _needWhiteBackground;
    [SerializeField] Color _gameFieldBackGroundColor = Color.black;
    public Sprite[] CardSprites { get { return _cardSprites; } }
    public Sprite CardBack { get { return _cardBack; } }    
    public bool NeedWhiteBackground { get { return _needWhiteBackground; } }
    public Color GameFieldBackgroundColor { get { return _gameFieldBackGroundColor; } }
    public int CardsAmount() { return _cardSprites.Length; }


    public string Description { get { return _name; } }
    public TableSkins.SkinName SkinName { get { return _nameInDB; } }
    public Sprite GetPreviewSprite(int number)
    {
        if (number >= _deckPreview.Length)
            return null;
        else
            return _deckPreview[number];
    }
}
