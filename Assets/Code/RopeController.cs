using System;
using UnityEngine;

public class RopeController : MonoBehaviour
{
	public static RopeController Instance { get; private set; }

	public int Value { get; set; }

	[SerializeField] private Transform topLine;
	[SerializeField] private Transform botLine;
	[SerializeField] private Vector2 minMaxValue;

	private Vector2 _minMaxVerticalPosition;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		_minMaxVerticalPosition = new Vector2(botLine.position.y, topLine.position.y);
	}

	private void FixedUpdate()
	{
		var position = transform.position;
		var normalize = Mathf.InverseLerp(minMaxValue.x, minMaxValue.y, Value);
		var verticalPosition = Mathf.Lerp(_minMaxVerticalPosition.x, _minMaxVerticalPosition.y, normalize);
		var currentVerticalPosition = Mathf.Lerp(transform.position.y, verticalPosition, .1f);
		position.y = currentVerticalPosition;
		transform.position = position;

		if (Mathf.Abs(Math.Abs(transform.position.y) - Math.Abs(_minMaxVerticalPosition.y)) < .1f)
		{
			Debug.Log("Game Finish");
			if (transform.position.y > 0)
				Debug.Log("Red Win");
			else
				Debug.Log("Blue Win");
			Time.timeScale = 0;
		}
	}
}