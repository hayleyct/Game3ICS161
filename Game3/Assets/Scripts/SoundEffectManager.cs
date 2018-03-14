using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundEffectManager : MonoBehaviour {

	public Sound[] sounds; 

	// Use this for initialization
	void Awake () {

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip; 
			s.source.playOnAwake = false;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch; 
		}

	}
	
	public void Play(string sound) {
		Sound s = Array.Find (sounds, item => item.name == sound);
		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		Debug.Log (s.source.clip);
		s.source.Play ();
	}
}
