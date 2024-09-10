using TMPro;
using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	[SerializeField] Timer timer;
	[SerializeField] BrokenObjectManager brokenObjectManager;
	[SerializeField] UiManager uiManager;
    [SerializeField] List<GameObject> killObjectList;
	[SerializeField] GameObject ballPrefab;
	[SerializeField] int ballCount = 3;
    [SerializeField] public static bool inGame = true;
	private int score = 0;
    private int highScore = 0;
    private void Start()
    {
        EventSet();
        uiManager.UiFirstProcessing();
    }
    private void EventSet()
    {
        timer.timeOverEvent = uiManager.TimeOverEvent;
        timer.SetTimeEvent = uiManager.SetTimeEvent;
        brokenObjectManager.allBrokeEvent = ClearEvent;
        brokenObjectManager.addScoreEvent = AddScoreEvent;
        for (int i = 0; i < killObjectList.Count; ++i)
        {
            killObjectList[i].GetComponent<Kill>().KillBallEvent = KillBallEvent;
        }
    }
	private void AddScoreEvent(int point)
	{
        score += point;
        uiManager.SetScoreText(point);
    }
    private void ClearEvent()
    {
        inGame = false;
        uiManager.ShowResult(score,highScore,ballCount,timer.Timelimit);
    }
    private void KillBallEvent()
	{
		ballCount--;

		if (ballCount > 0)
		{
			GameObject newBall = Instantiate(ballPrefab);
			newBall.name = ballPrefab.name;
		}
		else
		{
			inGame = false;
            uiManager.NoRemainingBall();
        }
	}
}
