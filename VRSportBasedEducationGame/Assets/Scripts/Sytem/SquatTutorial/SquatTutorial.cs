using System.Collections;
using UnityEngine;
using TMPro;

public class SquatTutorial : MonoBehaviour
{
    [SerializeField] private Transform CameraRig;
    private Animator animator;
    public static int squatCount;
    private bool standingAgain = true;
    [SerializeField] private TextMeshProUGUI SquatTutorialText;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Run60Sec());
        if (animator == null) Debug.LogError("Animator null");
    }

    IEnumerator Run60Sec()
    {
        while(true)
        {
            Debug.Log(CameraRig.transform.position);
            StartCoroutine(SquatTutorialDoneChecker());
            yield return new WaitForSeconds(60);
        }
    }
    IEnumerator SquatTutorialDoneChecker()
    {
        float duration = 60f;
        float timer = 0f;

        while (timer < duration)
        {
            if (CameraRig.position.y <= 1f && standingAgain) { squatCount++; standingAgain = false; }
            if (CameraRig.position.y >= 1.4f) { standingAgain = true; }
            if (squatCount >= 4) {
                animator.SetBool("SquatTutorialDone", true);
                if(PlayerPrefs.GetInt("langugage") == 0) { SquatTutorialText.text = ""; }
                break;
            }
            Debug.Log(squatCount);
            timer += Time.deltaTime;
            yield return null;
        }

    }
}
