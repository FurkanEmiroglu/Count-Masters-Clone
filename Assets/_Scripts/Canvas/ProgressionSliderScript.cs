using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressionSliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _percentageTxt;
    [SerializeField] private Transform _mainCharacterTransform;
    [SerializeField] private Transform _LastFightTriggerTransform;
    private float finishpositionZ;

    private void Start() {
        finishpositionZ = _LastFightTriggerTransform.position.z;
    }

    private void Update() {
        UpdateSlider(FindProgressionPercentage());
    }

    private float FindProgressionPercentage() {
        float percentage = (_mainCharacterTransform.position.z / finishpositionZ) * 100;
        return percentage;
    }

    void UpdateSlider(float value) {
        _slider.value = value;
        _percentageTxt.text = _slider.value.ToString();
    }
}
