using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private int _highScore;
   private int _currentScore;
   private Stopwatch _stopWatch;

   public SpawnManager SpawnManager;

   public Text MainText;
   public Text HighscoreText;
   public Text LastScoreText;
   public Text CurrentScoreText;

   // Use this for initialization
   private void Start()
   {
      _highScore = PlayerPrefs.GetInt("highScore", 0);
      _currentScore = 10000;

      MainText.text = string.Empty;
      HighscoreText.text = GetHighScoreText();
      LastScoreText.text = string.Empty;
      CurrentScoreText.text = string.Empty;

      SpawnManager.InitWorld();

      _stopWatch = new Stopwatch();
      _stopWatch.Start();
   }

   private string GetHighScoreText()
   {
      return _highScore > 0 ? string.Format("High score: {0}p", _highScore) : string.Empty;
   }

   // Update is called once per frame
   private void Update()
   {
      var currentScore = CalculateCurrentScore();
      CurrentScoreText.text = string.Format("Current score: {0}s", currentScore);
   }

   public void WinFlagCollision(Collision2D col)
   {
      if (SpawnManager.IsPlayer(col.gameObject))
      {
         var currentScore = CalculateCurrentScore();

         if (_highScore == 0 || _highScore < currentScore)
            SetHighScore();

         MainText.text = string.Format("You Win! Time: {0}p", currentScore);
         LastScoreText.text = string.Format("Last score: {0}p", currentScore);

         SpawnManager.InactivatePlayer();
         StartCoroutine(RestartGame());
      }
   }

   private void SetHighScore()
   {
      var currentScore = CalculateCurrentScore();
      PlayerPrefs.SetInt("highScore", currentScore);
      _highScore = currentScore;
   }

   public void LosePoints(int points)
   {
      _currentScore -= points;
   }

   private IEnumerator RestartGame()
   {
      yield return new WaitForSeconds(5);
      SwitchScene();

      SpawnManager.ResetWorld();

      _stopWatch = new Stopwatch();
      _stopWatch.Start();

      HighscoreText.text = GetHighScoreText();
      MainText.text = string.Empty;
      _currentScore = 10000;
   }

   public void Restart()
   {
      _stopWatch = new Stopwatch();
      _stopWatch.Start();
      _currentScore = 10000;
      SpawnManager.ResetPlayerSpawn();
   }

   public void SwitchScene()
   {
      var nextScene = GetNextScene();
      SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
   }

   private static int GetNextScene()
   {
      var currentScene = SceneManager.GetActiveScene().buildIndex;
      if (currentScene >= SceneManager.sceneCountInBuildSettings - 1)
         return 0;

      return currentScene + 1;
   }

   private int CalculateCurrentScore()
   {
      var currentTime = (int)_stopWatch.Elapsed.TotalSeconds;
      return _currentScore - (currentTime / 2) * 100;
   }
}
