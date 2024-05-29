using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    private float _timer = 0;
    private bool _isTimeOut = true;
    public float TimerInSeconds
    {
        get { return _timer; }
        set { _timer = value; }
    }
    public bool IsTimeOut
    {
        get { return _isTimeOut; }
        set { _isTimeOut = value; }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _timer -= 0.02f;
        if (_timer < 0)
        {

            _isTimeOut = true;
        }
        else
        {
            _isTimeOut = false;
        }
        Debug.Log("is time out " + _isTimeOut);
    }
    public void SetTimer(float time)
    {
        _isTimeOut = false;
        _timer = time;
    }
}
