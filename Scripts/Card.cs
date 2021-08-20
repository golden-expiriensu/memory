using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] SceneController _sceneController;
    [SerializeField] SpriteRenderer _face;
    [SerializeField] GameObject _back;
    bool _revealed = false;
    public int Id { get; private set; }

    public void SetCard(Sprite sprite, int id)
    {
        _face.sprite = sprite;
        Id = id;
    }
    
    public void Unreveal()
    {
        _back.SetActive(true);
        _revealed = false;
    }

    private void Reveal()
    {
        _back.SetActive(false);
        _revealed = true;
    }

    private void OnMouseUp()
    {
        if (_sceneController.CanReveal && !_revealed)
        {
            Reveal();
            _sceneController.RevealCard(this); 
        }
    }
}
