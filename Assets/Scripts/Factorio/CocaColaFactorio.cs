using System.Collections;
using UnityEngine;

public class CocaColaFactorio : Factorio
{
    [SerializeField] private Storage _extraStorage;
    protected override IEnumerator CreateProductCoroutine()
    {
        StartCoroutine(base.CreateProductCoroutine());

        while (true)
        {
            bool isProduct0 = false, isProduct1 = false;
            Product product0 = null;
            Product product1 = null;
            yield return new WaitForSeconds(_factorioSO.cooldownInstantiate);
            if (_incomingStorage.products.Count != 0 && _outgoingStorage.isFree)
            {
                for (int i = 0; i < _incomingStorage.products.Count; i++)
                {
                    if (_incomingStorage.products[i].typeOfProduct == _incomingStorage.typeOfProduct[0])
                    {
                        product0 = _incomingStorage.products[i];
                        isProduct0 = true;
                    }
                    else
                    {
                        product1 = _incomingStorage.products[i];
                        isProduct1 = true;
                    }
                    if (isProduct0 == isProduct1)
                    {
                        _incomingStorage.ClearProducts(Vector3.zero, _outgoingStorage.transform, product1);
                        yield return null;
                        PoolProduct.ProductDeq(ref product1);

                        product0.SetInfoProduct(ref _factorioSO);
                        product0.typeOfProduct = _factorioSO.typeOfProduct;
                        _incomingStorage.ClearProducts(Vector3.zero, _outgoingStorage.transform, product0);
                        _outgoingStorage.AddProduct(product0);
                        yield return new WaitForSeconds(.3f);
                        break;
                    }
                }
                if (_incomingStorage.CheckList())
                {
                    _extraStorage.AddProduct(_incomingStorage.products[0]);
                    _incomingStorage.ClearProducts(Vector3.zero, _extraStorage.transform, _incomingStorage.products[0]);
                }
            }
        }
    }
}
