using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterDefinition characterDefinition;

    private Character character;

    // Start is called before the first frame update
    private void Start()
    {
        character = InstantiateCharacter(characterDefinition);
    }

    public static Character InstantiateCharacter(CharacterDefinition definition)
    {
        return new Character(definition.Name, definition.Hp, definition.Atk, definition.Def, definition.Spec);
    }
}