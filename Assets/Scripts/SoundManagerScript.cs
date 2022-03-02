using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerJumpSound, coinCollectSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip> ("playerJump");
        //coinCollectSound = Resources.Load<AudioClip> ("coinCollect");
        
        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip){
        switch (clip) {
            case "playerJump":
            audioSrc.PlayOneShot (playerJumpSound);
            break;
            //add other sounds in the switch statement here
        }
    }
}
