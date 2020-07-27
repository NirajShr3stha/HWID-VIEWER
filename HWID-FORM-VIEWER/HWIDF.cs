using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HWID_FORM_VIEWER
{
    public partial class HWIDF : Form
    {
        public HWIDF()
        {
            InitializeComponent();
        }
        private static string GetHWID()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography"; string name = "MachineGuid";

            using (RegistryKey localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null) throw new KeyNotFoundException(string.Format("Registry key not found: {0}", location));
                    object HWID = rk.GetValue(name);
                    if (HWID == null) throw new IndexOutOfRangeException(string.Format("Index not found: {0}", name));
                    return HWID.ToString();
                }
            }
        }
        private void danylf_hwidviewer_Click(object sender, EventArgs e)
        {
            HWID.Text = GetHWID();
        }
    }
}
