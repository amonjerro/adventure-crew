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

    private Dictionary<string, GameObject> mapDictionary;
    private Dictionary<string, GameObject> battleDictionary;

    private bool onboardingStarted;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

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
        GameObject currentObject;
        //DRYD
        switch (task)
        {
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
                mapDictionary.TryGetValue("Roster", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                mapDictionary.TryGetValue("Shop", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                mapDictionary.TryGetValue("Gold", out currentObject);
                currentObject.GetComponent<Button>().interactable = true;
                break;
            case "quest":
                mapDictionary.TryGetValue("Gray Out", out currentObject);
                currentObject.SetActive(false);
                break;
        }
    }
    private void OnSceneChange(Scene current, Scene next)
    {
        Debug.Log(current.name + "" + next.name);
        canvas = GameObject.Find("Canvas").transform;

        dialogueUI = canvas.GetComponentInChildren<DialogueUI>(true);
        Debug.Log(dialogueUI);
        dialogueUI.onboarding = this;

        if (next.name == "MapScene" && mapDictionary.Count == 0)
        {
            dialogueUI.gameObject.SetActive(true);

            for (int i=0; i<canvas.childCount; i++)
            {
                GameObject child = canvas.GetChild(i).gameObject;
                mapDictionary.Add(child.name, child);
            }

        }
        else if (next.name == "Battlefield-Non-Test" && battleDictionary.Count == 0)
        {
            dialogueUI.gameObject.SetActive(true);

            for (int i = 0; i < canvas.childCount; i++)
            {
                GameObject child = canvas.GetChild(i).gameObject;
                battleDictionary.Add(child.name, child);
            }
        }
    }
}
