using UnityEngine;

public class Touch : MonoBehaviour
{

	private Controls _player;
	private AudioManager _audioManager;
	private GameManager _gameManager;

	void Start()
	{
		_player = FindObjectOfType<Controls>();
		_audioManager = FindObjectOfType<AudioManager>();
		_gameManager = FindObjectOfType<GameManager>();
	}

	public void LeftArrow()
	{
		if (_player == null)
			_player = FindObjectOfType<Controls>();

		_player.MoveRight = false;
		_player.MoveLeft = true;
	}

	public void RightArrow()
	{
		if (_player == null)
			_player = FindObjectOfType<Controls>();

		_player.MoveRight = true;
		_player.MoveLeft = false;
	}

	public void ReleaseLeftArrow()
	{
		if (_player == null)
			_player = FindObjectOfType<Controls>();

		_player.MoveLeft = false;
	}

	public void ReleaseRightArrow()
	{
		if (_player == null)
			_player = FindObjectOfType<Controls>();

		_player.MoveRight = false;

	}

	public void ReleaseJump()
	{
		if (_player == null)
			_player = FindObjectOfType<Controls>();

		_player.Jump = false;

	}

	public void Jump()
	{
		if (_player == null)
			_player = FindObjectOfType<Controls>();

		_player.Jump = true;
	}

	public void Restart()
	{
		_gameManager.Restart();
	}

	public void ToggleMusic()
	{
		_audioManager.ToggleMusic();
	}
}
