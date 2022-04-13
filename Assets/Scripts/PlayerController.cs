using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float jump;
    private Rigidbody rigidBody;
    private bool allowControl = false;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.mGameState == GameState.Playing)
        {
            if (Input.GetMouseButtonDown(0) && allowControl == true)
            {
                rigidBody.AddForce(Vector3.up * jump);
                allowControl = false;
            }
        }
    }
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.transform.tag == "Land")
        {
            allowControl = true;
        }
        if (obj.transform.tag == "Obstacle")
        {
            GameManager.Instance.mGameState = GameState.GameOver;
            //
            UIManager.Instance.pnlGameOver.SetActive(true);
            UIManager.Instance.txtPnlScore.GetComponent<Text>().text = ScoreManager.Instance.GetScore().ToString();
            UIManager.Instance.txtPnlScoreBest.GetComponent<Text>().text = ScoreManager.Instance.GetScoreBest().ToString();
        }
    }
}
