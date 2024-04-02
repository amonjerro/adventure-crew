using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueCharacter
{
    [SerializeField] private string charName;
    [SerializeField, Multiline] private string[] dialogue;
    [SerializeField] private Color charBox;
    [SerializeField] private Sprite charArt;


    public string CharName => charName;
    public string[] Dialogue => dialogue;
    public Color CharBox => charBox;
    public Sprite CharArt => charArt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
