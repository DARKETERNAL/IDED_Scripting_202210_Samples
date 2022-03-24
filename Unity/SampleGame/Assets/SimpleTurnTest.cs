using UnityEngine;

public class SimpleTurnTest : MonoBehaviour
{
    private enum EActionType
    {
        Attack,
        Block,
        Skill,
        Item
    }

    [SerializeField]
    private CharacterDefinition characterDefA;

    [SerializeField]
    private CharacterDefinition characterDefB;

    [SerializeField]
    private EActionType actionToPerform;

    [SerializeField]
    private bool performSpecialAttack = false;

    private Character characterA;
    private Character characterB;

    // Start is called before the first frame update
    private void Start()
    {
        characterA = CharacterBehavior.InstantiateCharacter(characterDefA);
        characterB = CharacterBehavior.InstantiateCharacter(characterDefB);

        characterA.AssignTargetCharacter(characterB);
        characterB.AssignTargetCharacter(characterA);

        switch (actionToPerform)
        {
            case EActionType.Attack:
                if (performSpecialAttack)
                {
                    characterA.PerformSpecialAttack();
                }
                else
                {
                    characterA.PerformAttack();
                }
                break;

            case EActionType.Block:
                characterA.BlockAttack();
                break;

            case EActionType.Skill:
                //characterA.PermformSkill(/*which?*/);
                break;

            case EActionType.Item:
                //characterA.UseItem(/*which*/);
                break;

            default:
                characterA.PerformAttack();
                break;
        }
    }
}