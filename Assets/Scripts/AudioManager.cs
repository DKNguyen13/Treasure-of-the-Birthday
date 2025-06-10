using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;

    public AudioClip musicClip;
    public AudioClip win;
    public AudioClip lose;

    public GameObject winPanel;
    public TextMeshProUGUI winText, loseText;
    // Start is called before the first frame update
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySFX(AudioClip clip)
    {
        musicAudioSource.Stop();
        vfxAudioSource.clip = win;
        vfxAudioSource.PlayOneShot(clip);
        winPanel.SetActive(true);
        winText.enabled = true;
        loseText.enabled = false;
        //StartCoroutine(ShowPanelAfterSound());
    }
    public void StopMusic(AudioClip clip)
    {
        musicAudioSource.Stop();
        vfxAudioSource.clip = lose;
        vfxAudioSource.PlayOneShot(clip);

    }
    /*
    IEnumerator ShowPanelAfterSound()
    {
        // Chờ cho đến khi âm thanh kết thúc
        while (vfxAudioSource.isPlaying)
        {
            yield return null;
        }

        // Hiển thị panel chiến thắng
        winPanel.SetActive(true);
    }*/
}
