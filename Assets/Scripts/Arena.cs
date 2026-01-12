using UnityEngine;
using Fusion;

public class Arena : SimulationBehaviour
{
    [field: SerializeField] public Transform[] SpawnPoints { get; private set; }
    [field: SerializeField] public Color[] _playerSkins;

    private void Awake()
    {
        foreach(var spawnPoint in SpawnPoints){
            spawnPoint.LookAt(Vector3.zero);
        }
    }

    public void AssignPlayer(GameObject player, int index)
    {
        var indexClamped = index % _playerSkins.Length;
        player.transform.SetPositionAndRotation(SpawnPoints[indexClamped].position, SpawnPoints[indexClamped].rotation);
        player.transform.GetComponent<PlayerSkin>().SetSkin(_playerSkins[indexClamped]);
    }
}
