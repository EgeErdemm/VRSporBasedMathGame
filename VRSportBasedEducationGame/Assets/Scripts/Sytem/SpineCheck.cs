using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineCheck : MonoBehaviour
{
    [SerializeField] private Transform spine;
    [SerializeField] private GameObject spineUI;
    private void Update()
    {
        if(spine.rotation.eulerAngles.x > 50f && spine.rotation.eulerAngles.x < 180f)
        {
            spineUI.SetActive(true);
            SquatTutorial.squatCount = 0;
        }
        else
        {
            spineUI.SetActive(false);
        }
    }
}
