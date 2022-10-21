using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [SerializeField] private GameObject[] _startingPoint;

    [SerializeField] private GameObject _resultScreen;
    private Image _image;
    public int dragScore;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _timeRemaining;
    private float _time = 5;
    [SerializeField] private Text _ultimateScore;
    private Settings _settings;

    public void OnBeginDrag(PointerEventData eventData)
    {
        var tempColor = _image.color;
        tempColor.a = 0.5f;
        _image.color = tempColor;
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name);
        transform.position = eventData.position;
        if (eventData.pointerDrag.name =="AliensImage")
        {
            Debug.Log(eventData.pointerDrag.name);
            eventData.pointerDrag.transform.position = _startingPoint[Random.Range(0, _startingPoint.Length)].transform.position;
        }   
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        var tempColor = _image.color;
        tempColor.a = 1f;
        _image.color = tempColor;
        _image.raycastTarget = true;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        _settings = GameObject.Find("ProfileScreen").GetComponent<Settings>();
        _image = GetComponent<Image>();
        _time = 10;
        _timeRemaining.text = _time.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            _timeRemaining.text = _time.ToString();
        }
        else
        {
            _resultScreen.gameObject.SetActive(true);
            _ultimateScore.text = _scoreText.text;

            if (_settings.otherPlayer==false)
            {
                PlayerPrefs.SetString("SpaceGameScore", dragScore.ToString());
            }
            else
            {
                PlayerPrefs.SetString("SpaceGameScore1", dragScore.ToString());
            }
         
        }
    }

    public void TryAgain()
    {
        _time = 10;
        _timeRemaining.text = _time.ToString();
        dragScore = 0;
        _scoreText.text = dragScore.ToString();
    }


}
