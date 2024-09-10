using UnityEngine;
using System;
using TMPro;
using UnityEngine.Assertions;

public class Timer : MonoBehaviour
{
    public Action timeOverEvent;
    public Action<int> SetTimeEvent;
    [SerializeField] private float timelimit = 30;
    [SerializeField] public int Timelimit { get => Mathf.RoundToInt(timelimit); }
    private void Update()
    {
        if (GameManager.inGame == true)
        {
            timelimit -= Time.deltaTime;
            SetTimeEvent(Timelimit);
            if (timelimit <= 0)
            {
                timeOverEvent();
            }
        }
    }
}
