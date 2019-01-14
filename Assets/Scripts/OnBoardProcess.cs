using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class OnBoardProcess : MonoBehaviour {
    public GameObject RecipeMenuPrefab;
    public GameObject TimerMenuPrefab;
    public GameObject GuidancePrefab;
    public GameObject VoiceRecognizerPrefab;
    public GameObject CursorPrefab;

    public bool MenuOpen { get; set; }
    public bool TimerOpen { get; set; }
    public bool Cooking { get; set; }

    private Guidance _guidance;
    private VoiceRecognizer _voiceRecognizer;

    private void Awake()
    {
        var cursor = Instantiate(CursorPrefab);
        cursor.transform.parent = Camera.main.transform;

        _guidance = Instantiate(GuidancePrefab).GetComponent<Guidance>();
        _guidance.transform.parent = Camera.main.transform;
        _guidance.GetComponent<Guidance>().SetInstruction("Say \"Menu\" to open the recipe menu");

        _voiceRecognizer = Instantiate(VoiceRecognizerPrefab).GetComponent<VoiceRecognizer>();
        _voiceRecognizer.RegisterKeyword("menu");
        _voiceRecognizer.RegisterKeyword("set timer");
        _voiceRecognizer.RegisterKeyword("add timer");

        _voiceRecognizer.OnDictionaryReset += RegisterVoiceEvent;
        RegisterVoiceEvent();
    }

    private void RegisterVoiceEvent()
    {
        _voiceRecognizer.KeywordRecognizer.OnPhraseRecognized += VoiceHandler;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            MenuHandler();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            TimerHandler();
        }
    }

    private void MenuHandler()
    {
        if (!MenuOpen)
        {
            MenuOpen = true;
            Cooking = false;

            // Destroy all cooking elements
            DestroyObjectsInLayer(9);

            // Destroy guidance
            if(_guidance != null) {
                _guidance.GetComponent<Guidance>().CloseInstruction();
            }

            Instantiate(RecipeMenuPrefab).SetActive(true);
        }
    }
    
    private void TimerHandler()
    {
        if (Cooking && !TimerOpen)
        {
            // Close step by step guidance
            var guid = GameObject.Find("InstructionPanel").GetComponent<SBSPanel>().Guide;
            if(guid != null)
            {
                guid.CloseInstruction();
            }

            // Create timer menu
            var timerMenu = Instantiate(TimerMenuPrefab);
            TimerOpen = true;
        }
    }

    private void VoiceHandler(PhraseRecognizedEventArgs pArgs)
    {
        Debug.Log("Jooo ik hoor wat denk ik!!! : " + pArgs.text);
        if (pArgs.text == "menu")
        {
            MenuHandler();
        }
        if(pArgs.text == "set timer" || pArgs.text == "add timer")
        {
            TimerHandler();
        }
    }

    public void DestroyObjectsInLayer(int layer)
    {
        var objects = FindObjectsOfType(typeof(GameObject));
        for (var i = 0; i < objects.Length; i++)
        {
            var gameObj = (GameObject)objects[i];
            if (gameObj.layer == layer)
            {
                Destroy(gameObj);
            }
        }
    }

    private Transform GetChildComponent(string name)
    {
        foreach (Transform child in transform)
        {
            if (child.name == name)
            {
                return child;
            }
        }

        return null;
    }
}