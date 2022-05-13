using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	
	public int pullPower;
	public Vector2 rangeDelayAI;

	private void Awake()
	{
		Instance = this;
	}
}