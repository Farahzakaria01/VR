using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Whisper.Native;
using Whisper.Utils;
using Whisper;
using JetBrains.Annotations;
using UnityEngine.UI;


public class MicrophoneDevice : MonoBehaviour
    {
        public String[] devicename;
        private string _selectedMicDevice;
    public IEnumerable<string> AvailableMicDevices => Microphone.devices;

    [Tooltip("Max length of recorded audio from microphone in seconds")]
    public int maxLengthSec = 60;
    [Tooltip("After reaching max length microphone record will continue")]
    public bool loop;
    [Tooltip("Microphone sample rate")]
    public int frequency = 16000;
    [Tooltip("Length of audio chunks in seconds, useful for streaming")]
    public float chunksLengthSec = 0.5f;
    [Tooltip("Should microphone play echo when recording is complete?")]
    public bool echo = true;

    [Header("Voice Activity Detection (VAD)")]
    [Tooltip("Should microphone check if audio input has speech?")]
    public bool useVad = true;
    [Tooltip("How often VAD checks if current audio chunk has speech")]
    public float vadUpdateRateSec = 0.1f;
    [Tooltip("Seconds of audio record that VAD uses to check if chunk has speech")]
    public float vadContextSec = 30f;
    [Tooltip("Window size where VAD tries to detect speech")]
    public float vadLastSec = 1.25f;
    [Tooltip("Threshold of VAD energy activation")]
    public float vadThd = 1.0f;
    [Tooltip("Threshold of VAD filter frequency")]
    public float vadFreqThd = 100.0f;
    [Tooltip("Optional indicator that changes color when speech detected")]
    [CanBeNull] public Image vadIndicatorImage;

    [Header("VAD Stop")]
    [Tooltip("If true microphone will stop record when no speech detected")]
    public bool vadStop;
    [Tooltip("If true whisper transcription will drop last audio where silence was detected")]
    public bool dropVadPart = true;
    [Tooltip("After how many seconds of silence microphone will stop record")]
    public float vadStopTime = 3f;

    [Header("Microphone selection (optional)")]
    [Tooltip("Optional UI dropdown with all available microphone inputs")]
    [CanBeNull] public Dropdown microphoneDropdown;
    [Tooltip("The label of default microphone input in dropdown")]
    public string microphoneDefaultLabel = "Default microphone";

    public String getMicrophoneDevice()
    {
        return devicename[0];
    }

    public void SetMicrophoneDevice()
    {
        devicename = new string[1];
        devicename[0] = Microphone.devices[0];
    }

    public string SelectedMicDevice
    {
        get => _selectedMicDevice;
        set
        {
            if (value != null && !AvailableMicDevices.Contains(value))
                throw new ArgumentException("Microphone device not found");
            _selectedMicDevice = value;
        }
    }
    private void OnMicrophoneChanged(int ind)
    {
        if (microphoneDropdown == null) return;
        var opt = microphoneDropdown.options[ind];
        SelectedMicDevice = opt.text == microphoneDefaultLabel ? null : opt.text;
    }

    //start
    private void Awake()
    {
        if (microphoneDropdown != null)
        {
            microphoneDropdown.options = AvailableMicDevices
                .Prepend(microphoneDefaultLabel)
                .Select(text => new Dropdown.OptionData(text))
                .ToList();
            microphoneDropdown.value = microphoneDropdown.options
                .FindIndex(op => op.text == microphoneDefaultLabel);
            microphoneDropdown.onValueChanged.AddListener(OnMicrophoneChanged);
        }
    }



    //player (model) dalam ni
    
}

