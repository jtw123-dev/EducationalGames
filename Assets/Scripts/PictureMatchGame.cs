using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureMatchGame : MonoBehaviour
{
    [SerializeField] private Sprite[] _images;
    [SerializeField] private GameObject _grid;
    [SerializeField] private GameObject _gridCollection;
    [SerializeField] private Text _text;
    [SerializeField] private Image[] _imageCollection;
    [SerializeField] private Image _testing;
    [SerializeField] private Text _timeRemaining;
    [SerializeField] private GameObject _resultScreen;
    [SerializeField] private Text _ultimateScore;
    private float _time = 20;
    private int _score;
    private Settings _setting;
  
    // Start is called before the first frame update
    void Start()
    {
        _setting = GameObject.Find("ProfileScreen").GetComponent<Settings>();
        _time = 20;
        _timeRemaining.text = _time.ToString();
        _grid.gameObject.SetActive(true);
        foreach(var image in _imageCollection)
        {
            image.GetComponent<Image>().sprite = _images[Random.Range(0, _images.Length)];
            image.gameObject.SetActive(true);
        }
        _testing.sprite = _images[Random.Range(0, _images.Length)];
        
    } 
    public  void RandomImage(Image picture)
    {
        if (_testing.sprite.name == picture.sprite.name)
        {
            picture.gameObject.GetComponent<Image>().sprite = _images[Random.Range(0, _images.Length)];
            _score++;          
            _text.text = _score.ToString();
        }
    }

    private void Update()
    {    
            if (_time > 0)
            {
                _time -= Time.deltaTime;
                _timeRemaining.text = _time.ToString();
            }
            else
        {
            _gridCollection.SetActive(false);
            _resultScreen.gameObject.SetActive(true);
            _ultimateScore.text = _text.text;

            if (_setting.otherPlayer==false)
            {
                PlayerPrefs.SetString("MatchGameScore", _score.ToString());
            }
           else
            {
                PlayerPrefs.SetString("MatchGameScore1", _score.ToString());
            }
        }
    }

    public void Reset()
    {
        foreach (var image in _imageCollection)
        {
            image.GetComponent<Image>().sprite = _images[Random.Range(0, _images.Length)];
            image.gameObject.SetActive(true);      
        }
        _testing.sprite = _images[Random.Range(0, _images.Length)];
    }
    public void TryAgain()
    {
        foreach (var image in _imageCollection)
        {
            image.GetComponent<Image>().sprite = _images[Random.Range(0, _images.Length)];
            image.gameObject.SetActive(true);

        }
        _score = 0;
        _testing.sprite = _images[Random.Range(0, _images.Length)];
        _gridCollection.SetActive(true);

        _time = 20;
        _text.text = _score.ToString();
    }
}