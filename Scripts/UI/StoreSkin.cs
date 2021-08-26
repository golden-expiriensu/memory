using UnityEngine;
using UnityEngine.UI;

public class StoreSkin : MonoBehaviour
{
    [SerializeField] CardSkin _skin;
    [SerializeField] Image _background;
    [SerializeField] Image[] _preview;
    [SerializeField] Image[] _previewBack;
    [SerializeField] TMPro.TMP_Text _name;
    [SerializeField] GameObject _unavailablePanel;

    private void Awake()
    {
        InitPreviews();

        InitNameAndFieldBackground();

        if (_skin.NeedWhiteBackground)
            InitWhiteBackground();

        UpdateUnavailablePanel();
    }

    private void InitNameAndFieldBackground()
    {
        _background.color = _skin.GameFieldBackgroundColor;
        _name.text = $"{_skin.Description} deck";
    }

    private void InitPreviews()
    {
        for (int i = 0; i < _preview.Length; i++)
            _preview[i].sprite = _skin.GetPreviewSprite(i);
    }

    private void InitWhiteBackground()
    {
        for (int i = 0; i < _previewBack.Length; i++)
            _previewBack[i].enabled = true;
    }

    private void UpdateUnavailablePanel() => _unavailablePanel.SetActive(!TableSkins.Instance.IsSkinAvailable(_skin.SkinName));

    public void SetSkin() => TableSkins.Instance.SetSkin(_skin.SkinName);
    public void UnlockSkin()
    {
        TableSkins.Instance.UnlockSkin(_skin.SkinName);
        UpdateUnavailablePanel();
    }
}
