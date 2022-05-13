using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AssemblyComponent", menuName = "AssemblyComponent")]
public class AssemblyComponent : ScriptableObject
{
    public Sprite sprite;
    public Sprite spritePreview;
    public string description;
    public ComponentEffect effect;

}

[System.Serializable]
public class ComponentEffect
{
    public Battery battery = new Battery();
    public Propeller propeller = new Propeller();
    public Lights lights = new Lights();
    public Sensor sensor = new Sensor();
    public Camera camera = new Camera();
    public Processor processor = new Processor();

    public static ComponentEffect operator +(ComponentEffect a, ComponentEffect b)
    {
        ComponentEffect c = new ComponentEffect();

        c.battery = a.battery + b.battery;
        c.propeller = a.propeller + b.propeller;
        c.lights = a.lights + b.lights;
        c.sensor = a.sensor + b.sensor;
        c.camera = a.camera + b.camera;
        c.processor = a.processor + b.processor;

        return c;
    }

    [System.Serializable]
    public class Battery
    {
        public int amount = 0;

        public static Battery operator +(Battery a, Battery b)
        {
            a.amount += b.amount;
            return a;
        }
    }

    [System.Serializable]
    public class Propeller
    {
        public float amount = 0;

        public static Propeller operator +(Propeller a, Propeller b)
        {
            a.amount += b.amount;
            return a;
        }
    }

    [System.Serializable]
    public class Lights
    {
        public float amount = 0;

        public static Lights operator +(Lights a, Lights b)
        {
            a.amount += b.amount;
            return a;
        }
    }

    [System.Serializable]
    public class Sensor
    {
        public float amount = 0;

        public static Sensor operator +(Sensor a, Sensor b)
        {
            a.amount += b.amount;
            return a;
        }
    }

    [System.Serializable]
    public class Camera
    {
        public float amount = 0;

        public static Camera operator +(Camera a, Camera b)
        {
            a.amount += b.amount;
            return a;
        }
    }

    [System.Serializable]
    public class Processor
    {
        public float amount = 0;

        public static Processor operator +(Processor a, Processor b)
        {
            a.amount += b.amount;
            return a;
        }
    }
}
