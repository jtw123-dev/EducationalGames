using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfilesScript : MonoBehaviour
{
    [SerializeField] private InputField _name1,_name2;
    [SerializeField] private Text _output;

  
    public void SaveSettingsPlayer1()
    {
      
    }
    public void OutputText()
    {
        _output.text = "Your username is " + PlayerPrefs.GetString("name") + " and your password is " + PlayerPrefs.GetString("password");
    }
}
