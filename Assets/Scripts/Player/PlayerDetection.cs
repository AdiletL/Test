using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private PlayerSorting _playerSorting;

    private void Start()
    {
        InitLink();
    }

    private void InitLink()
    {
        _playerSorting = transform.parent.GetComponent<PlayerSorting>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Storage storage))
        {
            if (storage.typeOfStorage == TypeOfStorage.Outgoing)
            {
                int amount = storage.products.Count;
                for (int i = 0; i < amount; i++)
                {
                    _playerSorting.AddProduct(storage.products[0]);
                    storage.ClearProducts(_playerSorting.PointEnq(), _playerSorting.pointCollection, storage.products[0]);
                }
            }
            else
            {
                _playerSorting.SortingProduct(storage);
            }
        }
    }
}
