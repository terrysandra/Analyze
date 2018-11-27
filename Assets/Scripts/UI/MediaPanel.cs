using RenderHeads.Media.AVProVideo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaPanel : BasePanel
{
    public MediaPlayer _mediaPlayer;
    private float _setVideoSeekSliderValue;
    public Slider slider;
    public Toggle toggle;
    public Button closeButton;
    void Start()
    {
        toggle.onValueChanged.AddListener(ToggleListener);
        closeButton.onClick.AddListener(CloseButton);
        slider.onValueChanged.AddListener(SliderListener);
    }

    private void CloseButton()
    {
        UIManager.Instance.PopPanel();
    }

    private void ToggleListener(bool arg0)
    {
        if (arg0)
        {
            _mediaPlayer.Play();
        }
        else
        {
            _mediaPlayer.Pause();
        }
    }

    private void SliderListener(float arg0)
    {
        if (arg0 != _setVideoSeekSliderValue)
            _mediaPlayer.Control.Seek(arg0 * _mediaPlayer.Info.GetDurationMs());

    }

    void Update()
    {
        if (_mediaPlayer.Info.GetDurationMs() > 0f)
        {
            float time = _mediaPlayer.Control.GetCurrentTimeMs();
            float d = time / _mediaPlayer.Info.GetDurationMs();
            _setVideoSeekSliderValue = d;
            slider.value = d;
        }
    }
    public override void OnEnter(object value, Action PanelExitCallBack)
    {
        string mediaName = value as string;
        _mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL, Application.dataPath +"/"+ mediaName + ".mp4", false);
        base.OnEnter(value, PanelExitCallBack);
    }
    public override void OnExit()
    {
        base.OnExit();
        _mediaPlayer.Stop();
    }

}