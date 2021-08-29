using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : UI
{
    [SerializeField] GameController _game;
    [SerializeField] TMP_Text _scoreLabel;
    [SerializeField] TMP_Text _mistakeLabel;
    [SerializeField] TMP_Text _gmLabel; // (guessed / mistakes)
    [SerializeField] GameObject _menu;
    public bool MenuOpen { get; private set; } = false;


    private void Start()
    {
        Score.Instance.SetUI(this);
        UpdateScoreLabel();
        UpdateMistakeLabel();
        CardsAmountController.Instance.SetDropdownCardsAmountValue();
    }

    public void UpdateScoreLabel()
    {
        _scoreLabel.text = $"Guessed: {Score.Instance.Guessed}";
        UpdateGMLabel();
    }
    public void UpdateMistakeLabel()
    {
        _mistakeLabel.text = $"Mistakes: {Score.Instance.Mistakes}";
        UpdateGMLabel();
    }
    private void UpdateGMLabel()
    {
        if (Score.Instance.Mistakes == 0)
            _gmLabel.text = "G/M: -";
        else
            _gmLabel.text = $"G/M: {string.Format("{0:0.##}", (float)Score.Instance.Guessed / (float)Score.Instance.Mistakes)}";
    }

    public void Restart() => _game.Restart();

    public void ResetScore()
    {
        Score.Instance.ResetScore();
        Score.Instance.ResetMistakes();
    }

    public void Menu()
    {
        MenuOpen = !MenuOpen;
        _menu.SetActive(MenuOpen);
    }

    public void SkinStore()
    {
        SceneManager.LoadScene("Store");
    }

    public void Achievements() { }

    public void Exit() => Application.Quit();
}
