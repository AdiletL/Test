using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="InfoFactorio", menuName ="Information Factorio", order = 51)]
public class FactorioSO : ScriptableObject
{
    [SerializeField] private TypeOfProduct _typeOfProduct;
    [SerializeField] private Material _material;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private float _cooldownInstantiate;

    public TypeOfProduct typeOfProduct { get => _typeOfProduct;}
    public Material material { get => _material;}
    public MeshFilter meshFilter { get => _meshFilter;}
    public float cooldownInstantiate { get => _cooldownInstantiate;}
}
