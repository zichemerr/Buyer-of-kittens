using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FramesAnimation : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Vector2 _currentScale;

    private Queue<Sprite> _sprites;
    private FramesSprite _frames;

    public void SetFramesSprite(FramesSprite frames, Vector2 scale)
    {
        _frames = frames;
        _currentScale = scale;
        _image.transform.localScale = scale;

        _sprites = new Queue<Sprite>();

        for (int i = 0; i < _frames.SpritesCount; i++)
            _sprites.Enqueue(_frames.GetSprites(i));
    }

    private Sprite GetSprite()
    {
        if (_sprites.Count > 0)
            return _sprites.Dequeue();

        SetFramesSprite(_frames, _currentScale);
        return _sprites.Dequeue();
    }

    public void Play()
    {
        _image.sprite = GetSprite();
    }
}
