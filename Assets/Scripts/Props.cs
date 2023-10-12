using UnityEngine;

public class Props : Entity, IContactInteractable
{
    [Header("Drop Settings")]
    [SerializeField] private DropObject _dropPrefab;
    [SerializeField][Min(0)] private int _amount;

    [SerializeField] private bool _isDropRandom;
    [SerializeField][Min(0)] private int _minAmount;
    [SerializeField][Min(0)] private int _maxAmount;

    public void Interact()
    {
        SpawnDrop();

        Dies();
    }

    private void SpawnDrop()
    {
        if (_dropPrefab == null)
            return;

        if (_isDropRandom)
            _amount = UnityEngine.Random.Range(_minAmount, _maxAmount);

        for (int i = 0; i < _amount; i++)
        {
            DropObject drop = Instantiate(_dropPrefab, transform.position, Quaternion.identity);
        }
    }
}
