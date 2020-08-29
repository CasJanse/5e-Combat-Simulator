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

    [SerializeField] private List<int> baseAbilityScoreList = new List<int>(6);
    [SerializeField] private List<int> currentAbilityScoreList = new List<int>(6);
    [SerializeField] private List<int> abilityScoreModifierList = new List<int>(6);

    [Header("Base stats")]
    [SerializeField] private int baseHP;
    [SerializeField] private int currentHP;
    [SerializeField] private int baseAC;
    [SerializeField] private int currentAC;
    [SerializeField] private int baseMovementSpeed;
    [SerializeField] private int currentMovementSpeed;


    private void Awake()
    {
        FillBaseAbilityScoreList();
        FillInitialCurrentAbilityScoreList();
        FillInitialAbilityScoreModifiers();
    }

    #region List Initialisation
    private void FillBaseAbilityScoreList()
    {
        baseAbilityScoreList.Add(baseStrength);
        baseAbilityScoreList.Add(baseDexterity);
        baseAbilityScoreList.Add(baseConstitution);
        baseAbilityScoreList.Add(baseIntelligence);
        baseAbilityScoreList.Add(baseWisdom);
        baseAbilityScoreList.Add(baseCharisma);
    }

    private void FillInitialCurrentAbilityScoreList() 
    {
        for (int i = 0; i < baseAbilityScoreList.Count; i++)
        {
            currentAbilityScoreList.Add(baseAbilityScoreList[i]);
        }
    }

    private void FillInitialAbilityScoreModifiers()
    {
        for (int i = 0; i < currentAbilityScoreList.Count; i++)
        {
            abilityScoreModifierList.Add(CalculateAbilityScoreModifier(currentAbilityScoreList[i]));
        }
    }
    #endregion

    private void SetCurrentAttributes() 
    {
        for (int i = 0; i < baseAbilityScoreList.Count; i++)
        {
            currentAbilityScoreList[i] = baseAbilityScoreList[i];
        }
    }

    private void CalculateAbilityScoreModifiers() 
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
