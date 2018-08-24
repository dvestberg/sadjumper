using UnityEngine;

public class AudioManager : MonoBehaviour
{
   private AudioSource _musicPlayer;
   private int _currentAudioClip;

   public AudioClip[] AudioClips;

   // Use this for initialization
   void Start()
   {
      _currentAudioClip = 0;
      _musicPlayer = GetComponent<AudioSource>();
      _musicPlayer.clip = AudioClips[PlayerPrefs.GetInt("clipNumber", 0)];
      _musicPlayer.volume = GlobalGameValues.Volume;
      _musicPlayer.Play();
   }

   public void ToggleMusic()
   {
      SetNextAudioClip();
      _musicPlayer.clip = AudioClips[_currentAudioClip];
      _musicPlayer.volume = GlobalGameValues.Volume;
      _musicPlayer.Play();
   }

   private void SetNextAudioClip()
   {
      _currentAudioClip++;

      if (_currentAudioClip == AudioClips.Length)
         _currentAudioClip = 0;

      PlayerPrefs.SetInt("clipNumber", _currentAudioClip);
   }

}
