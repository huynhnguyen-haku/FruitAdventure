using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;


    [Header("Audio Clips")]
    public AudioClip fruit;
    public AudioClip jump;
    public AudioClip playerHit;
    public AudioClip monsterHit;

    [Header("Background Music and Effect")]
    public AudioClip BGM;
    public AudioClip checkPoint;
    public AudioClip finishStage;
    public AudioClip deadScreen;
    public AudioClip resultScreen;
    public AudioClip buttonClick;
    public AudioClip booster;
    public AudioClip trampoline;
    public AudioClip box;
    public AudioClip dash;

    private void Start()
    {
        musicSource.clip = BGM;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();
    }

}
