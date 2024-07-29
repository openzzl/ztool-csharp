using System;
using System.Runtime.InteropServices;

namespace ZTool.Windows.Native
{
    /// <summary>
    /// Shell32.dll
    /// </summary>
    public class Shell32
    {
        /// <summary>
        /// 运行一个外部程序（或者是打开一个已注册的文件、打开一个目录、打印一个文件等等），并对外部程序有一定的控制。
        /// </summary>
        /// <param name="hwnd"> 指定父窗口句柄 </param>
        /// <param name="lpOperation"> 指定动作, 譬如: open、runas、print、edit、explore、find </param>
        /// <param name="lpFile"> 指定要打开的文件或程序 </param>
        /// <param name="lpParameters"> 给要打开的程序指定参数; 如果打开的是文件这里应该是 nil </param>
        /// <param name="lpDirectory"> 缺省目录 </param>
        /// <param name="nShowCmd"> 打开选项 参数可选值:SW_HIDE = 0; {隐藏}
        /// SW_SHOWNORMAL = 1; {用最近的大小和位置显示, 激活}
        /// SW_NORMAL = 1; {同 SW_SHOWNORMAL}
        /// SW_SHOWMINIMIZED = 2; {最小化, 激活}
        /// SW_SHOWMAXIMIZED = 3; {最大化, 激活}
        /// SW_MAXIMIZE = 3; {同 SW_SHOWMAXIMIZED}
        /// SW_SHOWNOACTIVATE = 4; {用最近的大小和位置显示, 不激活}
        /// SW_SHOW = 5; {同 SW_SHOWNORMAL}
        /// SW_MINIMIZE = 6; {最小化, 不激活}
        /// SW_SHOWMINNOACTIVE = 7; {同 SW_MINIMIZE}
        /// SW_SHOWNA = 8; {同 SW_SHOWNOACTIVATE}
        /// SW_RESTORE = 9; {同 SW_SHOWNORMAL}
        /// SW_SHOWDEFAULT = 10; {同 SW_SHOWNORMAL}
        /// SW_MAX = 10; {同 SW_SHOWNORMAL}
        /// </param>
        /// <returns></returns>
        [DllImport("shell32.dll", EntryPoint = "ShellExecute")]
        public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
    }
}
