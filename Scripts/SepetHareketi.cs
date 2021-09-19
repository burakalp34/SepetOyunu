using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SepetHareketi : MonoBehaviour
{
    public float XAxis = 0f, YAxis = 0f;
    public bool Right = false, Left = false, GameOver = false, Done = false;
    public Vector3 MousePos;
    public GameObject Point, Explode, End, Begin, Reload;
    public UnityEngine.UI.Text ScoreText, ScoreLeave;
    public int Score = 0, HighScore = 0;
    public string HighScoreKey = "HSK";
    public UnityEngine.UI.Text HS;
    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Score < 0) {
            GameOver = true;
        }
        if (GameOver && !Done) {
            End.SetActive(true);
            Begin.SetActive(false);
            Reload.SetActive(true);
            HS.text = "High: " + HighScore;
            if (Score > HighScore) {
                PlayerPrefs.SetInt(HighScoreKey, Score);
            }
            Done = true;
        }
        ScoreText.text = "Score: " + Score;
        ScoreLeave.text = "Score: " + Score;
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*if (Input.GetKeyDown(KeyCode.D)) {
            Right = true;
            Left = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Right = false;
            Left = true;
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            Right = false;
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            Left = false;
        }*/
        if (MousePos.x < 2.5f && MousePos.x > -2.5f && !GameOver) {
            XAxis = MousePos.x;
        }
        //YAxis = MousePos.y;
        this.transform.position = new Vector3(XAxis, -3f, this.transform.position.z);
    }
    private void FixedUpdate()
    {
        /*if (Right && XAxis < 2.5f) {
            XAxis += Time.fixedDeltaTime * 2;
        }
        if (Left && XAxis > -2.5f)
        {
            XAxis -= Time.fixedDeltaTime * 2;
        }*/
    }
    private void OnCollisionEnter2D(Collision2D cls)
    {
        if (cls.gameObject.tag.Equals("Bomb") && !GameOver && cls.transform.position.x > this.transform.position.x) {
            GameOver = true;
            SpriteRenderer SR = cls.gameObject.GetComponent<SpriteRenderer>();
            SR.sprite = null;
            GameObject go = Instantiate(Explode, this.transform.position, Quaternion.identity);
            go.transform.parent = this.gameObject.transform;
            go.SetActive(true);
            Destroy(go.gameObject, 0.417f);
            Destroy(cls.gameObject, 0.417f);
        }
        if (cls.gameObject.tag.Equals("Apple") && !GameOver)
        {
            Score++;
            SpriteRenderer SR = cls.gameObject.GetComponent<SpriteRenderer>();
            SR.sprite = null;
            GameObject go = Instantiate(Point, this.transform.position, Quaternion.identity);
            go.transform.parent = this.gameObject.transform;
            go.SetActive(true);
            Destroy(go.gameObject, 0.417f);
            Destroy(cls.gameObject, 1f);
        }
    }
}
