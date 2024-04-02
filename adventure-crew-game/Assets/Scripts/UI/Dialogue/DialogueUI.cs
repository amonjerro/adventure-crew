using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject grayOut;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject charMask;
    [SerializeField] private GameObject charBox;
    [SerializeField] private GameObject charArt;
    [SerializeField] private GameObject charName;
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private DialogueUIConfig config;

    private int charPosition;
    private int dialoguePosition;

    // Start is called before the first frame update
    void Start()
    {
        background = this.transform.GetChild(0).gameObject;
        charMask = background.transform.GetChild(0).gameObject;
        charBox = charMask.transform.GetChild(0).gameObject;
        charArt = charMask.transform.GetChild(1).gameObject;
        charName = background.transform.GetChild(1).gameObject;
        dialogueBox = background.transform.GetChild(2).gameObject;


        charBox.GetComponent<Image>().color = config.Characters[charPosition].CharBox;
        charArt.GetComponent<Image>().sprite = config.Characters[charPosition].CharArt;
        charName.GetComponent<TextMeshProUGUI>().text = config.Characters[charPosition].CharName;
        dialogueBox.GetComponent<TextMeshProUGUI>().text = config.Characters[charPosition].Dialogue[dialoguePosition];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetCharPosition(int pos) { charPosition = pos; }

    public void ContinueDialogue()
    {
        dialoguePosition++;
        if(dialoguePosition >= config.Characters[charPosition].Dialogue.Length) { this.gameObject.SetActive(false); return; }
        dialogueBox.GetComponent<TextMeshProUGUI>().text = config.Characters[charPosition].Dialogue[dialoguePosition];
    }

    private void OnEnable()
    {
        grayOut.SetActive(true);

        charBox.GetComponent<Image>().color = config.Characters[charPosition].CharBox;
        charArt.GetComponent<Image>().sprite = config.Characters[charPosition].CharArt;
        charName.GetComponent<TextMeshProUGUI>().text = config.Characters[charPosition].CharName;
        dialogueBox.GetComponent<TextMeshProUGUI>().text = config.Characters[charPosition].Dialogue[dialoguePosition];
    }

    private void OnDisable()
    {
        grayOut.SetActive(false);

        dialoguePosition = 0;
        charPosition++;
    }
}
