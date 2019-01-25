using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
    public delegate void OnAnimateFinishedFunc();
    public event OnAnimateFinishedFunc OnAnimateFinished;

    public float Duration { private set; get; }
    public float Speed { private set; get; }

    private Vector3 _endPosition;
    private float _startTime;
    private bool _active = false;

    private float _delayStart = 0;
    private float _delay = 0;

    void Awake()
    {
    }

    void Update () {
        if (_active)
        {
            // The time when the animation is complete
            float complete = (Time.time - _startTime) / (Duration + _delay) / Speed;
            // Move object
            transform.localPosition = Vector3.Lerp(transform.localPosition, _endPosition, complete);

            // Check if the distance is close enough to be done with animating
            if((_startTime + (Duration + _delay)) - Time.time < 0)
            {
                _active = false;

                if (OnAnimateFinished != null)
                {
                    OnAnimateFinished();
                }
            }
        }

        if (_delayStart > 0)
        {
            if ((_delayStart + _delay) < Time.time)
            {
                // Set delay off
                _delayStart = 0;
                _delay = 0;

                MoveTo(_endPosition);
            }
        }
    }

    public void SetOptions(float speed, float duration)
    {
        Duration = duration;
        Speed = speed;
    }

    public void MoveTo(Vector3 endPosition)
    {
        _endPosition = endPosition;
        _startTime = Time.time;
        _active = true;
    }

    public void MoveTo(Vector3 endPosition, float delay)
    {
        if (delay > 0)
        {
            _delay = delay;
            _endPosition = endPosition;
            _delayStart = Time.time;
        }
        else
        {
            MoveTo(endPosition);
        }
    }
}