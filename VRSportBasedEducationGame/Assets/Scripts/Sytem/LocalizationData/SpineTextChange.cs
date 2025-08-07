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
            spineText.text = "Don't forget to keep your back straight and break at the knees.";
        }else if(@event.language == 1)
        {
            spineText.text = "Sýrtýný düz tutmayý unutma ve dýz kapaklarýný kýr";
        }
    }
}
