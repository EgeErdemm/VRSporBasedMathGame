using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class MyTouchableBlocks : MonoBehaviour
{
    private IEventBus _eventBus;
    public int BlockId;
    public int score {  get; private set; }
    private readonly List<TMP_Text> _texts = new List<TMP_Text>();
    public bool scrEated = false;

public void InitalizeSC(int index,int scr)
    {
        BlockId = index;
        score= scr;
        textHolder();
    }
    private void textHolder()
    {
        var tmpTexts = gameObject.GetComponentsInChildren<TMP_Text>();

        if (tmpTexts != null)
            _texts.AddRange(tmpTexts);
        textWriter();
    }
    private void textWriter() 
    {
        foreach (var text in _texts)
        {
            text.text = score.ToString();
        }
    }

    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
        _eventBus?.Subscribe<SelfDestroyEvent>(DestroyMe);
    }

    private void OnDisable()
    {
        _eventBus?.UnSubscribe<SelfDestroyEvent>(DestroyMe);
    }
    private void DestroyMe(SelfDestroyEvent evnt)
    {
        Destroy(gameObject);
    }
}


