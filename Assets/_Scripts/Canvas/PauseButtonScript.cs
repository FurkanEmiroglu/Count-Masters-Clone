using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    bool _isPaused;
    [SerializeField] private Image currentImage;
    [SerializeField] private Sprite pausedImage;
    [SerializeField] private Sprite ResumeImage;


    private void Start() {
        _isPaused = false;
        currentImage = GetComponent<Image>();
        currentImage.sprite = ResumeImage;
        GameEvents.current.onStartGame += setActive;
        gameObject.SetActive(false);
    }

    public void ResumePauseButton() {
        if (!_isPaused) {
            ChangeToPausedImage();
            PlayClickedSound();
            GameEvents.current.PauseGame();
            _isPaused = true;
        }
        else {
            ChangeToResumeImage();
            PlayClickedSound();
            GameEvents.current.ResumeGame();
            _isPaused = false;
        }
    }

    private void ChangeToPausedImage() {
        currentImage.sprite = pausedImage;
    }

    private void ChangeToResumeImage() {
        currentImage.sprite = ResumeImage;
    }

    private void PlayClickedSound() {
        AudioTree.Instance.playBubble();
    }

    private void setActive() {
        gameObject.SetActive(true);
    }
}
