using UnityEngine;

[CreateAssetMenu(fileName = "NewItemDefinition", menuName = "ScriptableObjects/Create Item Definition")]
public class ItemDefinition : ScriptableObject
{
    public enum EItemType
    {
        BuffItem,
        HealItem
    }

    [SerializeField]
    private EItemType itemType;

    [SerializeField]
    private string name;

    [SerializeField]
    private float effectValue;

    [SerializeField]
    private EParameterType parameterType;

    public EItemType ItemType { get => itemType; }
    public string Name { get => name; }
    public float EffectValue { get => effectValue; }
    public EParameterType ParameterType { get => parameterType; }
}