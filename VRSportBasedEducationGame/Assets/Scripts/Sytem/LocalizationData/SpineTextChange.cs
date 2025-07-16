using System;
using TMPro;
using UnityEngine;

public class SpineTextChange : MonoBehaviour
{
    public TextMeshProUGUI spineText;
    private IEventBus eventBus;

    private void OnEnable()
    {
        eventBus = EventBus.Instance;
        eventBus.Subscribe<LanguageEvent>(ChangeText);
    }

    private void ChangeText(LanguageEvent @event)
    {
        if(@event.language == 0)
        {
            spineText.text = "Try to bend as the girl shows, remember to keep your back straight";
        }else if(@event.language == 1)
        {
            spineText.text = "K�z�n g�sterdi�i �ekilde e�ilmeye �al��, s�rt�n� d�z tutmay� unutma";
        }
    }
}
