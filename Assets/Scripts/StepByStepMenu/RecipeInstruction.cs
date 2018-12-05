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
        UpdateInstructions(new List<string>() { "Check ingredients", "Spread butter on your bread", "Scrape the cheese", "Put cheese and ham on top of the butter",
        "Place the bread in the sandwich iron", "Wait 6 minutes and you are done"});
        //end test code

        //_voiceRecognizer = Instantiate(VoiceRecognizerPrefab).GetComponent<VoiceRecognizer>();

        //_voiceRecognizer.RegisterKeyword("next");
        //_voiceRecognizer.RegisterKeyword("previous");

        //_voiceRecognizer.KeywordRecognizer.OnPhraseRecognized += VoiceHandler;


    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_instructionList.Count - 1 > _currentIndex)
            {
                _currentIndex++;
                UpdateCheck(true);

                if (_currentIndex > 0)
                {
                    AnimateMovement(true);

                }
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_currentIndex >= 0)
            {
                UpdateCheck(false);
                _currentIndex--;

                if (_currentIndex > -1)
                {
                    AnimateMovement(false);
                }
            }
        }
    }

    private void VoiceHandler(PhraseRecognizedEventArgs args)
    {
        if(args.text == "next")
        {
            if(_instructionList.Count - 1 > _currentIndex)
            {
                _currentIndex++;
                UpdateCheck(true);

                if (_currentIndex > 0)
                {
                    AnimateMovement(true);
                }
            }
        }
        else if(args.text == "previous")
        {
            if(_currentIndex >= 0)
            {
                UpdateCheck(false);
                _currentIndex--;

                if (_currentIndex > 0)
                {
                    AnimateMovement(false);
                }
            }
        }

        Debug.Log("current index: " + _currentIndex);
    }

    private void AnimateMovement(bool forward)
    {
        var animController = GameObject.Find("StepByStepContent").GetComponent<Animator>();
        var controller = GameObject.Find("StepByStepContent").GetComponent<LoopSamePosition>();
        if (forward)
        {
            //animController.Play("StepForward");

            //GameObject.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value -= 1f;
            controller.transform.parent.localPosition = new Vector3(controller.transform.parent.localPosition.x, controller.transform.parent.localPosition.y + 31, controller.transform.parent.localPosition.z);
        }
        else
        {
            //GameObject.Find("Scrollbar Vertical").GetComponent<Scrollbar>().value += 0.1f;
            controller.transform.parent.localPosition = new Vector3(controller.transform.parent.localPosition.x, controller.transform.parent.localPosition.y - 31, controller.transform.parent.localPosition.z);
        }
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
            Vector3 stepPosition = new Vector3(transform.localPosition.x - 8.8f, transform.localPosition.y + (-3f - (1.25f * index)), transform.localPosition.z - 0.1f);
            var stepInstance = Instantiate(Step, stepPosition, Quaternion.identity);
            _steps.Add(stepInstance);
            stepInstance.SetActive(true);
            
            var instructionPanel = GameObject.Find("StepByStepContent");
            stepInstance.transform.parent = instructionPanel.transform;

            
            foreach (Transform innerChild in instructionPanel.transform.GetChild(index))
            {
                if (innerChild.transform.name == "StepText")
                {
                    var component = innerChild.GetComponent<Text>();
                    component.text = instruction;
                    component.gameObject.SetActive(true);
                }
            }
            
            index++;
        }
    }
}