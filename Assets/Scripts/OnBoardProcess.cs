using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class OnBoardProcess : MonoBehaviour {
    public static OnBoardProcess Instance;

    public GameObject RecipeMenuPrefab;
    public GameObject GuidancePrefab;
    public GameObject VoiceRecognizerPrefab;

    public bool MenuOpen { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        var voiceRecognizer = Instantiate(VoiceRecognizerPrefab).GetComponent<VoiceRecognizer>();
        voiceRecognizer.RegisterKeyword("menu");
        voiceRecognizer.KeywordRecognizer.OnPhraseRecognized += VoiceHandler;

        DontDestroyOnLoad(gameObject);

        Instantiate(RecipeMenuPrefab).SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void VoiceHandler(PhraseRecognizedEventArgs args)
    {
        if (args.text == "menu")
        {
            if (!MenuOpen)
            {
                MenuOpen = true;

                // Destroy cooking elements
                DestroyObjectsInLayer(9);

                Instantiate(RecipeMenuPrefab).SetActive(true);
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