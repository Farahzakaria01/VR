using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteButton : MonoBehaviour 
    {
        //public Button mute;
        //bool status true = mute
        public bool buttonStatus;

    void Start()
    {
        //Button b = mute.GetComponent<Button>();
        //b.onClick.AddListener(ChangeMuteButtonStatus);
    }

    public bool GetMuteButtonStatus()
    {
        return buttonStatus;
    }

    public void ChangeMuteButtonStatus()
    {
        //buttonStatus = GetMuteButtonStatus();
        if (buttonStatus == true) 
        {
            buttonStatus = false; //unmute
        }
        else
        {
            buttonStatus = true; //mute
        }
    }
}

