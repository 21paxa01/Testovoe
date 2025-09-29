using UnityEngine;

public class BeamController : MonoBehaviour
{
    [SerializeField] private Transform crane;
    [SerializeField] private Transform hook;

    private Vector3 beamStartPos;
    private Vector3 craneStartPos;
    private Vector3 hookStartPos;

    [SerializeField] private float beamMaxDistance = 5f;
    [SerializeField] private float craneMaxDistance = 3f;
    [SerializeField] private float hookMaxDistance = 2f;
    
    private void OnEnable()
    {
        CraneInputHandler.OnMoveBeamCommand += MoveBeam;
        CraneInputHandler.OnMoveCraneCommand += MoveCrane;
        CraneInputHandler.OnMoveHookCommand += MoveHook;
    }

    private void OnDisable()
    {
        CraneInputHandler.OnMoveBeamCommand -= MoveBeam;
        CraneInputHandler.OnMoveCraneCommand -= MoveCrane;
        CraneInputHandler.OnMoveHookCommand -= MoveHook;
    }

    private void Start()
    {
        beamStartPos = transform.localPosition;
        craneStartPos = crane.localPosition;
        hookStartPos = hook.localPosition;
    }

    private void MoveBeam(Vector3 direction)
    {
        Vector3 nextPos = transform.position + transform.TransformDirection(direction * Time.deltaTime);
        float currentDistance = Vector3.Distance(beamStartPos, transform.position);
        float nextDistance = Vector3.Distance(beamStartPos, nextPos);

        if (nextDistance < beamMaxDistance || nextDistance < currentDistance)
        {
            transform.Translate(direction * Time.deltaTime, Space.Self);
        }
    }

    private void MoveCrane(Vector3 direction)
    {
        Vector3 nextPos = crane.localPosition + crane.TransformDirection(direction * Time.deltaTime);
        float currentDistance = Vector3.Distance(craneStartPos, crane.localPosition);
        float nextDistance = Vector3.Distance(craneStartPos, nextPos);

        if (nextDistance < craneMaxDistance || nextDistance < currentDistance)
        {
            crane.Translate(direction * Time.deltaTime, Space.Self);
        }
    }

    private void MoveHook(Vector3 direction)
    {
        Vector3 nextPos = hook.localPosition + hook.TransformDirection(direction * Time.deltaTime);
        float currentDistance = Vector3.Distance(hookStartPos, hook.localPosition);
        float nextDistance = Vector3.Distance(hookStartPos, nextPos);

        if ((nextDistance < hookMaxDistance || nextDistance < currentDistance) && nextPos.y <= hookStartPos.y)
        {
            hook.Translate(direction * Time.deltaTime, Space.Self);
        }
    }


}