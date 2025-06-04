using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform[] roomPositions;
    private int currentRoomIndex = 0;

    public void MoveToRoom(int index)
    {
        if (index >= 0 && index < roomPositions.Length)
        {
            currentRoomIndex = index;
            transform.position = roomPositions[index].position;
            transform.rotation = roomPositions[index].rotation;
        }
    }

    public void MoveToNextRoom()
    {
        if (currentRoomIndex < roomPositions.Length - 1)
        {
            currentRoomIndex++;
            MoveToRoom(currentRoomIndex);
        }
    }

    public void MoveToPreviousRoom()
    {
        if (currentRoomIndex > 0)
        {
            currentRoomIndex--;
            MoveToRoom(currentRoomIndex);
        }
    }

    public int GetCurrentRoomIndex()
    {
        return currentRoomIndex;
    }
}
