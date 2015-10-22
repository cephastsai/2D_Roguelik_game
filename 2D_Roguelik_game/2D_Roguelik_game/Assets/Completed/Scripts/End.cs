using UnityEngine;
using System.Collections;

namespace Completed
{
    public class End : MonoBehaviour
    {
        public int level;
        public int playerMaxFoodPoint;

        // Use this for initialization
        void Start()
        {
            level = PlayerPrefs.GetInt("level", level);
            playerMaxFoodPoint = PlayerPrefs.GetInt("playerMaxFoodPoint", playerMaxFoodPoint);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            GUI.Label(new Rect(10, 150, 300, 50), "After " + level + " days, you starved.");
            GUI.Label(new Rect(10, 200, 300, 50), "Max point: " + playerMaxFoodPoint);
            if (GUILayout.Button("Restart Game"))
            {
                Application.LoadLevel("Menu");
            }
        }
    }
}
