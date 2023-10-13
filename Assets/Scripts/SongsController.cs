using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongsController : MonoBehaviour
{
    [SerializeField]List<AudioClip> Clips;
    AudioSource Audio;
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        ChangeMusic(0);
    }
    public void ChangeMusic(int n)
    {
        Audio.Stop();
        Audio.clip = Clips[n];
        Audio.Play();
    }
}
