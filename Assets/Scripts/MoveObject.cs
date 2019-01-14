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

    void Awake()
    {
    }

    void Update () {
        if (_active)
        {
            // The time when the animation is complete
            float complete = (Time.time - _startTime) / Duration / Speed;
            // Move object
            transform.localPosition = Vector3.Lerp(transform.localPosition, _endPosition, complete);

            // Check if the distance is close enough to be done with animating
            if(Time.time - (_startTime + Duration) > 0)
            {
                _active = false;
                OnAnimateFinished();
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
}
