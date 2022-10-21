using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;//,_audioSource1;
    [SerializeField] private Image _image, _image2;
    [SerializeField] private Slider _slider,_audioSlider, _slider1,_audioSlider2;
    [SerializeField] private InputField _input,_input1;
    [SerializeField] private Text _statSpaceText,_statsMatchText,_statsBalloonText;
    private bool _paused;
    public bool otherPlayer;

    private float _volume,_volume2; //Beware makeing this serialized as that screws up playerpref public static float GetFloat(string key, float defaultValue = 0.0F);

   // Returns the value corresponding to key in the preference file if it exists.If it doesn't exist, it will return defaultValue.


    // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && _paused == false)
        {
            Time.timeScale = 0f;
            _paused = true;
            _settingsMenu.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _paused == true)
        {
            Time.timeScale = 1;
            _settingsMenu.gameObject.SetActive(false);
            _paused = false;
        }
    }

    public void SwitchPlayer()
    {
        otherPlayer = true;
    }
    public void SwitchPlayerAgain()
    {
        otherPlayer = false;
    }

    public void EscapeMenu()
    {
        Time.timeScale = 1;
        _settingsMenu.gameObject.SetActive(false);
        _paused = false;
    }

    public void EnterEscapeMenu()
    {
        
        Time.timeScale = 0;
        _settingsMenu.gameObject.SetActive(true);
        _paused = true;
    }
    public void BrightnessAdjustment()
    {
        var tempColor = _image.color;
        tempColor.a = _slider.value;
        _image.color = tempColor;
    }
    public void BrightnessAdjustment2()
    {
        var tempColor = _image2.color;
        tempColor.a = _slider1.value;
        _image2.color = tempColor;
    }

    public void VolumeAdjustment()
    {
        Debug.Log("VolumeAdjusted");
        _audioSource.volume = _volume;
        _volume = _audioSlider.value;
    }

    public void VolumeAdjustment2()
    {
        Debug.Log("VolumeAdjusted2");
        _audioSource.volume = _volume2;
        _volume2 = _audioSlider2.value;
    }
    public void PlayClip()
    {
        _audioSource.pitch = _volume;
        _audioSource.PlayOneShot(_audioClip);
    }

    public void SaveSettingsUserOne()
    {    
        
            PlayerPrefs.SetFloat("Volume", _audioSlider.value);
            PlayerPrefs.SetFloat("Brightness", _slider.value);
            PlayerPrefs.SetString("Name", _input.text);
            PlayerPrefs.Save();
           Debug.Log("Saved");
        
        
    }
    public void LoadUser1Settings()
    {
            _audioSlider.value = PlayerPrefs.GetFloat("Volume");
            _slider.value = PlayerPrefs.GetFloat("Brightness");
            _input.text = PlayerPrefs.GetString("Name");
    }    
  
    public void SaveSettingsUserTwo()
    {
        PlayerPrefs.SetFloat("Volume1", _audioSlider2.value);
        PlayerPrefs.SetFloat("Brightness1", _slider1.value);
        PlayerPrefs.SetString("Name1", _input1.text);
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }

    public void LoadUser2Settings()
    {
        _audioSlider2.value = PlayerPrefs.GetFloat("Volume1");
        _slider1.value = PlayerPrefs.GetFloat("Brightness1");
        _input1.text = PlayerPrefs.GetString("Name1");
    }

    public void LoadStats()
    {

        _statSpaceText.text = " Your SpaceGameScore is " + PlayerPrefs.GetString("SpaceGameScore"); 
        _statsBalloonText.text = "Your BalloonGameScore is " + PlayerPrefs.GetString("BalloonGameScore");
        _statsMatchText.text = "Your MatchGameScore is " + PlayerPrefs.GetString("MatchGameScore");

        Debug.Log(PlayerPrefs.GetString("SpaceGameScore"));
        Debug.Log(PlayerPrefs.GetString("BalloonGameScore"));
        Debug.Log(PlayerPrefs.GetString("MatchGameScore"));
    }

    public void LoadStats1()
    {
        _statSpaceText.text = " Your SpaceGameScore is " + PlayerPrefs.GetString("SpaceGameScore1");
        _statsBalloonText.text = "Your BalloonGameScore is " + PlayerPrefs.GetString("BalloonGameScore1");
        _statsMatchText.text = "Your MatchGameScore is " + PlayerPrefs.GetString("MatchGameScore1");
    }

}
