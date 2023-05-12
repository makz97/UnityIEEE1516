using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ieee1516
{
    public static class OpenRti
    {
        public delegate void DebugCallback(IntPtr message, int color, int size);

        public delegate void ConnectionLostCallback(IntPtr message, int size);

        public delegate void ReportFederationExecutionsCallback(IntPtr message1, IntPtr message2, int size1, int size2);

        public delegate void SynchronizationPointRegistrationSucceededCallback(IntPtr message1, int size1);

        public delegate void SynchronizationPointRegistrationFailedCallback(IntPtr message1, IntPtr message2, int size1,
            int size2);

        public delegate void AnnounceSynchronizationPointCallback(IntPtr message1, int size1);

        public delegate void FederationSynchronizedCallback(IntPtr message1, int size1);

        [DllImport("DLLtoUnity")]
        public static extern int Connect(StringBuilder myString, int length);

        [DllImport("DLLtoUnity")]
        public static extern int evokeCallback(double dT);

        [DllImport("DLLtoUnity")]
        public static extern int TestInteraction(StringBuilder myString, int length);

        [DllImport("DLLtoUnity")]
        public static extern int TestObjects(StringBuilder myString, int length);

        [DllImport("DLLtoUnity")]
        public static extern int ListFederationExecutions(StringBuilder myString, int length);

        [DllImport("DLLtoUnity")]
        public static extern int CreateFederationExecution(StringBuilder myString, int length);

        [DllImport("DLLtoUnity")]
        public static extern int JoinFederationExecution(StringBuilder myString, int length);

        [DllImport("DLLtoUnity")]
        public static extern int SynchronizationPointAchieved(StringBuilder myString, int length);

        [DllImport("DLLtoUnity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterDebugCallback(DebugCallback callback);

        [DllImport("DLLtoUnity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterConnectionLostCallback(ConnectionLostCallback callback);

        [DllImport("DLLtoUnity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterReportFederationExecutionsCallback(
            ReportFederationExecutionsCallback callback);

        [DllImport("DLLtoUnity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterSynchronizationPointRegistrationSucceededCallback(
            SynchronizationPointRegistrationSucceededCallback callback);

        [DllImport("DLLtoUnity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterSynchronizationPointRegistrationFailedCallback(
            SynchronizationPointRegistrationFailedCallback callback);

        [DllImport("DLLtoUnity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterAnnounceSynchronizationPointCallback(
            AnnounceSynchronizationPointCallback callback);

        [DllImport("DLLtoUnity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterFederationSynchronizedCallback(FederationSynchronizedCallback callback);

        [DllImport("DLLtoUnity")]
        public static extern int RegisterFederationSynchronizationPoint(StringBuilder myString, int length);
    }
}