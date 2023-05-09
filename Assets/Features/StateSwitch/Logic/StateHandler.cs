using Common.Logic.Event;
using Common.Logic.Variables;
using Features.Combat.Logic.CombatUnits;
using Features.Digging.Logic;
using Features.StateSwitch.Logic;
using UnityEngine;

public class StateHandler : MonoBehaviour {
    [SerializeField] private IntVariable enemyCount;

    [SerializeField]  private PlayerCombatParticipant playerCombatComponent;
   // [SerializeField]  private Digger playerDiggingComponent;
    [SerializeField] private DiggingTool diggingTool;
    
    private GameState currentGameState;
    private GameState oldGameState;
    
    public void Awake() {
        currentGameState = GameState.DIGGING;
        oldGameState = GameState.DIGGING;

        enemyCount.GetChangedEvent().RegisterListener(CheckEnemyCount);
        
        OnStateChange();
    }

    private void CheckEnemyCount() {
        Debug.Log("Enemy Count: " + enemyCount.Get());
        SetGameState(enemyCount.Get() > 0 ? GameState.COMBAT : GameState.DIGGING);
    }

    private void OnStateChange() {
        Debug.Log("Current State on Change: " + currentGameState);
        if (currentGameState == oldGameState) return;
        switch (currentGameState) {
            case GameState.DIGGING:
               // playerCombatComponent.enabled = false;
               // playerDiggingComponent.enabled = true;
               diggingTool.enabled = true;
                break;
            case GameState.COMBAT:
                //playerCombatComponent.enabled = true;
                //playerDiggingComponent.enabled = false;
                diggingTool.enabled = false;
                break;
            default:
                break;
        }
        oldGameState = currentGameState;
    }

    private void SetGameState(GameState newState) {
        this.currentGameState = newState;
        Debug.Log("Current State after Switching: " + newState);
        OnStateChange();
    }
}
