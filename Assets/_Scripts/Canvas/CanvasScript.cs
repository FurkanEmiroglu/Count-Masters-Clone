using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    private void Start() {
        GameEvents.current.onGameOver += EnableCanvas;
        gameObject.SetActive(false);
    }

    public void EnableCanvas() {
        gameObject.SetActive(true);
    }

    private void DisableCanvas() {
        gameObject.SetActive(false);
    }

}
