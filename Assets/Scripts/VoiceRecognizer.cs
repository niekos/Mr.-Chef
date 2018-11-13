using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceRecognizer : MonoBehaviour {
    public static VoiceRecognizer Instance;
    public KeywordRecognizer KeywordRecognizer { get; private set; }
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    
    public void BeginListening () {
        Debug.Log("Voice begins....");

        KeywordRecognizer.Start();
    }

    public void CreateKeywordRecognizer()
    {
        KeywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
    }

    public void RegisterKeyword(string keyword)
    {
        keywords.Add(keyword, () => { });
    }

    public void Update()
    {
        
    }
}
