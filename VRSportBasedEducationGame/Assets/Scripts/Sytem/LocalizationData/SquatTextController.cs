using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SquatTextController : MonoBehaviour
{
    public TextMeshProUGUI textSquat;
    private IEventBus _eventBus;

    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
        _eventBus.Subscribe<LanguageEvent>(TextChanger);
    }
    void Start()
    {
        // E�er "language" key'i daha �nce ayarlanmam��sa, 0 olarak ayarla
        if (!PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.SetInt("language", 0);
            PlayerPrefs.Save(); // De�eri diske kaydet
        }

        // Mevcut language de�erini okuyal�m
        int currentLang = PlayerPrefs.GetInt("language");
        Debug.Log("Current Language Value: " + currentLang);
    }

    private void TextChanger(LanguageEvent @event)
    {
        PlayerPrefs.SetInt("language", @event.language);
        PlayerPrefs.Save();
        if (PlayerPrefs.GetInt("language") == 0)
        {
            textSquat.text = "Come on, do squats like her and pick up the boxes from the floor.";
        }else if(PlayerPrefs.GetInt("language") == 1)
        {
            textSquat.text = "Hadi sen de onun gibi squat yap�p kutular� yerden al";
        }
    }
}
