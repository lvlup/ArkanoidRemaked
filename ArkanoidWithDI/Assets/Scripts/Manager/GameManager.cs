using System.Linq;
using Assets.View;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Manager
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        public int lives = 3;

        public float resetDelay = 1f;
        public Text livesText;
        public Text currentLevelText;
        public GameObject gameOver;
        public GameObject youWon;
        public GameObject bricksForFirstLevel;
        public GameObject bricksForSecondLevel;
        public GameObject paddle;
        public GameObject deathParticles;

        private GameObject clonePaddle;
        private int bricks;
        private int currentlevelIndex;
        private bool isAnimationCompleted = true;

        void Awake()
        {
            SetupStartSettings();
           
        }

        private void SetupStartSettings()
        {
            currentlevelIndex = 1;
            InitPaddle();
            InitFirstLevel();
        }

        private void InitPaddle()
        {
            clonePaddle = Instantiate(paddle, paddle.transform.position, Quaternion.identity) as GameObject;
        }

        private void InitFirstLevel()
        {
            Instantiate(bricksForFirstLevel, transform.position, Quaternion.identity);
            var gameObjFirstLevel = GameObject.FindGameObjectsWithTag("Level1").FirstOrDefault();
            if (gameObjFirstLevel != null)
                bricks = gameObjFirstLevel.transform.childCount;
        }

        private void InitSecondLevel()
        {
            Instantiate(bricksForSecondLevel, transform.position, Quaternion.identity);
            var gameObjSecondLevel = GameObject.FindGameObjectsWithTag("Level2").FirstOrDefault();
            if (gameObjSecondLevel != null)
                bricks = gameObjSecondLevel.transform.childCount;
        }

        private void CheckGameOver()
        {
            if (bricks < 1 && currentlevelIndex == 1)
            {
                LoadSecondLevel();
                return;
            }

            if (bricks < 1 && currentlevelIndex == 2)
            {
                isAnimationCompleted = false;
                youWon.SetActive(true);
                Time.timeScale = .25f;
                Invoke("Reset", resetDelay);
                return;
            }

            if (lives < 1)
            {
                isAnimationCompleted = false;
                gameOver.SetActive(true);
                Time.timeScale = .25f;
                Invoke("Reset", resetDelay);
            }

        }

        private void LoadSecondLevel()
        {
            currentlevelIndex++;
            currentLevelText.text = "Уровень: " + currentlevelIndex;
            InitSecondLevel();

            DestroyPaddleWithBall();

            Invoke("InitPaddle", 0);
        }

        void Reset()
        {
            Time.timeScale = 1f;
          
            Application.LoadLevel(Application.loadedLevel);
            isAnimationCompleted = true;
        }

        private void DestroyPaddleWithBall()
        {
            var ball = GameObject.FindGameObjectsWithTag("Ball").FirstOrDefault();
            if (ball != null)
                Destroy(ball);
            Destroy(clonePaddle);
        }

        void SetupPaddle()
        {
            clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        }

        public void DestroyBrick()
       {
            bricks--;
            CheckGameOver();
        }

       public void LoseLife()
       {
            lives--;
            livesText.text = "Жизни: " + lives;
            Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
            DestroyPaddleWithBall();
            Invoke("InitPaddle", resetDelay);
            CheckGameOver();
        }

       

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isAnimationCompleted)
            {
                Time.timeScale = 0f;
            }
        }
    }
}
