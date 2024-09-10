using System;
using UnityEngine;

public class Broken : MonoBehaviour
{
	public Action<GameObject> brokenAction;
	public int point = 100;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			brokenAction(gameObject);
			gameObject.SetActive(false);
        }
	}
}
