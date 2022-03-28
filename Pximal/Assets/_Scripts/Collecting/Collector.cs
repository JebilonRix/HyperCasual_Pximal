using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private GameObject _boxPrefab;
    [SerializeField] private Transform _collectedPoint;
    [SerializeField] private float _posOffset;
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _kickForce = 30f;

    [Range(5, 15)][SerializeField] private int _maxBoxCount = 10;
    [Range(1, 10)][SerializeField] private int _boxLimit = 4;

    private List<GameObject> _boxes = new List<GameObject>();
    private int _collectedBoxCount = 0;
    private bool _isPressed = false;
    private SwerveSystem _system;

    public List<GameObject> Boxes { get => _boxes; set => _boxes = value; }
    public bool IsPressed { get => _isPressed; set => _isPressed = value; }

    private void Start()
    {
        _system = FindObjectOfType<SwerveSystem>();

        for (int i = 0; i < _maxBoxCount; i++)
        {
            GameObject obj = Instantiate(_boxPrefab, _collectedPoint.position, Quaternion.identity);

            obj.transform.SetParent(_collectedPoint.transform);
            obj.transform.localPosition = new Vector3(0, obj.transform.localPosition.y + (i * _posOffset), 0);
            obj.SetActive(false);

            Boxes.Add(obj);
        }
    }

    [System.Obsolete]
    private void Update()
    {
        for (int i = 0; i < Boxes.Count; i++)
        {
            Boxes[i].transform.localPosition =
            new Vector3(Mathf.Lerp(Boxes[i].transform.localPosition.x, transform.localPosition.x, i * Time.deltaTime * _lerpSpeed),
            Boxes[i].transform.localPosition.y,
            Boxes[i].transform.localPosition.z);

            if (IsPressed && _system.MoveFactorX != 0)
            {
                if (_system.MoveFactorX < 0)
                {
                    Boxes[i].transform.localRotation = Quaternion.EulerRotation(new Vector3(0, 0, _rotateSpeed));
                }
                else
                {
                    Boxes[i].transform.localRotation = Quaternion.EulerRotation(new Vector3(0, 0, -_rotateSpeed));
                }
            }
            else
            {
                Boxes[i].transform.localRotation = Quaternion.EulerRotation(new Vector3(0, 0, 0));
            }
        }
    }

    public void AddBox()
    {
        Boxes[_collectedBoxCount].SetActive(true);

        _collectedBoxCount++;
    }
    public void RemoveBox(bool kicked = false)
    {
        if (!kicked)
        {
            if (_collectedBoxCount > _boxLimit)
            {
                Boxes[_collectedBoxCount - 1].SetActive(false);

                _collectedBoxCount--;
            }
        }
        else
        {
            if (_collectedBoxCount >= 1)
            {
                GameObject obj = Boxes[_collectedBoxCount - 1];

                Boxes.Remove(obj);

                _collectedBoxCount--;

                obj.transform.SetParent(null);
                var rb = obj.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.AddForce(new Vector3(0, 100, _kickForce));
            }
        }
    }
}