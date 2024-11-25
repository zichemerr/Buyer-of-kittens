using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimaion : MonoBehaviour
{
    [SerializeField] private FramesAnimation _framesAnimation;
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _clickDuration;

    private ClickAnimation _clickAnimation;

    public void Init()
    {
        _clickAnimation = new ClickAnimation(_transform, _scale, _clickDuration);
        _framesAnimation.Init();
    }

    public void Play()
    {
        _clickAnimation.Play();
        _framesAnimation.Play();
    }
}