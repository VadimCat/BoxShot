using UnityEngine;
using Fusion;

public class PlayerConnectionHandler : SimulationBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Arena _arena;

    public void PlayerJoined(PlayerRef player)
    {
        Debug.Log("Player joined: " + player);
        if(player == Runner.LocalPlayer)
        {
            Debug.Log("Assigning player to arena: " + player.AsIndex);
            _arena.AssignPlayer(Runner.Spawn(_playerPrefab).gameObject, player.AsIndex);
        }
    }
}