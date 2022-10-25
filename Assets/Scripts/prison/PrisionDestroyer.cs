using UnityEngine;

public class PrisionDestroyer : MonoBehaviour
{
    GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private  void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyprison"))
        {
            Transform[] ts = GameObject.Find("Player").GetComponentsInChildren<Transform>();
            foreach (Transform t in ts)
            {
                if (t.name == "Sphere")
                {
                    Destroy(t.gameObject);
                }
            }
            player.GetComponent<EnemyCollector>().ObiChain[0].gameObject.transform.position = new Vector3(100, 100, 100);
            other.gameObject.transform.parent.gameObject.SetActive(false);
            player.GetComponent<EnemyCollector>().ObiChain.RemoveAt(0);
            player.GetComponent<EnemyCollector>().EnemyCounter--;
            player.GetComponent<EnemyCollector>().StacksEnemy.RemoveAt(0);

            

            if (player.GetComponent<EnemyCollector>().StacksEnemy.Count == 0)
            {
                player.GetComponent<EnemyCollector>().tmpObjecttofollow = player;
            }
            if (player.GetComponent<EnemyCollector>().StacksEnemy.Count > 0)
            {
                player.GetComponent<EnemyCollector>().tmpObjecttofollow = player.GetComponent<EnemyCollector>().StacksEnemy[player.GetComponent<EnemyCollector>().EnemyCounter - 1].gameObject;
            }
        }
    }
}
