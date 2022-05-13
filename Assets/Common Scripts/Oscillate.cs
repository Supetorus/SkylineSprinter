using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
	[SerializeField] Vector3 Axis;
	[SerializeField] float Degrees;

	float gameTime = 0;

	// Update is called once per frame
	void Update()
	{
		gameTime += Time.deltaTime;
		gameObject.transform.localRotation = Quaternion.Euler(0, Degrees * Mathf.Cos(gameTime), 0);
	}
}
