using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factorio : MonoBehaviour
{
    [SerializeField] protected FactorioSO _factorioSO;
    [SerializeField] protected Storage _incomingStorage, _outgoingStorage;
    public FactorioSO factorioSO { get => _factorioSO; }
    protected virtual void Start()
    {
        StartCoroutine(CreateProductCoroutine());
    }
    protected virtual IEnumerator CreateProductCoroutine()
    {
        yield return null;
    }
}
