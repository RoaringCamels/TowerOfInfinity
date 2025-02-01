using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapSetup : MonoBehaviour
{
    [Header("References")]
    public GameObject mainGrid;
    public GameObject spawnRoomPreset;
    public List<GameObject> roomPresets; 

    [Header("Properties")]
    private int currentX;
    private int currentY;
    public int roomWidth;
    public int maxRoomsLength;
    private int[,] gridPositions;
    public int numRooms;



    void Awake()
    {
        InitializeGridPositions();
        //Generate();
    }

    public void InitializeGridPositions()
    {
        gridPositions = new int[maxRoomsLength, maxRoomsLength]; // values default to 0
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
        numRooms -= 1;
        while(numRooms > 0)
        {
            int num = Random.Range(0, 4);

            if(num == 0 && gridPositions[currentX, currentY+1] != 1) //up
            {
                currentY++;
                //generate new room here
                GenerateNewRoom(currentX, currentY);
                numRooms -= 1;
                //check if left is a valid option, if it is spawn a room here
                //if its not occupied
                //if its not on the edge
            }
            else if(num == 1 && gridPositions[currentX-1, currentY] != 1) //up
            {
                currentX--;
                //generate new room here
                GenerateNewRoom(currentX, currentY);
                numRooms -= 1;
                //check if left is a valid option, if it is spawn a room here
                //if its not occupied
                //if its not on the edge
            }
            else if(num == 2 && gridPositions[currentX, currentY-1] != 1) //up
            {
                currentY--;
                //generate new room here
                GenerateNewRoom(currentX, currentY);
                numRooms -= 1;
                //check if left is a valid option, if it is spawn a room here
                //if its not occupied
                //if its not on the edge
            }
            else if(num == 3 && gridPositions[currentX+1, currentY] != 1) //up
            {
                currentX++;
                //generate new room here
                GenerateNewRoom(currentX, currentY);
                numRooms -= 1;
                //check if left is a valid option, if it is spawn a room here
                //if its not occupied
                //if its not on the edge
            }
            else
            {
                continue;
            }
            
        }



    }


    public void GenerateSpawnRoom(int x, int y)
    {
        //instantiate the preset at the given position
        //set the preset's parent to the grid object
        GameObject spawned = Instantiate(spawnRoomPreset, new Vector2(x*roomWidth, y * roomWidth), Quaternion.identity);
        spawned.transform.SetParent(mainGrid.transform);


    }


    public void GenerateNewRoom(int x, int y)
    {
        //instantiate the preset at the given position
        //set the preset's parent to the grid object
        GameObject spawned = Instantiate(roomPresets[Random.Range(0, roomPresets.Count)], new Vector2(x * roomWidth, y * roomWidth), Quaternion.identity);
        spawned.transform.SetParent(mainGrid.transform);
        //set this grid position to 1
        gridPositions[x, y] = 1;
    }







    //no matter what, theres a spawn room

    ///parts needed
    ///grab a random preset
    ///choose a random direction from our current tilemap position
    ///
}
