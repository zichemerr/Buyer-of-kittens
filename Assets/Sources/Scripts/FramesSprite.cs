using UnityEngine;
using System;

[Serializable]
public struct FramesSprite
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Vector2 _scale;

    public int SpritesCount => _sprites.Length;
    public Vector2 Scale => _scale;

    public Sprite GetSprites(int index)
    {
        return _sprites[index];
    }
}