using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Timer Instance;
    private float _timer = 0;
    private bool _isTimeOut;
    public float TimerInSeconds
    {
        get { return _timer; }
        set { _timer = value; }
    }
    public bool IsTimeOut
    {
        get { return _isTimeOut; }
    }
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        _timer -= 0.02f;
        Debug.Log(_timer);
        _isTimeOut = _timer < 0;

    }

}
