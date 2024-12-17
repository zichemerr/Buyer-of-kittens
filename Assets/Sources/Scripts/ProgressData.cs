using UnityEngine;

[CreateAssetMenu(fileName = "Progress", menuName = "ProgressData")]
public class ProgressData : ScriptableObject
{
    [field: SerializeField] public int[] RewardsArray { get; private set; }
    [field: SerializeField] public int MaxValue { get; private set; }
    [field: SerializeField] public int Value { get; private set; }
    [field: SerializeField] public int Level { get; private set; }
}
