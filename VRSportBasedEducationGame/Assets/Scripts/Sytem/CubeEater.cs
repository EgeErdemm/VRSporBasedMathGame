using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CubeEater : MonoBehaviour
{
    private IEventBus _eventBus;
    public int score = 0;
    public Transform transformOfCube;
    [SerializeField] private WalkAI walkAI;


    private void OnTriggerEnter(Collider other)
    {
       MyTouchableBlocks myTouchableBlocks = other.GetComponent<MyTouchableBlocks>();
        if (myTouchableBlocks != null)
        {
            Rigidbody rb = myTouchableBlocks.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            transformOfCube = myTouchableBlocks.transform;
            walkAI.GoGetCube();
            if (myTouchableBlocks.scrEated != false) {return; }
            myTouchableBlocks.scrEated = true;
            myTouchableBlocks.gameObject.transform.DOScale(Vector3.zero, 8f)
                .SetEase(Ease.InBack)
                .OnComplete(() => {
                    score += myTouchableBlocks.score;
                    _eventBus.Publish(new MyScoreEvent(score));
                    Debug.Log(score);
                    Destroy(myTouchableBlocks.gameObject); 
                    transformOfCube=null;
                });
        }
    }

    private void OnEnable()
    {
        _eventBus=EventBus.Instance;
        _eventBus.Subscribe<MyScoreEvent>(UpdateScore);
    }

    private void UpdateScore(MyScoreEvent evnt)
    {
        score = evnt.MyScore;
    }
}
