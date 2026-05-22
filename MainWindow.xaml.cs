using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using DDC.Mil1553.Emace;
using System.Collections.Generic;

using U32BIT = System.UInt32;
using U16BIT = System.UInt16;
using S16BIT = System.Int16;

namespace DPU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ─────────────────────────────────────────
        // BC Constants  –  32-bit (Gain + BW)
        // ─────────────────────────────────────────
        private const S16BIT BC_DBLK1 = 1;
        private const S16BIT BC_MSG1 = 2;
        private const S16BIT BC_OP1 = 3;
        private const S16BIT BC_OP2 = 4;
        private const S16BIT BC_MNR1 = 5;
        private const S16BIT BC_MJR = 6;

        // ─────────────────────────────────────────
        // BC Constants  –  8-bit (Power Limit)
        // ─────────────────────────────────────────
        private const S16BIT BC_DBLK2 = 11;
        private const S16BIT BC_MSG2 = 12;
        private const S16BIT BC_OP3 = 13;
        private const S16BIT BC_OP4 = 14;
        private const S16BIT BC_MNR2 = 15;
        private const S16BIT BC_MJR2 = 16;

        // ─────────────────────────────────────────
        // BC Constants  –  24-bit (Gain TC only)
        // ─────────────────────────────────────────
        private const S16BIT BC_DBLK3 = 21;
        private const S16BIT BC_MSG3 = 22;
        private const S16BIT BC_OP5 = 23;
        private const S16BIT BC_OP6 = 24;
        private const S16BIT BC_MNR3 = 25;
        private const S16BIT BC_MJR3 = 26;

        // ─────────────────────────────────────────
        // RT Constants  (for RT→BC tab)
        // ─────────────────────────────────────────
        private const S16BIT RT_DBLK1 = 101;
        private const S16BIT RT_MSG1 = 102;
        private const S16BIT RT_OP1 = 103;
        private const S16BIT RT_OP2 = 104;
        private const S16BIT RT_MNR1 = 105;
        private const S16BIT RT_MJR = 106;

        // ─────────────────────────────────────────
        // RT Simulator State
        // ─────────────────────────────────────────
        private S16BIT rtSimDeviceId = -1;
        private bool rtSimRunning = false;
        private U16BIT rtSimRTAddress = 0;
        private U16BIT rtSimSubAddress = 1;

        // ─────────────────────────────────────────
        // Builder State  –  32-bit (Gain + BW)
        // ─────────────────────────────────────────
        private int _currentGainValue = 0;
        private int _currentBwCode = 0;
        private int _currentWordCount32 = 2;

        // ─────────────────────────────────────────
        // Builder State  –  8-bit (Power Limit)
        // ─────────────────────────────────────────
        private int _currentPowerLimitDbm = 0;
        private int _currentWordCount8 = 1;

        // ─────────────────────────────────────────
        // Builder State  –  24-bit (Gain TC only)
        // ─────────────────────────────────────────
        private int _currentWordCountGainTc = 2;

        // ─────────────────────────────────────────
        // Gain Lookup Table  (dBm → TC value)
        // ─────────────────────────────────────────
        private static readonly Dictionary<int, long> GainTcTable =
            new Dictionary<int, long>
        {
            { -45,      369 }, { -44,      414 }, { -43,      464 },
            { -42,      521 }, { -41,      584 }, { -40,      655 },
            { -39,      735 }, { -38,      825 }, { -37,      926 },
            { -36,     1039 }, { -35,     1165 }, { -34,     1308 },
            { -33,     1467 }, { -32,     1646 }, { -31,     1847 },
            { -30,     2072 }, { -29,     2325 }, { -28,     2609 },
            { -27,     2927 }, { -26,     3285 }, { -25,     3685 },
            { -24,     4135 }, { -23,     4640 }, { -22,     5206 },
            { -21,     5841 }, { -20,     6554 }, { -19,     7353 },
            { -18,     8250 }, { -17,     9257 }, { -16,    10387 },
            { -15,    11654 }, { -14,    13076 }, { -13,    14672 },
            { -12,    16462 }, { -11,    18471 }, { -10,    20724 },
            {  -9,    23253 }, {  -8,    26090 }, {  -7,    29274 },
            {  -6,    32846 }, {  -5,    36854 }, {  -4,    41350 },
            {  -3,    46396 }, {  -2,    52057 }, {  -1,    58409 },
            {   0,    65536 }, {   1,    73533 }, {   2,    82505 },
            {   3,    92572 }, {   4,   103868 }, {   5,   116541 },
            {   6,   130762 }, {   7,   146717 }, {   8,   164619 },
            {   9,   184706 }, {  10,   207243 }, {  11,   232531 },
            {  12,   260904 }, {  13,   292739 }, {  14,   328458 },
            {  15,   368536 }, {  16,   413504 }, {  17,   463959 },
            {  18,   520571 }, {  19,   584090 }, {  20,   655360 },
            {  21,   735326 }, {  22,   825049 }, {  23,   925721 },
            {  24,  1038676 }, {  25,  1165413 }, {  26,  1307615 },
            {  27,  1467168 }, {  28,  1646190 }, {  29,  1847055 },
            {  30,  2072430 }, {  31,  2325305 }, {  32,  2609035 },
            {  33,  2927386 }, {  34,  3284581 }, {  35,  3685360 },
            {  36,  4135042 }, {  37,    4639593},
            {  38,	5205710},
            {  39,	5840902},
            {  40,	6553600},
            {  41,	7353260},
            {  42,	8250494},
            {  43,	9257206},
            {  44,	10386756},
            {  45,	11654132}
        };

        // ─────────────────────────────────────────
        // Extended TC Table  (37..45 for -55 mode)
        // ─────────────────────────────────────────
        private static readonly Dictionary<int, long> GainTcTableExtended =
            new Dictionary<int, long>
        {
            {  37,   4639593 }, {  38,   5205710 }, {  39,   5840902 },
            {  40,   6553600 }, {  41,   7353260 }, {  42,   8250494 },
            {  43,   9257206 }, {  44,  10386756 }, {  45,  11654132 }
        };

        // ─────────────────────────────────────────
        // Power Limit Lookup Table (dBm → value)
        // ─────────────────────────────────────────
        private static readonly Dictionary<int, int> PowerLimitTable =
            new Dictionary<int, int>
        {
            {   0,  1 }, {  -1,  2 }, {  -2,  3 }, {  -3,  4 },
            {  -4,  5 }, {  -5,  6 }, {  -6,  7 }, {  -7,  8 },
            {  -8,  9 }, {  -9, 10 }, { -10, 11 }, { -11, 12 },
            { -12, 13 }, { -13, 14 }, { -14, 15 }, { -15, 16 },
            { -16, 17 }, { -17, 18 }, { -18, 19 }, { -19, 20 },
            { -20, 21 }, { -21, 22 }, { -22, 23 }, { -23, 24 },
            { -24, 25 }, { -25, 26 }, { -26, 27 }, { -27, 28 },
            { -28, 29 }, { -29, 30 }, { -30, 31 }, { -31, 32 },
            { -32, 33 }, { -33, 34 }, { -34, 35 }, { -35, 36 },
            { -36, 37 }, { -37, 38 }, { -38, 39 }, { -39, 40 },
            { -40, 41 }, { -41, 42 }, { -42, 43 }, { -43, 44 },
            { -44, 45 }, { -45, 46 }
        };

        // ─────────────────────────────────────────
        // Bandwidth Tables
        // ─────────────────────────────────────────
        private readonly int[] _bwCodes = new int[]
        {
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08
        };

        private readonly string[] _bwKhzLabels = new string[]
        {
            "0 KHz","50 KHz","100 KHz","150 KHz",
            "200 KHz","250 KHz","300 KHz","350 KHz","400 KHz"
        };

        // ─────────────────────────────────────────
        // 24-bit Sequential State
        // ─────────────────────────────────────────
        private struct GainTcStep
        {
            public int DbmValue;
            public long TcValue;
            public ushort Word1;
            public ushort Word2;
        }

        private List<GainTcStep> _gainTcSequence = new List<GainTcStep>();
        private bool _gainTcSendRunning = false;
        private bool _gainTcSendStop = false;
        private string _currentGainTcMode = "-55";

        // ═════════════════════════════════════════════════════
        // Constructor
        // ═════════════════════════════════════════════════════
        public MainWindow()
        {
            InitializeComponent();
            ApplyValidation();
            InitializeBCWordBuilder();
            UpdateStatus("Ready - Select a tab and configure parameters.");
        }

        // ═════════════════════════════════════════════════════
        //  INPUT VALIDATION
        // ═════════════════════════════════════════════════════
        private void ApplyValidation()
        {
            bc_deviceIdNumber.PreviewTextInput += ValidateNumericInput;
            DataObject.AddPastingHandler(bc_deviceIdNumber, PastingNumericInput);

            rt_deviceIdTextBox.PreviewTextInput += ValidateNumericInput;
            DataObject.AddPastingHandler(rt_deviceIdTextBox, PastingNumericInput);

            bc_txMessageTextBox.PreviewTextInput += ValidateHexInput;
            DataObject.AddPastingHandler(bc_txMessageTextBox, PastingHexInput);

            bc_pwrTxMessageTextBox.PreviewTextInput += ValidateHexInput;
            DataObject.AddPastingHandler(bc_pwrTxMessageTextBox, PastingHexInput);

            bc_gainTcTxMessageTextBox.PreviewTextInput += ValidateHexInput;
            DataObject.AddPastingHandler(bc_gainTcTxMessageTextBox, PastingHexInput);

            rtsim_deviceIdTextBox.PreviewTextInput += ValidateNumericInput;
            DataObject.AddPastingHandler(rtsim_deviceIdTextBox, PastingNumericInput);

            rtsim_responseDataTextBox.PreviewTextInput += ValidateHexInput;
            DataObject.AddPastingHandler(rtsim_responseDataTextBox, PastingHexInput);
        }

        private void ValidateNumericInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
                if (!char.IsDigit(c)) { e.Handled = true; return; }
        }

        private void PastingNumericInput(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                foreach (char c in text)
                    if (!char.IsDigit(c)) { e.CancelCommand(); return; }
            }
            else e.CancelCommand();
        }

        private void ValidateHexInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
                if (!IsHexChar(c)) { e.Handled = true; return; }
        }

        private void PastingHexInput(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                foreach (char c in text)
                    if (!IsHexChar(c)) { e.CancelCommand(); return; }
            }
            else e.CancelCommand();
        }

        private static bool IsHexChar(char c)
        {
            return (c >= '0' && c <= '9') ||
                   (c >= 'A' && c <= 'F') ||
                   (c >= 'a' && c <= 'f') ||
                    c == ' ' || c == '\n' || c == '\r';
        }

        // ═════════════════════════════════════════════════════
        //  COMBOBOX HELPER
        // ═════════════════════════════════════════════════════
        private string GetComboBoxSelectedText(ComboBox comboBox)
        {
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
            if (selectedItem != null && selectedItem.Content != null)
                return selectedItem.Content.ToString();
            if (comboBox.SelectedItem != null)
                return comboBox.SelectedItem.ToString();
            if (comboBox.SelectedValue != null)
                return comboBox.SelectedValue.ToString();
            return string.Empty;
        }

        // ═════════════════════════════════════════════════════
        //  SHARED UI HELPERS
        // ═════════════════════════════════════════════════════
        private void UpdateLedColor(Brush color, string mode)
        {
            ledEllipse.Fill = color;
            if (color == Brushes.Green)
            {
                ledStatusText.Text = "Connected";
                ledStatusText.Foreground = Brushes.Green;
                modeBadge.Background = new SolidColorBrush(Color.FromRgb(0, 130, 0));
                modeText.Text = mode;
            }
            else if (color == Brushes.Red)
            {
                ledStatusText.Text = "Not Connected";
                ledStatusText.Foreground = Brushes.Red;
                modeBadge.Background = Brushes.DarkRed;
                modeText.Text = "ERROR";
            }
            else
            {
                ledStatusText.Text = "Idle";
                ledStatusText.Foreground = Brushes.Gray;
                modeBadge.Background = Brushes.Gray;
                modeText.Text = "IDLE";
            }
        }

        private void UpdateStatus(string message) { statusBarText.Text = message; }

        public void LogCommand(string message)
        {
            string entry = string.Format("[{0:HH:mm:ss}] {1}", DateTime.Now, message);
            logListBox.Items.Add(entry);
            logListBox.ScrollIntoView(logListBox.Items[logListBox.Items.Count - 1]);
        }

        private void ClearLog_Click(object sender, RoutedEventArgs e)
        {
            logListBox.Items.Clear();
            UpdateStatus("Log cleared.");
        }

        private void SaveLog_Click(object sender, RoutedEventArgs e)
        {
            if (logListBox.Items.Count == 0)
            {
                MessageBox.Show("Command Log is empty.\nNothing to save.",
                    "Save Log", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Title = "Save Command Log",
                    Filter = "Text File (*.txt)|*.txt|Log File (*.log)|*.log|CSV File (*.csv)|*.csv|All Files (*.*)|*.*",
                    FilterIndex = 1,
                    DefaultExt = "txt",
                    FileName = string.Format("1553_Log_{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now)
                };
                bool? dialogResult = saveDialog.ShowDialog();
                if (dialogResult == true)
                {
                    string filePath = saveDialog.FileName;
                    string extension = Path.GetExtension(filePath).ToLower();
                    if (extension == ".csv") SaveLogAsCsv(filePath);
                    else SaveLogAsText(filePath);
                    UpdateStatus(string.Format("Log saved to: {0}", filePath));
                    MessageBox.Show(
                        string.Format("Log saved!\n\nFile : {0}\nLines: {1}",
                                      filePath, logListBox.Items.Count),
                        "Save Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogCommand(string.Format("Log saved to file: {0}", filePath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed to save log.\n\nError: {0}", ex.Message),
                    "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateStatus("Error: Failed to save log.");
            }
        }

        private void SaveLogAsText(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==============================================");
            sb.AppendLine("  MIL-STD-1553 Bus Controller Test System   ");
            sb.AppendLine("  Command Log                                ");
            sb.AppendLine(string.Format("  Saved : {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
            sb.AppendLine("==============================================");
            sb.AppendLine();
            foreach (object item in logListBox.Items)
                sb.AppendLine(item.ToString());
            sb.AppendLine();
            sb.AppendLine("==============================================");
            sb.AppendLine(string.Format("  Total Entries : {0}", logListBox.Items.Count));
            sb.AppendLine("==============================================");
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private void SaveLogAsCsv(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Index,Timestamp,Message");
            int index = 1;
            foreach (object item in logListBox.Items)
            {
                string line = item.ToString();
                string timestamp = string.Empty;
                string message = line;
                if (line.Length > 10 && line.StartsWith("[") && line[9] == ']')
                {
                    timestamp = line.Substring(1, 8);
                    message = line.Length > 11 ? line.Substring(11) : string.Empty;
                }
                message = message.Replace("\"", "\"\"");
                sb.AppendLine(string.Format("{0},{1},\"{2}\"", index, timestamp, message));
                index++;
            }
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (rtSimRunning && rtSimDeviceId >= 0)
            {
                try
                {
                    EmaceBU69092.aceRTMTStop(rtSimDeviceId);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    LogCommand("RT Simulator: Stopped on window close.");
                }
                catch { }
            }
            base.OnClosing(e);
        }

        // ═════════════════════════════════════════════════════
        //  INITIALISE ALL THREE BUILDERS
        // ═════════════════════════════════════════════════════
        private void InitializeBCWordBuilder()
        {
            // ── BUILDER 1: Gain ComboBox – show only dBm value ──
            bc_gainComboBox.Items.Clear();
            foreach (KeyValuePair<int, long> kvp in GainTcTable)
            {
                bc_gainComboBox.Items.Add(new ComboBoxItem
                {
                    Content = string.Format("{0} dBm", kvp.Key),
                    Tag = kvp.Key
                });
            }
            // Add extended range (37..45) for -55 mode
            foreach (KeyValuePair<int, long> kvp in GainTcTableExtended)
            {
                bc_gainComboBox.Items.Add(new ComboBoxItem
                {
                    Content = string.Format("{0} dBm", kvp.Key),
                    Tag = kvp.Key
                });
            }
            SelectGainComboByDbm(bc_gainComboBox, 0);

            // ── BUILDER 1: Bandwidth ComboBox – show only KHz ──
            bc_bandwidthComboBox.Items.Clear();
            for (int i = 0; i < _bwKhzLabels.Length; i++)
            {
                bc_bandwidthComboBox.Items.Add(new ComboBoxItem
                {
                    Content = _bwKhzLabels[i],
                    Tag = _bwCodes[i]
                });
            }
            bc_bandwidthComboBox.SelectedIndex = 0;
            bc_wordCountComboBox.SelectedIndex = 0;

            // ── BUILDER 2: Power Limit ComboBox – show only dBm number ──
            bc_powerLimitComboBox.Items.Clear();
            foreach (KeyValuePair<int, int> kvp in PowerLimitTable)
            {
                bc_powerLimitComboBox.Items.Add(new ComboBoxItem
                {
                    Content = string.Format("{0} dBm", kvp.Key),
                    Tag = kvp.Key
                });
            }
            bc_powerLimitComboBox.SelectedIndex = 0;
            bc_pwrWordCountComboBox.SelectedIndex = 0;

            // ── BUILDER 3 ──
            bc_gainTcWordCountComboBox.SelectedIndex = 0;

            // Initial previews (hidden labels still need values)
            Update32BitPreview();
            Update8BitPreview();
        }

        private void SelectGainComboByDbm(ComboBox combo, int dbm)
        {
            foreach (ComboBoxItem item in combo.Items)
            {
                if (item.Tag is int && (int)item.Tag == dbm)
                {
                    combo.SelectedItem = item;
                    return;
                }
            }
            if (combo.Items.Count > 0) combo.SelectedIndex = 0;
        }

        // ═════════════════════════════════════════════════════
        //  BUILDER 1 – 32-BIT  (internal helpers, hidden labels)
        // ═════════════════════════════════════════════════════
        private uint Build32BitWord(int gainDbm, int bwCode)
        {
            long gainTc;
            if (!GainTcTable.TryGetValue(gainDbm, out gainTc)) gainTc = 0;
            uint gainBits24 = (uint)(gainTc & 0x00FFFFFF);
            uint bwBits8 = (uint)(bwCode & 0xFF);
            return (gainBits24 << 8) | bwBits8;
        }

        private void Update32BitPreview()
        {
            uint word32 = Build32BitWord(_currentGainValue, _currentBwCode);
            uint gainBits24 = (word32 >> 8) & 0x00FFFFFF;
            uint bwBits8 = word32 & 0xFF;
            ushort w1 = (ushort)((word32 >> 16) & 0xFFFF);
            ushort w2 = (ushort)(word32 & 0xFFFF);

            // Hidden labels – still update so code-behind stays consistent
            bc_gainBitsLabel.Text = Convert.ToString((int)gainBits24, 2).PadLeft(24, '0');
            bc_bwBitsLabel.Text = Convert.ToString((int)bwBits8, 2).PadLeft(8, '0');
            bc_32bitHexPreview.Text = string.Format("0x{0:X8}", word32);
            bc_word1HexLabel.Text = string.Format("0x{0:X4}", w1);
            bc_word2HexLabel.Text = string.Format("0x{0:X4}", w2);

            long tc;
            GainTcTable.TryGetValue(_currentGainValue, out tc);
            bc_gainHexLabel.Text = string.Format("TC = {0}   (0x{1:X6})", tc, gainBits24);
            bc_bwHexLabel.Text = string.Format("= 0x{0:X2}", bwBits8);
        }

        // ── ComboBox changed handlers ──
        private void bc_gainComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem sel = bc_gainComboBox.SelectedItem as ComboBoxItem;
            if (sel != null && sel.Tag is int)
            {
                _currentGainValue = (int)sel.Tag;
                Update32BitPreview();
                // Auto-build TX message when selection changes
                AutoBuild32BitTxMessage();
            }
        }

        private void bc_bandwidthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem sel = bc_bandwidthComboBox.SelectedItem as ComboBoxItem;
            if (sel != null && sel.Tag is int)
            {
                _currentBwCode = (int)sel.Tag;
                Update32BitPreview();
                // Auto-build TX message when selection changes
                AutoBuild32BitTxMessage();
            }
        }

        private void bc_wordCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem sel = bc_wordCountComboBox.SelectedItem as ComboBoxItem;
            if (sel != null)
            {
                int.TryParse(sel.Content.ToString(), out _currentWordCount32);
                AutoBuild32BitTxMessage();
            }
        }

        // ── Auto-build TX message (no popup, no button needed) ──
        private void AutoBuild32BitTxMessage()
        {
            // Guard against calls before UI is fully initialized
            if (bc_txMessageTextBox == null || bc_tbGainValue == null ||
                bc_tbBandwidth == null || bc_tbWord32 == null || bc_tbSubAddr == null)
                return;

            uint word32 = Build32BitWord(_currentGainValue, _currentBwCode);
            ushort w1 = (ushort)((word32 >> 16) & 0xFFFF);
            ushort w2 = (ushort)(word32 & 0xFFFF);

            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0:X4} {1:X4}", w1, w2));
            for (int i = 2; i < _currentWordCount32; i++) sb.Append(" 0000");
            bc_txMessageTextBox.Text = sb.ToString();

            long gainTc;
            GainTcTable.TryGetValue(_currentGainValue, out gainTc);
            if (gainTc == 0) GainTcTableExtended.TryGetValue(_currentGainValue, out gainTc);

            string bwLabel = _currentBwCode < _bwKhzLabels.Length
                ? _bwKhzLabels[_currentBwCode] : "?";

            bc_tbGainValue.Text = string.Format("{0} dBm  |  TC = {1}  (0x{2:X6})",
                                        _currentGainValue, gainTc,
                                        (word32 >> 8) & 0x00FFFFFF);
            bc_tbBandwidth.Text = bwLabel;
            bc_tbWord32.Text = string.Format("0x{0:X8}  →  [{1:X4}] [{2:X4}]", word32, w1, w2);
            bc_tbSubAddr.Text = GetComboBoxSelectedText(bc_subAddressComboBox);
        }

        private void AutoBuild8BitTxMessage()
        {
            // Guard against calls before UI is fully initialized
            if (bc_pwrTxMessageTextBox == null || bc_tbPowerLimitValue == null ||
                bc_tbPowerWord == null || bc_tbPwrSubAddr == null)
                return;

            byte pwrByte = Build8BitPowerLimitByte(_currentPowerLimitDbm);
            ushort pwrWord = (ushort)(pwrByte & 0xFF);

            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0:X4}", pwrWord));
            for (int i = 1; i < _currentWordCount8; i++) sb.Append(" 0000");
            bc_pwrTxMessageTextBox.Text = sb.ToString();

            int regVal;
            PowerLimitTable.TryGetValue(_currentPowerLimitDbm, out regVal);

            bc_tbPowerLimitValue.Text = string.Format("{0} dBm  |  register = {1}  (0x{2:X2})",
                                            _currentPowerLimitDbm, regVal, pwrByte);
            bc_tbPowerWord.Text = string.Format("0x{0:X4}  (padded 16-bit)", pwrWord);
            bc_tbPwrSubAddr.Text = GetComboBoxSelectedText(bc_pwrSubAddressComboBox);
        }
        // ── Keep old handler name so XAML Click still works if present ──
        private void BC_Build32BitWord_Click(object sender, RoutedEventArgs e)
        {
            AutoBuild32BitTxMessage();
            long gainTc;
            GainTcTable.TryGetValue(_currentGainValue, out gainTc);
            if (gainTc == 0) GainTcTableExtended.TryGetValue(_currentGainValue, out gainTc);

            uint word32 = Build32BitWord(_currentGainValue, _currentBwCode);
            ushort w1 = (ushort)((word32 >> 16) & 0xFFFF);
            ushort w2 = (ushort)(word32 & 0xFFFF);
            string bwLabel = _currentBwCode < _bwKhzLabels.Length
                ? _bwKhzLabels[_currentBwCode] : "?";

            LogCommand(string.Format(
                "32-bit: Gain={0}dBm TC={1} | BW={2} | 0x{3:X8} | W1=0x{4:X4} W2=0x{5:X4}",
                _currentGainValue, gainTc, bwLabel, word32, w1, w2));
            UpdateStatus(string.Format("32-bit built: 0x{0:X8}", word32));
        }

        // ═════════════════════════════════════════════════════
        //  BUILDER 2 – 8-BIT (Power Limit)
        // ═════════════════════════════════════════════════════
        private byte Build8BitPowerLimitByte(int powerLimitDbm)
        {
            int regVal;
            if (!PowerLimitTable.TryGetValue(powerLimitDbm, out regVal)) regVal = 1;
            return (byte)(regVal & 0xFF);
        }

        private void Update8BitPreview()
        {
            byte pwrByte = Build8BitPowerLimitByte(_currentPowerLimitDbm);
            ushort pwrWord = (ushort)(pwrByte & 0xFF);
            int regVal;
            PowerLimitTable.TryGetValue(_currentPowerLimitDbm, out regVal);

            // Hidden labels
            bc_pwrBitsLabel.Text = Convert.ToString(pwrByte, 2).PadLeft(8, '0');
            bc_pwrWordHexLabel.Text = string.Format("0x{0:X4}", pwrWord);
            bc_pwrByteHexLabel.Text = string.Format("= 0x{0:X2}  (dec {1})", pwrByte, regVal);
        }

        private void bc_powerLimitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem sel = bc_powerLimitComboBox.SelectedItem as ComboBoxItem;
            if (sel != null && sel.Tag is int)
            {
                _currentPowerLimitDbm = (int)sel.Tag;
                Update8BitPreview();
                AutoBuild8BitTxMessage();
            }
        }

        private void bc_pwrWordCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem sel = bc_pwrWordCountComboBox.SelectedItem as ComboBoxItem;
            if (sel != null)
            {
                int.TryParse(sel.Content.ToString(), out _currentWordCount8);
                AutoBuild8BitTxMessage();
            }
        }

        // ── Auto-build 8-bit TX message ──
        //private void AutoBuild8BitTxMessage()
        //{
        //    byte pwrByte = Build8BitPowerLimitByte(_currentPowerLimitDbm);
        //    ushort pwrWord = (ushort)(pwrByte & 0xFF);

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(string.Format("{0:X4}", pwrWord));
        //    for (int i = 1; i < _currentWordCount8; i++) sb.Append(" 0000");
        //    bc_pwrTxMessageTextBox.Text = sb.ToString();

        //    int regVal;
        //    PowerLimitTable.TryGetValue(_currentPowerLimitDbm, out regVal);

        //    bc_tbPowerLimitValue.Text = string.Format("{0} dBm  |  register = {1}  (0x{2:X2})",
        //                                    _currentPowerLimitDbm, regVal, pwrByte);
        //    bc_tbPowerWord.Text = string.Format("0x{0:X4}  (padded 16-bit)", pwrWord);
        //    bc_tbPwrSubAddr.Text = GetComboBoxSelectedText(bc_pwrSubAddressComboBox);
        //}

        // ── Keep old handler name ──
        private void BC_Build8BitPowerWord_Click(object sender, RoutedEventArgs e)
        {
            AutoBuild8BitTxMessage();
            byte pwrByte = Build8BitPowerLimitByte(_currentPowerLimitDbm);
            ushort pwrWord = (ushort)(pwrByte & 0xFF);
            int regVal;
            PowerLimitTable.TryGetValue(_currentPowerLimitDbm, out regVal);

            LogCommand(string.Format(
                "8-bit Power: {0}dBm | Reg={1} | Byte=0x{2:X2} | Word=0x{3:X4}",
                _currentPowerLimitDbm, regVal, pwrByte, pwrWord));
            UpdateStatus(string.Format("8-bit Power Limit built: 0x{0:X2}", pwrByte));
        }

        // ═════════════════════════════════════════════════════
        //  BUILDER 3 – 24-BIT Gain TC Sequential
        // ═════════════════════════════════════════════════════
        private long GetTcForDbm(int dbm)
        {
            long tc;
            if (GainTcTable.TryGetValue(dbm, out tc)) return tc;
            if (GainTcTableExtended.TryGetValue(dbm, out tc)) return tc;
            return 0;
        }

        private GainTcStep MakeGainTcStep(int dbm)
        {
            long tc = GetTcForDbm(dbm);
            uint tc24 = (uint)(tc & 0x00FFFFFF);
            ushort w1 = (ushort)((tc24 >> 16) & 0x00FF);
            ushort w2 = (ushort)(tc24 & 0xFFFF);
            return new GainTcStep
            {
                DbmValue = dbm,
                TcValue = tc,
                Word1 = w1,
                Word2 = w2
            };
        }

        private void bc_gainTcModeComboBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem sel = bc_gainTcModeComboBox.SelectedItem as ComboBoxItem;
            if (sel != null && sel.Tag != null)
                _currentGainTcMode = sel.Tag.ToString();
        }

        private void bc_gainTcWordCountComboBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem sel = bc_gainTcWordCountComboBox.SelectedItem as ComboBoxItem;
            if (sel != null)
                int.TryParse(sel.Content.ToString(), out _currentWordCountGainTc);
        }

        // ── STOP ──
        private void BC_StopGainTcSequential_Click(object sender, RoutedEventArgs e)
        {
            _gainTcSendStop = true;
            LogCommand("24-bit GainTC: Stop requested by user.");
            UpdateStatus("24-bit GainTC: Stopping after current step...");
        }

        // ── SEND SEQUENTIAL (auto-builds sequence from mode, no Load button needed) ──
        private void BC_SendGainTcSequential_Click(object sender, RoutedEventArgs e)
        {
            // ── Auto-build sequence from selected mode ──
            ComboBoxItem modeSel = bc_gainTcModeComboBox.SelectedItem as ComboBoxItem;
            if (modeSel == null || modeSel.Tag == null)
            {
                MessageBox.Show("Please select a Gain Mode first.",
                    "No Mode Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_gainTcSendRunning)
            {
                MessageBox.Show("Sequential send is already running.",
                    "Already Running", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _currentGainTcMode = modeSel.Tag.ToString();
            _gainTcSequence.Clear();

            List<int> dbmRange = new List<int>();
            switch (_currentGainTcMode)
            {
                case "-55":
                    for (int d = 0; d <= 45; d++) dbmRange.Add(d);
                    break;
                case "-26":
                    for (int d = -22; d <= 22; d++) dbmRange.Add(d);
                    break;
                case "-10":
                    for (int d = -45; d <= 0; d++) dbmRange.Add(d);
                    break;
                default:
                    MessageBox.Show("Unknown mode selected.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            foreach (int dbm in dbmRange)
                _gainTcSequence.Add(MakeGainTcStep(dbm));

            // Validate inputs
            short devNumShort;
            if (!short.TryParse(bc_deviceIdNumber.Text.Trim(), out devNumShort))
            {
                MessageBox.Show("Invalid Device ID.", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string rtText = GetComboBoxSelectedText(bc_rtAddressComboBox);
            byte rtAddrByte;
            if (!byte.TryParse(rtText, out rtAddrByte))
            {
                MessageBox.Show("Invalid RT Address.", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string subText = GetComboBoxSelectedText(bc_gainTcSubAddressComboBox);
            byte subAddrByte;
            if (!byte.TryParse(subText, out subAddrByte))
            {
                MessageBox.Show("Invalid Sub Address.", "Input Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int delayMs = 500;
            ComboBoxItem delaySel = bc_gainTcDelayComboBox.SelectedItem as ComboBoxItem;
            if (delaySel != null)
                int.TryParse(delaySel.Content.ToString(), out delayMs);

            S16BIT capturedDevNum = (S16BIT)devNumShort;
            U16BIT capturedRtAddr = (U16BIT)rtAddrByte;
            U16BIT capturedSubAddr = (U16BIT)subAddrByte;
            string capturedBus = GetComboBoxSelectedText(bc_busSelectionComboBox);
            int capturedWordCount = _currentWordCountGainTc;
            int capturedDelay = delayMs;
            string capturedMode = _currentGainTcMode;
            List<GainTcStep> capturedSeq = new List<GainTcStep>(_gainTcSequence);

            // Update UI
            _gainTcSendRunning = true;
            _gainTcSendStop = false;
            bc_gainTcSendButton.IsEnabled = false;
            bc_gainTcStopButton.IsEnabled = true;
            bc_gainTcProgressBar.Value = 0;
            bc_gainTcProgressBar.Maximum = capturedSeq.Count;
            bc_gainTcCurrentStepLabel.Text = "0";
            bc_gainTcTotalStepsLabel.Text = capturedSeq.Count.ToString();
            bc_gainTcResponseTextBox.Clear();

            bc_tbGainTcMode.Text = string.Format("Mode {0}  →  {1} steps",
                                            capturedMode, capturedSeq.Count);
            bc_tbGainTcTotalSteps.Text = capturedSeq.Count.ToString();
            bc_tbGainTcSentSteps.Text = "0";
            bc_tbGainTcSubAddr.Text = GetComboBoxSelectedText(bc_gainTcSubAddressComboBox);

            LogCommand(string.Format(
                "24-bit GainTC: START | Mode={0} | Steps={1} | DevID={2} | RT={3} | SA={4} | Delay={5}ms",
                capturedMode, capturedSeq.Count, capturedDevNum,
                capturedRtAddr, capturedSubAddr, capturedDelay));

            UpdateStatus(string.Format(
                "24-bit GainTC: Sending {0} steps...", capturedSeq.Count));

            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                int sentCount = 0;
                int errorCount = 0;

                for (int stepIdx = 0; stepIdx < capturedSeq.Count; stepIdx++)
                {
                    if (_gainTcSendStop) break;

                    GainTcStep step = capturedSeq[stepIdx];
                    int localStep = stepIdx + 1;

                    Dispatcher.Invoke(new Action(() =>
                    {
                        bc_gainTcCurrentStepLabel.Text = localStep.ToString();
                        bc_gainTcProgressBar.Value = localStep;
                        bc_gainTcTxMessageTextBox.Text =
                            string.Format("{0:X4} {1:X4}", step.Word1, step.Word2);

                        // Also update hidden listbox selection if it exists
                        if (bc_gainTcSequenceListBox.Items.Count > stepIdx)
                        {
                            bc_gainTcSequenceListBox.SelectedIndex = stepIdx;
                            bc_gainTcSequenceListBox.ScrollIntoView(
                                bc_gainTcSequenceListBox.SelectedItem);
                        }

                        UpdateStatus(string.Format(
                            "GainTC: Step {0}/{1}  |  {2}dBm  TC={3}",
                            localStep, capturedSeq.Count,
                            step.DbmValue, step.TcValue));
                    }));

                    string sendResult = SendSingleGainTcStep(
                        step, capturedDevNum, capturedRtAddr,
                        capturedSubAddr, capturedBus,
                        capturedWordCount, localStep);

                    bool success = sendResult == "OK";
                    if (success) sentCount++;
                    else errorCount++;

                    string logLine = string.Format(
                        "Step {0:D3}/{1}  |  {2} dBm  TC={3}  W1=0x{4:X4} W2=0x{5:X4}  →  {6}",
                        localStep, capturedSeq.Count,
                        step.DbmValue, step.TcValue,
                        step.Word1, step.Word2,
                        success ? "✔ OK" : ("✘ " + sendResult));

                    Dispatcher.Invoke(new Action(() =>
                    {
                        bc_gainTcResponseTextBox.AppendText(logLine + "\n");
                        bc_gainTcResponseTextBox.ScrollToEnd();
                        bc_tbGainTcLastDbm.Text = string.Format("{0} dBm", step.DbmValue);
                        bc_tbGainTcValue.Text = string.Format(
                            "TC = {0}  (0x{1:X6})", step.TcValue,
                            (uint)(step.TcValue & 0xFFFFFF));
                        bc_tbGainTcSentSteps.Text = sentCount.ToString();
                        LogCommand(string.Format("24-bit GainTC: {0}", logLine));
                    }));

                    if (!_gainTcSendStop && stepIdx < capturedSeq.Count - 1)
                        Thread.Sleep(capturedDelay);
                }

                int finalSent = sentCount;
                int finalErrors = errorCount;
                bool stopped = _gainTcSendStop;

                Dispatcher.Invoke(new Action(() =>
                {
                    _gainTcSendRunning = false;
                    _gainTcSendStop = false;
                    bc_gainTcSendButton.IsEnabled = true;
                    bc_gainTcStopButton.IsEnabled = false;

                    bc_gainTcProgressBar.Foreground =
                        stopped ? Brushes.Orange :
                        finalErrors == 0
                            ? new SolidColorBrush(Color.FromRgb(0x99, 0x44, 0xFF))
                            : Brushes.OrangeRed;

                    UpdateStatus(string.Format(
                        "GainTC: {0} | Mode={1} Sent={2} Errors={3}",
                        stopped ? "STOPPED" : "COMPLETE",
                        capturedMode, finalSent, finalErrors));

                    string summary = string.Format(
                        "\n═══════════════════════════════\n" +
                        " {0}\n Mode={1}  Sent={2}  Errors={3}\n" +
                        "═══════════════════════════════",
                        stopped ? "STOPPED" : "COMPLETE",
                        capturedMode, finalSent, finalErrors);
                    bc_gainTcResponseTextBox.AppendText(summary);
                    bc_gainTcResponseTextBox.ScrollToEnd();

                    LogCommand(string.Format(
                        "24-bit GainTC: {0} | Mode={1} Sent={2} Errors={3}",
                        stopped ? "STOPPED" : "COMPLETE",
                        capturedMode, finalSent, finalErrors));

                    MessageBox.Show(
                        string.Format(
                            "Sequential Send {0}!\n\n" +
                            "Mode       : {1}\n" +
                            "Total Steps: {2}\n" +
                            "Sent OK    : {3}\n" +
                            "Errors     : {4}",
                            stopped ? "STOPPED" : "Complete",
                            capturedMode, capturedSeq.Count,
                            finalSent, finalErrors),
                        stopped ? "Stopped" : "Complete",
                        MessageBoxButton.OK,
                        stopped ? MessageBoxImage.Warning : MessageBoxImage.Information);
                }));
            });

            thread.IsBackground = true;
            thread.Start();
        }

        // ── Keep old Load button handler (does nothing now, send auto-loads) ──
        private void BC_LoadGainTcSequence_Click(object sender, RoutedEventArgs e)
        {
            // Auto-load happens in BC_SendGainTcSequential_Click
            // This stub prevents XAML binding errors if button still exists
            MessageBox.Show(
                "Click 'Send Sequential' directly.\nThe sequence loads automatically from the selected mode.",
                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // ─────────────────────────────────────────────────────────
        //  SEND SINGLE STEP
        // ─────────────────────────────────────────────────────────
        private string SendSingleGainTcStep(
            GainTcStep step,
            S16BIT devNum,
            U16BIT rtAddr,
            U16BIT subAddr,
            string busStr,
            int wordCount,
            int stepNumber)
        {
            bool started = false;

            S16BIT dblkId = BC_DBLK3;
            S16BIT msgId = BC_MSG3;
            S16BIT op1Id = BC_OP5;
            S16BIT op2Id = BC_OP6;
            S16BIT mnrId = BC_MNR3;
            S16BIT mjrId = BC_MJR3;

            try
            {
                BcMsgOption busOption = (busStr == "B")
                    ? BcMsgOption.ACE_BCCTRL_CHL_B
                    : BcMsgOption.ACE_BCCTRL_CHL_A;

                U16BIT[] msgWords = new U16BIT[wordCount];
                msgWords[0] = step.Word1;
                if (wordCount > 1) msgWords[1] = step.Word2;
                for (int i = 2; i < wordCount; i++) msgWords[i] = 0x0000;

                AceError result = EmaceBU69092.aceInitialize(
                    devNum, ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC, 0, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("Init failed: {0}", result);

                result = EmaceBU69092.aceBCDataBlkCreate(
                    devNum, dblkId, BcDataBlkSize.ACE_BC_DBLK_SINGLE,
                    msgWords, (U16BIT)wordCount);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("DataBlk failed: {0}", result);

                result = EmaceBU69092.aceBCMsgCreateBCtoRT(
                    devNum, msgId, dblkId,
                    rtAddr, subAddr, (U16BIT)wordCount, 0, busOption);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("Msg failed: {0}", result);

                result = EmaceBU69092.aceBCOpCodeCreate(
                    devNum, op1Id, BcOpcode.ACE_OPCODE_XEQ,
                    BcConditionTest.ACE_CNDTST_ALWAYS, (U16BIT)msgId, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("XEQ failed: {0}", result);

                result = EmaceBU69092.aceBCOpCodeCreate(
                    devNum, op2Id, BcOpcode.ACE_OPCODE_CAL,
                    BcConditionTest.ACE_CNDTST_ALWAYS, (U16BIT)mnrId, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("CAL failed: {0}", result);

                result = EmaceBU69092.aceBCFrameCreate(
                    devNum, mnrId, BcFrameType.ACE_FRAME_MINOR,
                    new S16BIT[] { op1Id }, 1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("MinorFrame failed: {0}", result);

                result = EmaceBU69092.aceBCFrameCreate(
                    devNum, mjrId, BcFrameType.ACE_FRAME_MAJOR,
                    new S16BIT[] { op2Id }, 1, 1000, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("MajorFrame failed: {0}", result);

                result = EmaceBU69092.aceBCInstallHBuf(devNum, 32 * 1024);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("HBuf failed: {0}", result);

                result = EmaceBU69092.aceBCStart(devNum, mjrId, 1);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return string.Format("BCStart failed: {0}", result);

                started = true;
                Thread.Sleep(300);

                MSGSTRUCT msg = new MSGSTRUCT();
                U32BIT msgCount = 0;
                U32BIT lostCount = 0;

                result = EmaceBU69092.aceBCGetHBufMsgDecoded(
                    devNum, ref msg, ref msgCount, ref lostCount,
                    BcMsgLoc.ACE_BC_MSGLOC_NEXT_PURGE);

                if (result == AceError.ACE_ERR_SUCCESS && msgCount > 0)
                {
                    if ((msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_ERRFLG) ==
                         BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
                    {
                        string errStr = EmaceBU69092.aceGetBSWErrString(
                            ConfigMode.ACE_MODE_BC, msg.wBlkSts);
                        string localErr = errStr;
                        int localStep = stepNumber;
                        Dispatcher.Invoke(new Action(() =>
                        {
                            bc_tbGainTcMsgId.Text = localStep.ToString();
                            bc_tbGainTcTime.Text = ((U32BIT)(msg.wTimeTag * 2)).ToString() + " us";
                            bc_tbGainTcBus.Text = ((int)(msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_CHNL) > 1) ? "B" : "A";
                            bc_tbGainTcTxStatus.Text = msg.wStsWrd1Flg == 1
                                                         ? "0x" + msg.wStsWrd1.ToString("X4") : "N/A";
                            bc_tbGainTcError.Text = localErr;
                            bc_tbGainTcError.Foreground = Brushes.Red;
                        }));
                        return string.Format("BSW Error: {0}", errStr);
                    }

                    int localStepOk = stepNumber;
                    Dispatcher.Invoke(new Action(() =>
                    {
                        bc_tbGainTcMsgId.Text = localStepOk.ToString();
                        bc_tbGainTcTime.Text = ((U32BIT)(msg.wTimeTag * 2)).ToString() + " us";
                        bc_tbGainTcBus.Text = ((int)(msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_CHNL) > 1) ? "B" : "A";
                        bc_tbGainTcTxStatus.Text = msg.wStsWrd1Flg == 1
                                                       ? "0x" + msg.wStsWrd1.ToString("X4") : "N/A";
                        bc_tbGainTcError.Text = "None";
                        bc_tbGainTcError.Foreground = Brushes.Green;
                    }));
                    return "OK";
                }
                else
                {
                    return string.Format("NoResponse(Result={0} Count={1})", result, msgCount);
                }
            }
            catch (Exception ex)
            {
                return string.Format("Exception: {0}", ex.Message);
            }
            finally
            {
                if (started)
                {
                    EmaceBU69092.aceBCStop(devNum);
                    EmaceBU69092.aceFree(devNum);
                }
            }
        }

        // ═════════════════════════════════════════════════════
        //  BC TAB – CLEAR
        // ═════════════════════════════════════════════════════
        private void BC_LoadDefaultFrame_Click(object sender, RoutedEventArgs e)
        {
            ushort[] def = new ushort[]
            {
                0x0401,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,0xFFFF,
                0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,0x0000,
                0x0000,0x0000,0x0000,0x0000,0x0000,0x0000
            };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < def.Length; i++)
            {
                sb.Append(def[i].ToString("X4"));
                if (i < def.Length - 1) sb.Append(" ");
            }
            bc_txMessageTextBox.Text = sb.ToString();
            UpdateStatus("Default frame loaded.");
            LogCommand("BC: Default frame loaded.");
        }

        private void BC_Clear_Click(object sender, RoutedEventArgs e)
        {
            bc_txMessageTextBox.Clear();
            bc_responseTextBox.Clear();
            bc_tbMsgId.Text = bc_tbTime.Text = bc_tbBus.Text =
            bc_tbTxStatus.Text = bc_tbGainValue.Text =
            bc_tbBandwidth.Text = bc_tbWord32.Text = bc_tbSubAddr.Text = "-";
            bc_tbError.Text = "-"; bc_tbError.Foreground = Brushes.Red;

            bc_pwrTxMessageTextBox.Clear();
            bc_pwrResponseTextBox.Clear();
            bc_tbPowerLimitValue.Text = bc_tbPowerWord.Text =
            bc_tbPwrSubAddr.Text = bc_tbPwrMsgId.Text =
            bc_tbPwrTime.Text = bc_tbPwrBus.Text = bc_tbPwrTxStatus.Text = "-";
            bc_tbPwrError.Text = "-"; bc_tbPwrError.Foreground = Brushes.Red;

            bc_gainTcTxMessageTextBox.Clear();
            bc_gainTcResponseTextBox.Clear();
            bc_tbGainTcSubAddr.Text = bc_tbGainTcMsgId.Text =
            bc_tbGainTcTime.Text = bc_tbGainTcBus.Text =
            bc_tbGainTcTxStatus.Text = "-";
            bc_tbGainTcError.Text = "-"; bc_tbGainTcError.Foreground = Brushes.Red;

            SelectGainComboByDbm(bc_gainComboBox, 0);
            bc_bandwidthComboBox.SelectedIndex = 0;
            bc_wordCountComboBox.SelectedIndex = 0;
            bc_powerLimitComboBox.SelectedIndex = 0;
            bc_pwrWordCountComboBox.SelectedIndex = 0;
            bc_gainTcWordCountComboBox.SelectedIndex = 0;

            UpdateLedColor(Brushes.Gray, "IDLE");
            UpdateStatus("BC panel cleared.");
        }

        // ── Stub handlers ──
        private void bc_rtAddressComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void bc_subAddressComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Update sub address label when changed
            if (bc_tbSubAddr != null)
                bc_tbSubAddr.Text = GetComboBoxSelectedText(bc_subAddressComboBox);
        }

        // ═════════════════════════════════════════════════════
        //  SEND BUTTONS
        // ═════════════════════════════════════════════════════
        private void BC_Send32Bit_Click(object sender, RoutedEventArgs e)
        {
            // Auto-build before sending
            AutoBuild32BitTxMessage();

            BC_SendMessageCore(
                txTextBox: bc_txMessageTextBox,
                responseTextBox: bc_responseTextBox,
                deviceIdBox: bc_deviceIdNumber,
                busComboBox: bc_busSelectionComboBox,
                rtComboBox: bc_rtAddressComboBox,
                subAddrComboBox: bc_subAddressComboBox,
                dblkId: BC_DBLK1, msgId: BC_MSG1,
                op1Id: BC_OP1, op2Id: BC_OP2,
                mnrId: BC_MNR1, mjrId: BC_MJR,
                msgIdLabel: bc_tbMsgId,
                timeLabel: bc_tbTime,
                busLabel: bc_tbBus,
                txStatusLabel: bc_tbTxStatus,
                errorLabel: bc_tbError,
                logPrefix: "32-bit (Gain+BW)");
        }

        private void BC_Send8BitPower_Click(object sender, RoutedEventArgs e)
        {
            // Auto-build before sending
            AutoBuild8BitTxMessage();

            BC_SendMessageCore(
                txTextBox: bc_pwrTxMessageTextBox,
                responseTextBox: bc_pwrResponseTextBox,
                deviceIdBox: bc_deviceIdNumber,
                busComboBox: bc_busSelectionComboBox,
                rtComboBox: bc_rtAddressComboBox,
                subAddrComboBox: bc_pwrSubAddressComboBox,
                dblkId: BC_DBLK2, msgId: BC_MSG2,
                op1Id: BC_OP3, op2Id: BC_OP4,
                mnrId: BC_MNR2, mjrId: BC_MJR2,
                msgIdLabel: bc_tbPwrMsgId,
                timeLabel: bc_tbPwrTime,
                busLabel: bc_tbPwrBus,
                txStatusLabel: bc_tbPwrTxStatus,
                errorLabel: bc_tbPwrError,
                logPrefix: "8-bit (PowerLimit)");
        }

        private void BC_SendGainTcOnly_Click(object sender, RoutedEventArgs e)
        {
            BC_SendMessageCore(
                txTextBox: bc_gainTcTxMessageTextBox,
                responseTextBox: bc_gainTcResponseTextBox,
                deviceIdBox: bc_deviceIdNumber,
                busComboBox: bc_busSelectionComboBox,
                rtComboBox: bc_rtAddressComboBox,
                subAddrComboBox: bc_gainTcSubAddressComboBox,
                dblkId: BC_DBLK3, msgId: BC_MSG3,
                op1Id: BC_OP5, op2Id: BC_OP6,
                mnrId: BC_MNR3, mjrId: BC_MJR3,
                msgIdLabel: bc_tbGainTcMsgId,
                timeLabel: bc_tbGainTcTime,
                busLabel: bc_tbGainTcBus,
                txStatusLabel: bc_tbGainTcTxStatus,
                errorLabel: bc_tbGainTcError,
                logPrefix: "24-bit (GainTC)");
        }

        // ═════════════════════════════════════════════════════
        //  SHARED BC SEND CORE
        // ═════════════════════════════════════════════════════
        private void BC_SendMessageCore(
            TextBox txTextBox,
            TextBox responseTextBox,
            TextBox deviceIdBox,
            ComboBox busComboBox,
            ComboBox rtComboBox,
            ComboBox subAddrComboBox,
            S16BIT dblkId, S16BIT msgId,
            S16BIT op1Id, S16BIT op2Id,
            S16BIT mnrId, S16BIT mjrId,
            TextBlock msgIdLabel,
            TextBlock timeLabel,
            TextBlock busLabel,
            TextBlock txStatusLabel,
            TextBlock errorLabel,
            string logPrefix)
        {
            S16BIT localDevNum = 0;
            bool started = false;

            try
            {
                UpdateStatus(string.Format("{0}: Sending...", logPrefix));

                short devNumShort;
                if (!short.TryParse(deviceIdBox.Text.Trim(), out devNumShort))
                {
                    MessageBox.Show("Invalid Device ID.", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                localDevNum = (S16BIT)devNumShort;

                string selectedBus = GetComboBoxSelectedText(busComboBox);
                BcMsgOption busOption = (selectedBus == "B")
                    ? BcMsgOption.ACE_BCCTRL_CHL_B
                    : BcMsgOption.ACE_BCCTRL_CHL_A;

                string rtText = GetComboBoxSelectedText(rtComboBox);
                byte rtAddrByte;
                if (!byte.TryParse(rtText, out rtAddrByte))
                {
                    MessageBox.Show(string.Format("Invalid RT Address: '{0}'", rtText),
                        "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                U16BIT rtAddr = (U16BIT)rtAddrByte;

                string subAddrText = GetComboBoxSelectedText(subAddrComboBox);
                byte subAddrByte;
                if (!byte.TryParse(subAddrText, out subAddrByte))
                {
                    MessageBox.Show(string.Format("Invalid Sub Address: '{0}'", subAddrText),
                        "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                U16BIT subAddr = (U16BIT)subAddrByte;

                string rawText = txTextBox.Text.Trim();
                if (string.IsNullOrEmpty(rawText))
                {
                    MessageBox.Show("TX Message is empty.",
                        "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }

                string[] wordStrings = rawText.Split(
                    new char[] { ' ', ',', '\n', '\r', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);

                int wordCount = Math.Min(wordStrings.Length, 32);
                U16BIT[] msgWords = new U16BIT[wordCount];

                for (int i = 0; i < wordCount; i++)
                {
                    if (!UInt16.TryParse(wordStrings[i],
                            System.Globalization.NumberStyles.HexNumber,
                            null, out msgWords[i]))
                    {
                        MessageBox.Show(
                            string.Format("Invalid hex at position {0}: '{1}'", i + 1, wordStrings[i]),
                            "Parse Error", MessageBoxButton.OK, MessageBoxImage.Warning); return;
                    }
                }

                LogCommand(string.Format("{0}: DevID={1} RT={2} SA={3} Bus={4} Words={5}",
                    logPrefix, localDevNum, rtAddr, subAddr, selectedBus, wordCount));

                AceError result = EmaceBU69092.aceInitialize(
                    localDevNum, ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC, 0, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    UpdateLedColor(Brushes.Red, "ERROR");
                    MessageBox.Show(string.Format("Device not connected.\nError: {0}", result),
                        "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    UpdateStatus(logPrefix + " Error: Not connected."); return;
                }
                UpdateLedColor(Brushes.Green, "BC MODE");

                result = EmaceBU69092.aceBCDataBlkCreate(
                    localDevNum, dblkId, BcDataBlkSize.ACE_BC_DBLK_SINGLE,
                    msgWords, (U16BIT)wordCount);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Data block failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCMsgCreateBCtoRT(
                    localDevNum, msgId, dblkId,
                    rtAddr, subAddr, (U16BIT)wordCount, 0, busOption);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("BCtoRT message failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCOpCodeCreate(
                    localDevNum, op1Id, BcOpcode.ACE_OPCODE_XEQ,
                    BcConditionTest.ACE_CNDTST_ALWAYS, (U16BIT)msgId, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("XEQ opcode failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCOpCodeCreate(
                    localDevNum, op2Id, BcOpcode.ACE_OPCODE_CAL,
                    BcConditionTest.ACE_CNDTST_ALWAYS, (U16BIT)mnrId, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("CAL opcode failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCFrameCreate(
                    localDevNum, mnrId, BcFrameType.ACE_FRAME_MINOR,
                    new S16BIT[] { op1Id }, 1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Minor frame failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCFrameCreate(
                    localDevNum, mjrId, BcFrameType.ACE_FRAME_MAJOR,
                    new S16BIT[] { op2Id }, 1, 1000, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Major frame failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCInstallHBuf(localDevNum, 32 * 1024);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("HBuf failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCStart(localDevNum, mjrId, 1);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("BC Start failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }
                started = true;
                LogCommand(string.Format("{0}: Transmission started.", logPrefix));

                Thread.Sleep(500);

                MSGSTRUCT msg = new MSGSTRUCT();
                U32BIT msgCount = 0;
                U32BIT lostCount = 0;

                result = EmaceBU69092.aceBCGetHBufMsgDecoded(
                    localDevNum, ref msg, ref msgCount, ref lostCount,
                    BcMsgLoc.ACE_BC_MSGLOC_NEXT_PURGE);

                if (result == AceError.ACE_ERR_SUCCESS && msgCount > 0)
                {
                    BC_ProcessDecodedMessage(1, ref msg, responseTextBox,
                        msgIdLabel, timeLabel, busLabel, txStatusLabel, errorLabel, logPrefix);
                    LogCommand(string.Format("{0}: Response | Count={1} Lost={2}",
                        logPrefix, msgCount, lostCount));
                }
                else
                {
                    responseTextBox.Text = string.Format(
                        "No response from RT.\nResult: {0}\nCount: {1}\nLost: {2}",
                        result, msgCount, lostCount);
                    LogCommand(string.Format("{0}: No response from RT.", logPrefix));
                }

                UpdateStatus(string.Format("{0}: Complete.", logPrefix));
                MessageBox.Show(
                    string.Format("{0}: Sent!\nCheck Response panel.", logPrefix),
                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Exception:\n{0}\n\nStack:\n{1}", ex.Message, ex.StackTrace),
                    "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateStatus(logPrefix + " Exception: " + ex.Message);
                LogCommand(logPrefix + " EXCEPTION: " + ex.Message);
            }
            finally
            {
                if (started)
                {
                    EmaceBU69092.aceBCStop(localDevNum);
                    EmaceBU69092.aceFree(localDevNum);
                    LogCommand(string.Format("{0}: Device {1} freed.", logPrefix, localDevNum));
                }
            }
        }

        private void BC_ProcessDecodedMessage(
            U32BIT nMsgNum, ref MSGSTRUCT pMsg,
            TextBox responseTextBox,
            TextBlock msgIdLabel, TextBlock timeLabel, TextBlock busLabel,
            TextBlock txStatusLabel, TextBlock errorLabel, string logPrefix)
        {
            U16BIT wRT = 0, wTR1 = 0, wSA = 0, wWC = 0;
            string bus = ((int)(pMsg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_CHNL) > 1) ? "B" : "A";
            string msgType = EmaceBU69092.aceGetMsgTypeString(pMsg.wType);
            string timeUs = ((U32BIT)(pMsg.wTimeTag * 2)).ToString();
            string txStatus = string.Empty;
            string error = string.Empty;

            LogCommand(string.Format("{0} MSG#{1:D4} | {2}us | BUS={3} | {4}",
                logPrefix, nMsgNum, timeUs, bus, msgType));
            EmaceBU69092.aceCmdWordParse(pMsg.wCmdWrd1, ref wRT, ref wTR1, ref wSA, ref wWC);

            if (pMsg.wStsWrd1Flg == 1)
            { txStatus = pMsg.wStsWrd1.ToString("X4"); LogCommand(" STATUS1: 0x" + txStatus); }

            StringBuilder db = new StringBuilder();
            for (U16BIT i = 0; i < pMsg.wWordCount; i++)
            {
                db.Append(string.Format("{0:X4} ", pMsg.aDataWrds[i]));
                if ((i + 1) % 8 == 0) db.Append("\n");
            }
            string hexData = db.ToString().Trim();
            if (!string.IsNullOrEmpty(hexData)) LogCommand(" DATA: " + hexData);

            if ((pMsg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_ERRFLG) ==
                 BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
            {
                error = EmaceBU69092.aceGetBSWErrString(ConfigMode.ACE_MODE_BC, pMsg.wBlkSts);
                LogCommand(" ERROR: " + error);
            }

            StringBuilder resp = new StringBuilder();
            resp.AppendLine(string.Format("Time   : {0} us", timeUs));
            resp.AppendLine(string.Format("Bus    : {0}", bus));
            resp.AppendLine(string.Format("Type   : {0}", msgType));
            if (!string.IsNullOrEmpty(txStatus))
                resp.AppendLine(string.Format("Status : 0x{0}", txStatus));
            if (!string.IsNullOrEmpty(hexData))
            { resp.AppendLine(); resp.AppendLine("Data Words:"); resp.AppendLine(hexData); }
            if (!string.IsNullOrEmpty(error))
            { resp.AppendLine(); resp.AppendLine("ERROR: " + error); }

            responseTextBox.Text = resp.ToString();
            msgIdLabel.Text = nMsgNum.ToString();
            timeLabel.Text = timeUs + " us";
            busLabel.Text = bus;
            txStatusLabel.Text = string.IsNullOrEmpty(txStatus) ? "N/A" : ("0x" + txStatus);
            errorLabel.Text = string.IsNullOrEmpty(error) ? "None" : error;
            errorLabel.Foreground = string.IsNullOrEmpty(error) ? Brushes.Green : Brushes.Red;
        }

        // ═════════════════════════════════════════════════════
        //  RT → BC TAB HANDLERS
        // ═════════════════════════════════════════════════════
        private void RT_Clear_Click(object sender, RoutedEventArgs e)
        {
            rt_outputTextBox.Clear();
            rt_tbTime.Text = rt_tbBus.Text = rt_tbMsgType.Text =
            rt_tbWordCount.Text = rt_tbStatusWord.Text = rt_tbError.Text = "-";
            rt_tbError.Foreground = Brushes.Red;
            UpdateLedColor(Brushes.Gray, "IDLE");
            UpdateStatus("RT panel cleared.");
        }

        private void RT_ReceiveData_Click(object sender, RoutedEventArgs e)
        {
            S16BIT localDevNum = 0;
            bool started = false;

            try
            {
                UpdateStatus("RT→BC: Requesting data from RT...");

                short devNumShort;
                if (!short.TryParse(rt_deviceIdTextBox.Text.Trim(), out devNumShort))
                {
                    MessageBox.Show("Invalid Device ID.", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                localDevNum = (S16BIT)devNumShort;

                string selectedBus = GetComboBoxSelectedText(rt_busSelectionComboBox);
                BcMsgOption busOption = (selectedBus == "B")
                    ? BcMsgOption.ACE_BCCTRL_CHL_B
                    : BcMsgOption.ACE_BCCTRL_CHL_A;

                string rtText = GetComboBoxSelectedText(rt_rtAddressComboBox);
                byte rtAddrByte;
                if (!byte.TryParse(rtText, out rtAddrByte))
                {
                    MessageBox.Show(string.Format("Invalid RT Address: '{0}'", rtText),
                        "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                U16BIT rtAddr = (U16BIT)rtAddrByte;

                string subAddrText = GetComboBoxSelectedText(rt_subAddressComboBox);
                byte subAddrByte;
                if (!byte.TryParse(subAddrText, out subAddrByte))
                {
                    MessageBox.Show(string.Format("Invalid Sub Address: '{0}'", subAddrText),
                        "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                U16BIT subAddr = (U16BIT)subAddrByte;
                U16BIT wordCount = 32;

                U16BIT[] dummyData = new U16BIT[wordCount];
                for (int i = 0; i < wordCount; i++) dummyData[i] = (U16BIT)(0x1000 + i);

                LogCommand(string.Format("RT→BC: DevID={0} | RT={1} | SA={2} | Bus={3}",
                    localDevNum, rtAddr, subAddr, selectedBus));

                AceError result = EmaceBU69092.aceInitialize(
                    localDevNum, ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC, 0, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    UpdateLedColor(Brushes.Red, "ERROR");
                    MessageBox.Show(string.Format("Device not connected.\nError: {0}", result),
                        "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }
                UpdateLedColor(Brushes.Green, "RT MODE");

                EmaceBU69092.aceBCStop(localDevNum);
                EmaceBU69092.aceBCFrameDelete(localDevNum, RT_MJR);
                EmaceBU69092.aceBCFrameDelete(localDevNum, RT_MNR1);
                EmaceBU69092.aceBCOpCodeDelete(localDevNum, RT_OP1);
                EmaceBU69092.aceBCOpCodeDelete(localDevNum, RT_OP2);
                EmaceBU69092.aceBCMsgDelete(localDevNum, RT_MSG1);
                EmaceBU69092.aceBCDataBlkDelete(localDevNum, RT_DBLK1);

                result = EmaceBU69092.aceBCDataBlkCreate(
                    localDevNum, RT_DBLK1, BcDataBlkSize.ACE_BC_DBLK_SINGLE,
                    dummyData, wordCount);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Data block failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCMsgCreateRTtoBC(
                    localDevNum, RT_MSG1, RT_DBLK1,
                    rtAddr, subAddr, wordCount, 0, busOption);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("RTtoBC message failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCOpCodeCreate(
                    localDevNum, RT_OP1, BcOpcode.ACE_OPCODE_XEQ,
                    BcConditionTest.ACE_CNDTST_ALWAYS, (U16BIT)RT_MSG1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("XEQ opcode failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCOpCodeCreate(
                    localDevNum, RT_OP2, BcOpcode.ACE_OPCODE_CAL,
                    BcConditionTest.ACE_CNDTST_ALWAYS, (U16BIT)RT_MNR1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("CAL opcode failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCFrameCreate(
                    localDevNum, RT_MNR1, BcFrameType.ACE_FRAME_MINOR,
                    new S16BIT[] { RT_OP1 }, 1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Minor frame failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCFrameCreate(
                    localDevNum, RT_MJR, BcFrameType.ACE_FRAME_MAJOR,
                    new S16BIT[] { RT_OP2 }, 1, 1000, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Major frame failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCInstallHBuf(localDevNum, 32 * 1024);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("HBuf failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }

                result = EmaceBU69092.aceBCStart(localDevNum, RT_MJR, 1);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("BC Start failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }
                started = true;
                LogCommand("RT→BC: BC started, waiting for RT response...");

                Thread.Sleep(600);

                MSGSTRUCT msg = new MSGSTRUCT();
                U32BIT msgCount = 0;
                U32BIT lostCount = 0;

                result = EmaceBU69092.aceBCGetHBufMsgDecoded(
                    localDevNum, ref msg, ref msgCount, ref lostCount,
                    BcMsgLoc.ACE_BC_MSGLOC_NEXT_PURGE);

                if (result == AceError.ACE_ERR_SUCCESS && msgCount > 0)
                {
                    RT_DisplayReceivedMessage(ref msg);
                    LogCommand(string.Format("RT→BC: Data received | Count={0} Lost={1}",
                        msgCount, lostCount));
                    MessageBox.Show("Data received from RT successfully.\nCheck Response panel.",
                        "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    rt_outputTextBox.Text = string.Format(
                        "No response from RT.\nResult:{0}\nCount:{1}\nLost:{2}\n\n" +
                        "Check:\n1. RT Simulator running\n2. RT Address matches\n" +
                        "3. Sub Address matches\n4. Bus matches",
                        result, msgCount, lostCount);
                    LogCommand("RT→BC: No response received.");
                    MessageBox.Show(
                        "No response from RT.\n\nMake sure:\n" +
                        "1. RT Simulator tab is started\n2. RT Address matches\n" +
                        "3. Sub Address matches\n4. Same Bus (A or B)",
                        "No Response", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                UpdateStatus("RT→BC: Receive operation complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Exception:\n{0}\n\nStack:\n{1}", ex.Message, ex.StackTrace),
                    "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateStatus("RT→BC Exception: " + ex.Message);
                LogCommand("RT→BC EXCEPTION: " + ex.Message);
            }
            finally
            {
                if (started)
                {
                    EmaceBU69092.aceBCStop(localDevNum);
                    EmaceBU69092.aceFree(localDevNum);
                    LogCommand(string.Format("RT→BC: Device {0} freed.", localDevNum));
                }
            }
        }

        private void RT_DisplayReceivedMessage(ref MSGSTRUCT msg)
        {
            string bus = ((int)(msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_CHNL) > 1) ? "B" : "A";
            string msgType = EmaceBU69092.aceGetMsgTypeString(msg.wType);
            string timeUs = ((U32BIT)(msg.wTimeTag * 2)).ToString();
            string statusW1 = string.Empty, statusW2 = string.Empty, error = string.Empty;

            LogCommand(string.Format("RT→BC DATA: TIME={0}us | BUS={1} | TYPE={2} | WC={3}",
                timeUs, bus, msgType, msg.wWordCount));

            if (msg.wStsWrd1Flg == 1) statusW1 = msg.wStsWrd1.ToString("X4");
            if (msg.wStsWrd2Flg == 1) statusW2 = msg.wStsWrd2.ToString("X4");

            StringBuilder db = new StringBuilder();
            for (U16BIT i = 0; i < msg.wWordCount; i++)
            {
                db.Append(string.Format("{0:X4} ", msg.aDataWrds[i]));
                if ((i + 1) % 8 == 0) db.Append("\n");
            }
            string hexData = db.ToString().Trim();
            if (!string.IsNullOrEmpty(hexData)) LogCommand(" DATA: " + hexData);

            if ((msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_ERRFLG) ==
                 BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
                error = EmaceBU69092.aceGetBSWErrString(ConfigMode.ACE_MODE_BC, msg.wBlkSts);

            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("Time       : {0} us", timeUs));
            output.AppendLine(string.Format("Bus        : {0}", bus));
            output.AppendLine(string.Format("Msg Type   : {0}", msgType));
            output.AppendLine(string.Format("Word Count : {0}", msg.wWordCount));
            if (!string.IsNullOrEmpty(statusW1)) output.AppendLine("Status W1  : 0x" + statusW1);
            if (!string.IsNullOrEmpty(statusW2)) output.AppendLine("Status W2  : 0x" + statusW2);
            if (!string.IsNullOrEmpty(hexData))
            { output.AppendLine(); output.AppendLine("Data Words:"); output.AppendLine(hexData); }
            if (!string.IsNullOrEmpty(error))
            { output.AppendLine(); output.AppendLine("ERROR: " + error); }

            rt_outputTextBox.Text = output.ToString();
            rt_tbTime.Text = timeUs + " us";
            rt_tbBus.Text = bus;
            rt_tbMsgType.Text = msgType;
            rt_tbWordCount.Text = msg.wWordCount.ToString();
            rt_tbStatusWord.Text = string.IsNullOrEmpty(statusW1) ? "N/A" : "0x" + statusW1;
            rt_tbError.Text = string.IsNullOrEmpty(error) ? "None" : error;
            rt_tbError.Foreground = string.IsNullOrEmpty(error) ? Brushes.Green : Brushes.Red;
        }

        // ═════════════════════════════════════════════════════
        //  RT SIMULATOR TAB HANDLERS
        // ═════════════════════════════════════════════════════
        private void RTSim_LoadDefault_Click(object sender, RoutedEventArgs e)
        {
            ushort[] d = new ushort[]
            {
                0x1234,0x5678,0xABCD,0xEF01,0x2345,0x6789,0xBCDE,0xF012,
                0x3456,0x789A,0xCDEF,0x0123,0x4567,0x89AB,0xCDEF,0x0123,
                0x4567,0x89AB,0xCDEF,0x0123,0x4567,0x89AB,0xCDEF,0x0123,
                0x4567,0x89AB,0xCDEF,0x0123,0x4567,0x89AB,0xCDEF,0x0123
            };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < d.Length; i++)
            {
                sb.Append(d[i].ToString("X4"));
                if (i < d.Length - 1) sb.Append(" ");
            }
            rtsim_responseDataTextBox.Text = sb.ToString();
            UpdateStatus("RT Simulator: Default data loaded.");
            LogCommand("RT Simulator: Default data loaded.");
        }

        private void RTSim_Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                short devNumShort;
                if (!short.TryParse(rtsim_deviceIdTextBox.Text.Trim(), out devNumShort))
                {
                    MessageBox.Show("Invalid Device ID.", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                rtSimDeviceId = (S16BIT)devNumShort;

                string rtText = GetComboBoxSelectedText(rtsim_rtAddressComboBox);
                byte rtAddrByte;
                if (!byte.TryParse(rtText, out rtAddrByte))
                {
                    MessageBox.Show("Invalid RT Address.", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                rtSimRTAddress = (U16BIT)rtAddrByte;

                string subText = GetComboBoxSelectedText(rtsim_subAddressComboBox);
                byte subAddrByte;
                if (!byte.TryParse(subText, out subAddrByte))
                {
                    MessageBox.Show("Invalid Sub Address.", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }
                rtSimSubAddress = (U16BIT)subAddrByte;

                string rawText = rtsim_responseDataTextBox.Text.Trim();
                if (string.IsNullOrEmpty(rawText))
                {
                    MessageBox.Show("Response data is empty.", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning); return;
                }

                string[] ws = rawText.Split(
                    new char[] { ' ', ',', '\n', '\r', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);
                int wc = Math.Min(ws.Length, 32);
                U16BIT[] data = new U16BIT[wc];
                for (int i = 0; i < wc; i++)
                {
                    if (!UInt16.TryParse(ws[i],
                            System.Globalization.NumberStyles.HexNumber,
                            null, out data[i]))
                    {
                        MessageBox.Show(string.Format("Invalid hex at position {0}", i + 1),
                            "Parse Error", MessageBoxButton.OK, MessageBoxImage.Warning); return;
                    }
                }

                LogCommand(string.Format(
                    "RT Simulator: Starting | DevID={0} RT={1} SA={2} Words={3}",
                    rtSimDeviceId, rtSimRTAddress, rtSimSubAddress, wc));

                AceError result = EmaceBU69092.aceInitialize(
                    rtSimDeviceId, ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_RTMT, 0, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(
                        string.Format("RT Init failed.\nError: {0}\n\nCheck device is connected.", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    rtSimDeviceId = -1; return;
                }
                LogCommand("RT Simulator: STEP 1 - Initialized as RTMT.");

                result = EmaceBU69092.aceRTDataBlkCreate(
                    rtSimDeviceId, 1, RtDataBlkType.ACE_RT_DBLK_SINGLE,
                    data, (U16BIT)wc);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("RT Data Block Create failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    rtSimDeviceId = -1; return;
                }
                LogCommand(string.Format("RT Simulator: STEP 2 - Data block created with {0} words.", wc));

                result = EmaceBU69092.aceRTSetAddress(rtSimDeviceId, rtSimRTAddress);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("RT Set Address failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    rtSimDeviceId = -1; return;
                }
                LogCommand(string.Format("RT Simulator: STEP 3 - RT Address set to {0}.", rtSimRTAddress));

                result = EmaceBU69092.aceRTDataBlkMapToSA(
                    rtSimDeviceId, 1, rtSimSubAddress,
                    RtMsgType.ACE_RT_MSGTYPE_ALL, 0, true);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("RT Map to SA failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    rtSimDeviceId = -1; return;
                }
                LogCommand(string.Format("RT Simulator: STEP 4 - Data block mapped to SA={0}.", rtSimSubAddress));

                result = EmaceBU69092.aceRTMTStart(rtSimDeviceId);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("RT MT Start failed.\nError: {0}", result),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    rtSimDeviceId = -1; return;
                }
                LogCommand("RT Simulator: STEP 5 - aceRTMTStart called. RT is now ACTIVE.");

                rtSimRunning = true;

                rtsim_startButton.IsEnabled = false;
                rtsim_stopButton.IsEnabled = true;
                rtsim_updateDataButton.IsEnabled = true;
                rtsim_statusBorder.Background = Brushes.Green;
                rtsim_statusText.Text = "🟢 RT SIMULATOR RUNNING";
                UpdateLedColor(Brushes.Green, "RTMT");
                UpdateStatus(string.Format("RT Simulator: RUNNING as RT={0} SA={1}",
                    rtSimRTAddress, rtSimSubAddress));

                MessageBox.Show(
                    string.Format(
                        "RT Simulator Started!\n\n" +
                        "Device ID   : {0}\nRT Address  : {1}\n" +
                        "Sub Address : {2}\nData Words  : {3}\n\n" +
                        "Go to RT→BC tab and click 'Receive Data From RT'.",
                        rtSimDeviceId, rtSimRTAddress, rtSimSubAddress, wc),
                    "RT Simulator Started",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception starting RT Simulator:\n{0}", ex.Message),
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LogCommand("RTSim EXCEPTION: " + ex.Message);
                rtSimDeviceId = -1;
                rtSimRunning = false;
            }
        }

        // ═════════════════════════════════════════════════════
        //  RT SIMULATOR – LIVE DATA UPDATE
        // ═════════════════════════════════════════════════════
        private void RTSim_UpdateData_Click(object sender, RoutedEventArgs e)
        {
            if (!rtSimRunning || rtSimDeviceId < 0)
            {
                MessageBox.Show("RT Simulator is not running.\nStart it first.",
                    "Not Running", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                string rawText = rtsim_responseDataTextBox.Text.Trim();
                if (string.IsNullOrEmpty(rawText))
                {
                    MessageBox.Show("Response data is empty.", "Input Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string[] ws = rawText.Split(
                    new char[] { ' ', ',', '\n', '\r', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);

                int wc = Math.Min(ws.Length, 32);
                U16BIT[] newData = new U16BIT[wc];
                for (int i = 0; i < wc; i++)
                {
                    if (!UInt16.TryParse(ws[i],
                            System.Globalization.NumberStyles.HexNumber,
                            null, out newData[i]))
                    {
                        MessageBox.Show(
                            string.Format("Invalid hex at position {0}: '{1}'", i + 1, ws[i]),
                            "Parse Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                // Step 1: Delete old block
                LogCommand("RT Sim Update: Deleting old data block...");
                AceError result = EmaceBU69092.aceRTDataBlkDelete(rtSimDeviceId, 1);
                if (result != AceError.ACE_ERR_SUCCESS)
                    LogCommand(string.Format("RT Sim Update: aceRTDataBlkDelete={0} (ignored).", result));

                // Step 2: Recreate with new data
                result = EmaceBU69092.aceRTDataBlkCreate(
                    rtSimDeviceId, 1, RtDataBlkType.ACE_RT_DBLK_SINGLE,
                    newData, (U16BIT)wc);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format(
                            "Failed to create new data block.\nError: {0}\n\n" +
                            "Try stopping and restarting the RT Simulator.", result),
                        "Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    LogCommand(string.Format("RT Sim Update: aceRTDataBlkCreate FAILED: {0}", result));
                    return;
                }
                LogCommand("RT Sim Update: Data block created OK.");

                // Step 3: Remap
                result = EmaceBU69092.aceRTDataBlkMapToSA(
                    rtSimDeviceId, 1, rtSimSubAddress,
                    RtMsgType.ACE_RT_MSGTYPE_ALL, 0, true);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format(
                            "Failed to remap data block to SA={0}.\nError: {1}",
                            rtSimSubAddress, result),
                        "Remap Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    LogCommand(string.Format("RT Sim Update: aceRTDataBlkMapToSA FAILED: {0}", result));
                    return;
                }
                LogCommand(string.Format("RT Sim Update: Mapped to SA={0} OK.", rtSimSubAddress));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < wc; i++)
                {
                    sb.Append(string.Format("{0:X4}", newData[i]));
                    if (i < wc - 1) sb.Append(" ");
                }

                LogCommand(string.Format("RT Sim: Data UPDATED | Words={0} | {1}", wc, sb.ToString()));
                UpdateStatus(string.Format("RT Simulator: Data updated with {0} words.", wc));

                MessageBox.Show(
                    string.Format(
                        "RT Data Updated!\n\nRT Address  : {0}\nSub Address : {1}\n" +
                        "Words Loaded: {2}\n\nData:\n{3}\n\n" +
                        "Next receive will return the new data.",
                        rtSimRTAddress, rtSimSubAddress, wc, sb.ToString()),
                    "Data Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception updating RT data:\n{0}", ex.Message),
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LogCommand("RTSim UpdateData EXCEPTION: " + ex.Message);
            }
        }

        // ═════════════════════════════════════════════════════
        //  RT SIMULATOR – QUICK TEST PATTERNS
        // ═════════════════════════════════════════════════════
        private void RTSim_LoadTestData1_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                sb.Append(string.Format("{0:X4}", i + 1));
                if (i < 31) sb.Append(" ");
            }
            rtsim_responseDataTextBox.Text = sb.ToString();
            LogCommand("RT Sim: Pattern 1 — Incrementing (0001→0020).");
            UpdateStatus("RT Sim: Pattern 1 loaded.");
        }

        private void RTSim_LoadTestData2_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                sb.Append(i % 2 == 0 ? "AA55" : "55AA");
                if (i < 31) sb.Append(" ");
            }
            rtsim_responseDataTextBox.Text = sb.ToString();
            LogCommand("RT Sim: Pattern 2 — AA55/55AA.");
            UpdateStatus("RT Sim: Pattern 2 loaded.");
        }

        private void RTSim_LoadTestData3_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                sb.Append("0000");
                if (i < 31) sb.Append(" ");
            }
            rtsim_responseDataTextBox.Text = sb.ToString();
            LogCommand("RT Sim: Pattern 3 — All zeros.");
            UpdateStatus("RT Sim: Pattern 3 loaded.");
        }

        private void RTSim_LoadTestData4_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                sb.Append("FFFF");
                if (i < 31) sb.Append(" ");
            }
            rtsim_responseDataTextBox.Text = sb.ToString();
            LogCommand("RT Sim: Pattern 4 — All FFFF.");
            UpdateStatus("RT Sim: Pattern 4 loaded.");
        }

        private void RTSim_LoadTestData5_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                sb.Append(i % 2 == 0 ? "DEAD" : "BEEF");
                if (i < 31) sb.Append(" ");
            }
            rtsim_responseDataTextBox.Text = sb.ToString();
            LogCommand("RT Sim: Pattern 5 — DEAD/BEEF.");
            UpdateStatus("RT Sim: Pattern 5 loaded.");
        }

        private void RTSim_Stop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rtSimDeviceId >= 0 && rtSimRunning)
                {
                    AceError result = EmaceBU69092.aceRTMTStop(rtSimDeviceId);
                    if (result != AceError.ACE_ERR_SUCCESS)
                        LogCommand(string.Format("RT Simulator: aceRTMTStop returned {0}", result));

                    result = EmaceBU69092.aceFree(rtSimDeviceId);
                    if (result != AceError.ACE_ERR_SUCCESS)
                        LogCommand(string.Format("RT Simulator: aceFree returned {0}", result));

                    LogCommand(string.Format("RT Simulator: Stopped. DevID={0} RT={1} SA={2}",
                        rtSimDeviceId, rtSimRTAddress, rtSimSubAddress));
                }

                rtSimDeviceId = -1;
                rtSimRunning = false;
                rtSimRTAddress = 0;
                rtSimSubAddress = 1;

                rtsim_startButton.IsEnabled = true;
                rtsim_stopButton.IsEnabled = false;
                rtsim_updateDataButton.IsEnabled = false;
                rtsim_statusBorder.Background = Brushes.Gray;
                rtsim_statusText.Text = "⚫ RT SIMULATOR STOPPED";
                UpdateLedColor(Brushes.Gray, "IDLE");
                UpdateStatus("RT Simulator: Stopped.");

                MessageBox.Show("RT Simulator stopped successfully.",
                    "RT Simulator", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception stopping RT Simulator:\n{0}", ex.Message),
                    "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                LogCommand("RTSim Stop EXCEPTION: " + ex.Message);
            }
        }

        // ═════════════════════════════════════════════════════
        //  RT SIMULATOR – TEXTBOX LIVE VALIDATION
        // ═════════════════════════════════════════════════════
        private void RTSim_DataTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rtsim_wordCountLabel == null ||
                rtsim_validationBorder == null ||
                rtsim_validationText == null) return;

            string raw = rtsim_responseDataTextBox.Text.Trim();

            if (string.IsNullOrEmpty(raw))
            {
                rtsim_wordCountLabel.Text = "0";
                rtsim_validationBorder.Background = new SolidColorBrush(Color.FromRgb(0xFF, 0xEB, 0xEE));
                rtsim_validationBorder.BorderBrush = Brushes.Red;
                rtsim_validationText.Text = "⚠ Data box is empty — enter HEX words.";
                rtsim_validationText.Foreground = Brushes.Red;
                return;
            }

            string[] parts = raw.Split(
                new char[] { ' ', ',', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            int count = parts.Length;
            bool allValid = true;
            int badIndex = -1;
            string badToken = string.Empty;

            rtsim_wordCountLabel.Text = count > 32 ? "32+" : count.ToString();

            for (int i = 0; i < Math.Min(count, 32); i++)
            {
                ushort dummy;
                if (!UInt16.TryParse(parts[i],
                        System.Globalization.NumberStyles.HexNumber,
                        null, out dummy))
                {
                    allValid = false;
                    badIndex = i + 1;
                    badToken = parts[i];
                    break;
                }
            }

            if (!allValid)
            {
                rtsim_validationBorder.Background = new SolidColorBrush(Color.FromRgb(0xFF, 0xEB, 0xEE));
                rtsim_validationBorder.BorderBrush = Brushes.Red;
                rtsim_validationText.Text = string.Format(
                    "✘ Invalid hex at word #{0}: '{1}'", badIndex, badToken);
                rtsim_validationText.Foreground = Brushes.Red;
            }
            else if (count > 32)
            {
                rtsim_validationBorder.Background = new SolidColorBrush(Color.FromRgb(0xFF, 0xF3, 0xE0));
                rtsim_validationBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0xFF, 0x99, 0x00));
                rtsim_validationText.Text = string.Format(
                    "⚠ {0} words — only first 32 used.", count);
                rtsim_validationText.Foreground = new SolidColorBrush(Color.FromRgb(0xE6, 0x51, 0x00));
            }
            else
            {
                rtsim_validationBorder.Background = new SolidColorBrush(Color.FromRgb(0xE8, 0xF5, 0xE9));
                rtsim_validationBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0x4C, 0xAF, 0x50));
                rtsim_validationText.Text = string.Format(
                    "✔  {0} valid word{1} — ready to update.",
                    count, count == 1 ? "" : "s");
                rtsim_validationText.Foreground = new SolidColorBrush(Color.FromRgb(0x2E, 0x7D, 0x32));
            }
        }

        // ═════════════════════════════════════════════════════
        //  RT SIMULATOR – CLEAR DATA BUTTON
        // ═════════════════════════════════════════════════════
        private void RTSim_ClearData_Click(object sender, RoutedEventArgs e)
        {
            rtsim_responseDataTextBox.Clear();
            rtsim_responseDataTextBox.Focus();
            LogCommand("RT Sim: Data box cleared.");
            UpdateStatus("RT Sim: Data cleared. Type new HEX words and click Update.");
        }
    }
}