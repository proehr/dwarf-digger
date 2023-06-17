using Common.Logic.Variables;
using Features.Combat.Logic;
using Features.Combat.Logic.CombatUnits;
using Features.Digging.Logic;
using Features.StateSwitch.Logic;
using UnityEngine;

public class StateHandler : MonoBehaviour {
    [SerializeField] private IntVariable enemyCount;
    
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
                break;
            case GameState.COMBAT:
                break;
            default:
                break;
        }
        currentGameState = newState;
    }
}
