using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PetSoundEmitter : MonoBehaviour {
    public StudioEventEmitter SmallPetSound;
    public StudioEventEmitter MediumPetSound;
    public StudioEventEmitter LargePetSound;
    public float MinTimeInterval = 10f;
    public float MaxTimeInterval = 20f;
    public bool Alterate;

    private float _currentInterval = 0f;
    private float _timeElapsed = 0f;
    private StudioEventEmitter[] _sounds;
    private StudioEventEmitter _currentSound;
    void Start() {
        _sounds = new [] { SmallPetSound, MediumPetSound, LargePetSound};
        Vector3 petScale = transform.localScale;
        if (petScale.x == 0.5f) {
            _currentSound = SmallPetSound;
        } else if (petScale.x == 1f) {
            _currentSound = MediumPetSound;
        } else if (petScale.x == 1.5) {
            _currentSound = LargePetSound;
        }

        ResetInterval();
    }

    void Update() {
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _currentInterval) {
            PlaySound();
            ResetInterval();
        }
    }

    public void PlaySound() {
        if (_currentSound != null) {
            if (Alterate) {
                RuntimeManager.PlayOneShot(_sounds[Random.Range(0, 2)].Event, transform.position);
            } else {
                RuntimeManager.PlayOneShot(_currentSound.Event, transform.position);
            }
        }
    }

    private void ResetInterval() {
        _timeElapsed = 0;
        _currentInterval = Random.Range(MinTimeInterval, MaxTimeInterval);
    }
}
