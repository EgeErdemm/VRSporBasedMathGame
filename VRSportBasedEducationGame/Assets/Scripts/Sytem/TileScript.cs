
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private IEventBus _eventBus;
    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
        _eventBus?.Subscribe<SelfDestroyEvent>(DestroyMe);
    }

    private void OnDisable()
    {
        _eventBus?.UnSubscribe<SelfDestroyEvent>(DestroyMe);
    }
    private void DestroyMe(SelfDestroyEvent evnt)
    {
        Destroy(gameObject);
    }
}

