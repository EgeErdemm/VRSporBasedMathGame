using UnityEngine;
public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject WinPanel, LosePanel;
    private IEventBus _eventBus;
    private int targetScore;
    private void OnEnable()
    {
        _eventBus = EventBus.Instance;
        _eventBus.Subscribe<MyScoreEvent>(WinLosePanelShow); // cubeeater
        _eventBus.Subscribe<TargetScoreEvent>(GetTargetScore);//baselevelloader 
        _eventBus.Subscribe<SelfDestroyEvent>(CloseAllPanel); //gamerestarter
    }
    private void GetTargetScore(TargetScoreEvent evnt)
    {
        targetScore = evnt.targetScore;
    }
    private void WinLosePanelShow(MyScoreEvent evnt)
    {
        if (targetScore > evnt.MyScore) { return; }
        else if(targetScore == evnt.MyScore) { ShowWinPanel(); }
        else { ShowLosePanel(); }
    }
    private void ShowWinPanel()
    {
        WinPanel.SetActive(true);
        LosePanel.SetActive(false);
    }

    private void ShowLosePanel() 
    {
        WinPanel?.SetActive(false);
        LosePanel?.SetActive(true);
    }

    private void CloseAllPanel(SelfDestroyEvent evnt) { if (evnt.destroyYourSelf)
        {
            WinPanel?.SetActive(false);
            LosePanel?.SetActive(false);
        } }

}
