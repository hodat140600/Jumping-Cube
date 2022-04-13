using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public float speedMove;
    private GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.mGameState == GameState.Playing)
        {
            // Move this object
            transform.Translate(Vector3.back * Time.deltaTime * speedMove);

            // Destruy this obj
            AutoDestroy();
        }
    }
    void AutoDestroy()
    {
        // If player is null then we will find player object in screen
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        // -2 is distance betweet this object and player, may change it
        if (transform.position.z - player.transform.position.z < -2)
        {
            Destroy(gameObject);
            ScoreManager.Instance.AddScore(1);
        }
    }
}
