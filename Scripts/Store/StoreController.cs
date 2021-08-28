using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    [SerializeField] RectTransform _storeContent;
    [SerializeField] GridLayoutGroup _contentGrid;
    [SerializeField] GameObject _skinPrefab;
    [SerializeField] CardSkin[] _skins;

    private void Awake()
    {
        InstantiateContent();
        TuneStoreContentHeight();
    }

    private void InstantiateContent()
    {
        foreach (CardSkin skin in _skins)
        {
            GameObject obj = Instantiate(_skinPrefab, _storeContent);
            obj.GetComponent<StoreSkin>().SetCardSkin(skin);
        }
    }

    private void TuneStoreContentHeight()
    {
        _storeContent.sizeDelta = new Vector2(
                    _storeContent.sizeDelta.x,
                    (_contentGrid.cellSize.y + _contentGrid.spacing.y) * _skins.Length
                    );
    }
}
