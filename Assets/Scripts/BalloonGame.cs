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
    private int _firstNumber, _secondNumber,_sum;
    private int _randomNumber1,_randomNumber2;
    // Start is called before the first frame update
    void Start()
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

    public void CheckAnswer()
    {


        _sum = _randomNumber1 + _randomNumber2;

        if (_input.text == _sum.ToString())
        {
            _text.text = "Correct";
        }

        else
        {
            _text.text = "Incorrect";
        }
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
}
//Instantiate different balloons only when you hit enter
