using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Config", menuName = "", order = 0)]
public class DialogueUIConfig : ScriptableObject
{
    [SerializeField] private DialogueCharacter[] characters;

    public DialogueCharacter[] Characters => characters;

    internal DialogueCharacter GetDialogueByName(string name)
    {
        return characters.FirstOrDefault(character => character.CharName == name);
    }
}
