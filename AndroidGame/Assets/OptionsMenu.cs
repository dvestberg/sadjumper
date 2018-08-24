using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
   public Slider VolumeSlider;

   public void Start()
   {
      VolumeSlider.value = GlobalGameValues.Volume;
   }

   public void SetVolume()
   {
      Debug.Log("Setting volume: " + VolumeSlider.value);
      PlayerPrefs.SetFloat("volume", VolumeSlider.value);
      GlobalGameValues.SetVolume(VolumeSlider.value);
   }
}
