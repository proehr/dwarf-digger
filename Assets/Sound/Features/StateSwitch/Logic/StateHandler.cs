using Common.Logic.Variables;
using Features.StateSwitch.Logic;
using UnityEngine;

public class StateHandler : MonoBehaviour {
    [SerializeField] private IntVariable enemyCount;
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource stateSwitchAudioSource;
    [SerializeField] private AudioClip environmentAudio;
    [SerializeField] private AudioClip toCombatSwitchAudio;
    [SerializeField] private AudioClip combatAudio;
    [SerializeField] private AudioClip toEnvironmentSwitchAudio;
    
    private GameState currentGameState;

    public GameState CurrentGameState {
        get => currentGameState;
    }

    public void Awake() {
        currentGameState = GameState.DIGGING;
        enemyCount.GetChangedEvent().RegisterListener(CheckEnemyCount);
    }

    private void CheckEnemyCount() {
        Debug.Log("Enemy Count: " + enemyCount.Get());
        OnStateChange(enemyCount.Get() > 0 ? GameState.COMBAT : GameState.DIGGING);
    }

    private void OnStateChange(GameState newState) {
        if (newState == currentGameState) return;
        switch (newState) {
            case GameState.DIGGING:
                stateSwitchAudioSource.clip = toEnvironmentSwitchAudio;
                stateSwitchAudioSource.Play();
                LoopSoundtrack(environmentAudio);
                break;
            case GameState.COMBAT:
                stateSwitchAudioSource.clip = toCombatSwitchAudio;
                stateSwitchAudioSource.Play();
                LoopSoundtrack(combatAudio);
                break;
            default:
                break;
        }
        currentGameState = newState;
    }

    private void LoopSoundtrack(AudioClip audioClip)
    {
        backgroundAudioSource.clip = audioClip;
        backgroundAudioSource.Play();
    }
}
