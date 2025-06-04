using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject roomCanvasesParent; // Parent containing all room canvases

    public void StartExperience()
    {
        mainMenuPanel.SetActive(false);
        roomCanvasesParent.SetActive(true);
    }

    public void QuitExperience()
    {
        roomCanvasesParent.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
