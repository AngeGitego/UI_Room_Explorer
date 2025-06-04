using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Camera mainCamera;
    public Transform[] cameraPositions;
    public GameObject[] roomCanvases;

    private int currentIndex = 0;
    private bool isMoving = false;
    public float cameraMoveSpeed = 2f;

    void Start()
    {
        for (int i = 0; i < roomCanvases.Length; i++)
        {
            roomCanvases[i].SetActive(i == 0);
        }

        if (mainCamera != null && cameraPositions.Length > 0)
        {
            mainCamera.transform.position = cameraPositions[0].position;
            mainCamera.transform.rotation = cameraPositions[0].rotation;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveCamera();
        }
    }

    public void NextRoom()
    {
        if (currentIndex < roomCanvases.Length - 1)
        {
            roomCanvases[currentIndex].SetActive(false);
            currentIndex++;
            roomCanvases[currentIndex].SetActive(true);
            isMoving = true;
        }
    }

    public void PreviousRoom()
    {
        if (currentIndex > 0)
        {
            roomCanvases[currentIndex].SetActive(false);
            currentIndex--;
            roomCanvases[currentIndex].SetActive(true);
            isMoving = true;
        }
    }

    void MoveCamera()
    {
        Transform target = cameraPositions[currentIndex];

        mainCamera.transform.position = Vector3.MoveTowards(
            mainCamera.transform.position,
            target.position,
            cameraMoveSpeed * Time.deltaTime
        );

        mainCamera.transform.rotation = Quaternion.Slerp(
            mainCamera.transform.rotation,
            target.rotation,
            cameraMoveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(mainCamera.transform.position, target.position) < 0.01f)
        {
            mainCamera.transform.position = target.position;
            mainCamera.transform.rotation = target.rotation;
            isMoving = false;
        }
    }
}
