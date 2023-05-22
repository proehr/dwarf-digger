using Common.Logic.Event;
using Common.Logic.Variables;
using Features.Combat.Logic;
using Features.Combat.Logic.CombatUnits;
using Features.Digging.Logic;
using Features.StateSwitch.Logic;
using UnityEngine;

public class StateHandler : MonoBehaviour {
    [SerializeField] private IntVariable enemyCount;

    [SerializeField] private PlayerCombatParticipant playerCombatComponent;
    [SerializeField]  private Digger playerDiggingComponent;

    [SerializeField] private DiggingTool diggingTool;

    private GameState currentGameState;

    public void Awake() {
        currentGameState = GameState.DIGGING;
        playerCombatComponent.enabled = false;
        playerDiggingComponent.enabled = true;
        diggingTool.enabled = true;
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
                playerCombatComponent.enabled = false;
                playerDiggingComponent.enabled = true;
                diggingTool.enabled = true;
                break;
            case GameState.COMBAT:
                playerCombatComponent.enabled = true;
                playerDiggingComponent.enabled = false;
                diggingTool.enabled = false;
                break;
            default:
                break;
        }
        currentGameState = newState;
    }
}
