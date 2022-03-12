using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolProduct : MonoBehaviour
{
    [SerializeField] private Product _productPrefab;
    private static Product _product;
    private static List<Product> _products = new List<Product>();
    public static PoolProduct Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        InitLink();
    }
    private void InitLink()
    {
        _product = _productPrefab;
    }

    public static Product ProductEnq(ref FactorioSO infoProductSO, Vector3 pointSpawn, Quaternion rot)
    {
        for (int i = 0; i < _products.Count; i++)
        {
            if (_products[i].isFree)
            {
                return ProductSpawn(_products[i], ref infoProductSO, ref pointSpawn, ref rot);
            }
        }
        Product product = Instantiate(_product, Singleton.transform.parent);
        _products.Add(product);
        return ProductSpawn(product, ref infoProductSO, ref pointSpawn, ref rot);
    }
    private static Product ProductSpawn(Product product, ref FactorioSO infoProductSO, ref Vector3 pointSpawn, ref Quaternion rot)
    {
        product.transform.position = pointSpawn;
        product.transform.rotation = rot;
        product.SetInfoProduct(ref infoProductSO);
        product.transform.SetParent(null);
        _products.Remove(product);
        return product;
    }
    public static void ProductDeq(ref Product product)
    {
        product.ClearInfoProduct();
        product.transform.SetParent(Singleton.transform);
        product.transform.position = Vector3.zero;
        _products.Add(product);
    }
}
