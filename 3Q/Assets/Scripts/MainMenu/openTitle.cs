using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openTitle : MonoBehaviour {

    private float sscale = 2;
    private float escale = 0.73278f;
    private float vscale;

    private float sy = 4;
    private float ey = 1.26f;
    private float vy;

    private float sa = 0.2f;
    private float ea = 1f;
    private float va;

    private float t = 60;
    private float ct = 0;

    // Use this for initialization
    void Start () {
	}

    float EaseInQuad(float start, float end, float value)
    {
        return (end - start) * value * value + start;
    }

    float EaseOutQuad(float start, float end, float value)
    {
        end -= start;
        return -end * value * (value - 2) + start;
    }

    // Update is called once per frame
    void Update () {
        float cscale = EaseOutQuad(sscale, escale, ct / t);
        float cy = EaseOutQuad(sy, ey, ct / t);
        float ca = EaseOutQuad(sa, ea, ct / t);
        this.transform.position = new Vector3(0, cy, 0);
        this.transform.localScale = new Vector3(cscale, cscale, cscale);
        Color current = this.GetComponent<SpriteRenderer>().color;
        this.GetComponent<SpriteRenderer>().color = new Color(current.r, current.g, current.b, ca);
        ct += 1;
        ct = ct < t ? ct : t;
	}
}
