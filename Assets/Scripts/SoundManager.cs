using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip move;
    [SerializeField] AudioClip delete;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void MoveSE()
    {
        audioSource.PlayOneShot(move);
    }

    public void DeleteSE()
    {
        audioSource.PlayOneShot(delete);
    }
}
