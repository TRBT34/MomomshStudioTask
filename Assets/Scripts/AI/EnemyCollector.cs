using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyCollector : MonoBehaviour
{
    public GameObject tmpObjecttofollow;
    public List<GameObject> StacksEnemy = new List<GameObject>();
    public List<GameObject> ObiChain = new List<GameObject>();
    public int EnemyCounter = 0;
    public GameObject Rope;
    GameObject ChainCollector;
    private void Awake()
    {
        tmpObjecttofollow = this.gameObject;
        ChainCollector = GameObject.Find("Player");
    }
    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (StacksEnemy.Count > 0)
            {
                tmpObjecttofollow = StacksEnemy[EnemyCounter - 1].gameObject;
            }  
            if (StacksEnemy.Count == 0 && ChainCollector.GetComponent<ChainCollector>().StackChains.Count >= 1)
            {
                ChainCollector.GetComponent<ChainCollector>().TmpYPos += new Vector3(0, -0.4f, 0);
                other.gameObject.GetComponent<Collider>().enabled = false;
                StacksEnemy.Add(other.gameObject);
                var Lastchain = ChainCollector.GetComponent<ChainCollector>().StackChains.Last();
                Lastchain.GetComponent<Collider>().enabled = false;
                Lastchain.transform.parent = null;
                Lastchain.transform.DOJump(StacksEnemy[0].transform.position, 7f, 1, 0.5f).OnComplete(()=> 
                ChainCollector.GetComponent<ChainCollector>().StackChains.Remove(Lastchain));
                await Task.Delay(System.TimeSpan.FromSeconds(0.6f));
                Destroy(Lastchain);
                var rope = Instantiate(Rope);
                ObiChain.Add(rope);
                var obj1 = rope.GetComponent<RopeAccesChild>().obj1;
                obj1.transform.parent = tmpObjecttofollow.transform;
                obj1.transform.localPosition = new Vector3(0, 1, 0);
                var obj2 = rope.GetComponent<RopeAccesChild>().obj2;
                obj2.transform.parent = StacksEnemy[0].transform;
                obj2.transform.localPosition = new Vector3(0, 1, 0);
                other.gameObject.GetComponent<AIControl>().AIState = true;
                EnemyCounter++;
                await Task.Delay(System.TimeSpan.FromSeconds(0.5f));
            }
            else if(StacksEnemy.Count >= 1 && ChainCollector.GetComponent<ChainCollector>().StackChains.Count >= 1)
            {
                ChainCollector.GetComponent<ChainCollector>().TmpYPos += new Vector3(0, -0.4f, 0);
                other.gameObject.GetComponent<Collider>().enabled = false;
                StacksEnemy.Add(other.gameObject);
                var Lastchain = ChainCollector.GetComponent<ChainCollector>().StackChains.Last();
                Lastchain.GetComponent<Collider>().enabled = false;
                Lastchain.transform.parent = null;
                Lastchain.transform.DOJump(StacksEnemy[StacksEnemy.Count-1].transform.position, 7f, 1, 0.5f).OnComplete(() =>
                ChainCollector.GetComponent<ChainCollector>().StackChains.Remove(Lastchain));
                await Task.Delay(System.TimeSpan.FromSeconds(0.6f));
                Destroy(Lastchain);
                var rope = Instantiate(Rope);
                ObiChain.Add(rope);
                var obj1 = rope.GetComponent<RopeAccesChild>().obj1;
                obj1.transform.parent = StacksEnemy[StacksEnemy.Count-2].transform;
                obj1.transform.localPosition = new Vector3(0, 1, 0);
                var obj2 = rope.GetComponent<RopeAccesChild>().obj2;
                obj2.transform.parent = StacksEnemy[StacksEnemy.Count-1].transform;
                obj2.transform.localPosition = new Vector3(0, 1, 0);
                other.gameObject.GetComponent<AIControl>().AIState = true;
                EnemyCounter++;
            }

        }
    }
}
