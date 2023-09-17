using UnityEngine;
using UnityEngine.Serialization;

public class FootstepSoundManager : MonoBehaviour
{
    [SerializeField] private float _footstepCooldown = 0.5f;
    [SerializeField] private AudioClip[] _footstepSounds;
    
    [SerializeField] private float _minPitch = 0.5f;
    [SerializeField] private float _maxPitch = 1f;
    
    private AudioSource _audioSource;
    private float _lastFootstepTime;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _lastFootstepTime = -_footstepCooldown;
    }

    private void PlayRandomFootstepSound()
    {
        if (_footstepSounds.Length <= 0) 
            return;

        float randomPitch = Random.Range(_minPitch, _maxPitch);
        _audioSource.pitch = randomPitch;
        
        int randomIndex = Random.Range(0, _footstepSounds.Length);
        _audioSource.clip = _footstepSounds[randomIndex];
        
        _audioSource.Play();
    }

    public void PlayFootstep()
    {
        float currentTime = Time.time;
        if (!(currentTime - _lastFootstepTime >= _footstepCooldown)) 
            return;
        
        PlayRandomFootstepSound();
        _lastFootstepTime = currentTime;
    }
}