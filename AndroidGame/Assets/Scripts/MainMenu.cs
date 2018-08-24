using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Start()
   {
      Debug.Log("Menu start, volume: " + PlayerPrefs.GetFloat("volume"));
      GlobalGameValues.SetVolume(PlayerPrefs.GetFloat("volume"));
   }

   public void PlayGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void QuitGame()
   {
      Debug.Log("Quit Game...");
      Application.Quit();
   }
}
