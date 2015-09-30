using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Controller;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Manager
{
    public class MenuManager : MonoBehaviour, IMenuManager
    {
        public Button StartGameButton;
        public Button CloseGameButton;

        private GameObject mMenuGameObject;
        private GameObject mGameSessionGameObject;



        private bool _isGameStarted;

        private void Awake()
        {
            StartGameButton.onClick.AddListener(LoadGame);

            CloseGameButton.onClick.AddListener(CloseGame);

            mMenuGameObject = GameObject.Find("MenuGame");

            mGameSessionGameObject = null;
        }

        public void LoadGame()
        {
            if (!_isGameStarted)
            {
                Application.LoadLevelAdditive(1);
                StartGameButton.GetComponentsInChildren<Text>().First().text = "Продолжить";
                _isGameStarted = true;
                mMenuGameObject.SetActive(false);
                return;
            }

            Time.timeScale = 1f;
            mMenuGameObject.SetActive(false);
            mGameSessionGameObject.SetActive(true);
        }

        public void CloseGame()
        {
            Application.Quit();
        }

        private void Update()
        {
            if(_isGameStarted && mGameSessionGameObject == null)
                mGameSessionGameObject = GameObject.Find("GameSession");
            if(Math.Abs(Time.timeScale) < .25f)
                mMenuGameObject.SetActive(true);
        }
    }
}
