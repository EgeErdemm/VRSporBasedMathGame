
using System.Collections;
using UnityEngine;

public class RandomNumberSizeChanger : MonoBehaviour
{
    public IEventBus _eventBus;
    [SerializeField] private GameRestarter _gameRestarter;
    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
    }
    public void RandomNumberSizeSmall()
    {
        _eventBus.Publish(new NumberRangeEvent(1, 16));
        _gameRestarter.LevelRestart();
    }
    public void RandomNumberSizeMedium()
    {
        _eventBus.Publish(new NumberRangeEvent(1, 31));
        _gameRestarter.LevelRestart();

    }
    public void RandomNumberSizeLarge()
    {
        _eventBus.Publish(new NumberRangeEvent(1, 46));
        _gameRestarter.LevelRestart();

    }

  

}
