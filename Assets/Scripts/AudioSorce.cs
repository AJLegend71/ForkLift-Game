using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSorce : MonoBehaviour
{
  AudioSource audioSource;
  public AudioClip other;
  bool playing;
  [SerializeField]
  private bool onlyOnce;
  
  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    playing = true;
  }

  void Update()
  {
    if(!audioSource.isPlaying)
    {
        playing = false;
    }

    if(onlyOnce != true && !playing)
    {
        audioSource.clip = other;
        audioSource.Play();
        playing = true;
    }
    
  }
}
