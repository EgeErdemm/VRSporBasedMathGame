using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Instructer : MonoBehaviour
{
    [SerializeField] private ButtonReader buttonReader;
    [SerializeField] private TextMeshProUGUI InstructerText;
    [SerializeField] private GameObject arrow;

    void Start()
    {
        RectTransform arrowRect = arrow.GetComponent<RectTransform>();
        arrowRect.DOAnchorPosY(75f, 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetUpdate(true); // Tween çalýþmaya devam eder, aktif deðilse bile
    }
    private void Update()
    {
        if(buttonReader.holdingButton)
        {
            InstructerText.text = "Drop the box here";
            arrow.SetActive(true);
        }
        else if(!buttonReader.holdingButton)
        {
            InstructerText.text = "Hold the box with your finger";
            arrow.SetActive(false);
        }
    }

}
