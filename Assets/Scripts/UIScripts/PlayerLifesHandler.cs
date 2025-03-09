using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLifesHandler : MonoBehaviour
{
    public LayerMask ballLayer;
    public int initialLives = 20;
    public TextMeshProUGUI[] playerLivesUI;
    public GameObject[] players;
    public GameObject[] playerBarriers;
    public GameObject winnerCanvas;
    public TextMeshProUGUI winnerText;
    public Color[] playerColours;
    public string[] playerNames;

    private GameManager[] playerData = new GameManager[4];
    public Collider[] playerFields = new Collider[4];
    public float detectionRadius = 0.5f;

    void Start()
    {
        Time.timeScale = 1;

        InitializePlayers();
        InitializeplayerBarriers();
        winnerCanvas.SetActive(false);

        StartCoroutine(WaitForBallsToSpawn());
    }

    void InitializePlayers()
    {
        for (int i = 0; i < playerData.Length; i++)
        {
            playerData[i] = new GameManager
            {
                Lives = initialLives,
                LivesUI = playerLivesUI[i],
                PlayerObject = players[i],
                BarrierObject = playerBarriers[i],
                FieldCollider = playerFields[i],
                Color = playerColours[i],
                Name = playerNames[i]
            };
        }
    }

    void InitializeplayerBarriers()
    {
        foreach (var barrier in playerBarriers)
        {
            barrier.SetActive(false);
        }
    }

    IEnumerator WaitForBallsToSpawn()
    {
        yield return new WaitForSeconds(1.0f);
    }

    void Update()
    {
        foreach (var player in playerData)
        {
            Collider[] ballsInField = Physics.OverlapSphere(player.FieldCollider.transform.position, detectionRadius, ballLayer);

            foreach (Collider ball in ballsInField)
            {
                player.Lives--;
                UpdatePlayerLivesUI(player);

                if (player.Lives <= 0)
                {
                    player.PlayerObject.SetActive(false);
                    player.BarrierObject.SetActive(true);
                }

                ball.gameObject.SetActive(false);
            }
        }

        CheckForWinner();
    }

    void UpdatePlayerLivesUI(GameManager player)
    {
        player.LivesUI.text = player.Lives.ToString();
    }

    void CheckForWinner()
    {
        int activePlayers = 0;
        GameManager lastActivePlayer = null;

        foreach (var player in playerData)
        {
            if (player.Lives > 0)
            {
                activePlayers++;
                lastActivePlayer = player;
            }
        }

        if (activePlayers == 1)
        {
            winnerCanvas.SetActive(true);
            winnerCanvas.GetComponent<Image>().color = lastActivePlayer.Color;
            winnerText.text = lastActivePlayer.Name + "\n Wins";
            Time.timeScale = 0;
        }
    }
}