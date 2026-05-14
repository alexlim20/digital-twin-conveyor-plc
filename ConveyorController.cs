using UnityEngine;
using S7.Net;

public class ConveyorController : MonoBehaviour
{
    private Plc plc;

    [Header("Assign your 3 Belt Planks here")]
    public ConveyorBelt belt1;
    public ConveyorBelt belt2;
    public ConveyorBelt belt3;

    void Start()
    {
        plc = new Plc(CpuType.S71500, "10.10.10.10", 0, 1); 
        plc.Open();
    }

    void Update()
    {
        if (plc != null && plc.IsConnected)
        {
            // 1. Read the 3 motors from the PLC
            belt1.isRunning = (bool)plc.Read("Q0.0");
            belt2.isRunning = (bool)plc.Read("Q0.1");
            belt3.isRunning = (bool)plc.Read("Q0.2");

            // 3. Send Keyboard presses to the PLC (S1, S2, S3, S4)
            if (Input.GetKeyDown(KeyCode.Alpha1)) plc.Write("I0.0", true);
            if (Input.GetKeyUp(KeyCode.Alpha1))   plc.Write("I0.0", false);

            if (Input.GetKeyDown(KeyCode.Alpha2)) plc.Write("I0.1", true);
            if (Input.GetKeyUp(KeyCode.Alpha2))   plc.Write("I0.1", false);

            if (Input.GetKeyDown(KeyCode.Alpha3)) plc.Write("I0.2", true);
            if (Input.GetKeyUp(KeyCode.Alpha3))   plc.Write("I0.2", false);

            if (Input.GetKeyDown(KeyCode.Alpha4)) plc.Write("I0.3", true);
            if (Input.GetKeyUp(KeyCode.Alpha4))   plc.Write("I0.3", false);
        }
    }

    void OnApplicationQuit()
    {
        if (plc != null && plc.IsConnected) plc.Close();
    }
}