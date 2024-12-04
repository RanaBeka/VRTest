using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallAudioController : MonoBehaviour
{
    [SerializeField] AudioSource ballAudioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] float maxMagnitude = 18f;
    Rigidbody rb;

    private void Awake()
    {
        ballAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<AudioProperties>() == null)
            return;

        audioClip = collision.gameObject.GetComponent<AudioProperties>().audioClips;
        ballAudioSource.volume = CalculateVolumeFromSpeed();

        ballAudioSource.PlayOneShot(audioClip);
    }

    private float CalculateVolumeFromSpeed()
    {
        var volume = rb.velocity.magnitude / maxMagnitude;
        return volume;
    }
}
