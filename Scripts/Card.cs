using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] RectTransform _rectTransform;
    public RectTransform rectTransform { get { return _rectTransform; } }

    [SerializeField] Image _nativeSize;
    [SerializeField] GameController _sceneController;
    [SerializeField] Image _face;
    [SerializeField] Image _back;
    [SerializeField] Image _whiteBackground;
    bool _hasWhiteBackground = false;
    bool _revealed = false;
    public int Id { get; private set; }

    public void SetCard(Sprite face, Sprite back, int id, bool needWhiteBackground)
    {
        InitFace(face);

        InitBack(back);

        if (needWhiteBackground)
            InitWhiteBackground();

        Id = id;
    }

    public void Click()
    {
        if (_sceneController.CanReveal && !_revealed)
        {
            Reveal();
            _sceneController.RevealCard(this);
        }
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

    private void InitFace(Sprite face)
    {
        _face.sprite = face;
        float faceScaleFactor = CalculateScaleFactor(_face);
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

    private float CalculateScaleFactor(Image sprite)
    {
        float W = sprite.rectTransform.rect.width;
        float H = sprite.rectTransform.rect.height;
        float ScaleXfactor = _nativeSize.rectTransform.rect.width / W;
        float ScaleYfactor = _nativeSize.rectTransform.rect.height / H;
        float ScaleFactor = ScaleXfactor > ScaleYfactor ? ScaleYfactor : ScaleXfactor;
        return ScaleFactor;
    }
}
