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
    public bool VoiceOn { get; set; }

    private void Awake()
    {
        VoiceOn = true;

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
        //if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    MenuHandler();
        //}
        //if(Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    TimerHandler();
        //}
    }

    public void MenuHandler()
    {
        if (!MenuOpen)
        {
            MenuOpen = true;
            Cooking = false;
            TimerOpen = false;

            // Destroy all cooking elements
            DestroyObjectsInLayer(9);

            // Close all guidance to prevent overlaps
            DestroyAllGuidance();

            Instantiate(RecipeMenuPrefab).SetActive(true);
        }
    }
    
    public void TimerHandler()
    {
        if (Cooking && !TimerOpen)
        {
            // Close step by step guidance
            DestroyAllGuidance();

            // Create timer menu
            var timerMenu = Instantiate(TimerMenuPrefab);
            TimerOpen = true;

            // Timer guidance
            _guidance = Instantiate(GuidancePrefab).GetComponent<Guidance>();
            _guidance.transform.parent = Camera.main.transform;
            _guidance.SetInstruction("Click on the + numbers to increase the time in minutes");
        }
    }

    private void CreateGuide(Sprite sprite, AnimatorOverrideController controller)
    {
        _guidance = Instantiate(GuidancePrefab).GetComponent<Guidance>();
        _guidance.transform.parent = Camera.main.transform;

        if (sprite != null)
        {
            _guidance.SetSprite(sprite);
        }
        if (controller != null)
        {
            _guidance.SetAnimationController(controller);
        }
    }

    public void CreateGuide(string text, Sprite sprite, AnimatorOverrideController controller)
    {
        CreateGuide(sprite, controller);

        _guidance.SetInstruction(text);
    }

    public void CreateGuide(string text, Sprite sprite, AnimatorOverrideController controller, float duration)
    {
        CreateGuide(sprite, controller);

        _guidance.SetInstruction(text, duration);
    }

    private void VoiceHandler(PhraseRecognizedEventArgs pArgs)
    {
        if (VoiceOn)
        {
            if (pArgs.text == "menu")
            {
                MenuHandler();
            }
            if (pArgs.text == "set timer" || pArgs.text == "add timer")
            {
                TimerHandler();
            }
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

    public void DestroyAllGuidance()
    {
        var objects = FindObjectsOfType(typeof(GameObject));
        for (var i = 0; i < objects.Length; i++)
        {
            var gameObj = (GameObject)objects[i];
            if (gameObj.layer == 11)
            {
                Guidance guide = gameObj.GetComponent<Guidance>();
                guide.CloseInstruction();
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