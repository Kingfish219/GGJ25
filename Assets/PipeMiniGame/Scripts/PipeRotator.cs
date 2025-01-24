using UnityEngine;
using System.Collections;

namespace PipeMiniGame
{
    public class PipeRotator : MonoBehaviour
    {
        [Header("Parent And Audio Source")]
        [SerializeField] private GridFlow parent;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioSource selfAudioSource;
        [SerializeField] private AudioClip[] snapAudioClips;
        [Header("Rotation Settings")]
        [SerializeField] private float duration = 1.0f;   // Time to rotate
        [SerializeField] private float angle = 90.0f;     // Rotation angle per click

        [Header("Game State")]
        [SerializeField] private bool activeTurn = true;
        // The number of distinct rotations (e.g., 4 for up-right-down-left)
        [SerializeField] private int CorrectTurnMode = 4;
        [SerializeField] private int CorrectTurn;  // 0=Up, 1=Right, 2=Down, 3=Left
        private int turn = 0;
        internal bool isCorrect = false;

        [Header("Dragging & Snapping")]
        [SerializeField] private Transform[] placeholders; // Assign placeholder transforms
        [SerializeField] private Transform correctPlaceholder; // Assign placeholder transforms
        private Vector3 initTransPose; // Self Init Transform
        [SerializeField] internal bool isCorrectPlace = true;
        [SerializeField] private float snapDistance = 1.0f; // Max distance to snap
        private bool canDrag = false; // True if this pipe was initially activeTurn=false
        [SerializeField] private bool isSnapped = false;

        [Header("Click vs Drag Settings")]
        [Tooltip("Max time (seconds) to count as a 'click' rather than a drag.")]
        [SerializeField] private float clickTimeThreshold = 0.2f;

        [Tooltip("Max movement in world units to still count as a 'click'.")]
        [SerializeField] private float dragDistanceThreshold = 0.1f;

        // Internal state
        private Camera mainCamera;
        private bool isRotating = false;
        private bool isPointerDown = false;
        private bool isDragging = false;
        private float pointerDownTime;
        private Vector2 pointerDownPos;
        private Vector2 dragOffset;

        void Start()
        {
            selfAudioSource = GetComponent<AudioSource>();
            mainCamera = Camera.main;
            initTransPose = transform.position;
            // Determine if this pipe can *ever* be dragged
            // If it started with activeTurn = false, it is draggable.
            // If it started with activeTurn = true, it never becomes draggable.
            canDrag = !activeTurn;

            // Check initial correctness
            isCorrect = (turn == CorrectTurn);
        }

        void Update()
        {
            // 1) Check for mouse/touch down
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                // Raycast to check if we hit this pipe
                RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    // Start tracking pointer
                    isPointerDown = true;
                    pointerDownTime = Time.time;
                    pointerDownPos = worldPos;
                    dragOffset = (Vector2)transform.position - worldPos;
                    isDragging = false; // reset
                }
            }

            // 2) While pointer is down, check if user drags
            if (isPointerDown && Input.GetMouseButton(0))
            {
                Vector2 currentPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                float distance = Vector2.Distance(currentPos, pointerDownPos);

                // If we exceed drag threshold, switch to drag mode (if allowed)
                if (!isDragging && canDrag && distance > dragDistanceThreshold)
                {
                    isDragging = true;
                }

                // If currently dragging, move the pipe
                if (isDragging)
                {
                    transform.position = currentPos + dragOffset;
                }
            }

            // 3) On mouse/touch up, decide: click or drag?
            if (isPointerDown && Input.GetMouseButtonUp(0))
            {
                isPointerDown = false;

                // If we did NOT drag, then check if it's a quick click => rotate
                if (!isDragging)
                {
                    float pressDuration = Time.time - pointerDownTime;
                    if (pressDuration <= clickTimeThreshold && !isRotating && isSnapped)
                    {
                        // Rotate on short click
                        audioSource.Play();
                        StartCoroutine(RotatePipe());
                    }
                }
                else
                {
                    // We were dragging => snap to nearest placeholder
                    SnapToNearestPlaceholder();
                }
            }
        }

        private IEnumerator RotatePipe()
        {
            isRotating = true;

            // Store the initial rotation
            Quaternion startRotation = transform.rotation;
            // Calculate the target rotation
            Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, angle);

            // Lerp the rotation over the duration
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
                yield return null;
            }

            // Snap to final rotation exactly
            transform.rotation = endRotation;
            ChangeTurn();

            isRotating = false;
            parent.WinPipe();
        }

        private void ChangeTurn()
        {
            // Cycle the turn index
            turn = (turn + 1) % CorrectTurnMode;
            isCorrect = (turn == CorrectTurn);
        }

        private void SnapToNearestPlaceholder()
        {
            if (placeholders == null || placeholders.Length == 0) return;

            Transform closestPlaceholder = null;
            float minDist = Mathf.Infinity;
            Vector2 currentPos = transform.position;

            // Find the nearest placeholder
            foreach (Transform placeholder in placeholders)
            {
                float dist = Vector2.Distance(currentPos, placeholder.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closestPlaceholder = placeholder;
                }
            }

            // Snap if within snapDistance
            if (closestPlaceholder != null && minDist <= snapDistance)
            {
                selfAudioSource.clip = snapAudioClips[0];
                selfAudioSource.Play();
                if (closestPlaceholder == correctPlaceholder)
                    isCorrectPlace = true;
                else
                    isCorrectPlace = false;
                transform.position = closestPlaceholder.position;
                isSnapped = true;
                parent.WinPipe();
            }
            else
            {
                selfAudioSource.clip = snapAudioClips[1];
                selfAudioSource.Play();
                transform.position = initTransPose;
                isSnapped = false;
                isCorrectPlace = false;
            }
        }
    }
}
