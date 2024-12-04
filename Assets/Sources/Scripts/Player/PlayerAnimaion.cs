using UnityEngine;

public class PlayerAnimaion : MonoBehaviour
{
    [SerializeField] private FramesAnimation _frames;
    [SerializeField] private AnimationSwitcher _switcher;
    [SerializeField] private SwingAnimation _swing;
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private float _clickDuration;

    private ClickAnimation _clickAnimation;

    public void Init()
    {
        _clickAnimation = new ClickAnimation(_transform, _scale, _clickDuration);
        _switcher.Init(_frames);
        _swing.Init();
        _swing.Play();
    }

    public void Play()
    {
        _clickAnimation.Play();
        _frames.Play();
    }
}
