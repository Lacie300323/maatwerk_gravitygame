using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    [SerializeField] private Transform orbitingObject; //controlling mtion
    public Ellipse orbitPath;

    [Range(0f, 1f)]
    public float orbitProgress = 0f;
    public float orbitPeriod = 3f;
    public bool orbitActive = true; 

    // Start is called before the first frame update
    void Start()
    {
        if( orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        setOrbitObject();
        StartCoroutine(animateOrbit());
    }

    void setOrbitObject()
    {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, orbitPos.y, 0);
    }

    IEnumerator animateOrbit()
    {
        if (orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }

        float orbitSpeed = 0.2f / orbitPeriod;
        
        while(orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            setOrbitObject();
            yield return null;
        }
    }
}
