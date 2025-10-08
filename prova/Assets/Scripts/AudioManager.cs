using System.Collections.Generic;
using UnityEngine;
public enum AudioClips
{
    Yamete,
    Shot
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private List<AudioClip> _clip = new List<AudioClip>();
    public Dictionary<AudioClips, AudioClip> clipList = new Dictionary<AudioClips, AudioClip>();
    private void Awake()
    {
        Instance = this;
        clipList.Add(AudioClips.Yamete, _clip[0]);
        clipList.Add(AudioClips.Shot, _clip[1]);
    }
}
