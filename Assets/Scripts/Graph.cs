using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/*
Warning: Mathf
*/
public class Graph : MonoBehaviour {
    public int resolution = 10;
    public float a = 1f;
    public float b = 1f;
    public float c = 1f;
    public float d = 1f;
    public float e = 1f;
    public float f = 1f;
    private bool isDrawing = false;

    [HideInInspector]
    [SerializeField]
    private Text textA, textB, textC, textD, textE, textF;

    [HideInInspector]
    [SerializeField]
    private Slider sliderA, sliderB, sliderC, sliderD, sliderE, sliderF;
    
    private float secondsSince = 0;

    public float particleStartSize = 0;

    private ParticleSystem.Particle[] points;
    private ParticleSystem particleSys;
    private float xn = 0f;
    private float yn = 0f;
    private float zn = 0f;

    public void SetA(float new_a) {
        a = new_a;
        DrawParticles();
    }

    public void SetB(float new_b) {
        b = new_b;
        DrawParticles();

    }

    public void SetC(float new_c) {
        c = new_c;
        DrawParticles();

    }

    public void SetD(float new_d) {
        d = new_d;
        DrawParticles();

    }

    public void SetE(float new_e) {
        e = new_e;
        DrawParticles();

    }

    public void SetF(float new_f) {
        f = new_f;
        DrawParticles();
    }

    public void Randomize() {
        a = Random.Range(0f, 3.14f);
        b = Random.Range(0f, 3.14f);
        c = Random.Range(0f, 3.14f);
        d = Random.Range(0f, 3.14f);
        e = Random.Range(0f, 3.14f);
        f = Random.Range(0f, 3.14f);
        DrawParticles();
    }

    void Awake() {
        particleSys = GetComponent<ParticleSystem>();
    }

    void Start () {
        DrawParticles();
    }

    void DrawParticles() {
        zn = 0;
        isDrawing = true;
        sliderA.value = a;
        sliderB.value = b;
        sliderC.value = c;
        sliderD.value = d;
        sliderE.value = e;
        sliderF.value = f;

        textA.text = a.ToString("0.00"); ;
        textB.text = b.ToString("0.00"); ;
        textC.text = c.ToString("0.00"); ;
        textD.text = d.ToString("0.00"); ;
        textE.text = e.ToString("0.00"); ;
        textF.text = f.ToString("0.00");

        points = new ParticleSystem.Particle[resolution];
        float increment = .1f;

        for (int i = resolution - 1; i >= 0; i--) {
            PlotRecursiveDynamicSystem(i, increment);
        }

        
        particleSys.SetParticles(points, points.Length);
    }

    void Update() {}


    void PlotRecursiveDynamicSystem(int i, float increment) {
        float new_x = Mathf.Sin(a * xn) + Mathf.Sin(b * yn) - Mathf.Cos(c * zn);
        float new_y = Mathf.Sin(d * xn) + Mathf.Sin(e * yn) - Mathf.Cos(f * zn);

        xn = new_x;
        yn = new_y;
        zn = zn + increment;


       // if (i < 10) {
            //Debug.Log(xn + ", " + yn + ", " + zn);
            //Debug.Log(new_x + ", " + new_y + "," + Mathf.Cos(c * 5000000f));
        //}
        points[i].position = new Vector3(-xn, -yn, 0f);
        
        //points[i].startColor = new Color(0f, 0f, 0f);
        points[i].startSize = particleStartSize;
    }
}
