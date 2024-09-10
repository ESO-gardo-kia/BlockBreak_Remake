using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionSystem : MonoBehaviour
{
    [SerializeField] string title = "Title";
    [SerializeField] string nextSceneName1 = "Stage01";
    [SerializeField] string nextSceneName2 = "Stage02";
    public void OnTapRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TitleTransition()
    {
        SceneManager.LoadScene(title);
    }
    public void Stage1Transition()
    {
        SceneManager.LoadScene(nextSceneName1);
    }
    public void Stage2Transition()
    {
        SceneManager.LoadScene(nextSceneName2);
    }
}
