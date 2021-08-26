using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] Camera _camera;
    private void Awake()
    {
        _camera.orthographicSize = Screen.currentResolution.height / 2f / 100f;
    }
}
