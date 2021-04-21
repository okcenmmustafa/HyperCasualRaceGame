using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button PlayButton,RestartButton,QuitButton;
    public CharacterManager[] players;
    public RankSystem rankSystem;
    public AudioSource StartSound,GameSound;
    public GameObject Winner;
    public RawImage drawableLayer;
    Texture2D texWall;
    public bool restart;
     Color fillColor = Color.black;

    public void Start()
    {
        GameSound.Play();
        texWall = drawableLayer.texture as Texture2D;
    }
    private void Update()
    {
        restart = rankSystem.gameOver;
            foreach (PlayerInfo p in rankSystem.playersInfo)
            {
                if (p.rank.Equals("Winner")){
                    Winner.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(p.name);
                    Winner.SetActive(true);
                    RestartButton.gameObject.SetActive(true);
                    QuitButton.gameObject.SetActive(true);
                    GameSound.Pause();
            }
            }
           
    }
    public void StartGame()
    {

        rankSystem.gameObject.SetActive(true);
        foreach(CharacterManager opponet in players)
        {
            opponet.CharactersMovementStart();
        }
        PlayButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        StartSound.Play();
        resestTextureColor();
    }
    public void RestartGame()
    {
        RestartButton.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        GameSound.Play();
        resestTextureColor();
    }
    public void Quit()
    {
        QuitButton.gameObject.SetActive(false);
        Application.Quit();
    }
    void resestTextureColor()
    {
        var fillColorArray = texWall.GetPixels();

        for (var i = 0; i < fillColorArray.Length; ++i)
        {
            fillColorArray[i] = fillColor;
        }

        texWall.SetPixels(fillColorArray);

        texWall.Apply();
    }


}
