using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZTool.Windows.Util
{
    /// <summary>
    /// 注册表工具类
    /// </summary>
    public class RegistryUtils
    {
        #region Key

        public static readonly Microsoft.Win32.RegistryKey CurrentUser = Microsoft.Win32.Registry.CurrentUser;

        /// <summary>
        /// ClassesRoot 注册表
        /// </summary>
        public static readonly Microsoft.Win32.RegistryKey ClassesRoot = Microsoft.Win32.Registry.ClassesRoot;

        /// <summary>
        /// LocalMachine 注册表
        /// </summary>
        public static readonly Microsoft.Win32.RegistryKey LocalMachine = Microsoft.Win32.Registry.LocalMachine;

        public static readonly Microsoft.Win32.RegistryKey Users = Microsoft.Win32.Registry.Users;

        public static readonly Microsoft.Win32.RegistryKey CurrentConfig = Microsoft.Win32.Registry.CurrentConfig;

        #endregion

        /// <summary>
        /// // 添加到文件右键菜单
        /// </summary>
        /// <param name="menuItemName"></param>
        /// <param name="command"></param>
        /// <param name="fileType"></param>
        public static void AddContextMenuForFileType(string menuItemName, string command, string fileType)
        {
            // 打开HKEY_CLASSES_ROOT下的文件类型键
            using (RegistryKey key = ClassesRoot.CreateSubKey(fileType))
            {
                // 获取或创建shell子键
                using (RegistryKey shellKey = key.CreateSubKey("shell"))
                {
                    // 获取或创建右键菜单项的子键
                    using (RegistryKey menuKey = shellKey.CreateSubKey(menuItemName))
                    {
                        // 设置菜单项的默认值
                        menuKey.SetValue("", menuItemName);

                        // 创建command子键
                        using (RegistryKey commandKey = menuKey.CreateSubKey("command"))
                        {
                            // 设置command子键的默认值
                            commandKey.SetValue("", "\"" + command + "\" \"%1\"");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加到文件夹右键菜单
        /// </summary>
        /// <param name="menuItemName"></param>
        /// <param name="command"></param>
        public static void AddContextMenuForFolder(string menuItemName, string command)
        {
            // 打开HKEY_CLASSES_ROOT下的文件夹类型键
            using (RegistryKey key = ClassesRoot.CreateSubKey(@"Directory\Background\shell"))
            {
                // 获取或创建右键菜单项的子键
                using (RegistryKey menuKey = key.CreateSubKey(menuItemName))
                {
                    // 设置菜单项的默认值
                    menuKey.SetValue("", menuItemName);

                    // 创建command子键
                    using (RegistryKey commandKey = menuKey.CreateSubKey("command"))
                    {
                        // 设置command子键的默认值
                        commandKey.SetValue("", "\"" + command + "\" \"%V\"");
                    }
                }
            }
        }

        /// <summary>
        /// 获取当前用户注册表下的所有文件类型
        /// </summary>
        /// <returns></returns>
        public static RegistryKey GetRegistryUserSoftwareClassesAllShell()
        {
            return CurrentUser.OpenSubKey("Software").OpenSubKey("Classes").OpenSubKey("*").OpenSubKey("shell", true);
        }

        /// <summary>
        /// 生成右键菜单按钮（当前用户）
        /// </summary>
        /// <param name="keyName">右键菜单名</param>
        /// <param name="programPath">点击按钮后打开的程序路径</param>
        public static void CreateUserContextMenu(string keyName, string programPath)
        {
            RegistryKey key = GetRegistryUserSoftwareClassesAllShell();
            if (key.GetSubKeyNames().Contains(keyName))
            {
                key.DeleteSubKeyTree(keyName);
            }
            var contextMenuRegistryKey = key.CreateSubKey(keyName);
            contextMenuRegistryKey.SetValue("", keyName);
            var command = contextMenuRegistryKey.CreateSubKey("command");
            command.SetValue("", $"\"{programPath}\" \"%1\"");
        }

        /// <summary>
        /// 删除右键菜单按钮（当前用户）
        /// </summary>
        /// <param name="keyName">右键菜单名</param>
        public static void DeleteUserContextMenu(string keyName)
        {
            RegistryKey key = GetRegistryUserSoftwareClassesAllShell();
            if (key.GetSubKeyNames().Contains(keyName))
            {
                key.DeleteSubKeyTree(keyName);
            }
        }
    }
}
