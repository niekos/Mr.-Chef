using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSamePosition : MonoBehaviour {

    private bool _animation_started = false;
    //private bool _animation_finished = true;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void LateUpdate () {
        if (!AnimatorIsPlaying() && _animation_started)
        {
            _animation_started = false;

            //Vector3 countVector = new Vector3(0, 1, 0);

            //transform.parent.position = countVector;
            transform.localPosition = Vector3.zero;
        }
    }

    private bool AnimatorIsPlaying()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).length >
               _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && _animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    public void Play(string animState)
    {
        _animation_started = true;
        // _animation_finished = false;

        _animator = GetComponent<Animator>();
        _animator.Play(animState);
    }
}
