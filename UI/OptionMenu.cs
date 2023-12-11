using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider UISlider;
    [SerializeField] Toggle swapButtonPosition;

    public CanvasController canvas;

    void Start()
    {
        SFXSlider.onValueChanged.AddListener((value) => { SoundManager.Instance.SetVolume(AudioChannel.SFX, value); });
        BGMSlider.onValueChanged.AddListener((value) => { SoundManager.Instance.SetVolume(AudioChannel.BGM, value); });
        //UISlider.onValueChanged.AddListener((value) => { SoundManager.Instance.SetVolume(AudioChannel.BGM, value); });
    }

}