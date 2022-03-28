using UnityEngine;

public class SwerveSystem : MonoBehaviour
{
    [Range(1f, 5f)][SerializeField] private float _forwardSpeed = 3.0f;
    [Range(0.1f, 0.75f)][SerializeField] private float _horizontalSpeed = 0.5f;

    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    private Collector collector;

    public float MoveFactorX { get => _moveFactorX;private set => _moveFactorX = value; }

    private void Start()
    {
        collector = FindObjectOfType<Collector>();
    }
    private void Update()
    {
        if (CharacterState.Instance.States == CharState.None)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                MoveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;

                collector.IsPressed = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                MoveFactorX = 0f;
                collector.IsPressed = false;
            }

            transform.Translate(new Vector3(MoveFactorX * _horizontalSpeed * Time.deltaTime, 0, _forwardSpeed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}