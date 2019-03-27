using UnityEngine;

public class MoveTopToBottom : MonoBehaviour
{
    [SerializeField] private float FallSpeed = 0;
    [SerializeField] private float MaxFallDistance = 0;
    private Vector2 InitialPosition = Vector2.zero;
    private Vector2 TargetPosition = Vector2.zero;

    private bool IsFalling = false;

    private void Awake()
    {
        StartFall();
    }

    public void StartFall(){
        InitialPosition = transform.localPosition;
        DefineTargetPosition(MaxFallDistance);
        IsFalling = true;
    }

    public void DefineTargetPosition(float distance)
    {
        MaxFallDistance = distance;
        TargetPosition = InitialPosition - new Vector2(0, MaxFallDistance);
    }

    void Update(){
        if (IsFalling)
        {
            if (transform.localPosition.y <= TargetPosition.y)
            {
                return;
            }
            transform.Translate(Vector3.down * Time.deltaTime * FallSpeed);
        }
    }
}
