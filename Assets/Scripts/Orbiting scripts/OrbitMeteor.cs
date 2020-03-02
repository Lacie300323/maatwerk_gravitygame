using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMeteor : MonoBehaviour
{
    [SerializeField] private Transform orbitingMeteor; //controlling mtion
    public Ellipse meteorPath;

    [Range(0f, 1f)]
    public float meteorProgress = 0f;
    public float meteorPeriod = 3f;
    public bool meteorActive = true;
    void Start()
    {
        if (orbitingMeteor == null)
        {
            meteorActive = false;
            return;
        }
        setOrbitObject();
        StartCoroutine(animateOrbit());
    }

    void setOrbitObject()
    {
        Vector2 orbitPos = meteorPath.Evaluate(meteorProgress);
        orbitingMeteor.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }
    IEnumerator animateOrbit()
    {
        if (meteorPeriod < 0.1f)
        {
            meteorPeriod = 0.1f;
        }

        float orbitSpeed = 0.2f / meteorPeriod;
        
        while(meteorActive)
        {
            meteorProgress += Time.deltaTime * orbitSpeed;
            meteorProgress %= 1f;
            setOrbitObject();
            yield return null;
        }
    }
}
