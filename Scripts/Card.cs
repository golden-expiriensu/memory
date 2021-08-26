using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] BoxCollider2D _cardCollider;
    [SerializeField] GameController _sceneController;
    [SerializeField] SpriteRenderer _face;
    [SerializeField] SpriteRenderer _back;
    [SerializeField] SpriteRenderer _whiteBackground;
    bool _hasWhiteBackground = false;
    readonly float _faceWithWhiteBackgroundScaleFactor = .9f;
    bool _revealed = false;
    public int Id { get; private set; }

    public void SetCard(Sprite face, Sprite back, int id, bool needWhiteBackground)
    {
        InitFace(face, needWhiteBackground);

        InitBack(back);

        if (needWhiteBackground)
            InitWhiteBackground();

        Id = id;
    }

    public void Unreveal()
    {
        _back.gameObject.SetActive(true);

        _face.gameObject.SetActive(false);
        if (_hasWhiteBackground) _whiteBackground.gameObject.SetActive(false);

        _revealed = false;
    }

    private void Reveal()
    {
        _back.gameObject.SetActive(false);

        _face.gameObject.SetActive(true);
        if (_hasWhiteBackground) _whiteBackground.gameObject.SetActive(true);

        _revealed = true;
    }

    private void OnMouseDown()
    {
        if (_sceneController.CanReveal && !_revealed)
        {
            Reveal();
            _sceneController.RevealCard(this);
        }
    }

    private void InitFace(Sprite face, bool needWhiteBackground)
    {
        _face.sprite = face;
        float faceScaleFactor = CalculateScaleFactor(_face);
        if (needWhiteBackground)
            faceScaleFactor *= _faceWithWhiteBackgroundScaleFactor;
        _face.transform.localScale = new Vector3(faceScaleFactor, faceScaleFactor, faceScaleFactor);
    }

    private void InitBack(Sprite back)
    {
        _back.sprite = back;
        float backScaleFactor = CalculateScaleFactor(_back);
        _back.transform.localScale = new Vector3(backScaleFactor, backScaleFactor, backScaleFactor);
    }

    private void InitWhiteBackground()
    {
        _hasWhiteBackground = true;
        float s = CalculateScaleFactor(_whiteBackground);
        _whiteBackground.transform.localScale = new Vector3(s, s, s);
    }

    private float CalculateScaleFactor(SpriteRenderer sprite)
    {
        float W = sprite.size.x;
        float H = sprite.size.y;
        float ScaleXfactor = _cardCollider.size.x / W;
        float ScaleYfactor = _cardCollider.size.y / H;
        float ScaleFactor = ScaleXfactor > ScaleYfactor ? ScaleYfactor : ScaleXfactor;
        return ScaleFactor;
    }
}
