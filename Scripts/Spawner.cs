using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public float Timer = 3f;
    public GameObject[] Objects;
    public SepetHareketi SH;
    public UnityEngine.UI.Text StartTimer;
    public GameObject StartTimerGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartTimer.text = ((int)Timer) + "";
        if (Timer <= 1f) {
            StartTimerGO.SetActive(false);
        }
        if (Timer <= 0f && !SH.GameOver)
        {
            Timer = Random.Range(1f, 1.6f);
            Instantiate(Objects[0], new Vector3(Random.Range(-2.5f, 2.6f), 6f, 0f), Quaternion.identity);
            for (int i = 1; i <= 3; i++) {
                Instantiate(Objects[4], new Vector3(Random.Range(-2.5f, 2.6f), 6f, 0f), Quaternion.identity);
            }
        }
    }
    private void FixedUpdate()
    {
        Timer -= Time.fixedDeltaTime;
    }
    private void OnCollisionEnter2D(Collision2D cls)
    {
        if (cls.gameObject.tag.Equals("Apple")) {
            SH.Score -= 1;
        }
        Destroy(cls.gameObject);
    }
    public void Restart() {
        SceneManager.LoadScene("GameScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
