using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1ゲーム内で何回も鳴るSE用スクリプト

public class SEController : MonoBehaviour
{

    PlayerParamClass
    paramClass = PlayerParamClass.GetInstance();

    private bool[] seBool = new bool[4];

    [Range(0.0f, 1.0f)]
    public float
        vol = 0.1f;
    public bool
        mute = false;

    [SerializeField]
    private float
        delay = 0.1f;

    public AudioClip Jump_SE;
    public AudioClip Slide_SE;
    public AudioClip Run_SE;
    public AudioClip Dmg_SE;
    public Animator Anm;

    bool a =false;
    bool b = false;
    bool c = false;

    AudioSource SoundEffecter;

    void Start()
    { 
        SoundEffecter = gameObject.AddComponent<AudioSource>();
 
    }
    void FixedUpdate()
    {
        a = Anm.GetBool("Runs");
        b = Anm.GetBool("Jump");
        c = Anm.GetBool("Sliding");
    }
    void Update()
    {
        if (b)
        {
            //SoundEffecter.PlayOneShot(Jump_SE);
        }
        if (Anm.GetCurrentAnimatorStateInfo(0).IsName("Esc_Slide_All"))
            SoundEffecter.PlayOneShot(Slide_SE);

        if (paramClass.playerSpeed !=0 && !SoundEffecter.isPlaying)
        {
            SoundEffecter.clip = Run_SE;
            SoundEffecter.PlayScheduled(delay);
            SoundEffecter.SetScheduledEndTime(AudioSettings.dspTime + Run_SE.length /4 +delay);
        }
        SoundEffecter.mute = mute;
        SoundEffecter.volume = vol;
    }

    public void DamageSE()
    {
        SoundEffecter.PlayOneShot(Run_SE);
        SoundEffecter.mute = mute;
        SoundEffecter.volume = vol;
    }

}
