using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FramesAnimation : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Queue<Sprite> _sprites = new Queue<Sprite>();
    private FramesSprite _frames;

    public void SetFramesSprite(FramesSprite frames)
    {
        _frames = frames;
        _sprites = new Queue<Sprite>();

        for (int i = 0; i < _frames.SpritesCount; i++)
            _sprites.Enqueue(_frames.GetSprites(i));
    }

    private Sprite GetSprite()
    {
        if (_sprites.Count > 0)
            return _sprites.Dequeue();

        SetFramesSprite(_frames);
        return _sprites.Dequeue();
    }

    public void Play()
    {
        _image.sprite = GetSprite();
    }
}
