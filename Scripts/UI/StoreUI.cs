using UnityEngine.SceneManagement;

public class StoreUI : UI
{
    public void BackToGame() => SceneManager.LoadScene("Main");
}
