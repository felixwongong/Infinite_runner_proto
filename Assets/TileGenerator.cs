using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] int pregeneratedTileNum = 10;

    ObjectPool pool;
    TileMover mover;

    GameObject dummy;

    Tile curTile;

    private void Awake()
    {
        mover = GetComponent<TileMover>();
        pool = GetComponent<ObjectPool>();
        dummy = new GameObject("dummy");
    }

    private void Start()
    {
        for (int i = 0; i < pregeneratedTileNum; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        Tile newTile = null;
        newTile = pool.Get().GetComponent<Tile>();
        print(newTile);
        if (curTile != null)
        {
            Transform spawnTransform = CalcSpawnTransform(curTile, newTile);
            newTile.transform.position = spawnTransform.position;
            newTile.transform.rotation = spawnTransform.rotation;
        }
        curTile = newTile;
    }

    private Transform CalcSpawnTransform(Tile prevTile, Tile newTile)
    {
        Transform prevExitTransform = prevTile.GetExitPos();
        Vector3 newEnterPos = newTile.GetEnterOffset();

        Vector3 newPosition = prevExitTransform.position + prevExitTransform.forward * newEnterPos.magnitude;

        dummy.transform.position = newPosition;
        dummy.transform.rotation = prevExitTransform.rotation;

        Transform spawnTransform = dummy.transform;

        return spawnTransform;
    }
}
