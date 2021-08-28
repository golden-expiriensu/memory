using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameUI _uI;
    [SerializeField] CardDealer _dealer;
    [SerializeField] CardsCreator _cardsCreator;

    public bool CanReveal { get; private set; } = true;
    Card _firstRevealed;
    Card _secondRevealed;
    readonly float _cardShowingTime = .5f;

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        Card[] cards = _cardsCreator.Create();
        float cardScale = _dealer.DealCards(cards);
        ScaleCards(cards, cardScale);
    }

    private static void ScaleCards(Card[] cards, float cardScale)
    {
        if (cardScale == 1f)
            return;

        foreach (Card card in cards)
        {
            card.rectTransform.localScale = new Vector3(cardScale, cardScale, cardScale);
        }
    }

    public void RevealCard(Card card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.Id == _secondRevealed.Id)
        {
            Score.Instance.AddScore();
        }
        else
        {
            CanReveal = false;
            yield return new WaitForSeconds(_cardShowingTime);
            Score.Instance.AddMistake();
            CanReveal = true;

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
