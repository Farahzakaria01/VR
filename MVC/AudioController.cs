using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Whisper;
using Whisper.Utils;
using Whisper.Native;
using JetBrains.Annotations;

public class AudioController : MonoBehaviour
{
    //public AudioUtils audioUtils; //static class
    public MicrophoneDevice microphoneDevice;
    public MuteButton muteButton;
    public Button button;
    public RecordClip recordClip;
    public MicDropdown micDropdown;
    public Dropdown dropdown;

    public void ChangeMuteButton()
    {
        muteButton.ChangeMuteButtonStatus();
        Debug.Log("WIWIWIWIIWIW" + muteButton.GetMuteButtonStatus());

    }

    public void SetDropdownButton()
    {
        micDropdown.SetMicrophoneDropdownOptions();
    }

    public void OnDropdownClick(PointerEventData eventData)
    {
        SetDropdownButton();
    }

    /*public void StartRecord()
    {
        if (IsRecording)
            return;

        RecordStartMicDevice = SelectedMicDevice;
        _clip = Microphone.Start(RecordStartMicDevice, loop, maxLengthSec, frequency);
        IsRecording = true;

        _lastMicPos = 0;
        _madeLoopLap = false;
        _lastChunkPos = 0;
        _lastVadPos = 0;
        _vadStopBegin = null;
        _chunksLength = (int)(_clip.frequency * _clip.channels * chunksLengthSec);
    }*/

    /*public void Start()
    {
        button = muteButton.GetComponent<Button>();
        button.onClick.AddListener(ChangeMuteButton);
        dropdown = micDropdown.GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(delegate {
            OnDropdownClick(new PointerEventData(EventSystem.current));
        }); 
            List<string> dropdownOptions = micDropdown.GetMicrophoneDropdownOptions();
        Debug.Log("Debug for dropdownOptions" + dropdownOptions);
        dropdown.AddOptions(dropdownOptions);

    }

    public void Update()
    {
        bool status;
        status = muteButton.GetMuteButtonStatus();
        //string statusString = status ? "true" : "false";

        //debug log
        Debug.Log("Audio Controller start function debug status" + status);

        if (status == false)
        {
            //microphonedevice
            //recordclip
            //recordClip.SetRecordClip(microphoneDevice.StartRecording());

        }
    }*/

}