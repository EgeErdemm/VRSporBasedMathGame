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
            spineText.text = "Kýzýn gösterdiði þekilde eðilmeye çalýþ, sýrtýný düz tutmayý unutma";
        }
    }
}
