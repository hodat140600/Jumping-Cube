using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject obstacle;
    private GameObject obstacleStayingScreen;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.mGameState == GameState.Playing)
        {
            // find obstacle object in screen
            obstacleStayingScreen = GameObject.FindGameObjectWithTag("Obstacle");
            // if screen not any obstacle then we will create a obstacle at this position.
            if (obstacleStayingScreen == null)
            {
                // case 1:
                Instantiate(obstacle);

                // case 2:
                //Instantiate(obstacle, transform.position, Quaternion.identity);
            }
        }
    }
}
