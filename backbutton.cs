using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class backbutton : MonoBehaviour
{
  

   private void Update()
    {
        if (SpawnLightning.�lenK�yl� == 20)
        {
            SceneManager.LoadScene("gameover");
            SpawnLightning.�lenK�yl� = 21;

        }
        Debug.Log(SpawnLightning.�lenK�yl�);
    }

    public  void back()
    {
        SceneManager.LoadScene("anamen�");
    }
    public void setttings()
    {
        SceneManager.LoadScene("settingsmen�");
    }
    public void play()
    {
        SceneManager.LoadScene("Oyun");
      
    }
    public void credits()
    {
        SceneManager.LoadScene("credits");
    }
    public AudioMixer AudioMixer;
    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
