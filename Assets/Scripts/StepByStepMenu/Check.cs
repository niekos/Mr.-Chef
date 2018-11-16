using System;

using UnityEngine;
using UnityEngine.Video;

public class Check : MonoBehaviour {
    // public VideoPlayer gifImage;
    //private List<Texture2D> _gifFrames = new List<Texture2D>();
    private Animator _animator;


    // Use this for initialization
    void Awake () {
        _animator = GetComponent<Animator>();
        _animator.SetBool("PlayCheck", false);
    }

    private void Update()
    {
        _animator.SetBool("PlayCheck", false);
        //_animator.StopPlayback();
        //GetComponent<Renderer>().material.mainTexture = gifImage.texture;
        //gifImage.Play();
    }

    //private void OnGUI()
    //{
    //    GUI.DrawTexture(new Rect(0, 0, _gifFrames[0].width, _gifFrames[0].height),
    //        _gifFrames[20]);//(int)(Time.frameCount * 1) % _gifFrames.Count]);
    //}

    //private void GetImageFrames()
    //{
    //    var gifImage = (Bitmap)Image.FromFile("Assets/Images/Check.gif", true);
    //    var dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
    //    int frameCount = gifImage.GetFrameCount(dimension);
    //    for (int i = 0; i < frameCount; i++)
    //    {
    //        gifImage.SelectActiveFrame(dimension, i);
    //        var frame = new Bitmap(gifImage.Width, gifImage.Height);
    //        System.Drawing.Graphics.FromImage(frame).DrawImage(gifImage, Point.Empty);
    //        var frameTexture = new Texture2D(frame.Width, frame.Height);
    //        for (int x = 0; x < frame.Width; x++)
    //            for (int y = 0; y < frame.Height; y++)
    //            {
    //                System.Drawing.Color sourceColor = frame.GetPixel(x, y);
    //                frameTexture.SetPixel(frame.Width - 1 - x, y, new Color32(sourceColor.R, sourceColor.G, sourceColor.B, sourceColor.A)); // for some reason, x is flipped
    //            }
    //        frameTexture.Apply();
    //        _gifFrames.Add(frameTexture);
    //    }
    //}
}
