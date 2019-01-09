using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class VoiceRecognizer : MonoBehaviour {
    public delegate void ResetEvent();
    public event ResetEvent OnDictionaryReset;
    
    public static VoiceRecognizer Instance { get; private set; }

    public KeywordRecognizer KeywordRecognizer { get; private set; }
    private Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private DateTime _lastTime;
    private const int RESETTIMER = 60000;

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
    
    private void BeginListening ()
    {
        _lastTime = DateTime.Now;
        KeywordRecognizer.Start();
    }

    private void CreateKeywordRecognizer()
    {
        KeywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        BeginListening();
    }

    public void RegisterKeyword(string keyword)
    {
        if (!keywords.ContainsKey(keyword))
        {
            if (KeywordRecognizer != null)
            {
                KeywordRecognizer.Stop();
            }

            keywords.Add(keyword, () => { });
            CreateKeywordRecognizer();
        }
    }

    private void Update()
    {
        if (KeywordRecognizer != null && DateTime.Now.Subtract(_lastTime).TotalMilliseconds >= RESETTIMER)
        {
            // Reset to keep listening
            OnDictionaryReset.Invoke();
            CreateKeywordRecognizer();
        }
    }
}
