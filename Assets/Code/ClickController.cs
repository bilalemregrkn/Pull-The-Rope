using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class ClickController : MonoBehaviour, IPointerDownHandler
{
	private int _pullValue = 10;
	[SerializeField] private bool isAI;
	[SerializeField] private bool isBot;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (isAI) return;
		Pull();
	}

	private void Pull()
	{
		RopeController.Instance.Value += _pullValue;
	}

	private void Start()
	{
		_pullValue = GameManager.Instance.pullPower;
		if (isBot) _pullValue *= -1;

		if (isAI)
			StartCoroutine(AutoClick());
	}

	IEnumerator AutoClick()
	{
		while (true)
		{
			var data = GameManager.Instance.rangeDelayAI;
			var second = Random.Range(data.x, data.y);
			yield return new WaitForSeconds(second);
			Pull();
		}
		// ReSharper disable once IteratorNeverReturns
	}
}