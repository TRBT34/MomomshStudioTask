using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChainCollector : MonoBehaviour
{
    public Transform ChainDefaultPos;
    public List<GameObject> StackChains = new List<GameObject>();
    public Vector3 TmpYPos;

    private void Awake()
    {
        TmpYPos = ChainDefaultPos.localPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("chain"))
        {
            StackChains.Add(other.gameObject);
            other.gameObject.transform.parent = this.transform;
            other.gameObject.transform.DOLocalJump(TmpYPos, 6f, 1, 0.2f);
            other.gameObject.transform.DOLocalRotate(new Vector3(0,0,0), 0.1f);
            TmpYPos += new Vector3(0, 0.4f, 0);
        }
    }
}
