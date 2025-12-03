using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] chars;

    void Start()
    {
        chars[CharacterManager.Instance.currentIndex].SetActive(true);
    }


}
