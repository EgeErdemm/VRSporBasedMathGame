using UnityEngine;
using TMPro;
using DG.Tweening;


public class ShowHide : MonoBehaviour
{
    [SerializeField] private CubeEater CubeEater;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject HideShowObject;
    [SerializeField] private TextMeshProUGUI ButtonText;
    [SerializeField] private TextMeshProUGUI TargetScoreTxt;
    [SerializeField] private TextMeshProUGUI MyScoreTxt;
    private IEventBus _eventBus;

    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
        _eventBus.Subscribe<TargetScoreEvent>(UpdateTargetTxt);
        _eventBus.Subscribe<MyScoreEvent>(UpdateMyScoreTxt);

    }
    private void OnDisable()
    {
        _eventBus.UnSubscribe<TargetScoreEvent>(UpdateTargetTxt);
        _eventBus.UnSubscribe<MyScoreEvent>(UpdateMyScoreTxt);

    }

    private void Start()
    {
        Invoke("UpdateTargetTxt", 1f);
    }

    public void HideOrShowPanel() {
        if (HideShowObject.transform.localScale.y == 0)
        {
            ShowPanel();
        }
        else if (HideShowObject.transform.localScale.y == 1) {  HidePanel(); }
    }
    private void HidePanel() { HideShowObject.transform.DOScaleY(0f, 1f); ButtonText.text = "Show";  }

    private void ShowPanel() { HideShowObject.transform.DOScaleY(1f, 1f); ButtonText.text = "Hide"; }

    private void UpdateTargetTxt(TargetScoreEvent evnt) { TargetScoreTxt.text = "Target Score:" + evnt.targetScore; }

    private void UpdateMyScoreTxt(MyScoreEvent evnt) { MyScoreTxt.text = "My Score:" + evnt.MyScore; }


}
