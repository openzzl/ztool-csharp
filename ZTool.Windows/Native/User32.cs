using System;
using System.Runtime.InteropServices;

namespace ZTool.Windows.Native
{
    /// <summary>
    /// Win32 Native
    /// </summary>
    public class User32
    {
        #region Window

        /// <summary>
        /// 检索处理顶级窗口的类名和窗口名称匹配指定的字符串。不搜索子窗口。
        /// </summary>
        /// <param name="lpClassName"> 指向一个以NULL字符结尾的、用来指定类名的字符串或一个可以确定类名字符串的原子。 </param>
        /// <param name="lpWindowName"> 指向一个以NULL字符结尾的、用来指定窗口名（即窗口标题）的字符串。如果此参数为NULL，则匹配所有窗口名。 </param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 该函数设置指定窗口的显示状态。
        /// </summary>
        /// <param name="hWnd"> 指窗口句柄 </param>
        /// <param name="nCmdShow"> 指定窗口如何显示 </param>
        /// <returns> 如果窗口之前可见，则返回值为非零。如果窗口之前被隐藏，则返回值为零。 </returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 窗口显示方式
        /// </summary>
        public enum SW
        {
            /// <summary>
            /// 隐藏窗口并激活其他窗口。
            /// </summary>
            SW_HIDE = 0,
            /// <summary>
            /// 激活并显示一个窗口。如果窗口被最小化或最大化，系统将其恢复到原来的尺寸和大小。应用程序在第一次显示窗口的时候应该指定此标志。
            /// </summary>
            SW_SHOWNORMAL = 1,
            /// <summary>
            /// 激活窗口并将其最小化。
            /// </summary>
            SW_SHOWMINIMIZED = 2,
            /// <summary>
            /// 激活窗口并将其最大化。
            /// </summary>
            SW_SHOWMAXIMIZED = 3,
            /// <summary>
            /// 最大化指定的窗口。
            /// </summary>
            SW_MAXIMIZE = 3,
            /// <summary>
            /// 以窗口最近一次的大小和状态显示窗口。激活窗口仍然维持激活状态。
            /// </summary>
            SW_SHOWNOACTIVATE = 4,
            /// <summary>
            /// 在窗口原来的位置以原来的尺寸激活和显示窗口。
            /// </summary>
            SW_SHOW = 5,
            /// <summary>
            /// 最小化指定的窗口并且激活在Z序中的下一个顶层窗口。
            /// </summary>
            SW_MINIMIZE = 6,
            /// <summary>
            /// 窗口最小化，激活窗口仍然维持激活状态。
            /// </summary>
            SW_SHOWMINNOACTIVE = 7,
            /// <summary>
            /// 以窗口原来的状态显示窗口。激活窗口仍然维持激活状态。
            /// </summary>
            SW_SHOWNA = 8,
            /// <summary>
            /// 激活并显示窗口。如果窗口最小化或最大化，则系统将窗口恢复到原来的尺寸和位置。在恢复最小化窗口时，应用程序应该指定这个标志。
            /// </summary>
            SW_RESTORE = 9,
            /// <summary>
            /// 依据在STARTUPINFO结构中指定的SW_FLAG标志设定显示状态，STARTUPINFO 结构是由启动应用程序的程序传递给CreateProcess函数的。
            /// </summary>
            SW_SHOWDEFAULT = 10,
            /// <summary>
            /// 在WindowNT5.0中最小化窗口，即使拥有窗口的线程被挂起也会最小化。在从其他线程最小化窗口时才使用这个参数。
            /// </summary>
            SW_FORCEMINIMIZE = 11,
        }

        /// <summary>
        /// 获取一个前台窗口的句柄（用户当前工作的窗口）。该系统分配给其他线程比它的前台窗口的线程创建一个稍微更高的优先级。
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetForegroundWindow")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// 将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程。
        /// 前台窗口是z序顶部的窗口，是用户的工作窗口。在一个多任务优先抢占环境中，应让用户控制前台窗口。
        /// </summary>
        /// <param name="hWnd"> 将要设置前台的窗口句柄 </param>
        /// <returns> 如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零。 </returns>
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion

        #region Message

        /// <summary>
        /// 将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。
        /// </summary>
        /// <param name="hWnd"> 指定要接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="Msg"> 指定被发送的消息。 </param>
        /// <param name="wParam"> 指定附加的消息特定信息。 </param>
        /// <param name="lParam"> 指定附加的消息特定信息。 </param>
        /// <returns> 返回值指定消息处理的结果，依赖于所发送的消息。 </returns>
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 将一个消息放入（寄送）到与指定窗口创建的线程相联系消息队列里，不等待线程处理消息就返回，是异步消息模式。消息队列里的消息通过调用GetMessage和PeekMessage取得。
        /// </summary>
        /// <param name="hWnd"> 其窗口程序接收消息的窗口的句柄。可取有特定含义的两个值： HWND_BROADCAST：消息被寄送到系统的所有顶层窗口，包括无效或不可见的非自身拥有的窗口、 被覆盖的窗口和弹出式窗口。消息不被寄送到子窗口。 NULL：此函数的操作和调用参数dwThread设置为当前线程的标识符PostThreadMessage函数一样</param>
        /// <param name="Msg"> 指定被寄送的消息。 </param>
        /// <param name="wParam"> 指定附加的消息特定的信息。 </param>
        /// <param name="lParam"> 指定附加的消息特定的信息。 </param>
        /// <returns> 如果函数调用成功，返回非零，否则函数调用返回值为零 </returns>
        [DllImport("user32.dll", EntryPoint = "PostMessage", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        #endregion
    }
}
