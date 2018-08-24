using UnityEngine;

public class FloorScript : MonoBehaviour
{

   private SpawnManager _spawnManager;
   private GameManager _gameManager;

   void Start()
   {
      _spawnManager = FindObjectOfType<SpawnManager>();
      _gameManager = FindObjectOfType<GameManager>();
   }

   void OnCollisionEnter2D(Collision2D col)
   {
      if (_spawnManager.IsPlayer(col.gameObject))
      {
         _gameManager.LosePoints(100);
         _spawnManager.ResetPlayerSpawn();
      }
   }
}
