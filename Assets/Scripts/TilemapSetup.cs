using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TilemapSetup : MonoBehaviour
{
    [Header("References")]
    public GameObject mainGrid;
    public GameObject spawnRoomPreset;
    public List<GameObject> roomPresets; 
    public List<GameObject> enemies;

    [Header("Properties")]
    private int currentX;
    private int currentY;
    public int roomWidth;
    public int maxRoomsLength;
    private int[,] gridPositions;
    public int numRooms;
    public bool initializing = true;
    public BoundsInt area;
    public Tilemap boundaryTilemap;
    public TileBase boundaryTile;


    void Awake()
    {
        InitializeGridPositions();
        FillBoundaryTilemap();
        Generate();
        
        initializing = false;
    }

    public void InitializeGridPositions()
    {
        gridPositions = new int[maxRoomsLength, maxRoomsLength]; // values default to 0
    }

    void FillBoundaryTilemap()
    {
        int length = maxRoomsLength * roomWidth;
        for(int i =-1; i < length; i++)
        {
            for(int j = 0; j < length; j++)
            {
                //place a black tile
                boundaryTilemap.SetTile(new Vector3Int(i, j), boundaryTile);
            }
        }
    }

    public void Generate()
    {
        ///starting grid at 0, maxRoomNum/2
        ///
        ///set grid above and below to 1
        ///algorithm where we pick, see if its 0, spawn it
        ///
        
        //draw a border of 1s
        for(int i = 0; i < maxRoomsLength; i++)
        {
            gridPositions[0, i] = 1;
            gridPositions[maxRoomsLength-1, i] = 1;
        }

        for(int i = 0; i < maxRoomsLength; i++)
        {
            gridPositions[i, 0] = 1;
            gridPositions[i, maxRoomsLength-1] = 1;
        }
        GenerateSpawnRoom(0, maxRoomsLength/2);
   
        currentX= 1;
        currentY = maxRoomsLength/2;
        GenerateNewRoom(currentX, currentY);
        for(int i = currentX*roomWidth; i < (currentX*roomWidth)+roomWidth; i++)
            {
                for(int j = currentY*roomWidth; j < (currentY*roomWidth)+roomWidth; j++)
                {
                    //i and j should be positions of the tiles
                    //remove tiles in the boundary map.
                    boundaryTilemap.SetTile(new Vector3Int(i, j), null);
                }
            }
        
        numRooms -= 1;
        while(numRooms > 0)
        {
            int num = Random.Range(0, 4);

            if(num == 0 && gridPositions[currentX, currentY+1] != 1) //up
            {
                currentY++;
                //generate new room here
                //have it return a reference to itself, then we can access it's enemy tilemap
                GameObject room =GenerateNewRoom(currentX, currentY);
                Tilemap enemyTilemap = room.transform.GetChild(2).GetComponent<Tilemap>();
                //now can get all tiles on this map, each one will be an enemy spawn location.\
               
                BoundsInt bounds = enemyTilemap.cellBounds;
                
                TileBase[] enemySpawnTiles = enemyTilemap.GetTilesBlock(bounds);
                for (int x = 0; x < bounds.size.x; x++) {
                    for (int y = 0; y < bounds.size.y; y++) {
                        TileBase tile = enemySpawnTiles[x + y * bounds.size.x];
                        if (tile != null) {
                            //here, x and y should be enemy spawn position
                            Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector2(currentX*roomWidth + x-1.5f, currentY*roomWidth+y-.5f), Quaternion.identity);
                        } 
                    }
                }        
                numRooms -= 1;
                //check if left is a valid option, if it is spawn a room here
                //if its not occupied
                //if its not on the edge
            }
            else if(num == 1 && gridPositions[currentX-1, currentY] != 1) //up
            {
                currentX--;
                //generate new room here
                //have it return a reference to itself, then we can access it's enemy tilemap
                GameObject room =GenerateNewRoom(currentX, currentY);
                Tilemap enemyTilemap = room.transform.GetChild(2).GetComponent<Tilemap>();
                //now can get all tiles on this map, each one will be an enemy spawn location.\
               
                BoundsInt bounds = enemyTilemap.cellBounds;
                
                TileBase[] enemySpawnTiles = enemyTilemap.GetTilesBlock(bounds);
                for (int x = 0; x < bounds.size.x; x++) {
                    for (int y = 0; y < bounds.size.y; y++) {
                        TileBase tile = enemySpawnTiles[x + y * bounds.size.x];
                        if (tile != null) {
                            //here, x and y should be enemy spawn position
                            Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector2(currentX*roomWidth + x-1.5f, currentY*roomWidth+y-.5f), Quaternion.identity);
                        } 
                    }
                }        
                numRooms -= 1;
                //check if left is a valid option, if it is spawn a room here
                //if its not occupied
                //if its not on the edge
            }
            else if(num == 2 && gridPositions[currentX, currentY-1] != 1) //up
            {
                currentY--;
                ///generate new room here
                //have it return a reference to itself, then we can access it's enemy tilemap
                GameObject room =GenerateNewRoom(currentX, currentY);
                Tilemap enemyTilemap = room.transform.GetChild(2).GetComponent<Tilemap>();
                //now can get all tiles on this map, each one will be an enemy spawn location.\
               
                BoundsInt bounds = enemyTilemap.cellBounds;
                
                TileBase[] enemySpawnTiles = enemyTilemap.GetTilesBlock(bounds);
                for (int x = 0; x < bounds.size.x; x++) {
                    for (int y = 0; y < bounds.size.y; y++) {
                        TileBase tile = enemySpawnTiles[x + y * bounds.size.x];
                        if (tile != null) {
                            //here, x and y should be enemy spawn position
                            Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector2(currentX*roomWidth + x-1.5f, currentY*roomWidth+y-.5f), Quaternion.identity);
                        } 
                    }
                }        
                numRooms -= 1;
                //check if left is a valid option, if it is spawn a room here
                //if its not occupied
                //if its not on the edge
            }
            else if(num == 3 && gridPositions[currentX+1, currentY] != 1) //up
            {
                currentX++;
                //generate new room here
                //have it return a reference to itself, then we can access it's enemy tilemap
                GameObject room = GenerateNewRoom(currentX, currentY);
                Tilemap enemyTilemap = room.transform.GetChild(2).GetComponent<Tilemap>();
                Tilemap wallTilemap = room.transform.GetChild(1).GetComponent<Tilemap>();
                //now can get all tiles on this map, each one will be an enemy spawn location.\
               
                BoundsInt bounds = enemyTilemap.cellBounds;
                
                TileBase[] enemySpawnTiles = enemyTilemap.GetTilesBlock(bounds);
                for (int x = 0; x < bounds.size.x; x++) {
                    for (int y = 0; y < bounds.size.y; y++) {
                        TileBase tile = enemySpawnTiles[x + y * bounds.size.x];
                        if (tile != null) {
                            //here, x and y should be enemy spawn position
                            Instantiate(enemies[Random.Range(0, enemies.Count)], new Vector2(currentX*roomWidth + x-1.5f, currentY*roomWidth+y-.5f), Quaternion.identity);
                        } 
                    }
                }        
                numRooms -= 1;
                //check if left is a valid option, if it is spawn a room here
                //if its not occupied
                //if its not on the edge
            }
            else
            {
                continue;
            }
            for(int i = currentX*roomWidth; i < (currentX*roomWidth)+roomWidth; i++)
            {
                for(int j = currentY*roomWidth; j < (currentY*roomWidth)+roomWidth; j++)
                {
                    //i and j should be positions of the tiles
                    //remove tiles in the boundary map.
                    boundaryTilemap.SetTile(new Vector3Int(i, j), null);
                }
            }
        }



    }


    public void GenerateSpawnRoom(int x, int y)
    {
        //instantiate the preset at the given position
        //set the preset's parent to the grid object
        GameObject spawned = Instantiate(spawnRoomPreset, new Vector2(x*roomWidth, y * roomWidth), Quaternion.identity);
        spawned.transform.SetParent(mainGrid.transform);
        for(int i = x*roomWidth; i < (x*roomWidth)+roomWidth; i++)
        {
            for(int j = y*roomWidth; j < (y*roomWidth)+roomWidth; j++)
            {
                //i and j should be positions of the tiles
                //remove tiles in the boundary map.
                boundaryTilemap.SetTile(new Vector3Int(i, j), null);
            }
        }

    }


    public GameObject GenerateNewRoom(int x, int y)
    {
        //instantiate the preset at the given position
        //set the preset's parent to the grid object
        if(roomPresets.Count > 0)
        {
            GameObject spawned = Instantiate(roomPresets[Random.Range(0, roomPresets.Count)], new Vector2(x * roomWidth, y * roomWidth), Quaternion.identity);
            spawned.transform.SetParent(mainGrid.transform);
            //set this grid position to 1
            gridPositions[x, y] = 1;
            return spawned;
        }
        else
        {
            Debug.Log("Error, no room presets found");
            return null;
        }
        
    }







    //no matter what, theres a spawn room

    ///parts needed
    ///grab a random preset
    ///choose a random direction from our current tilemap position
    ///
}
