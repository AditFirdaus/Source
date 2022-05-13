using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInput
{
    public static class Drone
    {
        public static class Movement
        {
            public static Vector3 Get()
            {
                return new Vector3(GetRight(), GetUp(), GetForward());
            }

            public static float GetRight()
            {
                return ValidateInput(KeyCode.A, KeyCode.D);
            }

            public static float GetUp()
            {
                return ValidateInput(KeyCode.Q, KeyCode.E);
            }

            public static float GetForward()
            {
                return ValidateInput(KeyCode.S, KeyCode.W);
            }
        }

        public static class Rotation
        {
            public static Vector2 Get()
            {
                return new Vector2(GetHorizontal(), GetVertical());
            }

            public static float GetHorizontal()
            {
                return ValidateInput(KeyCode.LeftArrow, KeyCode.RightArrow);
            }

            public static float GetVertical()
            {
                return ValidateInput(KeyCode.DownArrow, KeyCode.UpArrow);
            }
        }

        public static float ValidateInput(KeyCode negative, KeyCode positive)
        {
            float value = 0;

            if (Input.GetKey(positive)) value = 1;
            else if (Input.GetKey(negative)) value = -1;

            return value;
        }
    }
}
