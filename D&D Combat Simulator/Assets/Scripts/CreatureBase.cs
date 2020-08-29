using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBase : MonoBehaviour
{
    [Header("Ability Scores")]
    [SerializeField] private int baseStrength;
    [SerializeField] private int baseDexterity;
    [SerializeField] private int baseConstitution;
    [SerializeField] private int baseIntelligence;
    [SerializeField] private int baseWisdom;
    [SerializeField] private int baseCharisma;

    [SerializeField] private List<int> baseAbilityScoreList = new List<int>();
    [SerializeField] private List<int> currentAbilityScoreList = new List<int>();
    [SerializeField] private List<int> abilityScoreModifierList = new List<int>();

    [Header("Base stats")]
    [SerializeField] private int baseHP;
    [SerializeField] private int currentHP;
    [SerializeField] private int baseAC;
    [SerializeField] private int currentAC;
    [SerializeField] private int baseMovementSpeed;
    [SerializeField] private int currentMovementSpeed;

    private CreatureBase() 
    {
        FillBaseAbilityScoreList();
        SetCurrentAttributes();
        CalculateCurrentAbilityScoreModifiers();
    }

    private void FillBaseAbilityScoreList()
    {
        baseAbilityScoreList[0] = baseStrength;
        baseAbilityScoreList[1] = baseDexterity;
        baseAbilityScoreList[2] = baseConstitution;
        baseAbilityScoreList[3] = baseIntelligence;
        baseAbilityScoreList[4] = baseWisdom;
        baseAbilityScoreList[5] = baseCharisma;
    }

    private void SetCurrentAttributes() 
    {
        for (int i = 0; i < baseAbilityScoreList.Count; i++)
        {
            currentAbilityScoreList[i] = baseAbilityScoreList[i];
        }
    }

    private void CalculateCurrentAbilityScoreModifiers() 
    {
        for (int i = 0; i < currentAbilityScoreList.Count; i++)
        {
            abilityScoreModifierList[i] = CalculateAbilityScoreModifier(currentAbilityScoreList[i]);
        }
    }

    private int CalculateAbilityScoreModifier(int currentAttribute) 
    {
        return Mathf.FloorToInt((float)currentAttribute / 2f) - 5;
    }
}
