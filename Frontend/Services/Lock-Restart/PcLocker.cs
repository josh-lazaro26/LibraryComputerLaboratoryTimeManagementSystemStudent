using System.Runtime.InteropServices;

public static class PcLocker
{
    [DllImport("user32.dll")]
    public static extern bool LockWorkStation();
}
