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
    private float _time = 20;
    private int _score;
  
    // Start is called before the first frame update
    void Start()
    {
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