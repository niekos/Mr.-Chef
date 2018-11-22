using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class OnBoardProcess : MonoBehaviour {
    public GameObject RecipeMenuPrefab;
    public GameObject VoiceRecognizerPrefab;

    private bool _menuOpen = false;

    // Use this for initialization
    void Start () {
        var voiceRecognizer = Instantiate(VoiceRecognizerPrefab).GetComponent<VoiceRecognizer>();

        voiceRecognizer.RegisterKeyword("menu");

        voiceRecognizer.KeywordRecognizer.OnPhraseRecognized += VoiceHandler;

        GetChildComponent("Guidance").gameObject.SetActive(false);
        Instantiate(RecipeMenuPrefab).SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void VoiceHandler(PhraseRecognizedEventArgs args)
    {
        if (args.text == "menu")
        {
            if (!_menuOpen)
            {
                GetChildComponent("Guidance").gameObject.SetActive(false);
                Instantiate(RecipeMenuPrefab).SetActive(true);

                Debug.Log("Menu openen");
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
