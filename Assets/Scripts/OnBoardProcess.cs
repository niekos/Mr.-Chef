using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class OnBoardProcess : MonoBehaviour {
    public GameObject RecipeMenuPrefab;
    public GameObject TimerMenuPrefab;
    public GameObject GuidancePrefab;
    public GameObject VoiceRecognizerPrefab;

    public bool MenuOpen { get; set; }
    public bool Cooking { get; set; }

    private VoiceRecognizer _voiceRecognizer;

    private void Awake()
    {
        Instantiate(GuidancePrefab).SetActive(true);

        _voiceRecognizer = Instantiate(VoiceRecognizerPrefab).GetComponent<VoiceRecognizer>();
        _voiceRecognizer.RegisterKeyword("menu");
        _voiceRecognizer.RegisterKeyword("set timer");

        _voiceRecognizer.OnDictionaryReset += RegisterVoiceEvent;
        RegisterVoiceEvent();
    }

    private void RegisterVoiceEvent()
    {
        _voiceRecognizer.KeywordRecognizer.OnPhraseRecognized += VoiceHandler;
    }

    // Update is called once per frame
    void Update () {
	}

    private void VoiceHandler(PhraseRecognizedEventArgs pArgs)
    {
        Debug.Log("Jooo ik hoor wat denk ik!!! : " + pArgs.text);
        if (pArgs.text == "menu")
        {
            if (!MenuOpen)
            {
                MenuOpen = true;
                Cooking = false;

                // Destroy all cooking elements
                DestroyObjectsInLayer(9);

                Instantiate(RecipeMenuPrefab).SetActive(true);
            }
        }
        if(pArgs.text == "set timer")
        {
            if (Cooking)
            {
                var timerMenu = Instantiate(TimerMenuPrefab);
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