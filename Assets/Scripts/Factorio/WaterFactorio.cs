using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFactorio : Factorio
{
    protected override IEnumerator CreateProductCoroutine()
    {
        StartCoroutine(base.CreateProductCoroutine());

        while (true)
        {
            yield return new WaitForSeconds(_factorioSO.cooldownInstantiate);
            if (_outgoingStorage.isFree)
            {
                Product product = PoolProduct.ProductEnq(ref _factorioSO, _outgoingStorage.transform.position, _outgoingStorage.transform.rotation);
                product.transform.SetParent(_outgoingStorage.transform);
                product.typeOfProduct = _factorioSO.typeOfProduct;
                _outgoingStorage.AddProduct(product);
            }
        }
    }
}
