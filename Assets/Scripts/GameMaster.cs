using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    private MapController mapController;
    private PlayerTurnController playerTurnController;
    private UnitController unitController;


    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        
    }
    // Start is called before the first frame update
    void Start()
    {
        mapController = MapController.Instance;
        playerTurnController = PlayerTurnController.Instance;
        unitController = UnitController.Instance;

        playerTurnController.InitializePlayers();
        playerTurnController.turnStateMachine.OnPhaseChanged += playerTurnController.OnPhaseChanged;
        playerTurnController.combatStateMachine.OnPhaseChanged += playerTurnController.OnCombatPhaseChanged;
        playerTurnController.InitializePlayersFleets();
        playerTurnController.InitializeFirstPlayer();

        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,1), PlayerType.PlayerOne); //debug purposes
        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,1), PlayerType.PlayerOne); //debug purposes
        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,1), PlayerType.PlayerOne); //debug purposes

        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,1), PlayerType.PlayerTwo); //debug purposes
        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,1), PlayerType.PlayerTwo); //debug purposes
        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,1), PlayerType.PlayerTwo); //debug purposes

        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,2), PlayerType.PlayerOne); //debug purposes
        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,2), PlayerType.PlayerOne); //debug purposes
        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,2), PlayerType.PlayerOne); //debug purposes

        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,2), PlayerType.PlayerTwo); //debug purposes
        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,2), PlayerType.PlayerTwo); //debug purposes
        unitController.SpawnShip(unitController.shipPrefab, new GridPosition(0,2), PlayerType.PlayerTwo); //debug purposes
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
