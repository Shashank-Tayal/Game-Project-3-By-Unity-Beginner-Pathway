using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // When the background starts to move we need to repeat it.
    // Since the background is repeated after half of it is passed, so we will use that point to repeat the background.
    // Variables:-
    private Vector3 startPosition;
    public float repeatWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // With this we can get the start position so that we can reset the background to the starting position.
        // The box collider will help us with getting the exact half of the background so we will using it for the same.
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // The "/ 2" in the code is for getting the halfway value of the background.
    }

    // Update is called once per frame
    void Update()
    {
        // Resets the position to the starting position when the background is done halfway through.
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
