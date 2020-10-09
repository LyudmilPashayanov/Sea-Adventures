using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour
{
    private static IslandManager instance;
    public static IslandManager Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }
}
