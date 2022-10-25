using DG.Tweening;
using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prisonChainback : MonoBehaviour
{
    public GameObject Chain;
    GameObject chaincollector;

    private void Awake()
    {
        chaincollector = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyprison"))
        {
            var chain = Instantiate(Chain);
            chain.transform.position= this.gameObject.transform.position;
            chain.transform.SetParent(chaincollector.transform);
            chain.transform.localScale= new Vector3(1.333333f, 0.3333333f, 0.3333333f);
            chain.transform.DOLocalJump(chaincollector.GetComponent<ChainCollector>().TmpYPos, 5f, 1, 0.5f);
            chain.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f);
            chaincollector.GetComponent<ChainCollector>().TmpYPos += new Vector3(0, 0.4f, 0);
            chaincollector.GetComponent<ChainCollector>().StackChains.Add(chain);
        }
    }
}
