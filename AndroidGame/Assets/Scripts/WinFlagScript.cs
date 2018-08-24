using UnityEngine;

public class WinFlagScript : MonoBehaviour
{

	private GameManager _gameManager;

	void Start()
	{
		_gameManager = FindObjectOfType<GameManager>();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		_gameManager.WinFlagCollision(col);
	}
}
