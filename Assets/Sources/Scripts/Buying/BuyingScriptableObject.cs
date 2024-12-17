using UnityEngine;

[CreateAssetMenu(fileName = "BuyingData", menuName = "Data")]
public class BuyingScriptableObject : ScriptableObject
{
    [field: SerializeField] public Product[] Products { get; private set; }
}
