using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShopUI : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    private GameDataScript scr;
    void Start()
    {
		GameObject data = GameObject.Find("GameData");
		scr = (GameDataScript) data.GetComponent("GameDataScript");
        Button btn = button1.GetComponent<Button>();
        btn.onClick.AddListener(Board1);
        btn = button2.GetComponent<Button>();
        btn.onClick.AddListener(Board2);
        btn = button3.GetComponent<Button>();
        btn.onClick.AddListener(Board3);
        btn = button4.GetComponent<Button>();
        btn.onClick.AddListener(Board4);
        btn = button5.GetComponent<Button>();
        btn.onClick.AddListener(NextLevel);
		scr.level += 1;
    }
    void Board1()
    {
		scr.hoverboardhealth = 5;
		scr.hoverboardspeed = 8;
		scr.hoverboardacc = 6;
    }
    void Board2()
    {
		scr.hoverboardhealth =  10;
		scr.hoverboardspeed = 10;
		scr.hoverboardacc = 8;
    }
    void Board3()
    {
		scr.hoverboardhealth = 8;
		scr.hoverboardspeed = 12;
		scr.hoverboardacc = 10;
    }
    void Board4()
    {
		scr.hoverboardhealth = 12;
		scr.hoverboardspeed = 14;
		scr.hoverboardacc = 12;
    }
    void NextLevel()
    {
        SceneManager.LoadScene("Roll-a-ball");
    }
}
