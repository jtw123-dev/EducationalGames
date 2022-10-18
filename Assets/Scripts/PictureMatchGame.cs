using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PictureMatchGame : MonoBehaviour
{
    [SerializeField] private Sprite[] _images;//assign number
    [SerializeField] private GameObject _grid;
    [SerializeField] private Text _text;
    [SerializeField] private Image[] _imageCollection;
    [SerializeField] private Image _testing, testing1;
    private Image _storedPicture;
    private int _cardsFlipped;
    private int _score;
    private bool _cardMatch;
    private bool _cardFlip;
    // Start is called before the first frame update
    void Start()
    {
        _grid.gameObject.SetActive(true);
        foreach(var image in _imageCollection)
        {
            image.GetComponent<Image>().sprite = _images[Random.Range(0, _images.Length)];
            image.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomImage(Image picture)
    {
        picture.gameObject.SetActive(true);
        _cardsFlipped++;
        _testing = picture;
        //  _cardFlip=true;

        if (_cardFlip==true)
        {
           
        }
        //check if they match
       // if (_cardsFlipped>=3)
    //    {
        //    picture.gameObject.SetActive(false);
        //    _cardsFlipped = 0;
       // }
      //  _storedPicture = picture;
        _text.text = _score.ToString();
    }
}
