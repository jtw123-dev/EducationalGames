using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonGame : MonoBehaviour
{
    [SerializeField] private Sprite[] _balloons;
    [SerializeField] private InputField _input;
    [SerializeField] private Image _balloon1, _balloon2;
    [SerializeField] private Text _text;
    [SerializeField] private Text _scoreText;
    private int _firstNumber, _secondNumber,_sum;
    private int _randomNumber1,_randomNumber2;
    private int _score;
    private float _time = 10;
    [SerializeField] private Text _timeRemaining;
    [SerializeField] private GameObject _resultScreen;
    [SerializeField] private Text _ultimateScore;
    private Settings _settings;
    // Start is called before the first frame update
    void Start()
    {
        _settings = GameObject.Find("ProfileScreen").GetComponent<Settings>();
        _randomNumber1 = Random.Range(0, _balloons.Length);
        _randomNumber2 = Random.Range(0, _balloons.Length);
        _balloon1.sprite = _balloons[_randomNumber1];
        _balloon2.sprite = _balloons[_randomNumber2];

        _firstNumber = _randomNumber1;
        _secondNumber = _randomNumber2;

        Debug.Log(_firstNumber);
        Debug.Log(_secondNumber);

        _text.text = "Add the numbers";
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
            _resultScreen.gameObject.SetActive(true);
            _ultimateScore.text = _scoreText.text;

            if (_settings.otherPlayer==false)
            {
                PlayerPrefs.SetString("BalloonGameScore", _score.ToString());
            }

            else
            {
                PlayerPrefs.SetString("BalloonGameScore1", _score.ToString());
            }
           
        }
    }
    public void CheckAnswer()
    {
        _sum = _randomNumber1 + _randomNumber2;

        if (_input.text == _sum.ToString())
        {
            _text.text = "Correct";
            _score++;
        }

        else
        {
            _text.text = "Incorrect";
            _score--;
        }
        _scoreText.text = _score.ToString();
    }

    public void RandomQuestion()
    {
        _randomNumber1 = Random.Range(0, _balloons.Length);
        _randomNumber2 = Random.Range(0, _balloons.Length);
        _balloon1.sprite = _balloons[_randomNumber1];
        _balloon2.sprite = _balloons[_randomNumber2];

        _firstNumber = _randomNumber1;
        _secondNumber = _randomNumber2;

        Debug.Log(_firstNumber);
        Debug.Log(_secondNumber);

        _text.text = "Add the numbers";
    }

    public void TryAgain()
    {
        _time = 10;
        _timeRemaining.text = _time.ToString();
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}

