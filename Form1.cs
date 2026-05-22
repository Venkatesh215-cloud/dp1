using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using DDC.Mil1553.Emace;

using U32BIT = System.UInt32;
using U16BIT = System.UInt16;
using S16BIT = System.Int16;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private double rtSimPowerValue = 0.0;  // current power value to send
        private S16BIT rtSimDeviceId = -1;
        private U16BIT rtSimRTAddress = 1;
        private U16BIT rtSimSubAddress = 1;
        private bool rtSimRunning = false;
        // ═══════════════════════════════════════════════════
        //  TCP CONNECTIONS
        // ═══════════════════════════════════════════════════
        private TcpClient tcpClient_SigGen = null;
        private TcpClient tcpClient_Spectrum = null;
        private TcpClient tcpClient_VNA = null;
        private NetworkStream stream_SigGen = null;
        private NetworkStream stream_Spectrum = null;
        private NetworkStream stream_VNA = null;
        private bool isSigGenConnected = false;
        private bool isSpectrumConnected = false;
        private bool isVNAConnected = false;

        // ═══════════════════════════════════════════════════
        //  DDC 1553 CONSTANTS
        // ═══════════════════════════════════════════════════
        private const S16BIT BC_DBLK3 = 21;
        private const S16BIT BC_MSG3 = 22;
        private const S16BIT BC_OP5 = 23;
        private const S16BIT BC_OP6 = 24;
        private const S16BIT BC_MNR3 = 25;
        private const S16BIT BC_MJR3 = 26;


        private const S16BIT RT_DBLK1 = 101;
        private const S16BIT RT_MSG1 = 102;
        private const S16BIT RT_OP1 = 103;
        private const S16BIT RT_OP2 = 104;
        private const S16BIT RT_MNR1 = 105;
        private const S16BIT RT_MJR = 106;

        // ═══════════════════════════════════════════════════
        //  DDC 1553 STATE
        // ═══════════════════════════════════════════════════
        private bool is1553Connected = false;
        private S16BIT _1553DeviceId = 0;
        private U16BIT _1553RTAddress = 1;
        private U16BIT _1553SubAddress = 1;
        private string _1553Bus = "A";

        //private S16BIT localDevNum = 0;

        private U16BIT gRtAddress = 3;
        private U16BIT gSubAddress =2;

        private BcMsgOption gBusOption = BcMsgOption.ACE_BCCTRL_CHL_A;



        string freq1;
        string freq2;
        double res;

        double fre1;
        double fre2;
     

        // ═══════════════════════════════════════════════════
        //  GAIN LOOKUP TABLE
        // ═══════════════════════════════════════════════════
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
            {  36,  4135042 }, {  37,  4639593 }, {  38,  5205710 },
            {  39,  5840902 }, {  40,  6553600 }, {  41,  7353260 },
            {  42,  8250494 }, {  43,  9257206 }, {  44, 10386756 },
            {  45, 11654132 }
        };


        // ═══════════════════════════════════════════════════
        //  POWER LIMIT LOOKUP TABLE
        // ═══════════════════════════════════════════════════
        private static readonly Dictionary<int, long> PowerLimitTable =
            new Dictionary<int, long>
        {
            { 0,        1}, { -1,       2}, { -3,       3},
            { -4,       4}, { -5,       5}, { -6,       7},
            { -7,       8}, { -8,       9}, { -9,      10},
            { -10,     11}, { -11,     12}, { -12,     13},
            { -13,     14}, { -14,     15}, { -15,     16},
            { -16,     17}, { -17,     18}, { -18,     19},
            { -19,     20}, { -20,     21}, { -21,     22},
            { -22,     23}, { -23,     24}, { -24,     25},
            { -25,     26}, { -26,     27}, { -27,     28},
            { -28,     29}, { -30,     31}, { -31,     32},
            { -32,     33}, { -33,     34}, { -34,     35},
            { -35,     36}, { -36,     37}, { -37,     38},
            { -38,     39}, { -39,     40}, { -40,     41},
            { -41,     42}, { -42,     43}, { -43,     44},
            { -44,     45}, { -45,     46}
        };


        // ═══════════════════════════════════════════════════
        //  BANDWIDTH LOOKUP TABLE
        // ═══════════════════════════════════════════════════
        private static readonly Dictionary<int, long> BandwidthTable =
            new Dictionary<int, long>
        {
            { 0,        0}, { 50,       1}, { 100,      2},
            { 150,      3}, { 200,      4}, { 250,      5},
            { 300,      6}, { 350,      7}, { 400,      8}
      
        };


     
         
        // ═══════════════════════════════════════════════════
        //  RUN STATE
        // ═══════════════════════════════════════════════════
        private bool isRunning = false;
        private bool stopRequested = false;

    
        // ═══════════════════════════════════════════════════
        //  RESULT DATA
        // ═══════════════════════════════════════════════════
        public class ResultData
        {
            public double Frequency { get; set; }
            public double Power { get; set; }
            public int GainStep { get; set; }
            public double Measured { get; set; }
            public double Accuracy { get; set; }
        }
        public class ResultPowerLevelData
        {
            public double RFFreq { get; set; }
            public string ToneFreq { get; set; }
            public double SetPower { get; set; }
            public string RTData { get; set; }
            public string RTDataDecimal { get; set; }  // ✅ NEW
        }
        // ═══════════════════════════════════════════════════
        //  RESULT POWER LIMIT DATA
        // ═══════════════════════════════════════════════════
        public class ResultlimitData
        {
            public double Frequency { get; set; }
            public double Power { get; set; }
            public int PowerLimitStep { get; set; }
            public double Measured { get; set; }
        }

        // ═══════════════════════════════════════════════════
        //  RESULT POWER LIMIT SWEEP DATA
        // ═══════════════════════════════════════════════════
        public class ResultlimitSweepData
        {
            public double Frequency { get; set; }
            public double Power { get; set; }
            public int PowerLimitStep { get; set; }
            public double Measured { get; set; }
            public double Accuracy { get; set; }
        }

        // ═══════════════════════════════════════════════════
        //  RESULT POWER LIMIT SWEEP DATA
        // ═══════════════════════════════════════════════════

        public class ResultBWData
        {
            public double Frequency { get; set; }
            public double Power { get; set; }
            public int Bandwidth { get; set; }
            public double Measured { get; set; }
            public double OutputBW { get; set; }
        }



        // ═══════════════════════════════════════════════════
        //  CONSTRUCTOR
        // ═══════════════════════════════════════════════════
        public Form1()
        {
            InitializeComponent();
            PopulateRTSimInstructions();
        }

        // ═══════════════════════════════════════════════════
        //  FORM LOAD
        // ═══════════════════════════════════════════════════
        private void Form1_Load(object sender, EventArgs e)
        {
            grpSigGenPowerSweep.Enabled = true;
            cmbMeasurement.Items.Clear();
            cmbMeasurement.Items.Add("Input Signal Power");
            cmbMeasurement.Items.Add("Telecommandable Gain");
            cmbMeasurement.Items.Add("Limiter functionality");
            cmbMeasurement.Items.Add("Bandwidth Scaling");
            cmbMeasurement.SelectedIndex = 0;

            cmbPower.Items.Clear();
            cmbPower.Items.Add("-55");
            cmbPower.Items.Add("-26");
            cmbPower.Items.Add("-10");
            cmbPower.SelectedIndex = 0;

            cmbLimiterMode.Items.Clear();
            cmbLimiterMode.Items.Add("Case 1 Sweep (-26 to -10)");
            cmbLimiterMode.Items.Add("Case 2 Fixed (-20)");

            grpTCPowerSelect.Visible = false;
            grp_powerLimit.Visible = false;
            txtLimiterPower.Enabled = false;
            btnStop.Enabled = false;

            LogMessage("System Ready - Please Connect Instruments");
            UpdateMainStatus("Ready - Please Connect Equipment", Color.Blue);
            cmbMode.SelectedIndex = 0;
            cmbBand.SelectedIndex = 0;
        }

        // ═══════════════════════════════════════════════════
        //  COMBOBOX EVENTS
        // ═══════════════════════════════════════════════════
        private void cmbMeasurement_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = cmbMeasurement.SelectedItem != null
                ? cmbMeasurement.SelectedItem.ToString() : "";

            grpTCPowerSelect.Visible = (sel == "Telecommandable Gain");
            grp_powerLimit.Visible = (sel == "Limiter functionality");
            grpSigGenPowerSweep.Visible = (sel == "Input Signal Power");
            grpBWScal.Visible = (sel == "Bandwidth Scaling");
        }

        private void cmbPower_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbPower.SelectedIndex == 0)
            {
                txtGainStart.Text = "0";
                txtGainStop.Text = "45";
                txtGainStep.Text = "5";

            }
            else if (cmbPower.SelectedIndex == 1)
            {
                txtGainStart.Text = "-22";
                txtGainStop.Text = "22";
                txtGainStep.Text = "5";
            }
            else if (cmbPower.SelectedIndex == 2)
            {
                txtGainStart.Text = "0";
                txtGainStop.Text = "-45";
                txtGainStep.Text = "5";
            }

        }

        private void cmbLimiterMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLimiterPower.Enabled = (cmbLimiterMode.SelectedIndex == 1);
            if (cmbLimiterMode.SelectedIndex == 1)
                grp_pwlimitcase2.Visible = true;


            txtLimiterPower.Enabled = (cmbLimiterMode.SelectedIndex == 1);
            if (cmbLimiterMode.SelectedIndex == 1)
                grp_pwlimitcase2.Visible = true;
            if (cmbLimiterMode.SelectedIndex == 0)
            {
                grp_pwlimitcase2.Enabled = false;
            }
            else if (cmbLimiterMode.SelectedIndex == 1)
            {
                grp_pwlimitcase2.Enabled = true;
                
            }

           
        }

        private void txtLimiterPower_TextChanged(object sender, EventArgs e) { }

        private void startGain()
        {
              // input power , freq , gain 
            
        }


        private void RunInputSignalPowerWith1553(string[] freqList, double cableLoss, double inputFreq, int startPower, int stopPower, int stepSize)
        {
            try
            {
                LogMessage("═══ RunInputSignalPower START ═══");
                List<ResultPowerLevelData> results = new List<ResultPowerLevelData>();
                string path = Path.Combine(Application.StartupPath, "inputsignal_power_level.xlsx");

                Excel.Application xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;
                Excel.Workbook wb = xlApp.Workbooks.Add(System.Type.Missing);
                Excel.Worksheet sheet = (Excel.Worksheet)wb.Sheets[1];

                // ✅ Excel Headers
                sheet.Cells[1, 1] = "RF Freq (Hz)";
                sheet.Cells[1, 2] = "Tone Freq (Hz)";
                sheet.Cells[1, 3] = "Set Power (dBm)";
                sheet.Cells[1, 4] = "RT Data (Hex)";
                sheet.Cells[1, 5] = "RT Data (Decimal)";  // ✅ NEW COLUMN

                int row = 2;

                Append1553Output("===== TEST STARTED =====");

                SafeInvoke(delegate()
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 100;
                    progressBar1.Value = 0;
                });

                try
                {
                    EmaceBU69092.aceBCStop(localDevNum);
                    EmaceBU69092.aceFree(localDevNum);
                }
                catch { }

                Thread.Sleep(500);
                Initialize1553();

                int totalSteps = ((stopPower - startPower) / stepSize) + 1;
                int currentStep = 0;

                for (int power = startPower; power <= stopPower; power += stepSize)
                {
                    if (stopRequested)
                        break;

                    currentStep++;

                    double actualPower = power + cableLoss;
                    SendCommand(":SOUR1:POW " + actualPower.ToString());
                    Append1553Output("Signal Generator Power = " + power + " dBm");

                    Thread.Sleep(1000);

                    string rtData = ReceiveRTtoBCData();

                    // ✅ Convert Hex to Decimal
                    string rtDataDecimal = ConvertHexToDecimal(rtData);

                    Append1553Output("Input Power : " + power + " dBm --> RT Data (Hex): " + rtData);
                    Append1553Output("RT Data (Decimal): " + rtDataDecimal);

                    // ✅ Write to Excel
                    sheet.Cells[row, 1] = inputFreq;
                    sheet.Cells[row, 2] = string.Join(",", freqList);
                    sheet.Cells[row, 3] = power;
                    sheet.Cells[row, 4] = rtData;           // Hex
                    sheet.Cells[row, 5] = rtDataDecimal;    // Decimal ✅

                    row++;

                    // ✅ Add to results list
                    results.Add(new ResultPowerLevelData
                    {
                        RFFreq = inputFreq,
                        ToneFreq = string.Join(",", freqList),
                        SetPower = power,
                        RTData = rtData,
                        RTDataDecimal = rtDataDecimal  // ✅ NEW
                    });

                    int progress = (currentStep * 100) / totalSteps;
                    if (progress > 100) progress = 100;

                    SafeInvoke(delegate()
                    {
                        progressBar1.Value = progress;
                        lblProgressText.Text = "Running " + progress + "%";
                    });
                }

                Append1553Output("===== TEST COMPLETED =====");

                wb.SaveAs(path);
                wb.Close(false);
                xlApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                SafeInvoke(delegate()
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = results;
                });

                LogMessage("═══ RunInputSignalPower COMPLETE ═══");
                UpdateMainStatus("Input Signal Power Complete!", Color.FromArgb(0, 130, 0));

                SafeInvoke(delegate()
                {
                    MessageBox.Show("Input Signal Power Complete!\nSaved: " + path,
                        "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
            catch (Exception ex)
            {
                Append1553Output("ERROR : " + ex.Message);
            }
            finally
            {
                Free1553();

                SafeInvoke(delegate()
                {
                    progressBar1.Value = 100;
                    lblProgressText.Text = "Completed";
                });
            }
        }

        private string ConvertHexToDecimal(string hexData)
        {
            if (string.IsNullOrWhiteSpace(hexData))
                return "";

            try
            {
                // Split by space or newline
                string[] hexWords = hexData.Split(new char[] { ' ', '\n', '\r', '\t' },
                                                  StringSplitOptions.RemoveEmptyEntries);

                List<string> decimalValues = new List<string>();

                foreach (string hexWord in hexWords)
                {
                    // Remove any "0x" prefix if present
                    string cleanHex = hexWord.Replace("0x", "").Replace("0X", "").Trim();

                    if (!string.IsNullOrEmpty(cleanHex))
                    {
                        try
                        {
                            // Convert hex to decimal (unsigned 16-bit)
                            ushort decValue = Convert.ToUInt16(cleanHex, 16);
                            decimalValues.Add(decValue.ToString());
                        }
                        catch
                        {
                            // If conversion fails, keep original
                            decimalValues.Add(hexWord);
                        }
                    }
                }

                return string.Join(" ", decimalValues);
            }
            catch (Exception ex)
            {
                return "Conversion Error: " + ex.Message;
            }
        }

        private string ReceiveRTtoBCData()
        {
            bool started = false;
            try
            {
                U16BIT rtAddr = gRtAddress;
                U16BIT subAddr = gSubAddress;
                U16BIT wordCount = 32;
                BcMsgOption busOption = gBusOption;

                // Initialize device
                AceError result = EmaceBU69092.aceInitialize(
                    localDevNum,
                    ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC,
                    0, 0, 0);

                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Initialize Failed: " + result;

                EmaceBU69092.aceBCStop(localDevNum);

                // Delete old objects
                EmaceBU69092.aceBCFrameDelete(localDevNum, RT_MJR);
                EmaceBU69092.aceBCFrameDelete(localDevNum, RT_MNR1);
                EmaceBU69092.aceBCOpCodeDelete(localDevNum, RT_OP1);
                EmaceBU69092.aceBCOpCodeDelete(localDevNum, RT_OP2);
                EmaceBU69092.aceBCMsgDelete(localDevNum, RT_MSG1);
                EmaceBU69092.aceBCDataBlkDelete(localDevNum, RT_DBLK1);

                U16BIT[] txData = new U16BIT[wordCount];

                result = EmaceBU69092.aceBCDataBlkCreate(
                    localDevNum, RT_DBLK1,
                    BcDataBlkSize.ACE_BC_DBLK_SINGLE,
                    txData, wordCount);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "DataBlk Failed: " + result;

                result = EmaceBU69092.aceBCMsgCreateRTtoBC(
                    localDevNum, RT_MSG1, RT_DBLK1,
                    rtAddr, subAddr, wordCount, 0, busOption);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Msg Create Failed: " + result;

                result = EmaceBU69092.aceBCOpCodeCreate(
                    localDevNum, RT_OP1,
                    BcOpcode.ACE_OPCODE_XEQ,
                    BcConditionTest.ACE_CNDTST_ALWAYS,
                    (U16BIT)RT_MSG1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Opcode1 Failed: " + result;

                result = EmaceBU69092.aceBCOpCodeCreate(
                    localDevNum, RT_OP2,
                    BcOpcode.ACE_OPCODE_CAL,
                    BcConditionTest.ACE_CNDTST_ALWAYS,
                    (U16BIT)RT_MNR1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Opcode2 Failed: " + result;

                result = EmaceBU69092.aceBCFrameCreate(
                    localDevNum, RT_MNR1,
                    BcFrameType.ACE_FRAME_MINOR,
                    new S16BIT[] { RT_OP1 }, 1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Minor Frame Failed: " + result;

                result = EmaceBU69092.aceBCFrameCreate(
                    localDevNum, RT_MJR,
                    BcFrameType.ACE_FRAME_MAJOR,
                    new S16BIT[] { RT_OP2 }, 1, 1000, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Major Frame Failed: " + result;

                result = EmaceBU69092.aceBCInstallHBuf(
                    localDevNum, 32 * 1024);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "HBUF Failed: " + result;

                result = EmaceBU69092.aceBCStart(
                    localDevNum, RT_MJR, 1);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "BC Start Failed: " + result;

                started = true;

                Thread.Sleep(600);

                MSGSTRUCT msg = new MSGSTRUCT();
                U32BIT msgCount = 0;
                U32BIT lostCount = 0;

                result = EmaceBU69092.aceBCGetHBufMsgDecoded(
                    localDevNum, ref msg,
                    ref msgCount, ref lostCount,
                    BcMsgLoc.ACE_BC_MSGLOC_NEXT_PURGE);

                // ✅ If data received → display AND return hexData
                if (result == AceError.ACE_ERR_SUCCESS && msgCount > 0)
                {
                    string hexData = RT_DisplayReceivedMessage(ref msg);

                    if (!string.IsNullOrEmpty(hexData))
                        return hexData;   // ← Returns hex to RunInputSignalPowerWith1553
                    else
                        return "RT Response: No Data Words";
                }

                return "No RT Response | Result=" + result
                       + " | Count=" + msgCount;
            }
            catch (Exception ex)
            {
                return "EXCEPTION: " + ex.Message;
            }
            finally
            {
                if (started)
                {
                    EmaceBU69092.aceBCStop(localDevNum);
                    EmaceBU69092.aceFree(localDevNum);
                }
            }
        }

        private string RT_DisplayReceivedMessage(ref MSGSTRUCT msg)
        {
            string bus = ((int)(msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_CHNL) > 1) ? "B" : "A";
            string msgType = EmaceBU69092.aceGetMsgTypeString(msg.wType);
            string timeUs = ((U32BIT)(msg.wTimeTag * 2)).ToString();
            string statusW1 = string.Empty, statusW2 = string.Empty, error = string.Empty;

            Append1553Output(string.Format("RT→BC DATA: TIME={0}us | BUS={1} | TYPE={2} | WC={3}",
                timeUs, bus, msgType, msg.wWordCount));

            if (msg.wStsWrd1Flg == 1) statusW1 = msg.wStsWrd1.ToString("X4");
            if (msg.wStsWrd2Flg == 1) statusW2 = msg.wStsWrd2.ToString("X4");

            // ✅ Build hex data string
            StringBuilder db = new StringBuilder();
            for (U16BIT i = 0; i < msg.wWordCount; i++)
            {
                db.Append(string.Format("{0:X4} ", msg.aDataWrds[i]));
                if ((i + 1) % 8 == 0) db.Append("\n");
            }
            string hexData = db.ToString().Trim();

            if (!string.IsNullOrEmpty(hexData))
                Append1553Output(" DATA: " + hexData);

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
            {
                output.AppendLine();
                output.AppendLine("Data Words:");
                output.AppendLine(hexData);
            }
            if (!string.IsNullOrEmpty(error))
            {
                output.AppendLine();
                output.AppendLine("ERROR: " + error);
            }

            // ✅ Return hexData so caller can use it
            return hexData;
        }

        private void Free1553()
        {
            try
            {
                EmaceBU69092.aceBCStop(
                    localDevNum);

                Thread.Sleep(100);

                EmaceBU69092.aceFree(
                    localDevNum);

                Append1553Output(
                    "1553 Device Freed");
            }
            catch (Exception ex)
            {
                Append1553Output(
                    "Free1553 Error : " +
                    ex.Message);
            }
        }

        private S16BIT localDevNum = 0;

        private void Initialize1553()
        {
            AceError result =
                EmaceBU69092.aceInitialize(
                    localDevNum,
                    ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC,
                    0,
                    0,
                    0);

            if (result != AceError.ACE_ERR_SUCCESS)
            {
                throw new Exception(
                    "1553 Initialization Failed : " +
                    result);
            }

            Append1553Output(
                "1553 Initialized Successfully");
        }

    


        private void Append1553Output(string text)
        {
            SafeInvoke(delegate()
            {
                txt1553Output_1.AppendText(
                    DateTime.Now.ToString("HH:mm:ss") +
                    "  " +
                    text +
                    Environment.NewLine);

                txt1553Output_1.SelectionStart =
                    txt1553Output_1.Text.Length;

                txt1553Output_1.ScrollToCaret();
            });
        }

     


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("Already running.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (!isSigGenConnected)
            //{
            //    MessageBox.Show("Connect Signal Generator first.", "Not Connected",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (!isSpectrumConnected)
            //{
            //    MessageBox.Show("Connect Spectrum Analyzer first.", "Not Connected",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (!is1553Connected)
            {
                MessageBox.Show(
                    "Connect DDC 1553 first.",
                    "Not Connected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string selected = cmbMeasurement.SelectedItem != null
                ? cmbMeasurement.SelectedItem.ToString() : "";

            try
            {
                int carrCount = Convert.ToInt32(txtCarrCount.Text);
                double inputFreq = Convert.ToDouble(txtFreq.Text);
                string[] freqList = txtCarrFreqs.Text.Split(',');
                double cableLoss = ReadCableLoss();
              int modeselected =   cmbMode.SelectedIndex;
                if (selected == "Input Signal Power")
                {
                    int startPower;
                    int stopPower;
                    int stepSize;

                    if (!int.TryParse( txtSigGenPowerStart.Text, out startPower) ||
                        !int.TryParse( txtSigGenPowerStop.Text,out stopPower) ||
                        !int.TryParse( txtSigGenPowerStep.Text, out stepSize))
                    {
                        MessageBox.Show(
                            "Enter valid Start/Stop/Step Power.");
                        return;
                    }

                    if (stepSize <= 0)
                    {
                        MessageBox.Show(
                            "Step must be > 0.");
                        return;
                    }

                    SetMeasurementRunning(true);
                    txtFreq.Text = "2579.511";
                    inputFreq = Convert.ToDouble(txtFreq.Text);
                    //=================================================================
                    //-------NOTE:- DO NOT DECLARE ANY VARIABLE  INSIDE THE THREAD-------------
                    //================================================================
                    Thread t = new Thread(delegate()
                    {


                        try
                        {
                            //---------------------------------
                            // SETUP SIGNAL GENERATOR
                            //---------------------------------
                            SetupSignalGenerator(freqList,
                                carrCount,
                                inputFreq);

                            //---------------------------------
                            // RUN AUTOMATION
                            //---------------------------------
                            RunInputSignalPowerWith1553
                            (
                                freqList,
                                cableLoss,
                                inputFreq,
                                startPower,
                                stopPower,
                                stepSize );
                        }
                        catch (Exception ex)
                        {
                            ShowError(ex.Message);
                        }
                        finally
                        {
                            SetMeasurementRunning(false);
                        }
                    });

                    t.IsBackground = true;
                    t.Start();
                }
                else if (selected == "Telecommandable Gain")
                {
                    if (cmbPower.SelectedItem == null)
                    { MessageBox.Show("Select a Power Level."); return; }

                    if (!is1553Connected)
                    {
                        DialogResult dr = MessageBox.Show(
                            "DDC 1553 not connected.\nContinue WITHOUT 1553?",
                            "1553 Not Connected",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.No) return;
                    }

                    int gainStart, gainStop, gainStep, delayMs;
                    if (!int.TryParse(txtGainStart.Text, out gainStart) ||
                        !int.TryParse(txtGainStop.Text, out gainStop) ||
                        !int.TryParse(txtGainStep.Text, out gainStep) ||
                        !int.TryParse(txtGainDelay.Text, out delayMs))
                    {
                        MessageBox.Show("Enter valid Gain Start/Stop/Step/Delay.");
                        return;
                    }
                    if (gainStep <= 0)
                    { MessageBox.Show("Gain Step must be > 0."); return; }

                    string power = cmbPower.SelectedItem.ToString();
                    SetMeasurementRunning(true);

                    Thread t = new Thread(delegate()
                    {
                        try
                        {
                            RunTCGain(freqList, cableLoss, power,
                                gainStart, gainStop, gainStep, delayMs, modeselected);
                        }
                        catch (Exception ex) { ShowError(ex.Message); }
                        finally { SetMeasurementRunning(false); }
                    });
                    t.IsBackground = true;
                    t.Start();
                }

                    // limiter functionality 
                // limiter functionality 
                else if (selected == "Limiter functionality")
                {
                    int limiter = cmbLimiterMode.SelectedIndex;

                    if (!is1553Connected)
                    {
                        DialogResult dr = MessageBox.Show(
                            "DDC 1553 not connected.\nContinue WITHOUT 1553?",
                            "1553 Not Connected",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.No) return;
                    }
                    int pwrlmtStart, pwrlmtStop, pwrlmtStep, delayMs;
                    if (!int.TryParse(txtlmtStart.Text, out pwrlmtStart) ||
                        !int.TryParse(txtlmtStop.Text, out pwrlmtStop) ||
                        !int.TryParse(txtlmtStep.Text, out pwrlmtStep) ||
                        !int.TryParse(txtlmtDelay.Text, out delayMs))
                    {
                        MessageBox.Show("Enter valid PowerLimit Start/Stop/Step/Delay.");
                        return;
                    }
                    if (pwrlmtStep <= 0)
                    { MessageBox.Show("PowerLimit Step must be > 0."); return; }

                    string selectedPower = "-55";
                    SetMeasurementRunning(true);
                    Thread t = new Thread(delegate()
                    {
                        try
                        {
                            if (limiter == 0)
                                RunLimiter(freqList, cableLoss, modeselected);
                            if (limiter == 1)
                                RunLimiterSweep(freqList, cableLoss,
             selectedPower, pwrlmtStart, pwrlmtStop,
               pwrlmtStep, delayMs, modeselected);

                        }
                        catch (Exception ex) { ShowError(ex.Message); }
                        finally { SetMeasurementRunning(false); }
                    });
                    t.IsBackground = true;
                    t.Start();
                }

                else if (selected == "Bandwidth Scaling")
                {
                     if (!is1553Connected)
                    {
                        DialogResult dr = MessageBox.Show(
                            "DDC 1553 not connected.\nContinue WITHOUT 1553?",
                            "1553 Not Connected",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.No) return;
                    }
                    int pwrlmtStart, pwrlmtStop, pwrlmtStep, delayMs;
                    if (!int.TryParse(txtlmtStart.Text, out pwrlmtStart) ||
                        !int.TryParse(txtlmtStop.Text, out pwrlmtStop) ||
                        !int.TryParse(txtlmtStep.Text, out pwrlmtStep) ||
                        !int.TryParse(txtlmtDelay.Text, out delayMs))
                    {
                        MessageBox.Show("Enter valid Gain Start/Stop/Step/Delay.");
                        return;
                    }
                    if (pwrlmtStep <= 0)
                    { MessageBox.Show("Gain Step must be > 0."); return; }

                    string selectedPower = "-55";
                    SetMeasurementRunning(true);
                    Thread t = new Thread(delegate()
                    {
                        try
                        {
                           // RunLimiter(freqList, cableLoss);

                            RunTCBandwidth(freqList, cableLoss, selectedPower,
                              0, 400, 50, delayMs, modeselected);
                        }
                        catch (Exception ex) { ShowError(ex.Message); }
                        finally { SetMeasurementRunning(false); }
                    });
                    t.IsBackground = true;
                    t.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Start Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopRequested = true;
            UpdateMainStatus("Stop requested...", Color.Orange);
            LogMessage("Stop requested by user.");
        }

        private void SetMeasurementRunning(bool running)
        {
            SafeInvoke(delegate()
            {
                isRunning = running;
                stopRequested = false;
                btnStart.Enabled = !running;
                btnStop.Enabled = running;
                if (!running)
                {
                    progressBar1.Value = 0;
                    lblProgressText.Text = "Done";
                }
            });
        }

        // ═══════════════════════════════════════════════════
        //  SIGNAL GENERATOR SETUP
        // ═══════════════════════════════════════════════════
        private void SetupSignalGenerator( string[] freqList, int carrCount, double inputFreq)
        {
            string[] offset = { "-0.910714286",
                                  "-0.410714286",
                                  "0.089285714",
                                  "0.589285714",
                                  "1.089285714",
                                  "1.589285714",
                                  "-2.035714286" };
            SendCommand(":SOUR1:FREQ:CW " + inputFreq);
            SendCommand(":SOUR1:BB:ARB:MCAR:CARR1:MODE ARB");
            SendCommand(":SOUR1:BB:ARB:MCAR:CARR:COUN " + carrCount);
            for (int i = 1; i <= offset.Length; i++)
            {
                SendCommand(":SOUR1:BB:ARB:MCAR:CARR" + i + ":STAT 1");
                SendCommand(":SOUR1:BB:ARB:MCAR:CARR" + i + ":FREQ "
                    + offset[i - 1] + "MHz");
            }
            SendCommand(":SOUR1:BB:ARB::MCAR:CLO");
            SendCommand(":SOUR1:BB:DM:STAT 1");
        }

        // ═══════════════════════════════════════════════════
        //  PARSE FREQUENCY
        // ═══════════════════════════════════════════════════
        private double ParseFrequency(string value)
        {
            value = value.Trim().ToUpper();
            double mult = 1;
            if (value.Contains("GHZ")) { mult = 1e9; value = value.Replace("GHZ", ""); }
            else if (value.Contains("MHZ")) { mult = 1e6; value = value.Replace("MHZ", ""); }
            else if (value.Contains("KHZ")) { mult = 1e3; value = value.Replace("KHZ", ""); }
            else if (value.Contains("HZ")) { mult = 1; value = value.Replace("HZ", ""); }
            return Convert.ToDouble(value.Trim()) * mult;
        }

        // ═══════════════════════════════════════════════════
        //  GET TC VALUE
        // ═══════════════════════════════════════════════════
        private long GetTcForDbm(int dbm)
        {
            long tc;
          
            return GainTcTable.TryGetValue(dbm, out tc) ? tc : 0;
        }


        // ═══════════════════════════════════════════════════
        //  GET powerlimit VALUE
        // ═══════════════════════════════════════════════════
        private long GetpowerForDbm(int dbm)
        {
            long tc;

            return PowerLimitTable.TryGetValue(dbm, out tc) ? tc : 0;
        }


         // ═══════════════════════════════════════════════════
        //  GET Bandwidth TC  VALUE
        // ═══════════════════════════════════════════════════
        private long GetBWTCForHz(int Hz)
        {
            long tc;

            return BandwidthTable.TryGetValue(Hz, out tc) ? tc : 0;
        }

        // ═══════════════════════════════════════════════════
        //  RUN TC GAIN - MAIN INTEGRATED FUNCTION
        // ═══════════════════════════════════════════════════
        private void RunTCGain(string[] freqList, double cableLoss,
            string selectedPower, int gainStart, int gainStop,
            int gainStep, int delayMs,int modeselect)
        {
            // U16BIT RTSubAddress = 0;
            _1553SubAddress = 0;
            double previousPeak = 0.0;

          
            bool isFirstPeak = true;
            LogMessage("═══ RunTCGain START ═══");
            LogMessage(string.Format(
                "Power={0}dBm Gain={1}to{2} Step={3} Delay={4}ms",
                selectedPower, gainStart, gainStop, gainStep, delayMs));

            List<ResultData> results = new List<ResultData>();
            double power = Convert.ToDouble(selectedPower);

            // ── Excel ──
            string path = Path.Combine(Application.StartupPath, "TC1_gain.xlsx");
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook wb;

            if (File.Exists(path))
            {
                wb = xlApp.Workbooks.Open(path);
            }
            else
            {
                wb = xlApp.Workbooks.Add(System.Type.Missing);
                ((Excel.Worksheet)wb.Sheets[1]).Name = "-55";

                Excel.Worksheet ws2 = (Excel.Worksheet)wb.Sheets.Add(
                    System.Type.Missing, wb.Sheets[1],
                    System.Type.Missing, System.Type.Missing);
                ws2.Name = "-26";

                Excel.Worksheet ws3 = (Excel.Worksheet)wb.Sheets.Add(
                    System.Type.Missing, wb.Sheets[2],
                    System.Type.Missing, System.Type.Missing);
                ws3.Name = "-10";
            }

            Excel.Worksheet sheet = null;
            try { sheet = (Excel.Worksheet)wb.Sheets[selectedPower]; }
            catch
            {
                sheet = (Excel.Worksheet)wb.Sheets.Add(
                    System.Type.Missing,
                    wb.Sheets[wb.Sheets.Count],
                    System.Type.Missing, System.Type.Missing);
                sheet.Name = selectedPower;
            }

            if (sheet.Cells[1, 1].Value == null ||
                sheet.Cells[1, 1].Value.ToString() == "")
            {
                sheet.Cells[1, 1] = "Frequency (Hz)";
                sheet.Cells[1, 2] = "Set Power (dBm)";
                sheet.Cells[1, 3] = "Gain (dBm)";
              //  sheet.Cells[1, 4] = "Gain TC Value";
                sheet.Cells[1, 4] = "Measured (dBm)";
              //  sheet.Cells[1, 6] = "1553 Status";
                sheet.Cells[1, 5] = "Accuracy";
                Excel.Range hdr = sheet.Range["A1", "F1"];
                hdr.Font.Bold = true;
                hdr.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                hdr.Interior.Color = System.Drawing.ColorTranslator.ToOle(
                    Color.FromArgb(0, 70, 140));
            }

            int row = sheet.UsedRange.Rows.Count + 1;
            int gainCount = (int)Math.Floor((double)(gainStop - gainStart) / gainStep) + 1;
            int totalSteps = freqList.Length * gainCount;
            int currentStep = 0;

            SafeInvoke(delegate()
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalSteps;
                progressBar1.Value = 0;
            });

            // ── SigGen initial ──
            SendCommand(":SOUR1:BB:TONE:STAT OFF");
            SendCommand("OUTP ON");
            SendCommand_SPECTRUM(":INIT:CONT ON");

            // ══════════════════════════════════════
            //  OUTER LOOP: Frequencies (1-7 MHz)
            // ══════════════════════════════════════
            foreach (string f in freqList)
            {



                   
                if (stopRequested) break;

                double freq = ParseFrequency(f);

                if (modeselect == 0)
                {
                    if (freq == 2578.6)
                        _1553SubAddress = 1;
                    if (freq == 2579.1)
                        _1553SubAddress = 2;

                    if (freq == 2579.6)
                        _1553SubAddress = 3;

                    if (freq == 2580.1)
                        _1553SubAddress = 4;
                    if (freq == 2580.6)
                        _1553SubAddress = 5;
                    if (freq == 2581.1)
                        _1553SubAddress = 6;
                    if (freq == 2577.475)
                        _1553SubAddress = 13;
                }
                else
                {
                    if (freq == 2578.6)
                        _1553SubAddress = 7;
                    if (freq == 2579.1)
                        _1553SubAddress = 8;

                    if (freq == 2579.6)
                        _1553SubAddress = 9;

                    if (freq == 2580.1)
                        _1553SubAddress = 10;
                    if (freq == 2580.6)
                        _1553SubAddress = 11;
                    if (freq == 2581.1)
                        _1553SubAddress = 12;
                    if (freq == 2577.475)
                        _1553SubAddress = 14;
                }
                double correctedPower = power + cableLoss;
                string freqLabel = (freq / 1e6).ToString("0.###") + " MHz";

                LogMessage("── Frequency: " + freqLabel + " ──");

                SafeInvoke(delegate()
                {
                    lblCurrentFreq.Text = freqLabel;
                    lblCurrentPower.Text = correctedPower.ToString("0.00") + " dBm";
                    lblCurrentGain.Text = "---";
                });
                UpdateMainStatus("Freq=" + freqLabel + " Power=" +
                    correctedPower.ToString("0.00") + "dBm",
                    Color.FromArgb(0, 100, 200));

                SendCommand("POW " + correctedPower);
                SendCommand(":SOUR1:FREQ:CW " + freq);
                Thread.Sleep(300);

                SendCommand_SPECTRUM(":SENS:FREQ:CENT " + freq);
                SendCommand_SPECTRUM(":SENS:FREQ:SPAN 5000000");
                SendCommand_SPECTRUM(":CALC:MARK1 ON");
                Thread.Sleep(300);
                
                // ══════════════════════════════════
                //  INNER LOOP: Gain 0 to 45
                // ══════════════════════════════════
                for (int gain = gainStart; gain <= gainStop; gain += gainStep)
                {
                      
                    if (stopRequested) break;

                    long gainTc = GetTcForDbm(gain);

                    int localGain = gain;
                    long localTc = gainTc;

                    SafeInvoke(delegate()
                    {
                        lblCurrentGain.Text = localGain + " dBm  (TC=" + localTc + ")";
                        txt1553StatusLive.Text = "Sending " + localGain + " dBm via 1553...";
                        txt1553StatusLive.BackColor = Color.LightYellow;
                    });

                    // ── Send via 1553 ──
                    string status1553 = "SKIPPED";
                    if (is1553Connected)
                        status1553 = Send1553Gain(gain, _1553SubAddress);
                    else
                        LogMessage("1553 SKIPPED Gain=" + gain);

                    string localStatus = status1553;
                    SafeInvoke(delegate()
                    {
                        txt1553StatusLive.Text = "Gain " + localGain + ": " + localStatus;
                        txt1553StatusLive.BackColor = (localStatus == "OK")
                            ? Color.FromArgb(200, 255, 200)
                            : Color.FromArgb(255, 220, 220);
                        txt1553CurrentGain.Text = localGain + " dBm  TC=" + localTc;
                        txt1553LastStatus.Text = localStatus;
                        txt1553LastStatus.BackColor = (localStatus == "OK")
                            ? Color.FromArgb(200, 255, 200)
                            : Color.FromArgb(255, 220, 220);
                    });

                    Thread.Sleep(delayMs);
                          
                    // ── Read Spectrum ──
                    SendCommand_SPECTRUM(":CALC:MARK1:MAX");
                    Thread.Sleep(500);
                    double measured = ReadPeakPower();
                    // ─────────────────────────────────────
                    // ACCURACY CALCULATION
                    //
                    // Formula:
                    // (B - 1) - A
                    //
                    // A = previous peak
                    // B = current peak
                    // ─────────────────────────────────────
                    double accuracy = 0.0;

                    if (!isFirstPeak)
                    {
                        accuracy =
                            (measured - 1) - previousPeak;
                    }

                    // Store current peak for next loop
                    previousPeak = measured;

                    isFirstPeak = false;

                
                                       
                    LogMessage(string.Format(
                        "Freq={0} Power={1:0.00}dBm Gain={2}dBm → {3:0.00}dBm",
                        freqLabel, correctedPower, gain, measured));

                    double localMeasured = measured;
                    SafeInvoke(delegate()
                    {
                        spectrum_output.Text = localMeasured.ToString("0.00") + " dBm";
                    });
                 
                    // ── Excel row ──
                    sheet.Cells[row, 1] = freq;
                    sheet.Cells[row, 2] = correctedPower;
                    sheet.Cells[row, 3] = gain;
                    //sheet.Cells[row, 4] = gainTc;
                    sheet.Cells[row, 4] = measured;
                    //sheet.Cells[row, 6] = status1553;
                    sheet.Cells[row, 5] = accuracy;

                    results.Add(new ResultData
                    {
                        Frequency = freq,
                        Power = correctedPower,
                        GainStep = gain,
                   //     GainTcValue = gainTc,
                        Measured = measured,
                     //   Status1553 = status1553
                     Accuracy = accuracy
                    });

                    currentStep++;
                    int localStep = currentStep;
                    int localTotal = totalSteps;
                    SafeInvoke(delegate()
                    {
                        if (localStep <= progressBar1.Maximum)
                            progressBar1.Value = localStep;
                        lblProgressText.Text = localStep + " / " + localTotal;
                    });
                    UpdateUI(correctedPower, measured, freq);
                   
                    row++;
                }
            }

            // ── Save Excel ──
            try
            {
                wb.SaveAs(path);
                wb.Close(false);
                xlApp.Quit();
                LogMessage("Excel saved: " + path);
            }
            catch (Exception ex)
            {
                LogMessage("Excel error: " + ex.Message);
                try { xlApp.Quit(); }
                catch { }
            }

            SafeInvoke(delegate()
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = results;
            });

            LogMessage("═══ RunTCGain COMPLETE ═══");
           // UpdateMainStatus("TC Gain Complete!", Color.FromArgb(0, 130, 0));

            SafeInvoke(delegate()
            {
                MessageBox.Show(
                    "TC Gain Complete!\n\nPower: " + selectedPower + " dBm\n" +
                    "Total Points: " + results.Count + "\nExcel: " + path,
                    "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        double CheckPower(double previousMeasured, double currentMeasured)
        {

            double accuracy = (currentMeasured - 1) - previousMeasured;

            previousMeasured = currentMeasured;
            return accuracy;
        }

        // ═══════════════════════════════════════════════════
        //  DDC 1553 - SEND GAIN
        // ═══════════════════════════════════════════════════
        private string Send1553Gain(int gainDbm, U16BIT rtSubAddress)
        {
            if (!is1553Connected) return "NOT CONNECTED";

            long gainTc = GetTcForDbm(gainDbm);
            uint tc24 = (uint)(gainTc & 0x00FFFFFF);
            ushort w1 = (ushort)((tc24 >> 16) & 0x00FF);
            ushort w2 = (ushort)(tc24 & 0xFFFF);

            LogMessage(string.Format(
                "1553 Send: Gain={0}dBm TC={1} W1=0x{2:X4} W2=0x{3:X4}",
                gainDbm, gainTc, w1, w2));

            return Send1553Core(gainDbm, gainTc, w1, w2,
                _1553DeviceId, _1553RTAddress, rtSubAddress, _1553Bus, 2);
        }

        private string Send1553Core(
            int gainDbm, long gainTc,
            ushort w1, ushort w2,
            S16BIT devNum, U16BIT rtAddr,
            U16BIT subAddr, string busStr, int wordCount)
        {
            bool started = false;
            try
            {
                BcMsgOption busOption = (busStr == "B")
                    ? BcMsgOption.ACE_BCCTRL_CHL_B
                    : BcMsgOption.ACE_BCCTRL_CHL_A;

                U16BIT[] msgWords = new U16BIT[wordCount];
                msgWords[0] = w1;
                if (wordCount > 1) msgWords[1] = w2;

                AceError result = EmaceBU69092.aceInitialize(
                    devNum, ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC, 0, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Init failed: " + result;

                result = EmaceBU69092.aceBCDataBlkCreate(
                    devNum, BC_DBLK3,
                    BcDataBlkSize.ACE_BC_DBLK_SINGLE,
                    msgWords, (U16BIT)wordCount);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "DataBlk failed: " + result;

                result = EmaceBU69092.aceBCMsgCreateBCtoRT(
                    devNum, BC_MSG3, BC_DBLK3,
                    rtAddr, subAddr, (U16BIT)wordCount, 0, busOption);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Msg failed: " + result;

                result = EmaceBU69092.aceBCOpCodeCreate(
                    devNum, BC_OP5, BcOpcode.ACE_OPCODE_XEQ,
                    BcConditionTest.ACE_CNDTST_ALWAYS,
                    (U16BIT)BC_MSG3, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "XEQ failed: " + result;

                result = EmaceBU69092.aceBCOpCodeCreate(
                    devNum, BC_OP6, BcOpcode.ACE_OPCODE_CAL,
                    BcConditionTest.ACE_CNDTST_ALWAYS,
                    (U16BIT)BC_MNR3, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "CAL failed: " + result;

                result = EmaceBU69092.aceBCFrameCreate(
                    devNum, BC_MNR3, BcFrameType.ACE_FRAME_MINOR,
                    new S16BIT[] { BC_OP5 }, 1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "MinorFrame failed: " + result;

                result = EmaceBU69092.aceBCFrameCreate(
                    devNum, BC_MJR3, BcFrameType.ACE_FRAME_MAJOR,
                    new S16BIT[] { BC_OP6 }, 1, 1000, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "MajorFrame failed: " + result;

                result = EmaceBU69092.aceBCInstallHBuf(devNum, 32 * 1024);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "HBuf failed: " + result;

                result = EmaceBU69092.aceBCStart(devNum, BC_MJR3, 1);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "BCStart failed: " + result;

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
                    if ((msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
                        == BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
                    {
                        string err = EmaceBU69092.aceGetBSWErrString(
                            ConfigMode.ACE_MODE_BC, msg.wBlkSts);
                        return "BSW Error: " + err;
                    }

                    string bus = ((int)(msg.wBlkSts &
                        BcBlockStatusWd.ACE_BC_BSW_CHNL) > 1) ? "B" : "A";
                    string timeUs = ((U32BIT)(msg.wTimeTag * 2)).ToString();

                    LogMessage("1553 OK Gain=" + gainDbm + "dBm TC=" +
                        gainTc + " Bus=" + bus + " Time=" + timeUs + "us");

                    int localGain = gainDbm;
                    long localTc = gainTc;
                    SafeInvoke(delegate()
                    {
                        txt1553CurrentGain.Text = localGain + " dBm  TC=" + localTc;
                        txt1553LastStatus.Text = "OK";
                        txt1553LastStatus.BackColor = Color.FromArgb(200, 255, 200);
                        lbl1553ConnInfo.Text = "Last: Gain=" + localGain +
                            "dBm TC=" + localTc + " Bus=" + bus + " Time=" + timeUs + "us";
                    });

                    return "OK";
                }
                return "NoResponse(Result=" + result + " Count=" + msgCount + ")";
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message;
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


        // ═══════════════════════════════════════════════════
        //  DDC 1553 - SEND POWER LIMIT
        // ═══════════════════════════════════════════════════
         private string Send1553PowerLimit(int powerlmtDbm,U16BIT _1553SubAddress)
        {
            _1553RTAddress = 3;
            if (!is1553Connected) return "NOT CONNECTED";

            long pwrlmtTc = GetpowerForDbm(powerlmtDbm);
        //    uint tc8 = (uint)(pwrlmtTc & 0x00FFFFFFF);
            ushort w1 = (ushort)(pwrlmtTc & 0xFFFF);

            LogMessage(string.Format(
                "1553 Send:PowerLimit={0}dBm TC={1} W1=0x{2:X4}",
                powerlmtDbm, pwrlmtTc, w1));

            return Send1553CorePL(powerlmtDbm, pwrlmtTc, w1,
                _1553DeviceId, _1553RTAddress, _1553SubAddress, _1553Bus, 2);
        }

         // ═══════════════════════════════════════════════════
         //  DDC 1553 - SEND POWER LIMIT
         // ═══════════════════════════════════════════════════
         private string Send1553PowerLimitNB(int powerlmtDbm, U16BIT _1553SubAddress)
         {
             if (!is1553Connected) return "NOT CONNECTED";

             long pwrlmtTc = GetpowerForDbm(powerlmtDbm);
             //    uint tc8 = (uint)(pwrlmtTc & 0x00FFFFFFF);
             ushort w1 = (ushort)(pwrlmtTc & 0xFFFF);
             ushort w2 = (ushort)(pwrlmtTc & 0xFFFF);
             ushort w3 = (ushort)(pwrlmtTc & 0xFFFF);
             ushort w4 = (ushort)(pwrlmtTc & 0xFFFF);
             ushort w5 = (ushort)(pwrlmtTc & 0xFFFF);
             ushort w6 = (ushort)(pwrlmtTc & 0xFFFF);

             LogMessage(string.Format(
                 "1553 Send:PowerLimit={0}dBm TC={1} W1=0x{2:X4}",
                 powerlmtDbm, pwrlmtTc, w1));

             return Send1553CorePL(powerlmtDbm, pwrlmtTc, w1,
                 _1553DeviceId, _1553RTAddress, _1553SubAddress, _1553Bus, 2);
         }

        private string Send1553CorePL(
            int gainDbm, long gainTc,
            ushort w1,
            S16BIT devNum, U16BIT rtAddr,
            U16BIT subAddr, string busStr, int wordCount)
        {
            bool started = false;
            try
            {
                BcMsgOption busOption = (busStr == "B")
                    ? BcMsgOption.ACE_BCCTRL_CHL_B
                    : BcMsgOption.ACE_BCCTRL_CHL_A;

                U16BIT[] msgWords = new U16BIT[wordCount];
                msgWords[0] = w1;
                //     if (wordCount > 1) msgWords[1] = w2;

                AceError result = EmaceBU69092.aceInitialize(
                    devNum, ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC, 0, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Init failed: " + result;

                result = EmaceBU69092.aceBCDataBlkCreate(
                    devNum, BC_DBLK3,
                    BcDataBlkSize.ACE_BC_DBLK_SINGLE,
                    msgWords, (U16BIT)wordCount);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "DataBlk failed: " + result;

                result = EmaceBU69092.aceBCMsgCreateBCtoRT(
                    devNum, BC_MSG3, BC_DBLK3,
                    rtAddr, subAddr, (U16BIT)wordCount, 0, busOption);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Msg failed: " + result;

                result = EmaceBU69092.aceBCOpCodeCreate(
                    devNum, BC_OP5, BcOpcode.ACE_OPCODE_XEQ,
                    BcConditionTest.ACE_CNDTST_ALWAYS,
                    (U16BIT)BC_MSG3, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "XEQ failed: " + result;

                result = EmaceBU69092.aceBCOpCodeCreate(
                    devNum, BC_OP6, BcOpcode.ACE_OPCODE_CAL,
                    BcConditionTest.ACE_CNDTST_ALWAYS,
                    (U16BIT)BC_MNR3, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "CAL failed: " + result;

                result = EmaceBU69092.aceBCFrameCreate(
                    devNum, BC_MNR3, BcFrameType.ACE_FRAME_MINOR,
                    new S16BIT[] { BC_OP5 }, 1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "MinorFrame failed: " + result;

                result = EmaceBU69092.aceBCFrameCreate(
                    devNum, BC_MJR3, BcFrameType.ACE_FRAME_MAJOR,
                    new S16BIT[] { BC_OP6 }, 1, 1000, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "MajorFrame failed: " + result;

                result = EmaceBU69092.aceBCInstallHBuf(devNum, 32 * 1024);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "HBuf failed: " + result;

                result = EmaceBU69092.aceBCStart(devNum, BC_MJR3, 1);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "BCStart failed: " + result;

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
                    if ((msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
                        == BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
                    {
                        string err = EmaceBU69092.aceGetBSWErrString(
                            ConfigMode.ACE_MODE_BC, msg.wBlkSts);
                        return "BSW Error: " + err;
                    }

                    string bus = ((int)(msg.wBlkSts &
                        BcBlockStatusWd.ACE_BC_BSW_CHNL) > 1) ? "B" : "A";
                    string timeUs = ((U32BIT)(msg.wTimeTag * 2)).ToString();

                    LogMessage("1553 OK Gain=" + gainDbm + "dBm TC=" +
                        gainTc + " Bus=" + bus + " Time=" + timeUs + "us");

                    int localpwrlmt = gainDbm;
                    long localTc = gainTc;
                    SafeInvoke(delegate()
                    {
                        txt1553CurrentGain.Text = localpwrlmt + " dBm  TC=" + localTc;
                        txt1553LastStatus.Text = "OK";
                        txt1553LastStatus.BackColor = Color.FromArgb(200, 255, 200);
                        lbl1553ConnInfo.Text = "Last: PowerLimit=" + localpwrlmt +
                            "dBm TC=" + localTc + " Bus=" + bus + " Time=" + timeUs + "us";
                    });

                    return "OK";
                }
                return "NoResponse(Result=" + result + " Count=" + msgCount + ")";
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message;
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


        // ═══════════════════════════════════════════════════
        //  DDC 1553 - SEND BANDWIDTH
        // ═══════════════════════════════════════════════════
   private string Send1553BW(int BWHz, U16BIT _1553SubAddress)
        {
            if (!is1553Connected) return "NOT CONNECTED";

            long BWTc = GetBWTCForHz(BWHz);
          //  uint tc8 = (uint)(BWTc & 0x00FFFFFF);
           ushort w1 = (ushort)(0  & 0xFFFF);
           ushort w2 = (ushort)(BWTc & 0x00FF);

            LogMessage(string.Format(
                "1553 Send: Bandwidth={0}dBm BWTc W1=0x{2:X4} W2=0x{3:X4}",
                BWHz, BWTc, w1, w2));

            return Send1553CoreBW(BWHz, BWTc, w1, w2,
                _1553DeviceId, _1553RTAddress, _1553SubAddress, _1553Bus, 2);
        }

        private string Send1553CoreBW(
            int  BWHz,  long BWTc,
            ushort w1, ushort w2,
            S16BIT devNum, U16BIT rtAddr,
            U16BIT subAddr, string busStr, int wordCount)
        {
            bool started = false;
            try
            {
                BcMsgOption busOption = (busStr == "B")
                    ? BcMsgOption.ACE_BCCTRL_CHL_B
                    : BcMsgOption.ACE_BCCTRL_CHL_A;

                U16BIT[] msgWords = new U16BIT[wordCount];
                msgWords[0] = w1;
                if (wordCount > 1) msgWords[1] = w2;

                AceError result = EmaceBU69092.aceInitialize(
                    devNum, ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC, 0, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Init failed: " + result;

                result = EmaceBU69092.aceBCDataBlkCreate(
                    devNum, BC_DBLK3,
                    BcDataBlkSize.ACE_BC_DBLK_SINGLE,
                    msgWords, (U16BIT)wordCount);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "DataBlk failed: " + result;

                result = EmaceBU69092.aceBCMsgCreateBCtoRT(
                    devNum, BC_MSG3, BC_DBLK3,
                    rtAddr, subAddr, (U16BIT)wordCount, 0, busOption);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "Msg failed: " + result;

                result = EmaceBU69092.aceBCOpCodeCreate(
                    devNum, BC_OP5, BcOpcode.ACE_OPCODE_XEQ,
                    BcConditionTest.ACE_CNDTST_ALWAYS,
                    (U16BIT)BC_MSG3, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "XEQ failed: " + result;

                result = EmaceBU69092.aceBCOpCodeCreate(
                    devNum, BC_OP6, BcOpcode.ACE_OPCODE_CAL,
                    BcConditionTest.ACE_CNDTST_ALWAYS,
                    (U16BIT)BC_MNR3, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "CAL failed: " + result;

                result = EmaceBU69092.aceBCFrameCreate(
                    devNum, BC_MNR3, BcFrameType.ACE_FRAME_MINOR,
                    new S16BIT[] { BC_OP5 }, 1, 0, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "MinorFrame failed: " + result;

                result = EmaceBU69092.aceBCFrameCreate(
                    devNum, BC_MJR3, BcFrameType.ACE_FRAME_MAJOR,
                    new S16BIT[] { BC_OP6 }, 1, 1000, 0);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "MajorFrame failed: " + result;

                result = EmaceBU69092.aceBCInstallHBuf(devNum, 32 * 1024);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "HBuf failed: " + result;

                result = EmaceBU69092.aceBCStart(devNum, BC_MJR3, 1);
                if (result != AceError.ACE_ERR_SUCCESS)
                    return "BCStart failed: " + result;

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
                    if ((msg.wBlkSts & BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
                        == BcBlockStatusWd.ACE_BC_BSW_ERRFLG)
                    {
                        string err = EmaceBU69092.aceGetBSWErrString(
                            ConfigMode.ACE_MODE_BC, msg.wBlkSts);
                        return "BSW Error: " + err;
                    }

                    string bus = ((int)(msg.wBlkSts &
                        BcBlockStatusWd.ACE_BC_BSW_CHNL) > 1) ? "B" : "A";
                    string timeUs = ((U32BIT)(msg.wTimeTag * 2)).ToString();
                   
                    LogMessage("1553 OK Gain=" + BWHz + "dBm TC=" +
                        BWTc + " Bus=" + bus + " Time=" + timeUs + "us");

                    int localBW = BWHz;
                    long localTc = BWTc;
                    SafeInvoke(delegate()
                    {
                        txt1553CurrentGain.Text = localBW + " dBm  TC=" + localTc;
                        txt1553LastStatus.Text = "OK";
                        txt1553LastStatus.BackColor = Color.FromArgb(200, 255, 200);
                        lbl1553ConnInfo.Text = "Last: Gain=" + localBW +
                            "dBm TC=" + localTc + " Bus=" + bus + " Time=" + timeUs + "us";
                    });

                    return "OK";
                }
                return "NoResponse(Result=" + result + " Count=" + msgCount + ")";
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message;
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
       

        // ================================================

        // ═══════════════════════════════════════════════════
        //  DDC 1553 CONNECTION BUTTON
        // ═══════════════════════════════════════════════════
        private void btn1553Connect_Click(object sender, EventArgs e)
        {
            try
            {
                short devNum;
                if (!short.TryParse(txt1553DeviceId.Text.Trim(), out devNum))
                {
                    MessageBox.Show("Invalid Device ID.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte rtAddr;
                if (!byte.TryParse(
                    cmb1553RTAddr.SelectedItem != null
                        ? cmb1553RTAddr.SelectedItem.ToString() : "1",
                    out rtAddr))
                {
                    
                    MessageBox.Show("Invalid RT Address.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte subAddr;
                if (!byte.TryParse(
                    cmb1553SubAddr.SelectedItem != null
                        ? cmb1553SubAddr.SelectedItem.ToString() : "1",
                    out subAddr))
                {
                    MessageBox.Show("Invalid Sub Address.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _1553DeviceId = (S16BIT)devNum;
                _1553RTAddress = (U16BIT)rtAddr;
                _1553SubAddress = (U16BIT)subAddr;
                _1553Bus = cmb1553Bus.SelectedItem != null
                    ? cmb1553Bus.SelectedItem.ToString() : "A";

                LogMessage(string.Format(
                    "Testing 1553: DevID={0} RT={1} SA={2} Bus={3}",
                    _1553DeviceId, _1553RTAddress, _1553SubAddress, _1553Bus));

                AceError result = EmaceBU69092.aceInitialize(
                    _1553DeviceId,
                    ConfigAccess.ACE_ACCESS_CARD,
                    ConfigMode.ACE_MODE_BC, 0, 0, 0);

                if (result == AceError.ACE_ERR_SUCCESS)
                {
                    EmaceBU69092.aceFree(_1553DeviceId);
                    is1553Connected = true;

                    pic1553Status.BackColor = Color.Green;
                    lbl1553Status.Text = "Connected OK";
                    lbl1553Status.ForeColor = Color.Green;
                    btn1553Connect.Enabled = false;
                    btn1553Disconnect.Enabled = true;

                    lbl1553ConnInfo.Text = string.Format(
                        "DDC 1553 Connected: DevID={0} RT={1} SA={2} Bus={3}",
                        _1553DeviceId, _1553RTAddress,
                        _1553SubAddress, _1553Bus);
                    lbl1553ConnInfo.ForeColor = Color.Green;

                    UpdateMainStatus(
                        "1553 Connected OK - DevID=" + _1553DeviceId,
                        Color.FromArgb(0, 130, 0));

                    LogMessage(string.Format(
                        "1553 OK: DevID={0} RT={1} SA={2} Bus={3}",
                        _1553DeviceId, _1553RTAddress,
                        _1553SubAddress, _1553Bus));

                    MessageBox.Show(
                        "DDC 1553 Connected!\n\n" +
                        "Device ID   : " + _1553DeviceId + "\n" +
                        "RT Address  : " + _1553RTAddress + "\n" +
                        "Sub Address : " + _1553SubAddress + "\n" +
                        "Bus         : " + _1553Bus,
                        "1553 Connected",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    is1553Connected = false;
                    pic1553Status.BackColor = Color.Red;
                    lbl1553Status.Text = "Failed: " + result;
                    lbl1553Status.ForeColor = Color.Red;
                    lbl1553ConnInfo.Text = "DDC 1553 FAILED: " + result;
                    lbl1553ConnInfo.ForeColor = Color.Red;
                    UpdateMainStatus("1553 Connection Failed", Color.Red);
                    LogMessage("1553 FAILED: " + result);
                    MessageBox.Show("1553 Failed!\nError: " + result,
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                is1553Connected = false;
                pic1553Status.BackColor = Color.Red;
                lbl1553Status.Text = "Exception";
                lbl1553Status.ForeColor = Color.Red;
                LogMessage("1553 Exception: " + ex.Message);
                MessageBox.Show("1553 Exception: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn1553Disconnect_Click(object sender, EventArgs e)
        {
            is1553Connected = false;
            pic1553Status.BackColor = Color.Red;
            lbl1553Status.Text = "Disconnected";
            lbl1553Status.ForeColor = Color.Red;
            btn1553Connect.Enabled = true;
            btn1553Disconnect.Enabled = false;
            lbl1553ConnInfo.Text = "DDC 1553 : Disconnected";
            lbl1553ConnInfo.ForeColor = Color.DarkRed;
            UpdateMainStatus("1553 Disconnected", Color.Orange);
            LogMessage("1553 Disconnected.");
        }

        private void btn1553ClearLog_Click(object sender, EventArgs e)
        {
            rtb1553Log.Clear();
        }


        // ═══════════════════════════════════════════════════
        //  VECTOR NETWORK ANALYZER COMMANDS
        // ═══════════════════════════════════════════════════
        private void SendCommand_VNA(string cmd)
        {
            if (stream_VNA == null || !isVNAConnected)
            {
                LogMessage("ERROR: VNA not connected! CMD=" + cmd);
                return;
            }
            byte[] data = Encoding.ASCII.GetBytes(cmd + "\n");
            stream_VNA.Write(data, 0, data.Length);
            Thread.Sleep(100);
            LogMessage("VNA >> " + cmd);
        }
        // ═══════════════════════════════════════════════════
        //  SIGNAL GENERATOR COMMANDS
        // ═══════════════════════════════════════════════════
        private void SendCommand(string cmd)
        {
            if (stream_SigGen == null || !isSigGenConnected)
            {
                LogMessage("ERROR: SigGen not connected! CMD=" + cmd);
                return;
            }
            byte[] data = Encoding.ASCII.GetBytes(cmd + "\n");
            stream_SigGen.Write(data, 0, data.Length);
            Thread.Sleep(100);
            LogMessage("SIG GEN >> " + cmd);
        }

        // ═══════════════════════════════════════════════════
        //  SPECTRUM COMMANDS
        // ═══════════════════════════════════════════════════
        private void SendCommand_SPECTRUM(string cmd)
        {
            if (stream_Spectrum == null || !isSpectrumConnected)
            {
                LogMessage("ERROR: Spectrum not connected! CMD=" + cmd);
                return;
            }
            byte[] data = Encoding.ASCII.GetBytes(cmd + "\n");
            stream_Spectrum.Write(data, 0, data.Length);
            Thread.Sleep(100);
            LogMessage("SPECTRUM >> " + cmd);
        }

        private string ReadCommand_SPECTRUM(string command)
        {
            try
            {
                byte[] cmdBytes = Encoding.ASCII.GetBytes(command + "\n");
                stream_Spectrum.Write(cmdBytes, 0, cmdBytes.Length);
                byte[] buffer = new byte[4096];
                int bytesRead = stream_Spectrum.Read(buffer, 0, buffer.Length);
                string resp = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                LogMessage("SPECTRUM << " + resp);
                return resp;
            }
            catch { return "0"; }
        }


        //=========================read vna
        private string ReadCommand_VNA(string command)
        {
            try
            {
                byte[] cmdBytes = Encoding.ASCII.GetBytes(command + "\n");
                stream_VNA.Write(cmdBytes, 0, cmdBytes.Length);
                byte[] buffer = new byte[4096];
                int bytesRead = stream_VNA.Read(buffer, 0, buffer.Length);
                string resp = Encoding.ASCII.GetString(
                    buffer, 0, bytesRead).Trim();
                LogMessage("VNA << " + resp);
                return resp;
            }
            catch { return "0"; }
        }

        private double ReadPeakPower()
        {
            try
            {
                SendCommand_SPECTRUM(":CALC:MARK1:MAX");
                Thread.Sleep(300);
                string response = ReadCommand_SPECTRUM(":CALC:MARK1:Y?");
                double power;
                if (double.TryParse(response,
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out power))
                    return power;
                return 0;
            }
            catch { return 0; }
        }

        // ═══════════════════════════════════════════════════
        //  RUN INPUT SIGNAL POWER
        // ═══════════════════════════════════════════════════
        //private void RunInputSignalPower(string [] freqList, double cableLoss, double inputFreq,int startPower, int stopPower, int stepSize, int modeselect)
        //{
        //    LogMessage("═══ RunInputSignalPower START ═══");
        //    List<ResultPowerLevelData> results = new List<ResultPowerLevelData>();
        //    string path = Path.Combine(Application.StartupPath,"inputsignal_power_level.xlsx");

        //    Excel.Application xlApp = new Excel.Application();
        //    xlApp.DisplayAlerts = false;
        //    Excel.Workbook wb = xlApp.Workbooks.Add(System.Type.Missing);
        //    Excel.Worksheet sheet = (Excel.Worksheet)wb.Sheets[1];

        //    sheet.Cells[1, 1] = "RF Freq (Hz)";
        //    sheet.Cells[1, 2] = "Tone Freq (Hz)";
        //    sheet.Cells[1, 3] = "Set Power (dBm)";
        //    sheet.Cells[1, 4] = "Measured (dBm)";

        //    int row = 2;
        // //   double[] tones = { 1e6, 2e6, 3e6, 4e6, 5e6, 6e6, 7e6 };

        //    int totalSteps = ((stopPower - startPower) / stepSize + 1) * freqList.Length;
        //    int currentStep = 0;

        //    SafeInvoke(delegate()
        //    {
        //        progressBar1.Minimum = 0;
        //        progressBar1.Maximum = totalSteps;
        //        progressBar1.Value = 0;
        //        lblCurrentFreq.Text = (inputFreq / 1e6).ToString("0.###") + " MHz";
        //    });

        //    SendCommand(":SOUR1:FREQ:CW " + inputFreq);

        //    for (int p = startPower; p <= stopPower; p += stepSize)
        //    {
        //        if (stopRequested) break;
        //        double corrected = p + cableLoss;
        //        SendCommand("POW " + corrected);

        //        double localCorrected = corrected;
        //        SafeInvoke(delegate()
        //        {
        //            lblCurrentPower.Text = localCorrected.ToString("0.00") + " dBm";
        //        });

        //        foreach (string f in freqList)
        //        {
        //            if (stopRequested) break;
        //            double freq = ParseFrequency(f);


        //            Thread.Sleep(300);

        //            SendCommand_SPECTRUM(":SENS:FREQ:CENT " + (inputFreq + f));
        //            SendCommand_SPECTRUM(":SENS:FREQ:SPAN 2000000");
        //            SendCommand_SPECTRUM(":CALC:MARK1 ON");
        //            Thread.Sleep(300);

        //            double measured = ReadPeakPower();

        //            double localMeasured = measured;
        //            double localTone = freq;
        //            SafeInvoke(delegate()
        //            {
        //                spectrum_output.Text = localMeasured.ToString("0.00") + " dBm";
        //                lblCurrentFreq.Text = (localTone / 1e6).ToString("0") + " MHz tone";
        //            });

        //            sheet.Cells[row, 1] = inputFreq;
        //            sheet.Cells[row, 2] = freq;
        //            sheet.Cells[row, 3] = corrected;
        //            sheet.Cells[row, 4] = measured;

        //            results.Add(new ResultPowerLevelData
        //            {
        //                Frequency = freq,
        //                Power = corrected,
        //                OutputPower = measured
        //            });

        //            UpdateUI(corrected, measured, freq);
        //            currentStep++;
        //            int localStep = currentStep;
        //            int localTotal = totalSteps;
        //            SafeInvoke(delegate()
        //            {
        //                if (localStep <= progressBar1.Maximum)
        //                    progressBar1.Value = localStep;
        //                lblProgressText.Text = localStep + " / " + localTotal;
        //            });
        //            row++;
        //        }
        //    }

        //    wb.SaveAs(path);
        //    wb.Close(false);
        //    xlApp.Quit();

        //    SafeInvoke(delegate()
        //    {
        //        dataGridView1.DataSource = null;
        //        dataGridView1.DataSource = results;
        //    });

        //    LogMessage("═══ RunInputSignalPower COMPLETE ═══");
        //    UpdateMainStatus("Input Signal Power Complete!", Color.FromArgb(0, 130, 0));
        //    SafeInvoke(delegate()
        //    {
        //        MessageBox.Show("Input Signal Power Complete!\nSaved: " + path,
        //            "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    });
        //}

        // ═══════════════════════════════════════════════════
        //  RUN LIMITER
        // ═══════════════════════════════════════════════════
        private void RunLimiter(string[] freqList, double cableLoss, int modeselect)
        {
            U16BIT _1553SubAddress = 0;
            LogMessage("═══ RunLimiter START ═══");
            List<ResultlimitData> results = new List<ResultlimitData>();
            string path = Path.Combine(Application.StartupPath, "Limiter.xlsx");

            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook wb = xlApp.Workbooks.Add(System.Type.Missing);
            Excel.Worksheet sheet = (Excel.Worksheet)wb.Sheets[1];

            sheet.Cells[1, 1] = "Mode";
            sheet.Cells[1, 2] = "Freq (Hz)";
            sheet.Cells[1, 3] = "Power (dBm)";
            sheet.Cells[1, 4] = "PowerLimit (dBm)";
            sheet.Cells[1, 5] = "Measured (dBm)";

            int row = 2;
            string mode = "";

            SafeInvoke(delegate()
            {
                mode = cmbLimiterMode.SelectedItem != null
                    ? cmbLimiterMode.SelectedItem.ToString() : "";
            });

            SendCommand(":SOUR1:BB:TONE:STAT OFF");

            if (mode.Contains("Case 1"))
            {

               

                for (int p = -26; p <= -10; p++)
                {
                    if (stopRequested) break;
                    double corrected = p + cableLoss;
                    SendCommand("POW " + corrected);

                    foreach (string f in freqList)
                    {
                        if (stopRequested) break;
                        double freq = ParseFrequency(f);
                        if (modeselect == 0)
                        {
                            if (freq == 2578.6)
                                _1553SubAddress = 16;
                            if (freq == 2579.1)
                                _1553SubAddress = 16;

                            if (freq == 2579.6)
                                _1553SubAddress =16;

                            if (freq == 2580.1)
                                _1553SubAddress = 16;
                            if (freq == 2580.6)
                                _1553SubAddress = 16;
                            if (freq == 2581.1)
                                _1553SubAddress = 16;
                            if (freq == 2577.475)
                                _1553SubAddress = 18;
                        }
                        else
                        {
                            if (freq == 2578.6)
                                _1553SubAddress = 17;
                            if (freq == 2579.1)
                                _1553SubAddress = 17;

                            if (freq == 2579.6)
                                _1553SubAddress = 17;

                            if (freq == 2580.1)
                                _1553SubAddress = 17;
                            if (freq == 2580.6)
                                _1553SubAddress = 17;
                            if (freq == 2581.1)
                                _1553SubAddress = 17;
                            if (freq == 2577.475)
                                _1553SubAddress = 18;
                        }


                        SendCommand(":SOUR1:FREQ:CW " + freq);

                        SendCommand("OUTP ON");
                        Thread.Sleep(200);
                        SendCommand_SPECTRUM(":SENS:FREQ:CENT " + freq);
                        SendCommand_SPECTRUM(":SENS:FREQ:SPAN 5000000");
                        SendCommand_SPECTRUM(":CALC:MARK1 ON");

                        Thread.Sleep(300);

                        // ─────────────────────────────
                        // SEND POWER LIMIT THROUGH 1553
                        // ─────────────────────────────
                        string status1553 = "SKIPPED";

                        int limiter1553Power = 0;

                        SafeInvoke(delegate()
                        {
                            int.TryParse(txtLimiterPower.Text, out limiter1553Power);
                        });

                        if (is1553Connected)
                        {
                            status1553 = Send1553PowerLimit(limiter1553Power, _1553SubAddress);

                            int localLimiterPower = limiter1553Power;
                            string localStatus = status1553;

                            SafeInvoke(delegate()
                            {
                                //  lblCurrentPower.Text = correctedPower.ToString("0.00") + " dBm";
                                lblCurrentPowerLmt.Text = localLimiterPower.ToString("0.00") + " dBm";
                                txt1553StatusLive.Text =
                                    "Limiter Power Sent : " +
                                    localLimiterPower + " dBm : " +
                                    localStatus;

                                txt1553StatusLive.BackColor =
                                    (localStatus == "OK")
                                    ? Color.LightGreen
                                    : Color.LightPink;

                                //txt1553CurrentGain.Text =
                                //    localLimiterPower +
                                //    " dBm  TC=" +
                                //    GetTcForDbm(localLimiterPower);

                                txt1553LastStatus.Text = localStatus;

                            });

                            LogMessage(
                                "Limiter 1553 Sent ONCE : " +
                                limiter1553Power +
                                " dBm Status=" +
                                status1553);
                        }


                        double measured = ReadPeakPower();

                        double localMeasured = measured;
                        SafeInvoke(delegate()
                        {
                            lblCurrentPower.Text = corrected.ToString("0.00") + " dBm";
                            spectrum_output.Text = localMeasured.ToString("0.00") + " dBm";
                            lblCurrentPowerLmt.Text = txtLimiterPower.Text + " dBm";
                        });


                        results.Add(new ResultlimitData
                        {
                            Frequency = freq,
                            Power = corrected,
                            PowerLimitStep = int.Parse(txtLimiterPower.Text),
                            Measured = measured
                        });

                        sheet.Cells[row, 1] = "Sweep";
                        sheet.Cells[row, 2] = freq;
                        sheet.Cells[row, 3] = corrected;
                        sheet.Cells[row, 4] = int.Parse(txtLimiterPower.Text);
                        sheet.Cells[row, 5] = measured;
                        UpdateUI(corrected, measured, freq);
                        row++;
                    }
                }
            }
            // ── Save Excel ──
            try
            {
                wb.SaveAs(path);
                wb.Close(false);
                xlApp.Quit();
                LogMessage("Excel saved: " + path);
            }
            catch (Exception ex)
            {
                LogMessage("Excel error: " + ex.Message);
                try { xlApp.Quit(); }
                catch { }
            }

            SafeInvoke(delegate()
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = results;
            });

            LogMessage("═══ RunTCPowerLimit COMPLETE ═══");
            UpdateMainStatus("TC PowerLimit Complete!", Color.FromArgb(0, 130, 0));

            SafeInvoke(delegate()
            {
                MessageBox.Show(
                    "TC PowerLimit Complete!\n\nPower: "  + "-26 to -10 dBm\n" +
                    "Total Points: " + results.Count + "\nExcel: " + path,
                    "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });

        }


        // ═══════════════════════════════════════════════════
        //  RUN POWER LIMIT SWEEP
        // ═══════════════════════════════════════════════════

        public void RunLimiterSweep(string[] freqList, double cableLoss,
            string selectedPower, int pwrlmtStart, int pwrlmtStop,
            int pwrlmtStep, int delayMs, int modeSelect)
        {
            double previousPeak = 0.0;
            U16BIT _1553SubAddress = 0;

            bool isFirstPeak = true;
            LogMessage("═══ RunTC Powerlimit START ═══");
            LogMessage(string.Format(
                "Power={0}dBm Power limit={1}to{2} Step={3} Delay={4}ms",
                selectedPower, pwrlmtStart, pwrlmtStop, pwrlmtStep, delayMs));

            List<ResultlimitSweepData> results = new List<ResultlimitSweepData>();
            double power = Convert.ToDouble(selectedPower);

            // ── Excel ──
            string path = Path.Combine(Application.StartupPath, "limterSweep.xlsx");
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook wb;

            if (File.Exists(path))
            {
                wb = xlApp.Workbooks.Open(path);
            }
            else
            {
                wb = xlApp.Workbooks.Add(System.Type.Missing);
                //((Excel.Worksheet)wb.Sheets[1]).Name = "Case2-Power Limit Sweep";

            }

            Excel.Worksheet sheet = null;
            try { sheet = (Excel.Worksheet)wb.Sheets["Case2-Power Limit Sweep"]; }
            catch
            {
                sheet = (Excel.Worksheet)wb.Sheets.Add(
                    System.Type.Missing,
                    wb.Sheets[wb.Sheets.Count],
                    System.Type.Missing, System.Type.Missing);
                sheet.Name = "Case2-Power Limit Sweep";
            }

            if (sheet.Cells[1, 1].Value == null ||
                sheet.Cells[1, 1].Value.ToString() == "")
            {
                sheet.Cells[1, 1] = "Frequency (Hz)";
                sheet.Cells[1, 2] = "Set Power (dBm)";
                sheet.Cells[1, 3] = "PowerLimit (dBm)";
                //  sheet.Cells[1, 4] = "Gain TC Value";
                sheet.Cells[1, 4] = "Measured (dBm)";
                //  sheet.Cells[1, 6] = "1553 Status";
                sheet.Cells[1, 5] = "Accuracy";
                Excel.Range hdr = sheet.Range["A1", "F1"];
                hdr.Font.Bold = true;
                hdr.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                hdr.Interior.Color = System.Drawing.ColorTranslator.ToOle(
                    Color.FromArgb(0, 70, 140));
            }

            int row = sheet.UsedRange.Rows.Count + 1;
            int PowerLimitCount = (int)Math.Floor((double)(pwrlmtStop - pwrlmtStart) / pwrlmtStep) + 1;
            int totalSteps = freqList.Length * PowerLimitCount;
            int currentStep = 0;

            SafeInvoke(delegate()
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalSteps;
                progressBar1.Value = 0;
            });

            // ── SigGen initial ──
            SendCommand(":SOUR1:BB:TONE:STAT OFF");
            SendCommand("OUTP ON");
            SendCommand_SPECTRUM(":INIT:CONT ON");

            // ══════════════════════════════════════
            //  OUTER LOOP: Frequencies (1-7 MHz)
            // ══════════════════════════════════════
            foreach (string f in freqList)
            {
                if (stopRequested) break;

                double freq = ParseFrequency(f);
                if (modeSelect == 0)
                {
                    if (freq == 2578.6)
                        _1553SubAddress = 16;
                    if (freq == 2579.1)
                        _1553SubAddress = 16;

                    if (freq == 2579.6)
                        _1553SubAddress = 16;

                    if (freq == 2580.1)
                        _1553SubAddress = 16;
                    if (freq == 2580.6)
                        _1553SubAddress = 16;
                    if (freq == 2581.1)
                        _1553SubAddress = 16;
                    if (freq == 2577.475)
                        _1553SubAddress = 18;
                }
                else
                {
                    if (freq == 2578.6)
                        _1553SubAddress = 17;
                    if (freq == 2579.1)
                        _1553SubAddress = 17;

                    if (freq == 2579.6)
                        _1553SubAddress = 17;

                    if (freq == 2580.1)
                        _1553SubAddress = 17;
                    if (freq == 2580.6)
                        _1553SubAddress = 17;
                    if (freq == 2581.1)
                        _1553SubAddress = 17;
                    if (freq == 2577.475)
                        _1553SubAddress = 18;
                }

                double correctedPower = power + cableLoss;
                string freqLabel = (freq / 1e6).ToString("0.###") + " MHz";

                LogMessage("── Frequency: " + freqLabel + " ──");

                SafeInvoke(delegate()
                {
                    lblCurrentFreq.Text = freqLabel;
                    lblCurrentPower.Text = correctedPower.ToString("0.00") + " dBm";
                    lblCurrentGain.Text = "---";
                });

                UpdateMainStatus("Freq=" + freqLabel + " Power=" +
                    correctedPower.ToString("0.00") + "dBm",
                    Color.FromArgb(0, 100, 200));

                SendCommand("POW " + correctedPower);
                SendCommand(":SOUR1:FREQ:CW " + freq);
                Thread.Sleep(300);

                SendCommand_SPECTRUM(":SENS:FREQ:CENT " + freq);
                SendCommand_SPECTRUM(":SENS:FREQ:SPAN 5000000");
                SendCommand_SPECTRUM(":CALC:MARK1 ON");
                Thread.Sleep(300);

                // ══════════════════════════════════
                //  INNER LOOP: Gain 0 to 45
                // ══════════════════════════════════
                for (int pwrlmt = pwrlmtStart; pwrlmt <= pwrlmtStop; pwrlmt += pwrlmtStep)
                {
                    if (stopRequested) break;

                    long pwrlmtTc = GetpowerForDbm(pwrlmt);

                    int localpwrlmt = pwrlmt;
                    long localTc = pwrlmtTc;

                    SafeInvoke(delegate()
                    {
                        lblCurrentPowerLmt.Text = localpwrlmt + " dBm  (TC=" + localTc + ")";

                        txt1553StatusLive.Text = "Sending " + localpwrlmt + " dBm via 1553...";
                        txt1553StatusLive.BackColor = Color.LightYellow;
                    });

                    // ── Send via 1553 ──
                    string status1553 = "SKIPPED";
                    if (is1553Connected)
                        status1553 = Send1553PowerLimit(pwrlmt, _1553SubAddress);
                    else
                        LogMessage("1553 SKIPPED Gain=" + pwrlmt);

                    string localStatus = status1553;
                    SafeInvoke(delegate()
                    {
                        txt1553StatusLive.Text = "Power Limit " + localpwrlmt + ": " + localStatus;
                        txt1553StatusLive.BackColor = (localStatus == "OK")
                            ? Color.FromArgb(200, 255, 200)
                            : Color.FromArgb(255, 220, 220);
                        txt1553CurrentGain.Text = localpwrlmt + " dBm  TC=" + localTc;
                        txt1553LastStatus.Text = localStatus;
                        txt1553LastStatus.BackColor = (localStatus == "OK")
                            ? Color.FromArgb(200, 255, 200)
                            : Color.FromArgb(255, 220, 220);
                    });

                    Thread.Sleep(delayMs);

                    // ── Read Spectrum ──
                    SendCommand_SPECTRUM(":CALC:MARK1:MAX");
                    Thread.Sleep(500);
                    double measured = ReadPeakPower();
                    // ─────────────────────────────────────
                    // ACCURACY CALCULATION
                    //
                    // Formula:
                    // (B - 1) - A
                    //
                    // A = previous peak
                    // B = current peak
                    // ─────────────────────────────────────
                    double accuracy = 0.0;

                    if (!isFirstPeak)
                    {
                        accuracy =
                            (measured - 1) - previousPeak;
                    }

                    // Store current peak for next loop
                    previousPeak = measured;

                    isFirstPeak = false;



                    LogMessage(string.Format(
                        "Freq={0} Power={1:0.00}dBm PowerLimit={2}dBm → {3:0.00}dBm",
                        freqLabel, correctedPower, pwrlmt, measured));

                    double localMeasured = measured;
                    SafeInvoke(delegate()
                    {
                        spectrum_output.Text = localMeasured.ToString("0.00") + " dBm";
                    });

                    // ── Excel row ──
                    sheet.Cells[row, 1] = freq;
                    sheet.Cells[row, 2] = correctedPower;
                    sheet.Cells[row, 3] = pwrlmt;
                    //sheet.Cells[row, 4] = gainTc;
                    sheet.Cells[row, 4] = measured;
                    //sheet.Cells[row, 6] = status1553;
                    sheet.Cells[row, 5] = accuracy;

                    results.Add(new ResultlimitSweepData
                    {
                        Frequency = freq,
                        Power = correctedPower,
                        PowerLimitStep = pwrlmt,
                        //     GainTcValue = gainTc,
                        Measured = measured,
                        //   Status1553 = status1553
                        Accuracy = accuracy
                    });

                    currentStep++;
                    int localStep = currentStep;
                    int localTotal = totalSteps;
                    SafeInvoke(delegate()
                    {
                        if (localStep <= progressBar1.Maximum)
                            progressBar1.Value = localStep;
                        lblProgressText.Text = localStep + " / " + localTotal;
                    });
                    UpdateUI(correctedPower, measured, freq);

                    row++;
                }
            }

            // ── Save Excel ──
            try
            {
                wb.SaveAs(path);
                wb.Close(false);
                xlApp.Quit();
                LogMessage("Excel saved: " + path);
            }
            catch (Exception ex)
            {
                LogMessage("Excel error: " + ex.Message);
                try { xlApp.Quit(); }
                catch { }
            }

            SafeInvoke(delegate()
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = results;
            });

            LogMessage("═══ RunTCPowerLimit COMPLETE ═══");
            UpdateMainStatus("TC PowerLimit Complete!", Color.FromArgb(0, 130, 0));

            SafeInvoke(delegate()
            {
                MessageBox.Show(
                    "TC PowerLimit Complete!\n\nPower: " + selectedPower + " dBm\n" +
                    "Total Points: " + results.Count + "\nExcel: " + path,
                    "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }


        // ══════════════════════════════════════
        // BANDWIDTH SCALING  
        // ══════════════════════════════════════

        private void RunTCBandwidth(string[] freqList, double cableLoss,
                    string selectedPower, int bwStart, int bwStop,
                    int bwStep, int delayMs, int modeSelect)
        {
            double previousPeak = 0.0;
            bool isFirstPeak = true;
            U16BIT _1553SubAddress = 0;

            LogMessage("═══ RunTCBandwidth START ═══");
            LogMessage(string.Format(
                "Power={0}dBm BW={1}to{2} Step={3} Delay={4}ms",
                selectedPower, bwStart, bwStop, bwStep, delayMs));

            List<ResultBWData> results = new List<ResultBWData>();
            double power = Convert.ToDouble(selectedPower);

            // ── Excel ──
            string path = Path.Combine(Application.StartupPath, "TC1_bandwidth.xlsx");
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            Excel.Workbook wb;

            if (File.Exists(path))
            {
                wb = xlApp.Workbooks.Open(path);
            }
            else
            {
                wb = xlApp.Workbooks.Add(System.Type.Missing);

                ((Excel.Worksheet)wb.Sheets[1]).Name = "-55";

                Excel.Worksheet ws2 = (Excel.Worksheet)wb.Sheets.Add(
                    System.Type.Missing, wb.Sheets[1],
                    System.Type.Missing, System.Type.Missing);
                ws2.Name = "-26";

            
            }

            Excel.Worksheet sheet = null;
            try
            {
                sheet = (Excel.Worksheet)wb.Sheets[selectedPower];
            }
            catch
            {
                sheet = (Excel.Worksheet)wb.Sheets.Add(
                    System.Type.Missing,
                    wb.Sheets[wb.Sheets.Count],
                    System.Type.Missing, System.Type.Missing);
                sheet.Name = selectedPower;
            }

            // ── Header ──
            if (sheet.Cells[1, 1].Value == null || sheet.Cells[1, 1].Value.ToString() == "")
            {
                sheet.Cells[1, 1] = "Frequency (Hz)";
                sheet.Cells[1, 2] = "Set Power (dBm)";
                sheet.Cells[1, 3] = "Bandwidth (Hz)";
                sheet.Cells[1, 4] = "Measured (dBm)";
                sheet.Cells[1, 5] = "OutputBW (Hz)";

                Excel.Range hdr = sheet.Range["A1", "E1"];
                hdr.Font.Bold = true;
                hdr.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
                hdr.Interior.Color = System.Drawing.ColorTranslator.ToOle(
                    Color.FromArgb(0, 70, 140));
            }

            int row = sheet.UsedRange.Rows.Count + 1;
            int bwCount = (int)Math.Floor((double)(bwStop - bwStart) / bwStep) + 1;
            int totalSteps = freqList.Length * bwCount;
            int currentStep = 0;

            SafeInvoke(delegate()
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalSteps;
                progressBar1.Value = 0;
            });

            // ── Instrument init ──
            SendCommand(":SOUR1:BB:TONE:STAT OFF");
            SendCommand("OUTP ON");
            SendCommand_SPECTRUM(":INIT:CONT ON");

            // ══════════════════════════════════════
            // OUTER LOOP: Frequency
            // ══════════════════════════════════════
            foreach (string f in freqList)
            {
                if (stopRequested) break;

                double freq = ParseFrequency(f);
                   if (modeSelect == 0)
                {
                    if (freq == 2578.6)
                        _1553SubAddress = 1;
                    if (freq == 2579.1)
                        _1553SubAddress = 2;

                    if (freq == 2579.6)
                        _1553SubAddress = 3;

                    if (freq == 2580.1)
                        _1553SubAddress = 4;
                    if (freq == 2580.6)
                        _1553SubAddress = 5;
                    if (freq == 2581.1)
                        _1553SubAddress = 6;
                    if (freq == 2577.475)
                        _1553SubAddress = 13;
                }
                else
                {
                    if (freq == 2578.6)
                        _1553SubAddress = 7;
                    if (freq == 2579.1)
                        _1553SubAddress = 8;

                    if (freq == 2579.6)
                        _1553SubAddress = 9;

                    if (freq == 2580.1)
                        _1553SubAddress = 10;
                    if (freq == 2580.6)
                        _1553SubAddress = 11;
                    if (freq == 2581.1)
                        _1553SubAddress = 12;
                    if (freq == 2577.475)
                        _1553SubAddress = 14;
                }


                double correctedPower = power + cableLoss;
                string freqLabel = (freq / 1e6).ToString("0.###") + " MHz";

                LogMessage("── Frequency: " + freqLabel + " ──");

                SafeInvoke(delegate()
                {
                    lblCurrentFreq.Text = freqLabel;
                    lblCurrentPower.Text = correctedPower.ToString("0.00") + " dBm";
                    txtBW.Text = "---";
                });

                UpdateMainStatus(
                    "Freq=" + freqLabel + " Power=" + correctedPower.ToString("0.00") + " dBm",
                    Color.FromArgb(0, 100, 200));

                SendCommand("POW " + correctedPower);
                SendCommand(":SOUR1:FREQ:CW " + freq);
                Thread.Sleep(300);

                SendCommand_SPECTRUM(":SENS:FREQ:CENT " + freq);
                SendCommand_SPECTRUM(":SENS:FREQ:SPAN 5000000");
                SendCommand_SPECTRUM(":CALC:MARK1 ON");
                Thread.Sleep(300);

                // ══════════════════════════════════════
                // INNER LOOP: Bandwidth sweep
                // ══════════════════════════════════════
                for (int bw = bwStart; bw <= bwStop; bw += bwStep)
                {
                    if (stopRequested) break;

                    long bwTc = GetBWTCForHz(bw);

                    int localBw = bw;
                    long localTc = bwTc;

                    SafeInvoke(delegate()
                    {
                        lblCurrBW.Text = localBw + " Hz (TC=" + localTc + ")";
                        txt1553StatusLive.Text = "Sending BW " + localBw + "...";
                        txt1553StatusLive.BackColor = Color.LightYellow;
                    });

                    // ── 1553 ──
                    string status1553 = "SKIPPED";
                    if (is1553Connected)
                        status1553 = Send1553BW(bw, _1553SubAddress);
                    else
                        LogMessage("1553 SKIPPED BW=" + bw);

                    SafeInvoke(delegate()
                    {
                        txt1553StatusLive.Text = "BW " + localBw + ": " + status1553;
                        txt1553StatusLive.BackColor = (status1553 == "OK")
                            ? Color.FromArgb(200, 255, 200)
                            : Color.FromArgb(255, 220, 220);

                        txt1553LastStatus.Text = status1553;
                        txt1553LastStatus.BackColor = (status1553 == "OK")
                            ? Color.FromArgb(200, 255, 200)
                            : Color.FromArgb(255, 220, 220);
                    });

                    Thread.Sleep(delayMs);

                    // ── Spectrum read ──
                    SendCommand_SPECTRUM(":CALC:MARK1:MAX");
                    Thread.Sleep(500);
                    double measured = ReadPeakPower();

                    // ── Accuracy ──
                    double accuracy = 0.0;

                    if (!isFirstPeak)
                    {
                        accuracy = measured - previousPeak;
                    }

                    previousPeak = measured;
                    isFirstPeak = false;

                    LogMessage(string.Format(
                        "Freq={0} BW={1}Hz → {2:0.00} dBm",
                        freqLabel, bw, measured));

                    SafeInvoke(delegate()
                    {
                        spectrum_output.Text = measured.ToString("0.00") + " dBm";
                    });

                    // ── Excel ──
                    sheet.Cells[row, 1] = freq;
                    sheet.Cells[row, 2] = correctedPower;
                    sheet.Cells[row, 3] = bw;
                    sheet.Cells[row, 4] = measured;
                    sheet.Cells[row, 5] = measured;

                    results.Add(new ResultBWData
                    {
                        Frequency = freq,
                        Power = correctedPower,
                        Bandwidth = bw,   // reused field for BW
                        Measured = measured,
                        OutputBW = measured
                    });

                    currentStep++;
                    int localStep = currentStep;
                    int localTotal = totalSteps;

                    SafeInvoke(delegate()
                    {
                        if (localStep <= progressBar1.Maximum)
                            progressBar1.Value = localStep;

                        lblProgressText.Text = localStep + " / " + localTotal;
                    });

                    UpdateUI(correctedPower, measured, freq);
                    row++;
                }
            }

            // ── Save Excel ──
            try
            {
                wb.SaveAs(path);
                wb.Close(false);
                xlApp.Quit();
                LogMessage("Excel saved: " + path);
            }
            catch (Exception ex)
            {
                LogMessage("Excel error: " + ex.Message);
                try { xlApp.Quit(); }
                catch { }
            }

            SafeInvoke(delegate()
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = results;
            });

            LogMessage("═══ RunTCBandwidth COMPLETE ═══");
            UpdateMainStatus("Bandwidth Sweep Complete!", Color.FromArgb(0, 130, 0));

            SafeInvoke(delegate()
            {
                MessageBox.Show(
                    "Bandwidth Sweep Complete!\n\nPower: " + selectedPower + " dBm\n" +
                    "Total Points: " + results.Count + "\nExcel: " + path,
                    "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }


        // ═══════════════════════════════════════════════════
        //  CABLE LOSS
        // ═══════════════════════════════════════════════════
        private double ReadCableLoss()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "cableloss.xlsx");
                if (!File.Exists(path))
                {
                    LogMessage("cableloss.xlsx not found, using 0 dB");
                    return 0;
                }
                Excel.Application xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;
                Excel.Workbook wb = xlApp.Workbooks.Open(path);
                Excel.Worksheet sheet = (Excel.Worksheet)wb.Sheets[1];
                double loss = 0;
                if (sheet.Cells[1, 1].Value != null)
                    loss = Convert.ToDouble(sheet.Cells[1, 1].Value);
                wb.Close(false);
                xlApp.Quit();
                return loss;
            }
            catch
            {
                LogMessage("Cable loss read failed, using 0 dB");
                return 0;
            }
        }

        // ═══════════════════════════════════════════════════
        //  UI HELPERS
        // ═══════════════════════════════════════════════════
        private void SafeInvoke(MethodInvoker action)
        {
            if (this.InvokeRequired)
                this.Invoke(action);
            else
                action();
        }

        private void UpdateUI(double power, double measured, double freq)
        {
            SafeInvoke(delegate()
            {
                txtPower.Text = power.ToString("0.00");
                txtOutPower.Text = measured.ToString("0.00");
                txtOutFreq.Text = freq.ToString("0");
            });
        }

        private void UpdateMainStatus(string message, Color color)
        {
            SafeInvoke(delegate()
            {
                lblMainStatus.Text = "Status: " + message;
                lblMainStatus.ForeColor = color;
            });
        }

        private void LogMessage(string message)
        {
            string entry = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message;
            SafeInvoke(delegate()
            {
                if (rtb1553Log != null)
                {
                    rtb1553Log.AppendText(entry + "\r\n");
                    rtb1553Log.ScrollToCaret();
                }
            });
        }

        private void ShowError(string message)
        {
            SafeInvoke(delegate()
            {
                MessageBox.Show("Error: " + message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage("ERROR: " + message);
            });
        }

        // ═══════════════════════════════════════════════════
        //  VALIDATE IP/PORT
        // ═══════════════════════════════════════════════════
        private bool ValidateIPPort(string ip, int port)
        {
            IPAddress ipAddr;
            if (!IPAddress.TryParse(ip, out ipAddr))
            {
                MessageBox.Show("Invalid IP: " + ip, "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (port < 1 || port > 65535)
            {
                MessageBox.Show("Invalid Port (1-65535)", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ═══════════════════════════════════════════════════
        //  SIGNAL GENERATOR CONNECTION
        // ═══════════════════════════════════════════════════
        private void btnSigGenConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtSigGenIP.Text.Trim();
                int port = int.Parse(txtSigGenPort.Text.Trim());
                if (!ValidateIPPort(ip, port)) return;

                UpdateMainStatus("Connecting to Signal Generator...", Color.Orange);
                tcpClient_SigGen = new TcpClient();
                tcpClient_SigGen.Connect(ip, port);
                stream_SigGen = tcpClient_SigGen.GetStream();

                lblSigGenStatus.Text = "Connected";
                lblSigGenStatus.ForeColor = Color.Green;
                picSigGenStatus.BackColor = Color.Green;
                btnSigGenConnect.Enabled = false;
                btnSigGenDisconnect.Enabled = true;
                isSigGenConnected = true;

                lblSigGenConnInfo.Text = "Signal Generator : Connected - IP:" +
                                              ip + " Port:" + port;
                lblSigGenConnInfo.ForeColor = Color.Green;
                UpdateMainStatus("Signal Generator Connected", Color.Green);
                LogMessage("SigGen Connected IP:" + ip + " Port:" + port);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SigGen Error: " + ex.Message,
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblSigGenStatus.Text = "Failed";
                lblSigGenStatus.ForeColor = Color.Red;
                picSigGenStatus.BackColor = Color.Red;
                LogMessage("ERROR SigGen: " + ex.Message);
            }
        }

        private void btnSigGenDisconnect_Click(object sender, EventArgs e)
        {
            if (stream_SigGen != null) { stream_SigGen.Close(); stream_SigGen = null; }
            if (tcpClient_SigGen != null) { tcpClient_SigGen.Close(); tcpClient_SigGen = null; }
            isSigGenConnected = false;
            lblSigGenStatus.Text = "Disconnected";
            lblSigGenStatus.ForeColor = Color.Red;
            picSigGenStatus.BackColor = Color.Red;
            btnSigGenConnect.Enabled = true;
            btnSigGenDisconnect.Enabled = false;
            lblSigGenConnInfo.Text = "Signal Generator : Not Connected";
            lblSigGenConnInfo.ForeColor = Color.DarkRed;
            UpdateMainStatus("Signal Generator Disconnected", Color.Orange);
            LogMessage("SigGen Disconnected.");
        }

        // ═══════════════════════════════════════════════════
        //  SPECTRUM CONNECTION
        // ═══════════════════════════════════════════════════
        private void btnSpectrumConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtSpectrumIP.Text.Trim();
                int port = int.Parse(txtSpectrumPort.Text.Trim());
                if (!ValidateIPPort(ip, port)) return;

                UpdateMainStatus("Connecting to Spectrum...", Color.Orange);
                tcpClient_Spectrum = new TcpClient();
                tcpClient_Spectrum.Connect(ip, port);
                stream_Spectrum = tcpClient_Spectrum.GetStream();

                lblSpectrumStatus.Text = "Connected";
                lblSpectrumStatus.ForeColor = Color.Green;
                picSpectrumStatus.BackColor = Color.Green;
                btnSpectrumConnect.Enabled = false;
                btnSpectrumDisconnect.Enabled = true;
                isSpectrumConnected = true;

            //    lblSpectrumConnInfo.Text = "Spectrum : Connected - IP:" +
                                              //  ip + " Port:" + port;
             //   lblSpectrumConnInfo.ForeColor = Color.Green;
                UpdateMainStatus("Spectrum Connected", Color.Green);
                LogMessage("Spectrum Connected IP:" + ip + " Port:" + port);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Spectrum Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblSpectrumStatus.Text = "Failed";
                lblSpectrumStatus.ForeColor = Color.Red;
                picSpectrumStatus.BackColor = Color.Red;
                LogMessage("ERROR Spectrum: " + ex.Message);
            }
        }

        private void btnSpectrumDisconnect_Click(object sender, EventArgs e)
        {
            if (stream_Spectrum != null)
            { stream_Spectrum.Close(); stream_Spectrum = null; }
            if (tcpClient_Spectrum != null)
            { tcpClient_Spectrum.Close(); tcpClient_Spectrum = null; }
            isSpectrumConnected = false;
            lblSpectrumStatus.Text = "Disconnected";
            lblSpectrumStatus.ForeColor = Color.Red;
            picSpectrumStatus.BackColor = Color.Red;
            btnSpectrumConnect.Enabled = true;
            btnSpectrumDisconnect.Enabled = false;
            //lblSpectrumConnInfo.Text = "Spectrum : Not Connected";
            //lblSpectrumConnInfo.ForeColor = Color.DarkRed;
            UpdateMainStatus("Spectrum Disconnected", Color.Orange);
            LogMessage("Spectrum Disconnected.");
        }

        // ═══════════════════════════════════════════════════
        //  VNA CONNECTION
        // ═══════════════════════════════════════════════════
        private void btnVNAConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtVNAIP.Text.Trim();
                int port = int.Parse(txtVNAPort.Text.Trim());
                if (!ValidateIPPort(ip, port)) return;

                tcpClient_VNA = new TcpClient();
                tcpClient_VNA.Connect(ip, port);
                stream_VNA = tcpClient_VNA.GetStream();

                lblVNAStatus.Text = "Connected";
                lblVNAStatus.ForeColor = Color.Green;
                picVNAStatus.BackColor = Color.Green;
                btnVNAConnect.Enabled = false;
                btnVNADisconnect.Enabled = true;
                isVNAConnected = true;

                //lblVNAConnInfo.Text = "VNA : Connected - IP:" + ip + " Port:" + port;
                //lblVNAConnInfo.ForeColor = Color.Green;
                UpdateMainStatus("VNA Connected", Color.Green);
                LogMessage("VNA Connected IP:" + ip + " Port:" + port);
            }
            catch (Exception ex)
            {
                MessageBox.Show("VNA Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage("ERROR VNA: " + ex.Message);
            }
        }

        private void btnVNADisconnect_Click(object sender, EventArgs e)
        {
            if (stream_VNA != null) { stream_VNA.Close(); stream_VNA = null; }
            if (tcpClient_VNA != null) { tcpClient_VNA.Close(); tcpClient_VNA = null; }
            isVNAConnected = false;
            lblVNAStatus.Text = "Disconnected";
            lblVNAStatus.ForeColor = Color.Red;
            picVNAStatus.BackColor = Color.Red;
            btnVNAConnect.Enabled = true;
            btnVNADisconnect.Enabled = false;
            //lblVNAConnInfo.Text = "VNA : Not Connected";
            //lblVNAConnInfo.ForeColor = Color.DarkRed;
            UpdateMainStatus("VNA Disconnected", Color.Orange);
            LogMessage("VNA Disconnected.");
        }

        // ── button1 (DDC Card connect = same as 1553) ──
        private void button1_Click(object sender, EventArgs e)
        {
            btn1553Connect_Click(sender, e);
        }

        // ═══════════════════════════════════════════════════
        //  FORM CLOSING
        // ═══════════════════════════════════════════════════
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            stopRequested = true;
            if (stream_SigGen != null)
            { try { stream_SigGen.Close(); } catch { } }
            if (tcpClient_SigGen != null)
            { try { tcpClient_SigGen.Close(); } catch { } }
            if (stream_Spectrum != null)
            { try { stream_Spectrum.Close(); } catch { } }
            if (tcpClient_Spectrum != null)
            { try { tcpClient_Spectrum.Close(); } catch { } }
            if (stream_VNA != null)
            { try { stream_VNA.Close(); } catch { } }
            if (tcpClient_VNA != null)
            { try { tcpClient_VNA.Close(); } catch { } }
            base.OnFormClosing(e);
        }

        private void lblCurrentPowerLmt_Click(object sender, EventArgs e)
        {
        
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void read_BW()
        {
            SendCommand_VNA("OUTP ON");

            SendCommand_VNA("CALC1:MEAS1:MARK2 ON");
            SendCommand_VNA("CALC1:MEAS1:MARK3 ON");
            freq1 = ReadCommand_VNA("CALC1:MEAS1:MARK2:X?");
            freq2 = ReadCommand_VNA("CALC1:MEAS1:MARK3:X?");

            txt1553Output_1.AppendText("Mark2 : " + freq1 + "\n");
            txt1553Output_1.AppendText("Mark3:  " + freq2);
            fre1 = double.Parse(freq1.Substring(0, 6));

            fre2 = double.Parse(freq2.Substring(0, 6));
            res = fre2 - fre1;
            txt1553Output_1.AppendText("ResultBWData" + res);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SafeInvoke(delegate()
            {
                for (int i = 1; i <= 7; i++)
                {
                    SendCommand_VNA("MMEM:LOAD 'D:/dpu calfiles/cal_bw"+i+".csa'");

                    read_BW();
                }
                 txt1553Output_1.SelectionStart =
                   txt1553Output_1.Text.Length;

               txt1553Output_1.ScrollToCaret(); 
         });
        }

        private void PopulateRTSimInstructions()
        {
            // Left panel - Setup steps
            AddInstructionLabel(pnlRTSimInstLeft, "▶ Setup & Start", 0, 0, true);
            AddInstructionBox(pnlRTSimInstLeft, "1. Set Device ID (usually 0)", 0, 25);
            AddInstructionBox(pnlRTSimInstLeft, "2. Choose RT Address and Sub Address", 0, 65);
            AddInstructionBox(pnlRTSimInstLeft, "3. Select Bus A or B", 0, 105);
            AddInstructionBox(pnlRTSimInstLeft, "4. Type HEX data or click Quick Test Pattern", 0, 145);
            AddInstructionBox(pnlRTSimInstLeft, "5. Click 'Start RT Simulator'", 0, 185);

            // Right panel - Testing steps
            //AddInstructionLabel(pnlRTSimInstRight, "▶ Test & Update Live", 0, 0, true);
            //AddInstructionBox(pnlRTSimInstRight, "6. Go to RT→BC tab → click 'Receive Data'", 0, 25);
            //AddInstructionBox(pnlRTSimInstRight, "7. Change data: type new HEX or pick pattern → Update", 0, 65);
            //AddInstructionBox(pnlRTSimInstRight, "8. Receive again — NEW data appears", 0, 105);
            //AddInstructionBox(pnlRTSimInstRight, "9. Click 'Stop RT Simulator' when done", 0, 145);

            Panel notePanel = new Panel();
            notePanel.BackColor = Color.FromArgb(232, 245, 233);
            notePanel.BorderStyle = BorderStyle.FixedSingle;
            notePanel.Location = new Point(0, 195);
            notePanel.Size = new Size(440, 60);
            //pnlRTSimInstRight.Controls.Add(notePanel);

            Label lblNote = new Label();
            lblNote.Text = "✔ Note: DDC card acts as BOTH BC and RT simultaneously\n(RTMT mode). No external RT hardware needed.";
            lblNote.Font = new Font("Lucida Sans", 8);
            lblNote.ForeColor = Color.FromArgb(46, 125, 50);
            lblNote.Location = new Point(5, 5);
            lblNote.Size = new Size(430, 50);
            notePanel.Controls.Add(lblNote);
        }

        private void AddInstructionLabel(Panel parent, string text, int x, int y, bool isBold)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(440, 20);
            lbl.Font = new Font("Lucida Sans", 10, isBold ? FontStyle.Bold : FontStyle.Regular);
            lbl.ForeColor = Color.Navy;
            parent.Controls.Add(lbl);
        }

        private void AddInstructionBox(Panel parent, string text, int x, int y)
        {
            Panel box = new Panel();
            box.BackColor = Color.FromArgb(245, 245, 255);
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Location = new Point(x, y);
            box.Size = new Size(440, 35);
            parent.Controls.Add(box);

            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Lucida Sans", 9);
            lbl.Location = new Point(5, 8);
            lbl.Size = new Size(430, 20);
            box.Controls.Add(lbl);
        }
        // ═════════════════════════════════════════════════════
        //  RT SIMULATOR EVENT HANDLERS
        // ═════════════════════════════════════════════════════

    //    private void RTSim_LoadDefault_Click(object sender, EventArgs e)
    //    {
    //        ushort[] d = new ushort[]
    //{
    //    0x1234,0x5678,0xABCD,0xEF01,0x2345,0x6789,0xBCDE,0xF012,
    //    0x3456,0x789A,0xCDEF,0x0123,0x4567,0x89AB,0xCDEF,0x0123,
    //    0x4567,0x89AB,0xCDEF,0x0123,0x4567,0x89AB,0xCDEF,0x0123,
    //    0x4567,0x89AB,0xCDEF,0x0123,0x4567,0x89AB,0xCDEF,0x0123
    //};
    //        StringBuilder sb = new StringBuilder();
    //        for (int i = 0; i < d.Length; i++)
    //        {
    //            sb.Append(d[i].ToString("X4"));
    //            if (i < d.Length - 1) sb.Append(" ");
    //        }
    //        txtRTSimResponseData.Text = sb.ToString();
    //        //UpdateStatus("RT Simulator: Default data loaded.");
    //        LogCommand("RT Simulator: Default data loaded.");
    //    }

    //    private void RTSim_LoadTestData1_Click(object sender, EventArgs e)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int i = 0; i < 32; i++)
    //        {
    //            sb.Append(string.Format("{0:X4}", i + 1));
    //            if (i < 31) sb.Append(" ");
    //        }
    //        txtRTSimResponseData.Text = sb.ToString();
    //        LogCommand("RT Sim: Pattern 1 — Incrementing (0001→0020).");
    //        //UpdateStatus("RT Sim: Pattern 1 loaded.");
    //    }

    //    private void RTSim_LoadTestData2_Click(object sender, EventArgs e)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int i = 0; i < 32; i++)
    //        {
    //            sb.Append(i % 2 == 0 ? "AA55" : "55AA");
    //            if (i < 31) sb.Append(" ");
    //        }
    //        txtRTSimResponseData.Text = sb.ToString();
    //        LogCommand("RT Sim: Pattern 2 — AA55/55AA.");
    //        //UpdateStatus("RT Sim: Pattern 2 loaded.");
    //    }

    //    private void RTSim_LoadTestData3_Click(object sender, EventArgs e)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int i = 0; i < 32; i++)
    //        {
    //            sb.Append("0000");
    //            if (i < 31) sb.Append(" ");
    //        }
    //        txtRTSimResponseData.Text = sb.ToString();
    //        LogCommand("RT Sim: Pattern 3 — All zeros.");
    //       // UpdateStatus("RT Sim: Pattern 3 loaded.");
    //    }

    //    private void RTSim_LoadTestData4_Click(object sender, EventArgs e)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int i = 0; i < 32; i++)
    //        {
    //            sb.Append("FFFF");
    //            if (i < 31) sb.Append(" ");
    //        }
    //        txtRTSimResponseData.Text = sb.ToString();
    //        LogCommand("RT Sim: Pattern 4 — All FFFF.");
    //        //UpdateStatus("RT Sim: Pattern 4 loaded.");
    //    }

    //    private void RTSim_LoadTestData5_Click(object sender, EventArgs e)
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        for (int i = 0; i < 32; i++)
    //        {
    //            sb.Append(i % 2 == 0 ? "DEAD" : "BEEF");
    //            if (i < 31) sb.Append(" ");
    //        }
    //        txtRTSimResponseData.Text = sb.ToString();
    //        LogCommand("RT Sim: Pattern 5 — DEAD/BEEF.");
    //        //UpdateStatus("RT Sim: Pattern 5 loaded.");
    //    }


        // =========================================================
        //  DEFAULT: 2-word power pattern (0 dBm)
        // =========================================================
        private void RTSim_LoadDefault_Click(object sender, EventArgs e)
        {
            // Default: 0.00 dBm => Word0=0x0000, Word1=0x0000
            txtRTSimResponseData.Text = "0000 0000";
            LogCommand("RT Sim: Default loaded - 0.00 dBm (0000 0000).");
        }

        // =========================================================
        //  PATTERN 1: +10.00 dBm
        // =========================================================
        private void RTSim_LoadTestData1_Click(object sender, EventArgs e)
        {
            // +10.00 dBm => intPart=0x000A(10), fracPart=0x0000(00)
            txtRTSimResponseData.Text = "000A 0000";
            LogCommand("RT Sim: Pattern 1 - +10.00 dBm (000A 0000).");
        }

        // =========================================================
        //  PATTERN 2: -10.00 dBm
        // =========================================================
        private void RTSim_LoadTestData2_Click(object sender, EventArgs e)
        {
            // -10.00 dBm => intPart=0xFFF6(-10 as signed), fracPart=0x0000
            short intPart = -10;
            txtRTSimResponseData.Text = string.Format("{0:X4} 0000", (ushort)intPart);
            LogCommand("RT Sim: Pattern 2 - -10.00 dBm (FFF6 0000).");
        }

        // =========================================================
        //  PATTERN 3: -23.50 dBm (typical test power)
        // =========================================================
        private void RTSim_LoadTestData3_Click(object sender, EventArgs e)
        {
            // -23.50 dBm => intPart=0xFFE9(-23), fracPart=0x0032(50)
            short intPart = -23;
            ushort fracPart = 50;
            txtRTSimResponseData.Text = string.Format("{0:X4} {1:X4}",
                (ushort)intPart, fracPart);
            LogCommand("RT Sim: Pattern 3 - -23.50 dBm (FFE9 0032).");
        }

        // =========================================================
        //  PATTERN 4: +20.00 dBm (max typical)
        // =========================================================
        private void RTSim_LoadTestData4_Click(object sender, EventArgs e)
        {
            // +20.00 dBm => intPart=0x0014(20), fracPart=0x0000(00)
            txtRTSimResponseData.Text = "0014 0000";
            LogCommand("RT Sim: Pattern 4 - +20.00 dBm (0014 0000).");
        }

        // =========================================================
        //  PATTERN 5: -40.75 dBm (low power test)
        // =========================================================
        private void RTSim_LoadTestData5_Click(object sender, EventArgs e)
        {
            // -40.75 dBm => intPart=0xFFD8(-40), fracPart=0x004B(75)
            short intPart = -40;
            ushort fracPart = 75;
            txtRTSimResponseData.Text = string.Format("{0:X4} {1:X4}",
                (ushort)intPart, fracPart);
            LogCommand("RT Sim: Pattern 5 - -40.75 dBm (FFD8 004B).");
        }
        private void SetRTSimPowerWords(double powerDbm)
        {
            // Method 1: Split into integer + decimal parts
            // e.g. -23.50 dBm => Word0 = 0xFF17 (-23 in signed), Word1 = 0x0032 (50)

            short intPart = (short)Math.Truncate(powerDbm);
            ushort fracPart = (ushort)(Math.Abs(powerDbm - Math.Truncate(powerDbm)) * 100);

            string hexStr = string.Format("{0:X4} {1:X4}",
                (ushort)intPart,   // signed short cast to ushort for hex display
                fracPart);

            txtRTSimResponseData.Text = hexStr;

            LogCommand(string.Format(
                "RT Sim: Power={0} dBm | Word0={1:X4} (int) Word1={2:X4} (frac*100)",
                powerDbm, (ushort)intPart, fracPart));
        }

        // =========================================================
        //  ALTERNATIVE HELPER: Power as scaled integer x100
        //  e.g. -23.50 dBm => 0xFFFFF49E (-2350 in 32-bit)
        //  split into 2x 16-bit words: Word0=HIGH, Word1=LOW
        // =========================================================
        private void SetRTSimPowerWords_Scaled(double powerDbm)
        {
            // Multiply by 100 to keep 2 decimal places as integer
            // e.g. -23.50 * 100 = -2350
            int scaled = (int)(powerDbm * 100.0);

            // Split into high and low 16-bit words
            ushort highWord = (ushort)((scaled >> 16) & 0xFFFF);
            ushort lowWord = (ushort)(scaled & 0xFFFF);

            string hexStr = string.Format("{0:X4} {1:X4}", highWord, lowWord);

            txtRTSimResponseData.Text = hexStr;

            LogCommand(string.Format(
                "RT Sim: Power={0} dBm | Scaled={1} | Word0={2:X4} Word1={3:X4}",
                powerDbm, scaled, highWord, lowWord));
        }
        // =========================================================
        //  CLEAR
        // =========================================================
        private void RTSim_ClearData_Click(object sender, EventArgs e)
        {
            txtRTSimResponseData.Clear();
            txtRTSimResponseData.Focus();
            LogCommand("RT Sim: Data box cleared.");
        }
        //private void RTSim_ClearData_Click(object sender, EventArgs e)
        //{
        //    txtRTSimResponseData.Clear();
        //    txtRTSimResponseData.Focus();
        //    LogCommand("RT Sim: Data box cleared.");
        //    //UpdateStatus("RT Sim: Data cleared.");
        //}

        private void RTSim_Start_Click(object sender, EventArgs e)
        {
            try
            {
                short devNumShort;
                if (!short.TryParse(txtRTSimDeviceId.Text.Trim(), out devNumShort))
                {
                    MessageBox.Show("Invalid Device ID.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                rtSimDeviceId = (S16BIT)devNumShort;

                string rtText = cmbRTSimRTAddr.SelectedItem.ToString();
                byte rtAddrByte;
                if (!byte.TryParse(rtText, out rtAddrByte))
                {
                    MessageBox.Show("Invalid RT Address.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                rtSimRTAddress = (U16BIT)rtAddrByte;

                string subText = cmbRTSimSubAddr.SelectedItem.ToString();
                byte subAddrByte;
                if (!byte.TryParse(subText, out subAddrByte))
                {
                    MessageBox.Show("Invalid Sub Address.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                rtSimSubAddress = (U16BIT)subAddrByte;

                string rawText = txtRTSimResponseData.Text.Trim();
                if (string.IsNullOrEmpty(rawText))
                {
                    MessageBox.Show("Response data is empty.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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
                            "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
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
                        string.Format("RT Init failed.\nError: {0}", result),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rtSimDeviceId = -1;
                    return;
                }

                result = EmaceBU69092.aceRTDataBlkCreate(
                    rtSimDeviceId, 1, RtDataBlkType.ACE_RT_DBLK_SINGLE,
                    data, (U16BIT)wc);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Data Block Create failed.\nError: {0}", result),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    rtSimDeviceId = -1;
                    return;
                }

                result = EmaceBU69092.aceRTSetAddress(rtSimDeviceId, rtSimRTAddress);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Set Address failed.\nError: {0}", result),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    rtSimDeviceId = -1;
                    return;
                }

                result = EmaceBU69092.aceRTDataBlkMapToSA(
                    rtSimDeviceId, 1, rtSimSubAddress,
                    RtMsgType.ACE_RT_MSGTYPE_ALL, 0, true);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("Map to SA failed.\nError: {0}", result),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    rtSimDeviceId = -1;
                    return;
                }

                result = EmaceBU69092.aceRTMTStart(rtSimDeviceId);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format("RTMT Start failed.\nError: {0}", result),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                    rtSimDeviceId = -1;
                    return;
                }

                rtSimRunning = true;

                btnRTSimStart.Enabled = false;
                btnRTSimStop.Enabled = true;
                btnRTSimUpdateData.Enabled = true;
                pnlRTSimStatusBorder.BackColor = Color.Green;
                lblRTSimStatus.Text = "🟢 RT SIMULATOR RUNNING";
                //UpdateStatus(string.Format("RT Simulator: RUNNING as RT={0} SA={1}",
                    //rtSimRTAddress, rtSimSubAddress));

                MessageBox.Show(
                    string.Format(
                        "RT Simulator Started!\n\n" +
                        "Device ID   : {0}\nRT Address  : {1}\n" +
                        "Sub Address : {2}\nData Words  : {3}",
                        rtSimDeviceId, rtSimRTAddress, rtSimSubAddress, wc),
                    "RT Simulator Started",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception:\n{0}", ex.Message),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogCommand("RTSim EXCEPTION: " + ex.Message);
                rtSimDeviceId = -1;
                rtSimRunning = false;
            }
        }

        private void RTSim_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtSimDeviceId >= 0 && rtSimRunning)
                {
                    EmaceBU69092.aceRTMTStop(rtSimDeviceId);
                    EmaceBU69092.aceFree(rtSimDeviceId);
                }

                rtSimDeviceId = -1;
                rtSimRunning = false;

                btnRTSimStart.Enabled = true;
                btnRTSimStop.Enabled = false;
                btnRTSimUpdateData.Enabled = false;
                pnlRTSimValidation.BackColor = Color.Gray;
                lblRTSimStatus.Text = "⚫ RT SIMULATOR STOPPED";
                //UpdateStatus("RT Simulator: Stopped.");

                MessageBox.Show("RT Simulator stopped successfully.",
                    "RT Simulator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception:\n{0}", ex.Message),
                    "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RTSim_UpdateData_Click(object sender, EventArgs e)
        {
            if (!rtSimRunning || rtSimDeviceId < 0)
            {
                MessageBox.Show("RT Simulator is not running.\nStart it first.",
                    "Not Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string rawText = txtRTSimResponseData.Text.Trim();
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
                            "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                EmaceBU69092.aceRTDataBlkDelete(rtSimDeviceId, 1);

                AceError result = EmaceBU69092.aceRTDataBlkCreate(
                    rtSimDeviceId, 1, RtDataBlkType.ACE_RT_DBLK_SINGLE,
                    newData, (U16BIT)wc);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format(
                            "Failed to create new data block.\nError: {0}", result),
                        "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                result = EmaceBU69092.aceRTDataBlkMapToSA(
                    rtSimDeviceId, 1, rtSimSubAddress,
                    RtMsgType.ACE_RT_MSGTYPE_ALL, 0, true);
                if (result != AceError.ACE_ERR_SUCCESS)
                {
                    MessageBox.Show(string.Format(
                            "Failed to remap.\nError: {0}", result),
                        "Remap Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < wc; i++)
                {
                    sb.Append(string.Format("{0:X4}", newData[i]));
                    if (i < wc - 1) sb.Append(" ");
                }

                LogCommand(string.Format("RT Sim: Data UPDATED | Words={0}", wc));
                //UpdateStatus(string.Format("RT Simulator: Data updated with {0} words.", wc));

                MessageBox.Show(
                    string.Format("RT Data Updated!\n\nWords: {0}\n\nData:\n{1}",
                        wc, sb.ToString()),
                    "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception:\n{0}", ex.Message),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void RTSim_DataTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    string raw = txtRTSimResponseData.Text.Trim();

        //    if (string.IsNullOrEmpty(raw))
        //    {
        //        lblRTSimWordCount.Text = "0";
        //        pnlRTSimValidation.BackColor = Color.FromArgb(255, 235, 238);
        //        lblRTSimValidation.Text = "⚠ Data box is empty";
        //        lblRTSimValidation.ForeColor = Color.Red;
        //        return;
        //    }

        //    string[] parts = raw.Split(
        //        new char[] { ' ', ',', '\n', '\r', '\t' },
        //        StringSplitOptions.RemoveEmptyEntries);

        //    int count = parts.Length;
        //    bool allValid = true;
        //    int badIndex = -1;
        //    string badToken = string.Empty;

        //    lblRTSimWordCount.Text = count > 32 ? "32+" : count.ToString();

        //    for (int i = 0; i < Math.Min(count, 32); i++)
        //    {
        //        ushort dummy;
        //        if (!UInt16.TryParse(parts[i],
        //                System.Globalization.NumberStyles.HexNumber,
        //                null, out dummy))
        //        {
        //            allValid = false;
        //            badIndex = i + 1;
        //            badToken = parts[i];
        //            break;
        //        }
        //    }

        //    if (!allValid)
        //    {
        //        pnlRTSimValidation.BackColor = Color.FromArgb(255, 235, 238);
        //        lblRTSimValidation.Text = string.Format(
        //            "✘ Invalid hex at word #{0}: '{1}'", badIndex, badToken);
        //        lblRTSimValidation.ForeColor = Color.Red;
        //    }
        //    else if (count > 32)
        //    {
        //        pnlRTSimValidation.BackColor = Color.FromArgb(255, 243, 224);
        //        lblRTSimValidation.Text = string.Format(
        //            "⚠ {0} words — only first 32 used.", count);
        //        lblRTSimValidation.ForeColor = Color.FromArgb(230, 81, 0);
        //    }
        //    else
        //    {
        //        pnlRTSimValidation.BackColor = Color.FromArgb(232, 245, 233);
        //        lblRTSimValidation.Text = string.Format(
        //            "✔  {0} valid word{1} — ready to update.",
        //            count, count == 1 ? "" : "s");
        //        lblRTSimValidation.ForeColor = Color.FromArgb(46, 125, 50);
        //    }
        //} 


        private void RTSim_DataTextBox_TextChanged(object sender, EventArgs e)
        {
            string raw = txtRTSimResponseData.Text.Trim();

            if (string.IsNullOrEmpty(raw))
            {
                lblRTSimWordCount.Text = "0";
                pnlRTSimValidation.BackColor =
                    System.Drawing.Color.FromArgb(255, 235, 238);
                lblRTSimValidation.Text = "Data box is empty - enter 2 HEX words.";
                lblRTSimValidation.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string[] parts = raw.Split(
                new char[] { ' ', ',', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            int count = parts.Length;
            bool allValid = true;
            int badIndex = -1;
            string badTok = string.Empty;

            // Show count - warn if not exactly 2
            lblRTSimWordCount.Text = count.ToString();

            // Validate each word is valid hex
            for (int i = 0; i < Math.Min(count, 2); i++)
            {
                ushort dummy;
                if (!UInt16.TryParse(parts[i],
                        System.Globalization.NumberStyles.HexNumber,
                        null, out dummy))
                {
                    allValid = false;
                    badIndex = i + 1;
                    badTok = parts[i];
                    break;
                }
            }

            if (!allValid)
            {
                // Red: invalid hex
                pnlRTSimValidation.BackColor =
                    System.Drawing.Color.FromArgb(255, 235, 238);
                lblRTSimValidation.ForeColor = System.Drawing.Color.Red;
                lblRTSimValidation.Text = string.Format(
                    "Invalid hex at word #{0}: '{1}'", badIndex, badTok);
            }
            else if (count > 2)
            {
                // Orange: too many words
                pnlRTSimValidation.BackColor =
                    System.Drawing.Color.FromArgb(255, 243, 224);
                lblRTSimValidation.ForeColor =
                    System.Drawing.Color.FromArgb(230, 81, 0);
                lblRTSimValidation.Text = string.Format(
                    "{0} words entered - only first 2 used for power.", count);
            }
            else if (count == 1)
            {
                // Yellow: need 2nd word
                pnlRTSimValidation.BackColor =
                    System.Drawing.Color.FromArgb(255, 253, 231);
                lblRTSimValidation.ForeColor =
                    System.Drawing.Color.FromArgb(130, 100, 0);
                lblRTSimValidation.Text =
                    "Need 2 words: Word0=integer part, Word1=decimal part x100";
            }
            else if (count == 2 && allValid)
            {
                // Green: exactly 2 valid words - show decoded power
                double pw = DecodeRTSimPower();
                pnlRTSimValidation.BackColor =
                    System.Drawing.Color.FromArgb(232, 245, 233);
                lblRTSimValidation.ForeColor =
                    System.Drawing.Color.FromArgb(46, 125, 50);
                lblRTSimValidation.Text = string.Format(
                    "2 valid words - Power = {0:F2} dBm - ready to update.",
                    pw);
            }
            else
            {
                // Default green
                pnlRTSimValidation.BackColor =
                    System.Drawing.Color.FromArgb(232, 245, 233);
                lblRTSimValidation.ForeColor =
                    System.Drawing.Color.FromArgb(46, 125, 50);
                lblRTSimValidation.Text = "Valid - ready to update.";
            }
        }
        // =========================================================
        //  POWER INPUT: User types dBm value, auto-converts to 2 words
        //  Call this from a TextBox TextChanged or Button Click
        // =========================================================
        private void ConvertPowerToHex(double powerDbm)
        {
            short intPart = (short)Math.Truncate(powerDbm);
            ushort fracPart = (ushort)(Math.Abs(powerDbm - Math.Truncate(powerDbm)) * 100);

            txtRTSimResponseData.Text = string.Format("{0:X4} {1:X4}",
                (ushort)intPart, fracPart);
        }

        // =========================================================
        //  DECODER: Read 2 words back to power dBm (for display)
        // =========================================================
        private double DecodeRTSimPower()
        {
            double result = 0.0;
            try
            {
                string raw = txtRTSimResponseData.Text.Trim();
                string[] ws = raw.Split(
                    new char[] { ' ', ',', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (ws.Length >= 2)
                {
                    ushort w0, w1;
                    if (UInt16.TryParse(ws[0],
                            System.Globalization.NumberStyles.HexNumber,
                            null, out w0) &&
                        UInt16.TryParse(ws[1],
                            System.Globalization.NumberStyles.HexNumber,
                            null, out w1))
                    {
                        // Reinterpret w0 as signed short
                        short intPart = (short)w0;
                        double fracPart = w1 / 100.0;

                        if (intPart < 0)
                            result = intPart - fracPart;
                        else
                            result = intPart + fracPart;
                    }
                }
            }
            catch { }
            return result;
        }
       
        private void LogCommand(string message)
        {
            SafeInvoke(delegate()
            {
                // Option 1: If you have a log textbox (adjust name to match yours)
                if (rtb1553Log != null)
                {
                    rtb1553Log.AppendText(
                        DateTime.Now.ToString("HH:mm:ss") + " - " +
                        message + Environment.NewLine);

                    // Auto-scroll to bottom
                    rtb1553Log.SelectionStart = rtb1553Log.Text.Length;
                    rtb1553Log.ScrollToCaret();
                }

                // Option 2: Also log to debug console
                System.Diagnostics.Debug.WriteLine(
                    DateTime.Now.ToString("HH:mm:ss.fff") + " | " + message);
            });
        }

       
        private void button6_Click(object sender, EventArgs e)
        {
            
            ReceiveRTtoBCData();
        

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // NB = -18 to -38dBm
            if (cmbBand.SelectedIndex == 0)
            {
                txtlmtStart.Text = "-38";
                txtlmtStop.Text = "-18";
            }
            else
            {
                // WB = -14 to -34dBm
                txtlmtStart.Text = "-34";
                txtlmtStop.Text = "-14";
            }

        }  
    }
}