using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{



    public GameObject settingMenu;
    public AudioSource MusicFx;
    AudioSource SoundFx;

    string MusicFxSave = "MusicFxSave";
    string SoundFxSave = "SoundFxSave";



    public void settingButtonOpen()
    {

        if (!settingMenu.activeSelf)
        {
            settingMenu.SetActive(true);
        }
        else
        {
            settingMenu.SetActive(false);
        }

        AudioManager.singleton.PlaySoundFX(3);

    }

    public void ButtonMusicFx()
    {
        if (MusicFx.volume == 1)
        {
            MusicFx.volume = 0;

        }
        else
        {
            MusicFx.volume = 1;

        }
        PlayerPrefs.SetInt(MusicFxSave, ((int)MusicFx.volume));

    }

    public void ButtonSoundcFx()
    {
        if (SoundFx.volume == 1)
        {
            SoundFx.volume = 0;


        }
        else
        {
            SoundFx.volume = 1;
        }
        PlayerPrefs.SetInt(SoundFxSave, ((int)SoundFx.volume));

    }



    public void PlayGame()
    {
        AudioManager.singleton.PlaySoundFX(3);
        SceneManager.LoadScene("game");
    }



    private void Awake()
    {
        SoundFx = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        MusicFx.volume = PlayerPrefs.GetInt(MusicFxSave);
        SoundFx.volume = PlayerPrefs.GetInt(SoundFxSave);


    }
}
