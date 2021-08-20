using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreLabel;
    [SerializeField] TMP_Text _mistakeLabel;
    [SerializeField] Camera _camera;


    private void Awake()
    {
        _camera.orthographicSize = Screen.currentResolution.height / 2f / 100f;
    }
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
