using UnityEngine;
using System.Collections;
using System;
public class GameController : MonoBehaviour
{
    public GameObject levelHolder;
    public const int X = 18;
    public const int Y = 11;
    public GameObject[,] level = new GameObject[X, Y];
    // Start is called before the first frame update
    void Start()
    {
        LevelScan();
    }

    public void LevelScan()
    {
        var objects = levelHolder.GetComponentsInChildren<Transform>();
        foreach (var child in objects)
        {
            level[(int)child.position.x, (int)child.position.y] = child.gameObject;
        }

        level[0, 0] = null;
    }
}
