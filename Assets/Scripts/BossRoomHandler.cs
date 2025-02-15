using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BossRoomHandler : MonoBehaviour
{

    public static BossRoomHandler Instance;
    [SerializeField] private Tilemap wallTilemap;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OpenDoor();
        }
    }


    public void OpenDoor()
    {

        wallTilemap.SetTile(new Vector3Int(6, 13), null);
        wallTilemap.SetTile(new Vector3Int(6, 14), null);
    }
}
