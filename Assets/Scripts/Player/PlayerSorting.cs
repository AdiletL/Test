using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSorting : MonoBehaviour
{
    [SerializeField] private Transform _pointCollection;
    public Transform pointCollection { get { return _pointCollection; } }

    private List<Vector3> _productsPos = new List<Vector3>();
    private List<Product> _products = new List<Product>();
    public List<Product> products { get => _products; }
    private Vector3 _pointV;
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public Vector3 PointEnq()
    {
        if (_productsPos.Count != 0)
            _pointV = _productsPos[_productsPos.Count - 1];
        else
            _pointV = Vector3.zero;
        if (_pointV.y < 5)
        {
            _pointV.y += .5f;
        }
        else
        {
            _pointV.y = .5f;
            _pointV.z -= .5f;
        }
        _productsPos.Add(_pointV);
        return _pointV;
    }

    public void SortingProduct(Storage storage) => StartCoroutine(Sorting(storage));
    private IEnumerator Sorting(Storage storage)
    {
        for (int i = _products.Count - 1; i >= 0; i--)
        {
            if (storage.isFree)
            {
                if (_products[i].typeOfProduct == storage.typeOfProduct[0] || _products[i].typeOfProduct == storage.typeOfProduct[1])
                {
                    storage.AddProduct(_products[i]);
                    _products[i].MoveTarget(Vector3.zero, storage.transform, false);
                    _productsPos.RemoveAt(_productsPos.Count - 1);
                    _products.RemoveAt(i);
                    yield return new WaitForSeconds(.05f);
                }
            }
            else
            {
                break;
            }
        }
        yield return null;
        for (int i = 0; i < _products.Count; i++)
        {
            _products[i].MoveTarget(_productsPos[i], pointCollection, false);
            yield return new WaitForSeconds(.02f);
        }
    }
}
