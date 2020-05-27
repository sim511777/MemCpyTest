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
        private double GB => (double)bytes / 1024 / 1024 / 1024;

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
            
            Log($"Alloc {GB:f3}GB Finished - {GetTimeMs()-t0:f3}ms");
        }

        private void lbxMemcpyType_MouseDoubleClick(object sender, MouseEventArgs e) {
            var t0 = GetTime();

            var methodTuple = lbxMemcpyType.SelectedItem as Tuple<string, MethodInfo>;
            var method = methodTuple.Item2;
            //method.Invoke(null, new object[] { dstBuf, srcBuf, bytes });
            var memcpyFunc = (Func<IntPtr, IntPtr, long, IntPtr>)method.CreateDelegate(typeof(Func<IntPtr, IntPtr, long, IntPtr>));
            memcpyFunc(dstBuf, srcBuf, bytes);

            var dt = GetTime() - t0;
            var ms = dt * 1000;
            var GBPS = GB / dt;
            Log($"memcpy {GB:f3}GB {method.Name,-20} : {ms:f3}ms - {GBPS:f1}GBPS");
        }

        private void btnMemetRandom_Click(object sender, EventArgs e) {
            Random rnd = new Random();
            int val = rnd.Next(0, 255);
            var t0 = GetTimeMs();
            Util2.memset(srcBuf, val, bytes);
            Log($"memset with ({val}) {GB:f3}GB  : {GetTimeMs()-t0:f3}ms");
        }
    }
}
