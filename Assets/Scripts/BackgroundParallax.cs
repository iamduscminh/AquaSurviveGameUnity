using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float _length, _startPosition;
    public GameObject cam1;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam1.transform.position.x * (1 - parallaxEffect));
        float dist = (cam1.transform.position.x * parallaxEffect);
        transform.position = new Vector3(_startPosition + dist, transform.position.y, transform.position.z);

        if (temp > _startPosition + _length)
        {
            _startPosition += _length;
        }else if (temp < _startPosition - _length)
        {
            _startPosition -= _length;
        }

    }
}
