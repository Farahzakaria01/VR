using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

    public class MicDropdown : MonoBehaviour
    {
        public List<string> microphoneDropdownOptions;

       public List<string> GetMicrophoneDropdownOptions()
    {
        return microphoneDropdownOptions;
    }
        
        public void SetMicrophoneDropdownOptions()
    {
        microphoneDropdownOptions = new List<string>();

        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            microphoneDropdownOptions[i] = Microphone.devices[i];
            Debug.Log("Debug for microphoneDropdownOptions" + microphoneDropdownOptions[i]);
        }

    }

    }


