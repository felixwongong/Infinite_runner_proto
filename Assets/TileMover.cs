using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    GameObject player;

    TileGenerator generator;

    private void Awake()
    {
        generator = GameObject.FindWithTag("TileGenerator").GetComponent<TileGenerator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        transform.position -= player.transform.forward * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        generator.SpawnTile();
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") yield return null;

        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }
}
