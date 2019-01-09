using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public string resourcePath;
    public Texture2D spriteTex;

    private Sprite[] _sprites;
    private int _percent = 0;

	// Use this for initialization
	void Awake () {
        string name = resourcePath + spriteTex.name;
        _sprites = Resources.LoadAll<Sprite>(resourcePath + spriteTex.name);
	}
	
	// Update is called once per frame
	void Update () {
        var spriteIndex = (int)(((float)_sprites.Length / 100) * _percent);

        GetComponent<SpriteRenderer>().sprite = _sprites[((spriteIndex - 1) <= 1) ? 0 : spriteIndex - 1];

        GameObject.Find("ProgressText").GetComponent<Text>().text = _percent + "%";
	}

    public void SetPercent(int percent)
    {
        _percent = percent;
    }

    public void CountPercent(int percent)
    {
        _percent += percent;
    }
}
