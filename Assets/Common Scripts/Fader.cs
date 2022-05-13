using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
	[SerializeField] float time = 1;
	Material material;
	float alpha = 0;
	// Start is called before the first frame update
	void Start()
	{
		material = GetComponent<Renderer>().material;
		StartCoroutine(FadeInRoutine());
		StartCoroutine(Timer(2));
		//StartCoroutine("Timer", 2);
		StartCoroutine(UpdateAI(3));
	}

	// Update is called once per frame
	void Update()
	{

	}

	void FadeIn()
	{
		alpha += Time.deltaTime / time;
		alpha = Mathf.Min(alpha, 1);

		Color color = material.color;
		color.a = alpha;
		material.color = color;
	}

	IEnumerator FadeInRoutine()
	{
		while (alpha < 1)
		{
			alpha += Time.deltaTime / time;
			alpha = Mathf.Min(alpha, 1);

			Color color = material.color;
			color.a = alpha;
			material.color = color;
			yield return null;
		}
	}

	IEnumerator Timer(float time)
	{
		print("hello");
		yield return new WaitForSeconds(time);
		print("world");
		yield return new WaitForSeconds(time);
		print("goodbye");
		yield return new WaitForSeconds(time);
	}

	IEnumerator UpdateAI(float time)
	{
		for (; ; )
		{
			print("thinking...");
			yield return new WaitForSeconds(time);
		}
	}
}
