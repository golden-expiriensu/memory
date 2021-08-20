using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreLabel;
    [SerializeField] TMP_Text _mistakeLabel;
    int _score = 0;
    int _mistakes = 0;


    public void AddScore()
    {
        _score++;
        UpdateScoreLabel();
    }

    public void ResetScore()
    {
        _score = 0;
        UpdateScoreLabel();
    }
    
    public void AddMistake()
    {
        _mistakes++;
        UpdateMistakeLabel();
    }

    public void ResetMistakes()
    {
        _mistakes = 0;
        UpdateMistakeLabel();
    }

    private void UpdateScoreLabel()
    {
        _scoreLabel.text = $"Guessed: {_score}";
    }

    private void UpdateMistakeLabel()
    {
        _mistakeLabel.text = $"Mistakes: {_mistakes}";
    }
}
