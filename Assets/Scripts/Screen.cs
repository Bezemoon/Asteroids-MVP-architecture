using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] Ship _ship;


    private Camera _camera;
    private Vector3 _topRightPoint;
    private Vector3 _bottomLeftPoint;
    private Asteroid[] _asteroids;


    private void Start()
    {
        AsteroidCapacityUpdate();
        _camera = GetComponent<Camera>();
        _topRightPoint = _camera.ViewportToWorldPoint(new Vector3(1.0f, 1.0f));
        _bottomLeftPoint = _camera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f));
        

    }

    private void Update()
    {

        _ship.transform.position = BorderCheck(_ship.transform, 0.3f);

        foreach(Asteroid asteroid in _asteroids)
        {
            if(asteroid == null)
            {
                AsteroidCapacityUpdate();
                continue;
            }

            asteroid.transform.position = BorderCheck(asteroid.transform, 0.8f); ;
        }

    }

    private Vector3 BorderCheck(Transform transormObject, float marginValue)
    {
        if (transormObject.transform.position.x >= _topRightPoint.x + (marginValue + 0.2f))
            transormObject.transform.position = new Vector3(_bottomLeftPoint.x - marginValue, transormObject.transform.position.y, transormObject.transform.position.z);
        else if (transormObject.transform.position.x <= _bottomLeftPoint.x - (marginValue + 0.2f))
            transormObject.transform.position = new Vector3(_topRightPoint.x + marginValue, transormObject.transform.position.y, transormObject.transform.position.z);

        if (transormObject.transform.position.y >= _topRightPoint.y + (marginValue + 0.2f))
            transormObject.transform.position = new Vector3(transormObject.transform.position.x, _bottomLeftPoint.y - marginValue, transormObject.transform.position.z);
        else if (transormObject.transform.position.y <= _bottomLeftPoint.y - (marginValue + 0.2f))
            transormObject.transform.position = new Vector3(transormObject.transform.position.x, _topRightPoint.y + marginValue, transormObject.transform.position.z);

        return transormObject.position;
    }

    private void AsteroidCapacityUpdate()
    {
        _asteroids = FindObjectsOfType(typeof(Asteroid)) as Asteroid[];
    }


}
