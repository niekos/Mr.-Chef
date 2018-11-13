using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class RecipeInstruction : MonoBehaviour {
    public GameObject VoiceRecognizerPrefab;
    private VoiceRecognizer _voiceRecognizer;

	// Use this for initialization
	void Awake () {
        _voiceRecognizer = Instantiate(VoiceRecognizerPrefab).GetComponent<VoiceRecognizer>();

        _voiceRecognizer.RegisterKeyword("next");
        _voiceRecognizer.RegisterKeyword("previous");

        _voiceRecognizer.CreateKeywordRecognizer();
        _voiceRecognizer.KeywordRecognizer.OnPhraseRecognized += VoiceHandler;
        _voiceRecognizer.BeginListening();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void VoiceHandler(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Dankjewel gozer!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Debug.Log(args.text);
    }
}
