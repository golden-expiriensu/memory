using UnityEngine;

public class Score : MonoBehaviour
{
    #region Singleton
    public static Score Instance { get; private set; }

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

    public int Guessed { get; private set; } = 0;
    public int Mistakes { get; private set; } = 0;

    UI _ui;

    public void SetUI(UI ui)
    {
        _ui = ui;
    }

    public void AddScore()
    {
        Guessed++;
        _ui.UpdateScoreLabel();
    }

    public void AddMistake()
    {
        Mistakes++;
        _ui.UpdateMistakeLabel();
    }

    public void ResetScore()
    {
        Guessed = 0;
        _ui.UpdateScoreLabel();
    }

    public void ResetMistakes()
    {
        Mistakes = 0;
        _ui.UpdateMistakeLabel();
    }
}
