using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    [SerializeField] float flipSpeed = .25f;
    Vector3 flip180 = new Vector3(0, 180, 0);

    RectTransform _willBeVisible;
    RectTransform _willNotBeVisible;
    Vector3 currentVelocity1;
    Vector3 currentVelocity2;

    bool needAnimate = false;

    private void Update()
    {
        if (needAnimate)
            AnimateFlip();
    }

    private void AnimateFlip()
    {
        _willNotBeVisible.eulerAngles =
            Vector3.SmoothDamp(_willNotBeVisible.eulerAngles, flip180, ref currentVelocity1, flipSpeed);
        _willBeVisible.eulerAngles =
            Vector3.SmoothDamp(_willBeVisible.eulerAngles, Vector3.zero, ref currentVelocity2, flipSpeed);

        if (_willBeVisible.eulerAngles.y < 90)
        {
            _willNotBeVisible.gameObject.SetActive(false);
            _willBeVisible.gameObject.SetActive(true);
        }

        if (_willBeVisible.eulerAngles == Vector3.zero)
            needAnimate = false;
    }

    public void Flip(RectTransform willBeVisible, RectTransform willNotBeVisible)
    {
        willBeVisible.eulerAngles = flip180;
        willNotBeVisible.eulerAngles = Vector3.zero;

        _willBeVisible = willBeVisible;
        _willNotBeVisible = willNotBeVisible;

        needAnimate = true;
    }
}
