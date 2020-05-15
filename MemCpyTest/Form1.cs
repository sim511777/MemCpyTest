using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MemCpyTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Type type = typeof(Util);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
            var listItems = methods.Select(method => Tuple.Create(method.Name, method)).ToArray();
            lbxMemcpyType.Items.AddRange(listItems);
            lbxMemcpyType.SelectedIndex = 0;
        }

        private static double GetTime() {
            return (double)Stopwatch.GetTimestamp() / Stopwatch.Frequency;
        }

        private static double GetTimeMs() {
            return GetTime() * 1000;
        }

        private void Log(string text) {
            DateTime now = DateTime.Now;
            string timeText = now.ToString("[HH:mm:ss.fff] ");
            text = timeText + text;
            lbxLog.Items.Add(text + Environment.NewLine);
        }

        private void btnClearLog_Click(object sender, EventArgs e) {
            lbxLog.Items.Clear();
        }

        IntPtr srcBuf = IntPtr.Zero;
        IntPtr dstBuf = IntPtr.Zero;
        long bytes = 0;
        private void btnAlloc_Click(object sender, EventArgs e) {
            var t0 = GetTimeMs();

            bytes = (long)numMegabyte.Value * 1024 * 1024;
            
            if (srcBuf != IntPtr.Zero)
                Marshal.FreeHGlobal(srcBuf);
            srcBuf = Marshal.AllocHGlobal((IntPtr)bytes);
            Util2.memset(srcBuf, 0, bytes);

            if (dstBuf != IntPtr.Zero)
                Marshal.FreeHGlobal(dstBuf);
            dstBuf = Marshal.AllocHGlobal((IntPtr)bytes);
            Util2.memset(dstBuf, 0, bytes);
            
            Log($"Alloc {numMegabyte.Value}MB Finished - {GetTimeMs()-t0:f3}ms");
        }

        private void lbxMemcpyType_MouseDoubleClick(object sender, MouseEventArgs e) {
            var t0 = GetTimeMs();

            var methodTuple = lbxMemcpyType.SelectedItem as Tuple<string, MethodInfo>;
            var method = methodTuple.Item2;
            method.Invoke(null, new object[] { dstBuf, srcBuf, bytes });
            Log($"{method.Name} {bytes / 1024 / 1024}MB Finished - {GetTimeMs()-t0:f3}ms");
        }
    }
}
