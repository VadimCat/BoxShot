using UnityEngine;
using Fusion;

public class Arena : SimulationBehaviour
{
    [field: SerializeField] public Transform[] SpawnPoints { get; private set; }

    private void Awake()
    {
        foreach(var spawnPoint in SpawnPoints){
            spawnPoint.LookAt(Vector3.zero);
        }
    }

    public void AssignPlayer(GameObject player, int index)
    {
        player.transform.SetPositionAndRotation(SpawnPoints[index].position, SpawnPoints[index % SpawnPoints.Length].rotation);
    }
}
