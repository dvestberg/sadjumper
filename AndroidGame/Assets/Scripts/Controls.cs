using UnityEngine;

public class Controls : MonoBehaviour
{
	public Rigidbody2D Player;
	public float MoveSpeed;
	public float JumpHeight;
	public bool MoveRight;
	public bool MoveLeft;
	public bool Jump;
	public AudioClip JumpSound;

	private AudioSource _audioSource;
	private const int JumpPointsLost = 100;

	private GameManager _gameScript;

	void Start()
	{
		Player = GetComponent<Rigidbody2D>();
		_gameScript = FindObjectOfType<GameManager>();
		_audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Player.velocity = new Vector2(-MoveSpeed, Player.velocity.y);

		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Player.velocity = new Vector2(MoveSpeed, Player.velocity.y);
		}
		if (Input.GetKey(KeyCode.Space) && Player.velocity.y < 0.1 && Player.velocity.y > -0.1)
		{
			DoJump();
		}

		if (MoveRight)
		{
			Player.velocity = new Vector2(MoveSpeed, Player.velocity.y);
		}
		if (MoveLeft)
		{
			Player.velocity = new Vector2(-MoveSpeed, Player.velocity.y);
		}
		if (Jump && Player.velocity.y < 0.1 && Player.velocity.y > -0.1)
		{
			DoJump();
		}
	}

	private void DoJump()
	{
		Player.velocity = new Vector2(Player.velocity.x, JumpHeight);
		_audioSource.clip = JumpSound;
		_audioSource.Play();
		_gameScript.LosePoints(JumpPointsLost);
	}
}
