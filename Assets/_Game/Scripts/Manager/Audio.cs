using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform transform;

    public void PlayAudio(Vector3 playPosition)
    {
        transform.position = playPosition;
        audioSource.Play();
    }
}
