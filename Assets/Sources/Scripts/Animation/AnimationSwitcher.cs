using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    [SerializeField] private FramesSprite[] _framesArray;
    [SerializeField] private BuyingCat _buyingCat;

    private Queue<FramesSprite> _frames;
    private FramesAnimation _framesAnimation;

    public int FramesCount => _frames.Count;

    public void Init(FramesAnimation framesAnimation)
    {
        _frames = new Queue<FramesSprite>();

        for (int i = 0; i < _framesArray.Length; i++)
            _frames.Enqueue(_framesArray[i]);

        _framesAnimation = framesAnimation;
        _framesAnimation.SetFramesSprite(_frames.Dequeue());

        for (int i = 0; i < _buyingCat.BuyedCats; i++)
            Switch();
    }

    public void Switch()
    {
        if (_frames.Count <= 0)
            return;

        _framesAnimation.SetFramesSprite(_frames.Dequeue());
        _framesAnimation.Play();
    }
}