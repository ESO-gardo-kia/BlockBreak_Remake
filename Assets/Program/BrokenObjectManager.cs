using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObjectManager : MonoBehaviour
{
    public Action allBrokeEvent;
    public Action<int> addScoreEvent;
    public List<GameObject> brokenObjectList;
    private static int brokenObjectNum;
    public int point = 100;
    private void Start()
    {
        GetAllBrokenObject();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BrokenAction(collision.gameObject);
        }
    }
    private void GetAllBrokenObject()
    {
        brokenObjectNum = 0;
        brokenObjectList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).CompareTag("Broken"))
            {
                brokenObjectList.Add(transform.GetChild(i).gameObject);
                transform.GetChild(i).GetComponent<Broken>().brokenAction = BrokenAction;
                brokenObjectNum++;
            }
        }
    }
    private void BrokenAction(GameObject brokenObject)
    {
        for (int i = 0; i < brokenObjectList.Count; i++)
        {
            if (brokenObjectList[i] == brokenObject)
            {
                addScoreEvent(100);
                brokenObjectList.RemoveAt(i);
                brokenObjectNum--;
            }
        }
        Debug.Log(brokenObjectNum);
        if (brokenObjectNum == 0)
        {
            Debug.Log("‘S”j‰ó");
            allBrokeEvent();
        }
    }
}
