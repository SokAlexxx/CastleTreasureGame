using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int totalTreasures;
    private int collectedTreasures;

    public GameObject winPanel;
    public GameObject losePanel;

    public Text treasureCounterText;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        totalTreasures = GameObject.FindGameObjectsWithTag("Treasure").Length;
        collectedTreasures = 0;

        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
        UpdateTreasureUI();
    }

    public void CollectTreasure()
    {
        collectedTreasures++;
        UpdateTreasureUI();

        if (collectedTreasures >= totalTreasures)
        {
            WinGame();
        }
    }

    void UpdateTreasureUI()
    {
        if (treasureCounterText != null)
        {
            treasureCounterText.text = "Treasures: " + collectedTreasures + "/" + totalTreasures;
        }
    }

    void WinGame()
    {
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
