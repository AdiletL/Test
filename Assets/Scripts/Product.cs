using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    private FactorioSO _factorioSO;
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;


     public TypeOfProduct typeOfProduct;
    [HideInInspector] public bool isFree;
    #region Mono
    private void Start()
    {
        InitLink();
    }
    private void InitLink()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }
    #endregion

    public void SetInfoProduct(ref FactorioSO infoFactorioSO) => StartCoroutine(SetInfoProductCoroutine(infoFactorioSO));
    private IEnumerator SetInfoProductCoroutine(FactorioSO infoFactorioSO)
    {
        yield return null;
        _factorioSO = infoFactorioSO;
        _meshFilter.sharedMesh = infoFactorioSO.meshFilter.sharedMesh;
        _meshRenderer.material = infoFactorioSO.material;
        _meshRenderer.enabled = true;
        _boxCollider.enabled = true; 
        isFree = false;
    }

    public void MoveTarget(Vector3 target, Transform parent, bool isFree) => StartCoroutine(Move(target, parent, isFree));

    private IEnumerator Move(Vector3 target, Transform parent, bool isFree)
    {
        _boxCollider.enabled = isFree;
        transform.SetParent(parent);
        yield return null;

        while (transform.localPosition != target)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, (_speedMove * 10) * Time.deltaTime);
            yield return null;
        }
        transform.localRotation = Quaternion.identity;
    }

    public void ClearInfoProduct()
    {
        _factorioSO = null;
        _meshFilter.sharedMesh = null;
        _meshRenderer.material = null;
        _meshRenderer.enabled = false;
        _boxCollider.enabled = false;
        isFree = true;
    }
}
