using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreLabel;
    [SerializeField] TMP_Text _mistakeLabel;

    private void Start()
    {
        Score.Instance.SetUI(this);
        UpdateScoreLabel();
        UpdateMistakeLabel();
    }

    public void UpdateScoreLabel()
    {
        _scoreLabel.text = $"Guessed: {Score.Instance.Guessed}";
    }

    public void UpdateMistakeLabel()
    {
        _mistakeLabel.text = $"Mistakes: {Score.Instance.Mistakes}";
    }

    public void ResetScoreButtonClick()
    {
        Score.Instance.ResetScore();
        Score.Instance.ResetMistakes();
    }
}
