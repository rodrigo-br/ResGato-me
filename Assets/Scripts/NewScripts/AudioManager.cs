using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] NewButtonsManager newButtonsManager;
    [SerializeField] Slider musicVolume;
    [SerializeField] Slider sfxVolume;
    [SerializeField] AudioClip notificationClip;
    [SerializeField] AudioClip denyClip;
    [SerializeField] AudioClip rewardClip;
    [SerializeField] AudioClip simpleButtonClip;
    AudioSource myAudioSource;

    void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        musicVolume.onValueChanged.AddListener(delegate {AdjustVolume();});
        myAudioSource.volume = musicVolume.value;
        myAudioSource.Play();
    }

    void AdjustVolume()
    {
        myAudioSource.volume = musicVolume.value;
    }

    void PlayClip(AudioClip clip)
    {
        if (clip == rewardClip)
        {
            Debug.Log("Testou");
            float saveVolume = myAudioSource.volume;
            if (myAudioSource.volume > 0)
            {
                myAudioSource.volume /= 10;
            }
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, sfxVolume.value);
            StartCoroutine(RestoreVolumeRoutine(saveVolume));
        }
        else
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, sfxVolume.value);
        }
    }

    IEnumerator RestoreVolumeRoutine(float saveVolume)
    {
        yield return new WaitForSecondsRealtime(0.4f);
        while (myAudioSource.volume < saveVolume)
        {
            myAudioSource.volume += 0.05f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        myAudioSource.volume = saveVolume;
    }

    void OnEnable()
    {
        newButtonsManager.OnCatOfferSelect += () => PlayClip(rewardClip);
        newButtonsManager.OnClickedButtonEarnMoney += () => PlayClip(simpleButtonClip);
    }
}
