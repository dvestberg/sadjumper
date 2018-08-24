using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
   public GameObject[] GrassPlatformPrefabs;
   public GameObject PlayerPrefab;
   public GameObject WinFlagGroupPrefab;
   public int MaxPlattforms = 17;

   private const float HorizontalMin = 1f;
   private const float HorizontalMax = 8f;
   private const float VerticalMin = -5f;
   private const float VerticalMax = 5f;

   private const float MinVerticalMovement = 1.5f;

   private Vector2 _startPosition;
   private readonly Vector2 _originPosition = new Vector2(-10, 0);
   private readonly Vector2 _playerStartPosition = new Vector2(-10, 5);

   private GameObject _playerInstance;
   private GameObject[] _groundInstances;
   private GameObject _winFlagInstance;

   public void InitWorld()
   {
      _startPosition = _originPosition;
      SpawnPlayer();
      SpawnGround();
      SpawnWinFlag();
   }

   private void SpawnPlayer()
   {
      _playerInstance = Instantiate(PlayerPrefab, _playerStartPosition, Quaternion.identity);
   }

   private void SpawnGround()
   {
      _groundInstances = new GameObject[MaxPlattforms + 1];
      _groundInstances[0] = Instantiate(GrassPlatformPrefabs[0], _startPosition, Quaternion.identity);

      for (var i = 0; i < MaxPlattforms; i++)
      {
         var randomPosition = GetNewRandomPosition();
         _groundInstances[i + 1] = Instantiate(GetRandomGroundPrefab(), randomPosition, Quaternion.identity);
         _startPosition = randomPosition;
      }
   }

   private void SpawnWinFlag()
   {
      _winFlagInstance = Instantiate(WinFlagGroupPrefab, GetNewRandomPosition(), Quaternion.identity);
   }

   private GameObject GetRandomGroundPrefab()
   {
      var number = Random.Range(0, GrassPlatformPrefabs.Length - 1);
      return GrassPlatformPrefabs[number];
   }

   private Vector2 GetNewRandomPosition()
   {
      var randomPosition = _startPosition + new Vector2(Random.Range(HorizontalMin, HorizontalMax), GetNewVerticalAdjustment());
      if (randomPosition.y < -20)
         randomPosition.y = -18;

      if (randomPosition.y > 20)
         randomPosition.y = 18;

      return randomPosition;
   }

   private static float GetNewVerticalAdjustment()
   {
      var newVerticalPosition = Random.Range(VerticalMin, VerticalMax);

      if (newVerticalPosition > MinVerticalMovement * -1f && newVerticalPosition < MinVerticalMovement)
         newVerticalPosition = Random.Range(0, 2) > 1f ? MinVerticalMovement : MinVerticalMovement * -1f;

      return newVerticalPosition;
   }

   public void ResetPlayerSpawn()
   {
      _playerInstance.transform.position = _playerStartPosition;
   }

   public bool IsPlayer(GameObject col)
   {
      return col == _playerInstance;
   }

   public void InactivatePlayer()
   {
      if (_playerInstance.activeInHierarchy)
         _playerInstance.SetActive(false);
   }

   public Vector3 GetPlayerPosition()
   {
      return _playerInstance == null ? Vector3.zero : _playerInstance.transform.position;
   }

   public void ResetWorld()
   {
      foreach (var groundObject in _groundInstances)
      {
         Destroy(groundObject);
      }


      Destroy(_playerInstance);
      Destroy(_winFlagInstance);

      _startPosition = _originPosition;

      SpawnPlayer();
      SpawnGround();
      SpawnWinFlag();

      _playerInstance.SetActive(true);
      ResetPlayerSpawn();
   }
}
