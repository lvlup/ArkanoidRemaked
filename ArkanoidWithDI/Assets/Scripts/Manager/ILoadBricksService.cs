using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Manager
{
   public interface ILoadBricksService
   {
       int InitFirstLevel(GameObject bricksForFirstLevel, Transform transform);

       int InitSecondLevel(GameObject bricksForSecondLevel, Transform transform);
   }

    public class LoadBricksService : MonoBehaviour, ILoadBricksService
    {
        public int InitFirstLevel(GameObject bricksForFirstLevel, Transform transform)
        {
            Instantiate(bricksForFirstLevel, transform.position, Quaternion.identity);
            var gameObjFirstLevel = GameObject.FindGameObjectsWithTag("Level1").FirstOrDefault();
            if (gameObjFirstLevel != null)
                return gameObjFirstLevel.transform.childCount;
            throw new Exception("Нету кубиков для первого уровня!");
        }

        public int InitSecondLevel(GameObject bricksForSecondLevel, Transform transform)
        {
            Instantiate(bricksForSecondLevel, transform.position, Quaternion.identity);
            var gameObjSecondLevel = GameObject.FindGameObjectsWithTag("Level2").FirstOrDefault();
            if (gameObjSecondLevel != null)
                return gameObjSecondLevel.transform.childCount;
            throw new Exception("Нету кубиков для второго уровня!");
        }
    }
}
