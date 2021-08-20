using UnityEngine;
using TMPro;

public class CardsAmountController : MonoBehaviour
{
    #region Singleton
    public static CardsAmountController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }        
    }
    #endregion

    public int Amount { get; private set; } = 8;

    public void SetDropdownCardsAmountValue()
    {
        TMP_Dropdown _dropdown = FindObjectOfType<TMP_Dropdown>();
        int value = 0;
        switch (Amount)
        {
            case 8:
                value = 0;
                break;
            case 12:
                value = 1;
                break;
            case 24:
                value = 2;
                break;
            case 32:
                value = 3;
                break;
        }

        _dropdown.onValueChanged.RemoveListener(ChangeCardsAmount);
        _dropdown.value = value;
        _dropdown.onValueChanged.AddListener(ChangeCardsAmount);
    }

    public void ChangeCardsAmount(int value)
    {
        switch (value)
        {
            case 0:
                Amount = 8;
                break;
            case 1:
                Amount = 12;
                break;
            case 2:
                Amount = 24;
                break;
            case 3:
                Amount = 32;
                break;
        }

        FindObjectOfType<SceneController>().Restart();
    }

}
