using UnityEngine;
using System.Collections;

namespace Completed
{
    public class End : MonoBehaviour
    {
        public int level;
        public int playerMaxFoodPoint;
        public int RuneCount;
        public int DieCount;

        // Use this for initialization
        void Start()
        {
            level = PlayerPrefs.GetInt("level", level);
            playerMaxFoodPoint = PlayerPrefs.GetInt("playerMaxFoodPoint", playerMaxFoodPoint);
            RuneCount = PlayerPrefs.GetInt("RuneCount", RuneCount);
            DieCount = PlayerPrefs.GetInt("DieCount", DieCount);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            GUI.Label(new Rect(10, 150, 300, 50), "After " + level + " days, you starved.");
            GUI.Label(new Rect(10, 200, 300, 50), "Max point: " + playerMaxFoodPoint);
            GUI.Label(new Rect(10, 250, 300, 50), "DieCount :" + DieCount);
            GUI.Label(new Rect(10, 300, 300, 50), "RuneCount: " + RuneCount);
            if (GUILayout.Button("Restart Game"))
            {
                Application.LoadLevel("Menu");
            }
        }
    }
}
