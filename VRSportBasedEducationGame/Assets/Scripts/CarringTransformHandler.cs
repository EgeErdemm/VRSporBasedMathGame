using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarringTransformHandler : MonoBehaviour
{
    void Start()
    {
        int index = CharacterManager.Instance.currentIndex;

        transform.localPosition =
            CharacterManager.Instance.characterSlots[index].characterPoint.position;
    }
}
