using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Son[] sons;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Son s in sons)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    void Start()
    {
        Play("music");
    }

    // Update is called once per frame
    public void Play(string nom)
    {
        Son s = Array.Find(sons, son => son.nom == nom);
        s.source.Play();
    }
}
