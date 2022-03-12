using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Storage : MonoBehaviour
{
    [SerializeField] private TypeOfStorage _typeOfStorage;
    [SerializeField] private TypeOfProduct[] _incomingTypeOfProduct;
    [SerializeField] private int _maxAmount;
    private List<Product> _products = new List<Product>();
    private TextMeshProUGUI _textMeshPro;

     public bool isFree = true;

    public TypeOfStorage typeOfStorage { get => _typeOfStorage; }
    public TypeOfProduct[] typeOfProduct { get => _incomingTypeOfProduct; }
    public List<Product> products { get => _products; }
    public int maxAmount { get => _maxAmount; }

    private void Start()
    {
        _textMeshPro = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        AmountText();
    }
    private void AmountText()
    {
        _textMeshPro.text = _products.Count.ToString() + "/" + _maxAmount.ToString();
    }
    public void AddProduct(Product product)
    {
        if (_products.Count < _maxAmount)
        {
            _products.Add(product);
            AmountText();
        }
        if (_products.Count == _maxAmount)
            isFree = false;
    }
    public bool CheckList()
    {
        bool similar = true, typeOfProduct0 = false, typeOfProduct1 = false;
        if (_products.Count == _maxAmount)
        {

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].typeOfProduct == _incomingTypeOfProduct[0])
                {
                    typeOfProduct0 = true;
                }
                else
                {
                    typeOfProduct1 = true;
                }
                if (typeOfProduct0 == typeOfProduct1)
                {
                    similar = false;
                    break;
                }
            }
            return similar;
        }
        else
        {
            return similar = false;
        }
    }
    public void ClearProducts(Vector3 target, Transform parent, Product product)
    {
        product.MoveTarget(target, parent, false);
        _products.Remove(product);
        AmountText();
        if (_products.Count < _maxAmount)
            isFree = true;
    }
}
