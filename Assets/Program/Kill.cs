using System;
using UnityEngine;

public class Kill : MonoBehaviour
{
	public Action KillBallEvent;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
            KillBallEvent();
            Destroy(collision.gameObject);
        }
	}
}
