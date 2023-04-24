using UnityEngine;

namespace Common.Logic.Event
{
	public abstract class AudioEvent : ScriptableObject
	{
		public abstract void Play(AudioSource source);
	}
}