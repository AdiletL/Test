using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarFactorio : Factorio
{
    protected override IEnumerator CreateProductCoroutine()
    {
        StartCoroutine(base.CreateProductCoroutine());

        while (true)
        {
            yield return new WaitForSeconds(_factorioSO.cooldownInstantiate);
            if (_incomingStorage.products.Count != 0 && _outgoingStorage.isFree)
            {
                Product product = _incomingStorage.products[0];
                product.SetInfoProduct(ref _factorioSO);
                product.typeOfProduct = _factorioSO.typeOfProduct;
                _incomingStorage.ClearProducts(Vector3.zero, _outgoingStorage.transform, product);
                yield return new WaitForSeconds(.3f);
                _outgoingStorage.AddProduct(product);
            }
        }
    }
}
