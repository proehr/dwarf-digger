using Common.Logic.Variables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Common.Logic.Event
{
	[CreateAssetMenu(fileName = "newSimpleAudioEvent", menuName = "General_Logic/SimpleAudioEvent")]
	public class SimpleAudioEvent : AudioEvent
	{
		public AudioClip[] clips;

		public RangedFloat volume;

		[MinMaxRange(0, 2)]
		public RangedFloat pitch;

		public override void Play(AudioSource source)
		{
			if (clips.Length == 0) return;

			source.clip = clips[Random.Range(0, clips.Length)];
			source.volume = Random.Range(volume.minValue, volume.maxValue);
			source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
			source.Play();
		}
	}
}