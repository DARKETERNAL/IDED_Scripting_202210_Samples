using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterDefinition", menuName = "ScriptableObjects/Create Character Definition")]
public class CharacterDefinition : ScriptableObject
{
    [SerializeField]
    private string name;

    [SerializeField]
    private int hp;

    [SerializeField]
    private float atk;

    [SerializeField]
    private float def;

    [SerializeField]
    private float spec;

    public string Name { get => name; }
    public float Atk { get => atk; }
    public float Def { get => def; }
    public float Spec { get => spec; }
    public int Hp { get => hp; }
}