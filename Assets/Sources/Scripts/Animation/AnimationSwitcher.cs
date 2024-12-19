using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] private AnimationFramesData _framesData;
    [SerializeField] private SwitchAnimation _switchAnimation;

    private Queue<FramesSprite> _frames;
    private FramesAnimation _framesAnimation;
    private ClickAnimation _clickAnimation;

    public int FramesCount => _frames.Count;

    public void Init(FramesAnimation framesAnimation, ClickAnimation clickAnimation)
    {
        _clickAnimation = clickAnimation;
        _frames = new Queue<FramesSprite>();

        for (int i = 0; i < _framesData.Frames.Length; i++)
            _frames.Enqueue(_framesData.Frames[i]);

        _framesAnimation = framesAnimation;

        SetFrame();
    }

    private void SetFrame()
    {
        FramesSprite frame = _frames.Dequeue();
        _framesAnimation.SetFramesSprite(frame, frame.Scale);
        _clickAnimation.Reset();
    }

    public void Switch()
    {
        if (_frames.Count <= 0)
            return;

        SetFrame();
        _framesAnimation.Play();
    }

    public void SmoothSwitch()
    {
        if (_frames.Count <= 0)
            return;

        StartCoroutine(PlaySwitch());
    }

    private IEnumerator PlaySwitch()
    {
        _switchAnimation.Disable();
        yield return new WaitForSeconds(0.2f);
        Switch();
         _switchAnimation.PlayEnable();
    }
}
