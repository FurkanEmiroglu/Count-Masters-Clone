using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour
{
    [SerializeField] private Image currentImage;
    [SerializeField] private Sprite mutedImage;
    [SerializeField] private Sprite notMutedImage;
    bool _isMuted;
    void Start()
    {
        _isMuted = false;
        currentImage = GetComponent<Image>();
        currentImage.sprite = notMutedImage;
        GameEvents.current.onStartGame += setActive;
        gameObject.SetActive(false);
    }

    public void MuteUnmuteButton() {
        if (!_isMuted) {
            ChangeImageToMuted();
            MuteGame();
            _isMuted = true;
        } else {
            ChangeImageToUnmuted();
            UnMuteGame();
            _isMuted = false;
        }
    }

    private void ChangeImageToMuted() {
        currentImage.sprite = mutedImage;
    }

    private void ChangeImageToUnmuted() {
        currentImage.sprite = notMutedImage;
    }

    private void MuteGame() {
        AudioListener.pause = true;
    }

    private void UnMuteGame() {
        AudioListener.pause = false;
    }

    private void setActive() {
        gameObject.SetActive(true);
    }
}
