using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
  private IEventBus _eventBus;

    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
    }

    public void MakeEnglish()
    {
        PlayerPrefs.SetInt("language", 0);
        PlayerPrefs.Save();
        _eventBus.Publish(new LanguageEvent(0));
    }

    public void MakeTurkish()
    {
        PlayerPrefs.SetInt("language", 1);
        PlayerPrefs.Save();
        _eventBus.Publish(new LanguageEvent(1));
        Debug.Log("Make Turkish");
        Debug.Log(PlayerPrefs.GetInt("language"));
    }
}
