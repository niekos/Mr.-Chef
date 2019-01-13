using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SBSCanvas : MonoBehaviour {
    public GameObject VoiceRecognizerPrefab;
    public GameObject Step;

    private VoiceRecognizer _voiceRecognizer;
    private List<string> _instructionList;
    private List<GameObject> _steps = new List<GameObject>();

    private bool startCommand = true;

	// Use this for initialization
	void Start () {
        //test code
        //UpdateInstructions(new List<string>() { "Turn on the tosti iron", "Check ingredients", "Spread butter on your bread", "Scrape the cheese", "Put cheese and ham on top of the butter",
        //"Place the bread in the sandwich iron", "Wait 6 minutes and you are done"});
        //end test code

        _voiceRecognizer = Instantiate(VoiceRecognizerPrefab).GetComponent<VoiceRecognizer>();
        _voiceRecognizer.RegisterKeyword("next");
        _voiceRecognizer.RegisterKeyword("previous");
        _voiceRecognizer.RegisterKeyword("volgende");
        _voiceRecognizer.RegisterKeyword("terug");

        _voiceRecognizer.OnDictionaryReset += RegisterVoiceEvent;
        RegisterVoiceEvent();
    }

    private void RegisterVoiceEvent()
    {
        _voiceRecognizer.KeywordRecognizer.OnPhraseRecognized += VoiceHandler;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StepHandler("previous");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StepHandler("next");
        }
    }

    private void StepHandler(string command)
    {
        if (command == "next" || command == "volgende")
        {
            var sbsPanel = GetComponentInChildren<SBSPanel>();
            
            if (!startCommand)
            {
                sbsPanel.Forward();
            }
            else
            {
                startCommand = false;
            }

            GameObject.Find("ProgressBarPanel").GetComponent<ProgressBar>().SetPercent(sbsPanel.Check());
        }
        else if (command == "previous" || command == "terug")
        {
            var sbsPanel = GetComponentInChildren<SBSPanel>();

            GameObject.Find("ProgressBarPanel").GetComponent<ProgressBar>().SetPercent(sbsPanel.UndoCheck());
            sbsPanel.Backward();

            if (sbsPanel.CurrentIndex <= 0)
            {
                startCommand = true;
            }
        }
    }

    private void VoiceHandler(PhraseRecognizedEventArgs pArgs)
    {
        StepHandler(pArgs.text);
    }
    
    public void UpdateInstructions(List<string> instructionList)
    {
        _instructionList = instructionList;
        GetComponentInChildren<SBSPanel>().SetInstructionList(instructionList);
    }
}