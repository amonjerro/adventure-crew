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
    public OnboardingManager onboarding;

    private int charPosition;
    private int dialoguePosition;

    public int CharPosition => charPosition;
    public int DialoguePosition => dialoguePosition;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

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
        if (dialoguePosition >= config.Characters[charPosition].Dialogue.Length) { this.gameObject.SetActive(false); return; }
        dialogueBox.GetComponent<TextMeshProUGUI>().text = config.Characters[charPosition].Dialogue[dialoguePosition];
        OnboardingCheck();
    }

    public void AdvanceCharacter()
    {
        dialoguePosition = 0;
        charPosition++;
    }

    private void OnboardingCheck()
    {
        if (charPosition == 0 && dialoguePosition >= config.Characters[0].Dialogue.Length) { onboarding.OnboardingTask("battle"); }
        else if (charPosition == 1 && dialoguePosition >= config.Characters[1].Dialogue.Length) { onboarding.OnboardingTask("battle start"); }
        else if (charPosition == 2 && dialoguePosition >= config.Characters[2].Dialogue.Length) { onboarding.OnboardingTask("roster"); }
        else if (charPosition == 3 && dialoguePosition >= config.Characters[3].Dialogue.Length) { onboarding.OnboardingTask("contracts"); }
        else if (charPosition == 4 && dialoguePosition >= config.Characters[4].Dialogue.Length) { onboarding.OnboardingTask("shop"); }
        else if (charPosition == 5 && dialoguePosition < config.Characters[5].Dialogue.Length) { onboarding.OnboardingTask("map"); }
        else if (charPosition == 5 && dialoguePosition >= config.Characters[5].Dialogue.Length) { onboarding.OnboardingTask("midland"); }
        else if (charPosition == 6 && dialoguePosition >= config.Characters[6].Dialogue.Length) { onboarding.OnboardingTask("quest"); }
    }


    private void OnEnable()
    {
        if (grayOut != null) { grayOut.SetActive(true); }

        Debug.Log(charPosition);

        charBox.GetComponent<Image>().color = config.Characters[charPosition].CharBox;
        charArt.GetComponent<Image>().sprite = config.Characters[charPosition].CharArt;
        charName.GetComponent<TextMeshProUGUI>().text = config.Characters[charPosition].CharName;
        dialogueBox.GetComponent<TextMeshProUGUI>().text = config.Characters[charPosition].Dialogue[dialoguePosition];
    }

    private void OnDisable()
    {
        //grayOut.SetActive(false);
        OnboardingCheck();
    }
}
