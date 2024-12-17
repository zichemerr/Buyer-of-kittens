using UnityEngine;

[CreateAssetMenu(fileName = "FramesData", menuName = "FramesDat")]
public class AnimationFramesData : ScriptableObject
{
    [SerializeField] private FramesSprite[] _framesArray;

    public FramesSprite[] Frames => _framesArray;
}