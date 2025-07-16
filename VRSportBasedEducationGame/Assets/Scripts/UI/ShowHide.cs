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
    private int Targetscore;
    private int MyScore;

    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
        _eventBus.Subscribe<TargetScoreEvent>(UpdateTargetTxt);
        _eventBus.Subscribe<MyScoreEvent>(UpdateMyScoreTxt);
        _eventBus.Subscribe<LanguageEvent>(ChangeText);


    }

    private void OnDisable()
    {
        _eventBus.UnSubscribe<TargetScoreEvent>(UpdateTargetTxt);
        _eventBus.UnSubscribe<MyScoreEvent>(UpdateMyScoreTxt);

    }

    private void Start()
    {
        Invoke("UpdateTargetTxt", 1f);
        Targetscore = 0;
        MyScore = 0;
        Invoke("UpdateMyScoreTxt", 1f);
        UpdateMyScoreTxt(null);
    }
    private void ChangeText(LanguageEvent @event)
    {
        UpdateTargetTxt(null);
        UpdateMyScoreTxt(null);
    }

    public void HideOrShowPanel() {
        if (HideShowObject.transform.localScale.y == 0)
        {
            ShowPanel();
        }
        else if (HideShowObject.transform.localScale.y == 1) {  HidePanel(); }
    }
    private void HidePanel() { HideShowObject.transform.DOScaleY(0f, 1f);  
        if (PlayerPrefs.GetInt("language") == 0) { ButtonText.text = "Show"; }
        else if (PlayerPrefs.GetInt("language") == 1) { ButtonText.text = "Göster"; }
    }

    private void ShowPanel() { HideShowObject.transform.DOScaleY(1f, 1f);
        if (PlayerPrefs.GetInt("language") == 0) { ButtonText.text = "Hide"; }
        else if (PlayerPrefs.GetInt("language") == 1) { ButtonText.text = "Gizle"; }

    }

    private void UpdateTargetTxt(TargetScoreEvent evnt)
    {
        if(evnt !=null)
        {
            Targetscore = evnt.targetScore;
        }
        if (PlayerPrefs.GetInt("language") == 0) { TargetScoreTxt.text = "My tummy won’t be full until I eat " + Targetscore + " fruits"; }
        else if (PlayerPrefs.GetInt("language") == 1) { TargetScoreTxt.text = "Benim karným ancak " + Targetscore + " tane meyveyle doyar"; }

    }

    private void UpdateMyScoreTxt(MyScoreEvent evnt) {
        if (evnt != null)
        {
            MyScore = evnt.MyScore;
        }
       if (PlayerPrefs.GetInt("language") == 0) { MyScoreTxt.text = "In the belly: " + MyScore; }
       else if (PlayerPrefs.GetInt("language") == 1) { MyScoreTxt.text = "Midesine indirdikleri: " + MyScore; }
    }


}
