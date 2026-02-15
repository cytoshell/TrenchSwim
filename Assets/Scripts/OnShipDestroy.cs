using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnShipDestroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject gameOverUI;
    public GameObject thrusters;
    public GameObject[] stars;
    public GameObject objectSpawner;
    public GameObject ship;
    public TextMeshProUGUI scoreText;
    public static bool isDead = false;
    private float score = 0f;

    //there's probably a better way to do this, to be honest
    //I would probably make some of this into a separate script in the future 
    void Start(){
        //on start behaviour, should not be dead and things should not be active until the player is dead
        isDead = false;
        gameOverUI.SetActive(false);
        explosion.SetActive(false);
    }

    //if not dead, increase score & update text,
    //if dead and 'r' is pressed, reload the scene
    void Update(){
        if(!isDead){
            score += Time.deltaTime*10;
            scoreText.text = Mathf.FloorToInt(score).ToString();
        }

        if (isDead && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //if the ship collides with an object, it's now dead
    //epic explosions happen, stars & thrusters are destroyed, game over UI is active 
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Object")){
            isDead = true;
            explosion.SetActive(true);

            GetComponent<MeshRenderer>().enabled = false;   //makes the ship invisible so the rest of the script can run
            Destroy(objectSpawner);      

            gameOverUI.SetActive(true);
            thrusters.SetActive(false);
            
            Destroy(stars[0]);
            Destroy(stars[1]);
        }
    }   
}
