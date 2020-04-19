using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float length, startpos;
    public GameObject cam;
    public float parallexEffect;

    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallexEffect));
        float dist = (cam.transform.position.x * parallexEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        Debug.Log(temp + " " + startpos + " " + length + " " + dist);
        
        if (temp > startpos + length)
            startpos += length;
        else if (temp < startpos - length)
            startpos -= length;

    }
}