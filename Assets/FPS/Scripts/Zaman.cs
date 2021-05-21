using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Zaman : MonoBehaviour
{
    public Spawner m_Spawner;
    public float zaman;
    public float verilen_zaman=10.0f;
    public Text Timer;
    public bool end=false;
    public Text skor1;
    // Start is called before the first frame update
    void Start()
    {
        zaman = verilen_zaman;
        m_Spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        zaman -= Time.deltaTime;
        Timer.text = zaman.ToString("f2");
        skor1.text = "Skor:"+m_Spawner.skor.ToString();
        if (zaman <= 0)
        {
            Timer.text = "0";
            end = true;
        }
    }
}
