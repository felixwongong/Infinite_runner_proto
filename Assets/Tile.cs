using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject enterPos;
    [SerializeField] GameObject exitPos;

    public Transform GetExitPos()
    {
        return exitPos.transform;
    }

    public Vector3 GetEnterOffset()
    {
        return transform.position - enterPos.transform.position;
    }
}
