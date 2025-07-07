using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestarter : MonoBehaviour
{
    [SerializeField] private LevelLoader3D levelLoader3D;
    private IEventBus _eventBus;
    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
    }
    public void LevelRestart()
    {
        DestroyPastGameObject();
        _eventBus.Publish(new MyScoreEvent(0));
        levelLoader3D.LevelStarter();
    }

    private void DestroyPastGameObject()
    {
        _eventBus?.Publish(new SelfDestroyEvent(true));
    }
}
