using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class OnboardingManager : MonoBehaviour
{
    [SerializeField] private Transform canvas;
    [SerializeField] private DialogueUI dialogueUI;

    [SerializeField]private Dictionary<string, GameObject> mapDictionary;
    private Dictionary<string, GameObject> battleDictionary;

    private bool onboardingStarted;
    [SerializeField]private bool onboardingFinished;

    private static OnboardingManager onboardingManager;
    private int numOfUnits = 0;

    // Start is called before the first frame update
    void Start()
    {

        if (onboardingManager == null)
        {
            DontDestroyOnLoad(this.gameObject);
            onboardingManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        SceneManager.activeSceneChanged += OnSceneChange;

        mapDictionary = new Dictionary<string, GameObject>();
        battleDictionary = new Dictionary<string, GameObject>();

        //OnSceneChange(SceneManager.GetActiveScene(), SceneManager.GetActiveScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnboardingTask(string task)
    {
        GameObject currentObject = null;
        //DRYD
        switch (task)
        {
            case "battle":
                battleDictionary.TryGetValue("FormationUI", out currentObject);
                currentObject.transform.GetChild(1).gameObject.SetActive(true);
                currentObject = currentObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
                for (int i = 0; i < currentObject.transform.childCount; i++)
                {
                    currentObject.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(UnitPlaced);
                }
                break;
            case "battle start":
                battleDictionary.TryGetValue("FormationUI", out currentObject);
                currentObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                break;
            case "roster":
                mapDictionary.TryGetValue("Roster", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                currentObject.transform.GetChild(0).GetComponent<Button>().interactable = true;
                break;
            case "contracts":
                mapDictionary.TryGetValue("Shop", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                currentObject.transform.GetChild(0).GetComponent<Button>().interactable = true;
                break;
            case "shop":
                mapDictionary.TryGetValue("Gold", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                //currentObject.transform.GetChild(0).GetComponent<Button>().interactable = true;
                break;
            case "map":
                mapDictionary.TryGetValue("Gray Out", out currentObject);
                currentObject.SetActive(false);
                mapDictionary.TryGetValue("Roster", out currentObject);
                currentObject.GetComponent<Button>().interactable = false;
                mapDictionary.TryGetValue("Shop", out currentObject);
                currentObject.GetComponent<Button>().interactable = false;
                mapDictionary.TryGetValue("Gold", out currentObject);
                currentObject.GetComponent<Button>().interactable = false;
                mapDictionary.TryGetValue("Roster Holder", out currentObject);
                currentObject.SetActive(false);
                mapDictionary.TryGetValue("Gold Store Holder", out currentObject);
                currentObject.SetActive(false);
                break;
            case "midland":
                break;
            case "quest":
                mapDictionary.TryGetValue("Roster", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                mapDictionary.TryGetValue("Shop", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                mapDictionary.TryGetValue("Gold", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                mapDictionary.TryGetValue("Gray Out", out currentObject);
                currentObject.SetActive(false);
                onboardingFinished = true;
                break;
        }

    }

    public void UnitPlaced()
    {
        Debug.Log(numOfUnits);
        numOfUnits++;
        if (numOfUnits == 5) { dialogueUI.AdvanceCharacter(); dialogueUI.gameObject.SetActive(true); }
    }
    private void TurnOffOnboarding(Scene current)
    {
        Debug.Log(current.name);
        GameObject currentObject;
        if (current.name == "MapScene")
        {
            //Turns off tutorial
            mapDictionary.TryGetValue("CountryTitles", out currentObject);
            currentObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            mapDictionary.TryGetValue("Roster", out currentObject);
            currentObject.GetComponent<Button>().interactable = true;
            currentObject.transform.GetChild(0).gameObject.SetActive(false);
            mapDictionary.TryGetValue("Shop", out currentObject);
            currentObject.GetComponent<Button>().interactable = true;
            currentObject.transform.GetChild(0).gameObject.SetActive(false);
            mapDictionary.TryGetValue("Gold", out currentObject);
            currentObject.GetComponent<Button>().interactable = true;

            Debug.Log("if");
        }
        else if(current.name == "Battlefield-Non-Test")
        {
            dialogueUI.gameObject.SetActive(false);
            battleDictionary.TryGetValue("FleeButton", out currentObject);
            currentObject.GetComponent<Button>().interactable = true;
            battleDictionary.TryGetValue("Powers UI", out currentObject);
            currentObject.gameObject.SetActive(true);
            battleDictionary.TryGetValue("FormationUI", out currentObject);
            currentObject.transform.GetChild(1).gameObject.SetActive(true);
            battleDictionary.TryGetValue("FormationUI", out currentObject);
            currentObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        else if(current.name == "Intro")
        {
            canvas.GetChild(3).GetChild(2).GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnSceneChange(Scene current, Scene next)
    {
        Debug.Log(current.name + "" + next.name);
        canvas = GameObject.Find("Canvas").transform;

        GameObject currentObject;

        if (next.name == "Intro" && onboardingStarted) { TurnOffOnboarding(next); }


        dialogueUI = canvas.GetComponentInChildren<DialogueUI>(true);
        Debug.Log(dialogueUI);
        if (dialogueUI != null) { dialogueUI.onboarding = this; }



        if (next.name == "MapScene")
        {
            mapDictionary.Clear();
            for (int i=0; i<canvas.childCount; i++)
            {
                GameObject child = canvas.GetChild(i).gameObject;
                mapDictionary.Add(child.name, child);
            }

            if (onboardingFinished) { Destroy(dialogueUI.gameObject); TurnOffOnboarding(next); }
            else
            {
                dialogueUI.SetCharPosition(2);
                dialogueUI.gameObject.SetActive(true);

                mapDictionary.TryGetValue("Gray Out", out currentObject);
                currentObject.SetActive(false);
            }
        }
        else if (next.name == "Battlefield-Non-Test")
        {
            onboardingStarted = true;

            battleDictionary.Clear();

            for (int i = 0; i < canvas.childCount; i++)
            {
                GameObject child = canvas.GetChild(i).gameObject;
                battleDictionary.Add(child.name, child);
            }

            if (onboardingFinished) { TurnOffOnboarding(next); return; }

            dialogueUI.gameObject.SetActive(true);
        }
    }

}
