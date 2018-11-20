using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class RecipeInstruction : MonoBehaviour {
    public GameObject VoiceRecognizerPrefab;
    public GameObject Step;
    private VoiceRecognizer _voiceRecognizer;
    
    private List<string> _instructionList;
    private List<GameObject> _steps = new List<GameObject>();
    private int _currentIndex = -1;

	// Use this for initialization
	void Awake () {
        //test code
        UpdateInstructions(new List<string>() { "Check ingredients",  "Cut carrot", "Stop the bleeding", "Use thuisbezorgd"});
        //end test code

        _voiceRecognizer = Instantiate(VoiceRecognizerPrefab).GetComponent<VoiceRecognizer>();

        _voiceRecognizer.RegisterKeyword("next");
        _voiceRecognizer.RegisterKeyword("previous");
        
        _voiceRecognizer.KeywordRecognizer.OnPhraseRecognized += VoiceHandler;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void VoiceHandler(PhraseRecognizedEventArgs args)
    {
        if(args.text == "next")
        {
            if(_instructionList.Count - 1 > _currentIndex)
            {
                _currentIndex++;
                UpdateCheck(true);
            }
        }
        else if(args.text == "previous")
        {
            if(_currentIndex >= 0)
            {
                UpdateCheck(false);
                _currentIndex--;
            }
        }

        Debug.Log("current index: " + _currentIndex);
    }

    private void UpdateCheck(bool active)
    {
        foreach (Transform child in _steps[_currentIndex].transform)
        {
            if (child.transform.name == "Check")
            {
                var component = child.GetComponent<Renderer>();
                component.gameObject.SetActive(active);

                var animator = component.GetComponent<Animator>();
                animator.SetBool("PlayCheck", true);
            }
        }
    }
    
    public void UpdateInstructions(List<string> instructionList)
    {
        _instructionList = instructionList;
        _steps.Clear();
        _currentIndex = -1;

        int index = 0;
        foreach (string instruction in _instructionList)
        {
            Vector3 stepPosition = new Vector3(transform.localPosition.x - 5.21f, transform.localPosition.y + (4.1f - (2f * index)), transform.localPosition.z - 0.02f);
            var stepInstance = Instantiate(Step, stepPosition, Quaternion.identity);
            _steps.Add(stepInstance);
            stepInstance.SetActive(true);

            foreach (Transform child in stepInstance.transform)
            {
                if (child.transform.name == "StepText")
                {
                    var component = child.GetComponent<Renderer>().gameObject.GetComponent<TextMesh>();
                    component.text = instruction;
                    component.gameObject.SetActive(true);
                }
            }

            //stepInstance.GetComponentInChildren<TextMesh>().text = instruction;
            stepInstance.transform.parent = this.transform;

            index++;
        }
    }
}
