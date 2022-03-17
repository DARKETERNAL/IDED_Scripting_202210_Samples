using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterDefinition characterDefinition;

    private Character character;

    // Start is called before the first frame update
    private void Start()
    {
        character = new Character(characterDefinition.Name, characterDefinition.Hp, characterDefinition.Atk, characterDefinition.Def, characterDefinition.Spec);
    }
}