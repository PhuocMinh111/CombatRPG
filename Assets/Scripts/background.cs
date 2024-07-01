using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float ParrallaxEffect;
    private GameObject camera;


    void Start()
    {
        camera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        var x = camera.transform.position.x * ParrallaxEffect;
        transform.position = new Vector3(x, transform.position.y, 0);
    }
}
