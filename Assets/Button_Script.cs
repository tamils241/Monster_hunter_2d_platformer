using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{
   public AudioSource Source;
   public AudioClip click;
   public AudioClip hower;

void Start()
{
 Source = GetComponent<AudioSource>();
}

   public void ButtonSoundClick()
   {
    Source.PlayOneShot(click);
   }
    public void ButtonSoundhower()
   {
    Source.PlayOneShot(hower);
   }

}
