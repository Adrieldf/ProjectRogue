using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Transform> StartPositions;
    public List<Transform> EndPositions;
    public RoomType RoomType;

    [SerializeField]
    private List<Transform> _enemySpawnerPositions;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            Debug.Log(child.gameObject.name);
        }
    }

    private void Start()
    {
        SpawnEnemies();
    }


    void SpawnEnemies()
    {
        foreach (Transform pos in _enemySpawnerPositions)
        {
            //pegar de uma pool de inimigos e spawnar randomicamente algum dentro dela
        }
    }
}

public enum RoomType
{
    Basic,
    Dangerous,
    Treasure,
    Trap,

}

