namespace WindowsFormsApplication1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;


        // ── Original Controls ──
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.TextBox txtFreq;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label lblOutFreq;
        private System.Windows.Forms.TextBox txtOutFreq;
        private System.Windows.Forms.Label lblOutPower;
        private System.Windows.Forms.TextBox txtOutPower;
        private System.Windows.Forms.TextBox txtCarrCount;
        private System.Windows.Forms.TextBox txtCarrFreqs;
        private System.Windows.Forms.ComboBox cmbMeasurement;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbPower;
        private System.Windows.Forms.ComboBox cmbLimiterMode;
        private System.Windows.Forms.Label lblLimiter;
        private System.Windows.Forms.TextBox txtLimiterPower;

        // ── Tab Controls ──
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage6;  // RT Simulator Tab
        private System.Windows.Forms.TabPage tabPage5;

        // ── Connection Tab Controls ──
        private System.Windows.Forms.Label lblMainStatus;
        private System.Windows.Forms.GroupBox grpSigGenConn;
        private System.Windows.Forms.PictureBox picSigGenStatus;
        private System.Windows.Forms.Label lblSigGenIP;
        private System.Windows.Forms.TextBox txtSigGenIP;
        private System.Windows.Forms.Label lblSigGenPort;
        private System.Windows.Forms.TextBox txtSigGenPort;
        private System.Windows.Forms.Button btnSigGenConnect;
        private System.Windows.Forms.Button btnSigGenDisconnect;
        private System.Windows.Forms.Label lblSigGenStatusTitle;
        private System.Windows.Forms.Label lblSigGenStatus;
        private System.Windows.Forms.GroupBox grpSpectrumConn;
        private System.Windows.Forms.PictureBox picSpectrumStatus;
        private System.Windows.Forms.Label lblSpectrumIP;
        private System.Windows.Forms.TextBox txtSpectrumIP;
        private System.Windows.Forms.Label lblSpectrumPort;
        private System.Windows.Forms.TextBox txtSpectrumPort;
        private System.Windows.Forms.Button btnSpectrumConnect;
        private System.Windows.Forms.Button btnSpectrumDisconnect;
        private System.Windows.Forms.Label lblSpectrumStatusTitle;
        private System.Windows.Forms.Label lblSpectrumStatus;
        private System.Windows.Forms.GroupBox grpVNAConn;
        private System.Windows.Forms.PictureBox picVNAStatus;
        private System.Windows.Forms.Label lblVNAIP;
        private System.Windows.Forms.TextBox txtVNAIP;
        private System.Windows.Forms.Label lblVNAPort;
        private System.Windows.Forms.TextBox txtVNAPort;
        private System.Windows.Forms.Button btnVNAConnect;
        private System.Windows.Forms.Button btnVNADisconnect;
        private System.Windows.Forms.Label lblVNAStatusTitle;
        private System.Windows.Forms.Label lblVNAStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        // ── NEW: 1553 Connection Controls ──
        private System.Windows.Forms.GroupBox grp1553Conn;
        private System.Windows.Forms.PictureBox pic1553Status;
        private System.Windows.Forms.Label lbl1553DeviceId;
        private System.Windows.Forms.TextBox txt1553DeviceId;
        private System.Windows.Forms.Label lbl1553RTAddr;
        private System.Windows.Forms.ComboBox cmb1553RTAddr;
        private System.Windows.Forms.Label lbl1553SubAddr;
        private System.Windows.Forms.ComboBox cmb1553SubAddr;
        private System.Windows.Forms.Label lbl1553Bus;
        private System.Windows.Forms.ComboBox cmb1553Bus;
        private System.Windows.Forms.Button btn1553Connect;
        private System.Windows.Forms.Button btn1553Disconnect;
        private System.Windows.Forms.Label lbl1553StatusTitle;
        private System.Windows.Forms.Label lbl1553Status;

        // ── Signal Generator Tab Controls ──
        private System.Windows.Forms.Label lblSigGenConnInfo;
        private System.Windows.Forms.GroupBox grpSigGenParams;
        private System.Windows.Forms.Label lblSigGenCenterFreqUnit;
        private System.Windows.Forms.Label lblSigGenCarrCount;
        private System.Windows.Forms.Label lblSigGenToneFreqs;
        private System.Windows.Forms.Label lblSigGenMeasType;
        private System.Windows.Forms.GroupBox grpSigGenPowerSweep;
        private System.Windows.Forms.Label lblSigGenPowerStart;
        private System.Windows.Forms.TextBox txtSigGenPowerStart;
        private System.Windows.Forms.Label lblSigGenPowerStartUnit;
        private System.Windows.Forms.Label lblSigGenPowerStop;
        private System.Windows.Forms.TextBox txtSigGenPowerStop;
        private System.Windows.Forms.Label lblSigGenPowerStopUnit;
        private System.Windows.Forms.Label lblSigGenPowerStep;
        private System.Windows.Forms.TextBox txtSigGenPowerStep;
        private System.Windows.Forms.Label lblSigGenPowerStepUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTCPowerSelect;
        private System.Windows.Forms.Label lblTCPowerSelect;
        private System.Windows.Forms.GroupBox grp_powerLimit;

        // ── NEW: Gain Loop Controls ──
        private System.Windows.Forms.Label lblGainStart;
        private System.Windows.Forms.TextBox txtGainStart;
        private System.Windows.Forms.Label lblGainStop;
        private System.Windows.Forms.TextBox txtGainStop;
        private System.Windows.Forms.Label lblGainStep;
        private System.Windows.Forms.TextBox txtGainStep;
        private System.Windows.Forms.Label lblGainDelay;
        private System.Windows.Forms.TextBox txtGainDelay;

        // ── NEW: Live Output Controls ──
        private System.Windows.Forms.GroupBox grpLiveOutput;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressText;
        private System.Windows.Forms.Label lblCurrentFreqTitle;
        private System.Windows.Forms.Label lblCurrentFreq;
        private System.Windows.Forms.Label lblCurrentPowerTitle;
        private System.Windows.Forms.Label lblCurrentPower;
        private System.Windows.Forms.Label lblCurrentGainTitle;
        private System.Windows.Forms.Label lblCurrentGain;
        private System.Windows.Forms.Label lbl1553StatusLive;
        private System.Windows.Forms.TextBox txt1553StatusLive;
        private System.Windows.Forms.TextBox spectrum_output;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStop;

        // ── Spectrum Tab Controls ──

        // ── VNA Tab Controls ──

        // ── NEW: DDC 1553 Tab Controls ──
        private System.Windows.Forms.GroupBox grp1553Info;
        private System.Windows.Forms.Label lbl1553ConnInfo;
        private System.Windows.Forms.GroupBox grp1553Params;
        private System.Windows.Forms.Label lbl1553DeviceTitle;
        private System.Windows.Forms.Label lbl1553RTTitle;
        private System.Windows.Forms.Label lbl1553SubTitle;
        private System.Windows.Forms.Label lbl1553BusTitle;
        private System.Windows.Forms.Label lbl1553CurrentGain;
        private System.Windows.Forms.TextBox txt1553CurrentGain;
        private System.Windows.Forms.Label lbl1553LastStatus;
        private System.Windows.Forms.TextBox txt1553LastStatus;
        private System.Windows.Forms.RichTextBox rtb1553Log;
        private System.Windows.Forms.Label lbl1553LogTitle;
        private System.Windows.Forms.Button btn1553ClearLog;



         // ✅ ADD RT SIMULATOR CONTROLS
    // ══════════════════════════════════════════════════════
    private System.Windows.Forms.Panel pnlRTSimMain;
    private System.Windows.Forms.GroupBox grpRTSimConfig;
    private System.Windows.Forms.Panel pnlRTSimWarning;
    private System.Windows.Forms.Label lblRTSimWarningTitle;
    private System.Windows.Forms.Label lblRTSimWarningMsg;
    private System.Windows.Forms.Label lblRTSimDeviceId;
    private System.Windows.Forms.TextBox txtRTSimDeviceId;
    private System.Windows.Forms.Label lblRTSimRTAddr;
    private System.Windows.Forms.ComboBox cmbRTSimRTAddr;
    private System.Windows.Forms.Label lblRTSimSubAddr;
    private System.Windows.Forms.ComboBox cmbRTSimSubAddr;
    private System.Windows.Forms.Label lblRTSimBus;
    private System.Windows.Forms.ComboBox cmbRTSimBus;
    private System.Windows.Forms.Panel pnlRTSimStatusBorder;
    private System.Windows.Forms.Label lblRTSimStatus;
    private System.Windows.Forms.Button btnRTSimStart;
    private System.Windows.Forms.Button btnRTSimStop;
    
    private System.Windows.Forms.GroupBox grpRTSimPatterns;
    private System.Windows.Forms.Label lblRTSimPatternInfo;
    private System.Windows.Forms.FlowLayoutPanel flowRTSimPatterns;
    private System.Windows.Forms.Button btnRTSimPattern0;
    private System.Windows.Forms.Button btnRTSimPattern1;
    private System.Windows.Forms.Button btnRTSimPattern2;
    private System.Windows.Forms.Button btnRTSimPattern3;
    private System.Windows.Forms.Button btnRTSimPattern4;
    private System.Windows.Forms.Button btnRTSimPattern5;
    private System.Windows.Forms.Button btnRTSimClear;
    
    private System.Windows.Forms.GroupBox grpRTSimData;
    private System.Windows.Forms.Panel pnlRTSimDataInfo;
    private System.Windows.Forms.Label lblRTSimDataInfoTitle;
    private System.Windows.Forms.Label lblRTSimDataInfoMsg;
    private System.Windows.Forms.Label lblRTSimDataPrompt;
    private System.Windows.Forms.Label lblRTSimWordCountStatic;
    private System.Windows.Forms.Label lblRTSimWordCount;
    private System.Windows.Forms.Label lblRTSimWordMax;
    private System.Windows.Forms.TextBox txtRTSimResponseData;
    private System.Windows.Forms.Panel pnlRTSimValidation;
    private System.Windows.Forms.Label lblRTSimValidation;
    private System.Windows.Forms.Panel pnlRTSimWorkflow;
    private System.Windows.Forms.Label lblRTSimWorkflow;
    private System.Windows.Forms.Button btnRTSimUpdateData;
    
    private System.Windows.Forms.GroupBox grpRTSimInstructions;
    private System.Windows.Forms.Panel pnlRTSimInstLeft;
    private System.Windows.Forms.Panel pnlRTSimInstRigh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRTDeviceId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbtxt1553DeviceId = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpSigGenConn = new System.Windows.Forms.GroupBox();
            this.picSigGenStatus = new System.Windows.Forms.PictureBox();
            this.lblSigGenIP = new System.Windows.Forms.Label();
            this.txtSigGenIP = new System.Windows.Forms.TextBox();
            this.lblSigGenPort = new System.Windows.Forms.Label();
            this.txtSigGenPort = new System.Windows.Forms.TextBox();
            this.btnSigGenConnect = new System.Windows.Forms.Button();
            this.btnSigGenDisconnect = new System.Windows.Forms.Button();
            this.lblSigGenStatusTitle = new System.Windows.Forms.Label();
            this.lblSigGenStatus = new System.Windows.Forms.Label();
            this.grpSpectrumConn = new System.Windows.Forms.GroupBox();
            this.picSpectrumStatus = new System.Windows.Forms.PictureBox();
            this.lblSpectrumIP = new System.Windows.Forms.Label();
            this.txtSpectrumIP = new System.Windows.Forms.TextBox();
            this.lblSpectrumPort = new System.Windows.Forms.Label();
            this.txtSpectrumPort = new System.Windows.Forms.TextBox();
            this.btnSpectrumConnect = new System.Windows.Forms.Button();
            this.btnSpectrumDisconnect = new System.Windows.Forms.Button();
            this.lblSpectrumStatusTitle = new System.Windows.Forms.Label();
            this.lblSpectrumStatus = new System.Windows.Forms.Label();
            this.grpVNAConn = new System.Windows.Forms.GroupBox();
            this.picVNAStatus = new System.Windows.Forms.PictureBox();
            this.lblVNAIP = new System.Windows.Forms.Label();
            this.txtVNAIP = new System.Windows.Forms.TextBox();
            this.lblVNAPort = new System.Windows.Forms.Label();
            this.txtVNAPort = new System.Windows.Forms.TextBox();
            this.btnVNAConnect = new System.Windows.Forms.Button();
            this.btnVNADisconnect = new System.Windows.Forms.Button();
            this.lblVNAStatusTitle = new System.Windows.Forms.Label();
            this.lblVNAStatus = new System.Windows.Forms.Label();
            this.grp1553Conn = new System.Windows.Forms.GroupBox();
            this.pic1553Status = new System.Windows.Forms.PictureBox();
            this.lbl1553DeviceId = new System.Windows.Forms.Label();
            this.txt1553DeviceId = new System.Windows.Forms.TextBox();
            this.lbl1553RTAddr = new System.Windows.Forms.Label();
            this.cmb1553RTAddr = new System.Windows.Forms.ComboBox();
            this.lbl1553SubAddr = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb1553SubAddr = new System.Windows.Forms.ComboBox();
            this.lbl1553Bus = new System.Windows.Forms.Label();
            this.cmb1553Bus = new System.Windows.Forms.ComboBox();
            this.btn1553Connect = new System.Windows.Forms.Button();
            this.btn1553Disconnect = new System.Windows.Forms.Button();
            this.lbl1553StatusTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl1553Status = new System.Windows.Forms.Label();
            this.lblMainStatus = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.cmbBand = new System.Windows.Forms.ComboBox();
            this.grpBWScal = new System.Windows.Forms.GroupBox();
            this.lblPowUnit = new System.Windows.Forms.Label();
            this.lbl_ipPow = new System.Windows.Forms.Label();
            this.txtbwPow = new System.Windows.Forms.TextBox();
            this.lblBwUnit = new System.Windows.Forms.Label();
            this.lblipBw = new System.Windows.Forms.Label();
            this.txtBW = new System.Windows.Forms.TextBox();
            this.lblFrequnit = new System.Windows.Forms.Label();
            this.lbl_ipFreq = new System.Windows.Forms.Label();
            this.txt_bwfreq = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.lblSigGenConnInfo = new System.Windows.Forms.Label();
            this.grpSigGenPowerSweep = new System.Windows.Forms.GroupBox();
            this.lblSigGenPowerStart = new System.Windows.Forms.Label();
            this.txtSigGenPowerStart = new System.Windows.Forms.TextBox();
            this.lblSigGenPowerStartUnit = new System.Windows.Forms.Label();
            this.lblSigGenPowerStop = new System.Windows.Forms.Label();
            this.txtSigGenPowerStop = new System.Windows.Forms.TextBox();
            this.lblSigGenPowerStopUnit = new System.Windows.Forms.Label();
            this.lblSigGenPowerStep = new System.Windows.Forms.Label();
            this.txtSigGenPowerStep = new System.Windows.Forms.TextBox();
            this.lblSigGenPowerStepUnit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.lblOutPower = new System.Windows.Forms.Label();
            this.txtOutPower = new System.Windows.Forms.TextBox();
            this.grpTCPowerSelect = new System.Windows.Forms.GroupBox();
            this.lblTCPowerSelect = new System.Windows.Forms.Label();
            this.cmbPower = new System.Windows.Forms.ComboBox();
            this.lblGainStart = new System.Windows.Forms.Label();
            this.txtGainStart = new System.Windows.Forms.TextBox();
            this.lblGainStop = new System.Windows.Forms.Label();
            this.txtGainStop = new System.Windows.Forms.TextBox();
            this.lblGainStep = new System.Windows.Forms.Label();
            this.txtGainStep = new System.Windows.Forms.TextBox();
            this.lblGainDelay = new System.Windows.Forms.Label();
            this.txtGainDelay = new System.Windows.Forms.TextBox();
            this.grpSigGenParams = new System.Windows.Forms.GroupBox();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.lblFreq = new System.Windows.Forms.Label();
            this.txtFreq = new System.Windows.Forms.TextBox();
            this.lblSigGenCenterFreqUnit = new System.Windows.Forms.Label();
            this.lblSigGenCarrCount = new System.Windows.Forms.Label();
            this.txtCarrCount = new System.Windows.Forms.TextBox();
            this.lblSigGenToneFreqs = new System.Windows.Forms.Label();
            this.txtCarrFreqs = new System.Windows.Forms.TextBox();
            this.lblSigGenMeasType = new System.Windows.Forms.Label();
            this.cmbMeasurement = new System.Windows.Forms.ComboBox();
            this.grp_powerLimit = new System.Windows.Forms.GroupBox();
            this.grp_pwlimitcase2 = new System.Windows.Forms.GroupBox();
            this.txtlmtStep = new System.Windows.Forms.TextBox();
            this.txtlmtDelay = new System.Windows.Forms.TextBox();
            this.lbl_pwrlmtStart = new System.Windows.Forms.Label();
            this.txtlmtStop = new System.Windows.Forms.TextBox();
            this.lbl_pwrlmtdel = new System.Windows.Forms.Label();
            this.lbl_pwrlmtStop = new System.Windows.Forms.Label();
            this.lbl_pwrlmtStep = new System.Windows.Forms.Label();
            this.txtlmtStart = new System.Windows.Forms.TextBox();
            this.lbl_powerlimit = new System.Windows.Forms.Label();
            this.PwrLimtunit = new System.Windows.Forms.Label();
            this.lblLimiter = new System.Windows.Forms.Label();
            this.cmbLimiterMode = new System.Windows.Forms.ComboBox();
            this.txtLimiterPower = new System.Windows.Forms.TextBox();
            this.grpLiveOutput = new System.Windows.Forms.GroupBox();
            this.lblCurrBW = new System.Windows.Forms.Label();
            this.lblCurrBWTitle = new System.Windows.Forms.Label();
            this.lbloPBw = new System.Windows.Forms.Label();
            this.lbloP_BwTitle = new System.Windows.Forms.Label();
            this.txt1553Output_1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl1553power = new System.Windows.Forms.Label();
            this.lbl1553PowerTitle = new System.Windows.Forms.Label();
            this.lblCurrentPowerLmt = new System.Windows.Forms.Label();
            this.lblcurrPwrLmtTitle = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgressText = new System.Windows.Forms.Label();
            this.lblCurrentFreqTitle = new System.Windows.Forms.Label();
            this.lblCurrentFreq = new System.Windows.Forms.Label();
            this.lblCurrentPowerTitle = new System.Windows.Forms.Label();
            this.lblCurrentPower = new System.Windows.Forms.Label();
            this.lblCurrentGainTitle = new System.Windows.Forms.Label();
            this.lblCurrentGain = new System.Windows.Forms.Label();
            this.lbl1553StatusLive = new System.Windows.Forms.Label();
            this.txt1553StatusLive = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.spectrum_output = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblOutFreq = new System.Windows.Forms.Label();
            this.txtOutFreq = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.grp1553Info = new System.Windows.Forms.GroupBox();
            this.lbl1553ConnInfo = new System.Windows.Forms.Label();
            this.grp1553Params = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt1553BW = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt1553bwstatus = new System.Windows.Forms.TextBox();
            this.lbl1553DeviceTitle = new System.Windows.Forms.Label();
            this.lbl1553RTTitle = new System.Windows.Forms.Label();
            this.lbl1553SubTitle = new System.Windows.Forms.Label();
            this.lbl1553BusTitle = new System.Windows.Forms.Label();
            this.lbl1553CurrentGain = new System.Windows.Forms.Label();
            this.txt1553CurrentGain = new System.Windows.Forms.TextBox();
            this.lbl1553LastStatus = new System.Windows.Forms.Label();
            this.txt1553LastStatus = new System.Windows.Forms.TextBox();
            this.lbl1553LogTitle = new System.Windows.Forms.Label();
            this.btn1553ClearLog = new System.Windows.Forms.Button();
            this.rtb1553Log = new System.Windows.Forms.RichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.pnlRTSimMain = new System.Windows.Forms.Panel();
            this.grpRTSimConfig = new System.Windows.Forms.GroupBox();
            this.pnlRTSimWarning = new System.Windows.Forms.Panel();
            this.lblRTSimWarningTitle = new System.Windows.Forms.Label();
            this.lblRTSimWarningMsg = new System.Windows.Forms.Label();
            this.lblRTSimDeviceId = new System.Windows.Forms.Label();
            this.txtRTSimDeviceId = new System.Windows.Forms.TextBox();
            this.lblRTSimRTAddr = new System.Windows.Forms.Label();
            this.cmbRTSimRTAddr = new System.Windows.Forms.ComboBox();
            this.lblRTSimSubAddr = new System.Windows.Forms.Label();
            this.cmbRTSimSubAddr = new System.Windows.Forms.ComboBox();
            this.lblRTSimBus = new System.Windows.Forms.Label();
            this.cmbRTSimBus = new System.Windows.Forms.ComboBox();
            this.pnlRTSimStatusBorder = new System.Windows.Forms.Panel();
            this.lblRTSimStatus = new System.Windows.Forms.Label();
            this.btnRTSimStart = new System.Windows.Forms.Button();
            this.btnRTSimStop = new System.Windows.Forms.Button();
            this.grpRTSimPatterns = new System.Windows.Forms.GroupBox();
            this.lblRTSimPatternInfo = new System.Windows.Forms.Label();
            this.flowRTSimPatterns = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRTSimPattern0 = new System.Windows.Forms.Button();
            this.btnRTSimPattern1 = new System.Windows.Forms.Button();
            this.btnRTSimPattern2 = new System.Windows.Forms.Button();
            this.btnRTSimPattern3 = new System.Windows.Forms.Button();
            this.btnRTSimPattern4 = new System.Windows.Forms.Button();
            this.btnRTSimPattern5 = new System.Windows.Forms.Button();
            this.btnRTSimClear = new System.Windows.Forms.Button();
            this.grpRTSimData = new System.Windows.Forms.GroupBox();
            this.pnlRTSimDataInfo = new System.Windows.Forms.Panel();
            this.lblRTSimDataInfoTitle = new System.Windows.Forms.Label();
            this.lblRTSimDataInfoMsg = new System.Windows.Forms.Label();
            this.lblRTSimDataPrompt = new System.Windows.Forms.Label();
            this.lblRTSimWordCountStatic = new System.Windows.Forms.Label();
            this.lblRTSimWordCount = new System.Windows.Forms.Label();
            this.lblRTSimWordMax = new System.Windows.Forms.Label();
            this.txtRTSimResponseData = new System.Windows.Forms.TextBox();
            this.pnlRTSimValidation = new System.Windows.Forms.Panel();
            this.lblRTSimValidation = new System.Windows.Forms.Label();
            this.pnlRTSimWorkflow = new System.Windows.Forms.Panel();
            this.lblRTSimWorkflow = new System.Windows.Forms.Label();
            this.btnRTSimUpdateData = new System.Windows.Forms.Button();
            this.grpRTSimInstructions = new System.Windows.Forms.GroupBox();
            this.pnlRTSimInstLeft = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblBandTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.grpSigGenConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSigGenStatus)).BeginInit();
            this.grpSpectrumConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpectrumStatus)).BeginInit();
            this.grpVNAConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVNAStatus)).BeginInit();
            this.grp1553Conn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1553Status)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.grpBWScal.SuspendLayout();
            this.grpSigGenPowerSweep.SuspendLayout();
            this.grpTCPowerSelect.SuspendLayout();
            this.grpSigGenParams.SuspendLayout();
            this.grp_powerLimit.SuspendLayout();
            this.grp_pwlimitcase2.SuspendLayout();
            this.grpLiveOutput.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.grp1553Info.SuspendLayout();
            this.grp1553Params.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.pnlRTSimMain.SuspendLayout();
            this.grpRTSimConfig.SuspendLayout();
            this.pnlRTSimWarning.SuspendLayout();
            this.pnlRTSimStatusBorder.SuspendLayout();
            this.grpRTSimPatterns.SuspendLayout();
            this.flowRTSimPatterns.SuspendLayout();
            this.grpRTSimData.SuspendLayout();
            this.pnlRTSimDataInfo.SuspendLayout();
            this.pnlRTSimValidation.SuspendLayout();
            this.pnlRTSimWorkflow.SuspendLayout();
            this.grpRTSimInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 610);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.grpSigGenConn);
            this.tabPage1.Controls.Add(this.grpSpectrumConn);
            this.tabPage1.Controls.Add(this.grpVNAConn);
            this.tabPage1.Controls.Add(this.grp1553Conn);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.lblMainStatus);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1140, 584);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  Connection  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtRTDeviceId);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cmbtxt1553DeviceId);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.comboBox3);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox4.Location = new System.Drawing.Point(6, 446);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1120, 90);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "  DDC MIL-STD-1553 Remote Terminal";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(12, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(40, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Device ID :";
            // 
            // txtRTDeviceId
            // 
            this.txtRTDeviceId.BackColor = System.Drawing.Color.LightYellow;
            this.txtRTDeviceId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRTDeviceId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRTDeviceId.Location = new System.Drawing.Point(115, 40);
            this.txtRTDeviceId.Name = "txtRTDeviceId";
            this.txtRTDeviceId.Size = new System.Drawing.Size(50, 23);
            this.txtRTDeviceId.TabIndex = 2;
            this.txtRTDeviceId.Text = "1";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(178, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "RT Address :";
            // 
            // cmbtxt1553DeviceId
            // 
            this.cmbtxt1553DeviceId.BackColor = System.Drawing.Color.LightYellow;
            this.cmbtxt1553DeviceId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtxt1553DeviceId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbtxt1553DeviceId.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbtxt1553DeviceId.Location = new System.Drawing.Point(258, 40);
            this.cmbtxt1553DeviceId.Name = "cmbtxt1553DeviceId";
            this.cmbtxt1553DeviceId.Size = new System.Drawing.Size(60, 23);
            this.cmbtxt1553DeviceId.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(330, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Sub Address :";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.LightYellow;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBox2.Location = new System.Drawing.Point(415, 40);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(60, 23);
            this.comboBox2.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(488, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Bus :";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.LightYellow;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBox3.Items.AddRange(new object[] {
            "A",
            "B"});
            this.comboBox3.Location = new System.Drawing.Point(528, 40);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(55, 23);
            this.comboBox3.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(598, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 32);
            this.button3.TabIndex = 9;
            this.button3.Text = "Test Connect";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Crimson;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(728, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 32);
            this.button4.TabIndex = 10;
            this.button4.Text = "Disconnect";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(855, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 11;
            this.label12.Text = "Status :";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(915, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(180, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "Not Tested";
            // 
            // grpSigGenConn
            // 
            this.grpSigGenConn.BackColor = System.Drawing.Color.White;
            this.grpSigGenConn.Controls.Add(this.picSigGenStatus);
            this.grpSigGenConn.Controls.Add(this.lblSigGenIP);
            this.grpSigGenConn.Controls.Add(this.txtSigGenIP);
            this.grpSigGenConn.Controls.Add(this.lblSigGenPort);
            this.grpSigGenConn.Controls.Add(this.txtSigGenPort);
            this.grpSigGenConn.Controls.Add(this.btnSigGenConnect);
            this.grpSigGenConn.Controls.Add(this.btnSigGenDisconnect);
            this.grpSigGenConn.Controls.Add(this.lblSigGenStatusTitle);
            this.grpSigGenConn.Controls.Add(this.lblSigGenStatus);
            this.grpSigGenConn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSigGenConn.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpSigGenConn.Location = new System.Drawing.Point(6, 8);
            this.grpSigGenConn.Name = "grpSigGenConn";
            this.grpSigGenConn.Size = new System.Drawing.Size(1120, 76);
            this.grpSigGenConn.TabIndex = 1;
            this.grpSigGenConn.TabStop = false;
            this.grpSigGenConn.Text = "  Signal Generator Connection";
            // 
            // picSigGenStatus
            // 
            this.picSigGenStatus.BackColor = System.Drawing.Color.Red;
            this.picSigGenStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSigGenStatus.Location = new System.Drawing.Point(12, 35);
            this.picSigGenStatus.Name = "picSigGenStatus";
            this.picSigGenStatus.Size = new System.Drawing.Size(20, 20);
            this.picSigGenStatus.TabIndex = 0;
            this.picSigGenStatus.TabStop = false;
            // 
            // lblSigGenIP
            // 
            this.lblSigGenIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenIP.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenIP.Location = new System.Drawing.Point(40, 37);
            this.lblSigGenIP.Name = "lblSigGenIP";
            this.lblSigGenIP.Size = new System.Drawing.Size(75, 20);
            this.lblSigGenIP.TabIndex = 1;
            this.lblSigGenIP.Text = "IP Address :";
            // 
            // txtSigGenIP
            // 
            this.txtSigGenIP.BackColor = System.Drawing.Color.LightYellow;
            this.txtSigGenIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSigGenIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSigGenIP.Location = new System.Drawing.Point(120, 35);
            this.txtSigGenIP.Name = "txtSigGenIP";
            this.txtSigGenIP.Size = new System.Drawing.Size(160, 23);
            this.txtSigGenIP.TabIndex = 2;
            this.txtSigGenIP.Text = "10.1.6.155";
            // 
            // lblSigGenPort
            // 
            this.lblSigGenPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenPort.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenPort.Location = new System.Drawing.Point(292, 37);
            this.lblSigGenPort.Name = "lblSigGenPort";
            this.lblSigGenPort.Size = new System.Drawing.Size(40, 20);
            this.lblSigGenPort.TabIndex = 3;
            this.lblSigGenPort.Text = "Port :";
            // 
            // txtSigGenPort
            // 
            this.txtSigGenPort.BackColor = System.Drawing.Color.LightYellow;
            this.txtSigGenPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSigGenPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSigGenPort.Location = new System.Drawing.Point(336, 35);
            this.txtSigGenPort.Name = "txtSigGenPort";
            this.txtSigGenPort.Size = new System.Drawing.Size(70, 23);
            this.txtSigGenPort.TabIndex = 4;
            this.txtSigGenPort.Text = "7";
            // 
            // btnSigGenConnect
            // 
            this.btnSigGenConnect.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSigGenConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSigGenConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSigGenConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSigGenConnect.ForeColor = System.Drawing.Color.White;
            this.btnSigGenConnect.Location = new System.Drawing.Point(420, 28);
            this.btnSigGenConnect.Name = "btnSigGenConnect";
            this.btnSigGenConnect.Size = new System.Drawing.Size(100, 30);
            this.btnSigGenConnect.TabIndex = 5;
            this.btnSigGenConnect.Text = "Connect";
            this.btnSigGenConnect.UseVisualStyleBackColor = false;
            this.btnSigGenConnect.Click += new System.EventHandler(this.btnSigGenConnect_Click);
            // 
            // btnSigGenDisconnect
            // 
            this.btnSigGenDisconnect.BackColor = System.Drawing.Color.Crimson;
            this.btnSigGenDisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSigGenDisconnect.Enabled = false;
            this.btnSigGenDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSigGenDisconnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSigGenDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnSigGenDisconnect.Location = new System.Drawing.Point(530, 28);
            this.btnSigGenDisconnect.Name = "btnSigGenDisconnect";
            this.btnSigGenDisconnect.Size = new System.Drawing.Size(100, 30);
            this.btnSigGenDisconnect.TabIndex = 6;
            this.btnSigGenDisconnect.Text = "Disconnect";
            this.btnSigGenDisconnect.UseVisualStyleBackColor = false;
            this.btnSigGenDisconnect.Click += new System.EventHandler(this.btnSigGenDisconnect_Click);
            // 
            // lblSigGenStatusTitle
            // 
            this.lblSigGenStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenStatusTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenStatusTitle.Location = new System.Drawing.Point(648, 37);
            this.lblSigGenStatusTitle.Name = "lblSigGenStatusTitle";
            this.lblSigGenStatusTitle.Size = new System.Drawing.Size(55, 20);
            this.lblSigGenStatusTitle.TabIndex = 7;
            this.lblSigGenStatusTitle.Text = "Status :";
            // 
            // lblSigGenStatus
            // 
            this.lblSigGenStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSigGenStatus.ForeColor = System.Drawing.Color.Red;
            this.lblSigGenStatus.Location = new System.Drawing.Point(708, 37);
            this.lblSigGenStatus.Name = "lblSigGenStatus";
            this.lblSigGenStatus.Size = new System.Drawing.Size(150, 20);
            this.lblSigGenStatus.TabIndex = 8;
            this.lblSigGenStatus.Text = "Disconnected";
            // 
            // grpSpectrumConn
            // 
            this.grpSpectrumConn.BackColor = System.Drawing.Color.White;
            this.grpSpectrumConn.Controls.Add(this.picSpectrumStatus);
            this.grpSpectrumConn.Controls.Add(this.lblSpectrumIP);
            this.grpSpectrumConn.Controls.Add(this.txtSpectrumIP);
            this.grpSpectrumConn.Controls.Add(this.lblSpectrumPort);
            this.grpSpectrumConn.Controls.Add(this.txtSpectrumPort);
            this.grpSpectrumConn.Controls.Add(this.btnSpectrumConnect);
            this.grpSpectrumConn.Controls.Add(this.btnSpectrumDisconnect);
            this.grpSpectrumConn.Controls.Add(this.lblSpectrumStatusTitle);
            this.grpSpectrumConn.Controls.Add(this.lblSpectrumStatus);
            this.grpSpectrumConn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSpectrumConn.ForeColor = System.Drawing.Color.DarkGreen;
            this.grpSpectrumConn.Location = new System.Drawing.Point(6, 92);
            this.grpSpectrumConn.Name = "grpSpectrumConn";
            this.grpSpectrumConn.Size = new System.Drawing.Size(1120, 74);
            this.grpSpectrumConn.TabIndex = 2;
            this.grpSpectrumConn.TabStop = false;
            this.grpSpectrumConn.Text = "  Spectrum Analyzer Connection";
            // 
            // picSpectrumStatus
            // 
            this.picSpectrumStatus.BackColor = System.Drawing.Color.Red;
            this.picSpectrumStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSpectrumStatus.Location = new System.Drawing.Point(12, 35);
            this.picSpectrumStatus.Name = "picSpectrumStatus";
            this.picSpectrumStatus.Size = new System.Drawing.Size(20, 20);
            this.picSpectrumStatus.TabIndex = 0;
            this.picSpectrumStatus.TabStop = false;
            // 
            // lblSpectrumIP
            // 
            this.lblSpectrumIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSpectrumIP.ForeColor = System.Drawing.Color.Black;
            this.lblSpectrumIP.Location = new System.Drawing.Point(40, 37);
            this.lblSpectrumIP.Name = "lblSpectrumIP";
            this.lblSpectrumIP.Size = new System.Drawing.Size(75, 20);
            this.lblSpectrumIP.TabIndex = 1;
            this.lblSpectrumIP.Text = "IP Address :";
            // 
            // txtSpectrumIP
            // 
            this.txtSpectrumIP.BackColor = System.Drawing.Color.LightCyan;
            this.txtSpectrumIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpectrumIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSpectrumIP.Location = new System.Drawing.Point(120, 35);
            this.txtSpectrumIP.Name = "txtSpectrumIP";
            this.txtSpectrumIP.Size = new System.Drawing.Size(160, 23);
            this.txtSpectrumIP.TabIndex = 2;
            this.txtSpectrumIP.Text = "127.0.0.1";
            // 
            // lblSpectrumPort
            // 
            this.lblSpectrumPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSpectrumPort.ForeColor = System.Drawing.Color.Black;
            this.lblSpectrumPort.Location = new System.Drawing.Point(292, 37);
            this.lblSpectrumPort.Name = "lblSpectrumPort";
            this.lblSpectrumPort.Size = new System.Drawing.Size(40, 20);
            this.lblSpectrumPort.TabIndex = 3;
            this.lblSpectrumPort.Text = "Port :";
            // 
            // txtSpectrumPort
            // 
            this.txtSpectrumPort.BackColor = System.Drawing.Color.LightCyan;
            this.txtSpectrumPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpectrumPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSpectrumPort.Location = new System.Drawing.Point(336, 35);
            this.txtSpectrumPort.Name = "txtSpectrumPort";
            this.txtSpectrumPort.Size = new System.Drawing.Size(70, 23);
            this.txtSpectrumPort.TabIndex = 4;
            this.txtSpectrumPort.Text = "7";
            // 
            // btnSpectrumConnect
            // 
            this.btnSpectrumConnect.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSpectrumConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSpectrumConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpectrumConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSpectrumConnect.ForeColor = System.Drawing.Color.White;
            this.btnSpectrumConnect.Location = new System.Drawing.Point(420, 28);
            this.btnSpectrumConnect.Name = "btnSpectrumConnect";
            this.btnSpectrumConnect.Size = new System.Drawing.Size(100, 30);
            this.btnSpectrumConnect.TabIndex = 5;
            this.btnSpectrumConnect.Text = "Connect";
            this.btnSpectrumConnect.UseVisualStyleBackColor = false;
            this.btnSpectrumConnect.Click += new System.EventHandler(this.btnSpectrumConnect_Click);
            // 
            // btnSpectrumDisconnect
            // 
            this.btnSpectrumDisconnect.BackColor = System.Drawing.Color.Crimson;
            this.btnSpectrumDisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSpectrumDisconnect.Enabled = false;
            this.btnSpectrumDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpectrumDisconnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSpectrumDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnSpectrumDisconnect.Location = new System.Drawing.Point(530, 28);
            this.btnSpectrumDisconnect.Name = "btnSpectrumDisconnect";
            this.btnSpectrumDisconnect.Size = new System.Drawing.Size(100, 30);
            this.btnSpectrumDisconnect.TabIndex = 6;
            this.btnSpectrumDisconnect.Text = "Disconnect";
            this.btnSpectrumDisconnect.UseVisualStyleBackColor = false;
            this.btnSpectrumDisconnect.Click += new System.EventHandler(this.btnSpectrumDisconnect_Click);
            // 
            // lblSpectrumStatusTitle
            // 
            this.lblSpectrumStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSpectrumStatusTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSpectrumStatusTitle.Location = new System.Drawing.Point(648, 37);
            this.lblSpectrumStatusTitle.Name = "lblSpectrumStatusTitle";
            this.lblSpectrumStatusTitle.Size = new System.Drawing.Size(55, 20);
            this.lblSpectrumStatusTitle.TabIndex = 7;
            this.lblSpectrumStatusTitle.Text = "Status :";
            // 
            // lblSpectrumStatus
            // 
            this.lblSpectrumStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSpectrumStatus.ForeColor = System.Drawing.Color.Red;
            this.lblSpectrumStatus.Location = new System.Drawing.Point(708, 37);
            this.lblSpectrumStatus.Name = "lblSpectrumStatus";
            this.lblSpectrumStatus.Size = new System.Drawing.Size(150, 20);
            this.lblSpectrumStatus.TabIndex = 8;
            this.lblSpectrumStatus.Text = "Disconnected";
            // 
            // grpVNAConn
            // 
            this.grpVNAConn.BackColor = System.Drawing.Color.White;
            this.grpVNAConn.Controls.Add(this.picVNAStatus);
            this.grpVNAConn.Controls.Add(this.lblVNAIP);
            this.grpVNAConn.Controls.Add(this.txtVNAIP);
            this.grpVNAConn.Controls.Add(this.lblVNAPort);
            this.grpVNAConn.Controls.Add(this.txtVNAPort);
            this.grpVNAConn.Controls.Add(this.btnVNAConnect);
            this.grpVNAConn.Controls.Add(this.btnVNADisconnect);
            this.grpVNAConn.Controls.Add(this.lblVNAStatusTitle);
            this.grpVNAConn.Controls.Add(this.lblVNAStatus);
            this.grpVNAConn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpVNAConn.ForeColor = System.Drawing.Color.DarkViolet;
            this.grpVNAConn.Location = new System.Drawing.Point(6, 174);
            this.grpVNAConn.Name = "grpVNAConn";
            this.grpVNAConn.Size = new System.Drawing.Size(1120, 80);
            this.grpVNAConn.TabIndex = 3;
            this.grpVNAConn.TabStop = false;
            this.grpVNAConn.Text = "  VNA Connection";
            // 
            // picVNAStatus
            // 
            this.picVNAStatus.BackColor = System.Drawing.Color.Red;
            this.picVNAStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVNAStatus.Location = new System.Drawing.Point(12, 35);
            this.picVNAStatus.Name = "picVNAStatus";
            this.picVNAStatus.Size = new System.Drawing.Size(20, 20);
            this.picVNAStatus.TabIndex = 0;
            this.picVNAStatus.TabStop = false;
            // 
            // lblVNAIP
            // 
            this.lblVNAIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVNAIP.ForeColor = System.Drawing.Color.Black;
            this.lblVNAIP.Location = new System.Drawing.Point(40, 37);
            this.lblVNAIP.Name = "lblVNAIP";
            this.lblVNAIP.Size = new System.Drawing.Size(75, 20);
            this.lblVNAIP.TabIndex = 1;
            this.lblVNAIP.Text = "IP Address :";
            // 
            // txtVNAIP
            // 
            this.txtVNAIP.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtVNAIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVNAIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVNAIP.Location = new System.Drawing.Point(120, 35);
            this.txtVNAIP.Name = "txtVNAIP";
            this.txtVNAIP.Size = new System.Drawing.Size(160, 23);
            this.txtVNAIP.TabIndex = 2;
            this.txtVNAIP.Text = "10.1.6.147";
            // 
            // lblVNAPort
            // 
            this.lblVNAPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVNAPort.ForeColor = System.Drawing.Color.Black;
            this.lblVNAPort.Location = new System.Drawing.Point(292, 37);
            this.lblVNAPort.Name = "lblVNAPort";
            this.lblVNAPort.Size = new System.Drawing.Size(40, 20);
            this.lblVNAPort.TabIndex = 3;
            this.lblVNAPort.Text = "Port :";
            // 
            // txtVNAPort
            // 
            this.txtVNAPort.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtVNAPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVNAPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVNAPort.Location = new System.Drawing.Point(336, 35);
            this.txtVNAPort.Name = "txtVNAPort";
            this.txtVNAPort.Size = new System.Drawing.Size(70, 23);
            this.txtVNAPort.TabIndex = 4;
            this.txtVNAPort.Text = "5025";
            // 
            // btnVNAConnect
            // 
            this.btnVNAConnect.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnVNAConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVNAConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVNAConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVNAConnect.ForeColor = System.Drawing.Color.White;
            this.btnVNAConnect.Location = new System.Drawing.Point(420, 28);
            this.btnVNAConnect.Name = "btnVNAConnect";
            this.btnVNAConnect.Size = new System.Drawing.Size(100, 30);
            this.btnVNAConnect.TabIndex = 5;
            this.btnVNAConnect.Text = "Connect";
            this.btnVNAConnect.UseVisualStyleBackColor = false;
            this.btnVNAConnect.Click += new System.EventHandler(this.btnVNAConnect_Click);
            // 
            // btnVNADisconnect
            // 
            this.btnVNADisconnect.BackColor = System.Drawing.Color.Crimson;
            this.btnVNADisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVNADisconnect.Enabled = false;
            this.btnVNADisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVNADisconnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVNADisconnect.ForeColor = System.Drawing.Color.White;
            this.btnVNADisconnect.Location = new System.Drawing.Point(530, 28);
            this.btnVNADisconnect.Name = "btnVNADisconnect";
            this.btnVNADisconnect.Size = new System.Drawing.Size(100, 30);
            this.btnVNADisconnect.TabIndex = 6;
            this.btnVNADisconnect.Text = "Disconnect";
            this.btnVNADisconnect.UseVisualStyleBackColor = false;
            this.btnVNADisconnect.Click += new System.EventHandler(this.btnVNADisconnect_Click);
            // 
            // lblVNAStatusTitle
            // 
            this.lblVNAStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVNAStatusTitle.ForeColor = System.Drawing.Color.Black;
            this.lblVNAStatusTitle.Location = new System.Drawing.Point(648, 37);
            this.lblVNAStatusTitle.Name = "lblVNAStatusTitle";
            this.lblVNAStatusTitle.Size = new System.Drawing.Size(55, 20);
            this.lblVNAStatusTitle.TabIndex = 7;
            this.lblVNAStatusTitle.Text = "Status :";
            // 
            // lblVNAStatus
            // 
            this.lblVNAStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVNAStatus.ForeColor = System.Drawing.Color.Red;
            this.lblVNAStatus.Location = new System.Drawing.Point(708, 37);
            this.lblVNAStatus.Name = "lblVNAStatus";
            this.lblVNAStatus.Size = new System.Drawing.Size(150, 20);
            this.lblVNAStatus.TabIndex = 8;
            this.lblVNAStatus.Text = "Disconnected";
            // 
            // grp1553Conn
            // 
            this.grp1553Conn.BackColor = System.Drawing.Color.White;
            this.grp1553Conn.Controls.Add(this.pic1553Status);
            this.grp1553Conn.Controls.Add(this.lbl1553DeviceId);
            this.grp1553Conn.Controls.Add(this.txt1553DeviceId);
            this.grp1553Conn.Controls.Add(this.lbl1553RTAddr);
            this.grp1553Conn.Controls.Add(this.cmb1553RTAddr);
            this.grp1553Conn.Controls.Add(this.lbl1553SubAddr);
            this.grp1553Conn.Controls.Add(this.label7);
            this.grp1553Conn.Controls.Add(this.cmb1553SubAddr);
            this.grp1553Conn.Controls.Add(this.lbl1553Bus);
            this.grp1553Conn.Controls.Add(this.cmb1553Bus);
            this.grp1553Conn.Controls.Add(this.btn1553Connect);
            this.grp1553Conn.Controls.Add(this.btn1553Disconnect);
            this.grp1553Conn.Controls.Add(this.lbl1553StatusTitle);
            this.grp1553Conn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grp1553Conn.ForeColor = System.Drawing.Color.DarkRed;
            this.grp1553Conn.Location = new System.Drawing.Point(6, 348);
            this.grp1553Conn.Name = "grp1553Conn";
            this.grp1553Conn.Size = new System.Drawing.Size(1120, 90);
            this.grp1553Conn.TabIndex = 4;
            this.grp1553Conn.TabStop = false;
            this.grp1553Conn.Text = "  DDC MIL-STD-1553 Bus Controller";
            // 
            // pic1553Status
            // 
            this.pic1553Status.BackColor = System.Drawing.Color.Red;
            this.pic1553Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic1553Status.Location = new System.Drawing.Point(12, 40);
            this.pic1553Status.Name = "pic1553Status";
            this.pic1553Status.Size = new System.Drawing.Size(20, 20);
            this.pic1553Status.TabIndex = 0;
            this.pic1553Status.TabStop = false;
            // 
            // lbl1553DeviceId
            // 
            this.lbl1553DeviceId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553DeviceId.ForeColor = System.Drawing.Color.Black;
            this.lbl1553DeviceId.Location = new System.Drawing.Point(40, 42);
            this.lbl1553DeviceId.Name = "lbl1553DeviceId";
            this.lbl1553DeviceId.Size = new System.Drawing.Size(70, 20);
            this.lbl1553DeviceId.TabIndex = 1;
            this.lbl1553DeviceId.Text = "Device ID :";
            // 
            // txt1553DeviceId
            // 
            this.txt1553DeviceId.BackColor = System.Drawing.Color.LightYellow;
            this.txt1553DeviceId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1553DeviceId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt1553DeviceId.Location = new System.Drawing.Point(115, 40);
            this.txt1553DeviceId.Name = "txt1553DeviceId";
            this.txt1553DeviceId.Size = new System.Drawing.Size(50, 23);
            this.txt1553DeviceId.TabIndex = 2;
            this.txt1553DeviceId.Text = "0";
            // 
            // lbl1553RTAddr
            // 
            this.lbl1553RTAddr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553RTAddr.ForeColor = System.Drawing.Color.Black;
            this.lbl1553RTAddr.Location = new System.Drawing.Point(178, 42);
            this.lbl1553RTAddr.Name = "lbl1553RTAddr";
            this.lbl1553RTAddr.Size = new System.Drawing.Size(75, 20);
            this.lbl1553RTAddr.TabIndex = 3;
            this.lbl1553RTAddr.Text = "RT Address :";
            // 
            // cmb1553RTAddr
            // 
            this.cmb1553RTAddr.BackColor = System.Drawing.Color.LightYellow;
            this.cmb1553RTAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb1553RTAddr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmb1553RTAddr.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmb1553RTAddr.Location = new System.Drawing.Point(258, 40);
            this.cmb1553RTAddr.Name = "cmb1553RTAddr";
            this.cmb1553RTAddr.Size = new System.Drawing.Size(60, 23);
            this.cmb1553RTAddr.TabIndex = 4;
            // 
            // lbl1553SubAddr
            // 
            this.lbl1553SubAddr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553SubAddr.ForeColor = System.Drawing.Color.Black;
            this.lbl1553SubAddr.Location = new System.Drawing.Point(330, 42);
            this.lbl1553SubAddr.Name = "lbl1553SubAddr";
            this.lbl1553SubAddr.Size = new System.Drawing.Size(80, 20);
            this.lbl1553SubAddr.TabIndex = 5;
            this.lbl1553SubAddr.Text = "Sub Address :";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(916, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Not tested";
            // 
            // cmb1553SubAddr
            // 
            this.cmb1553SubAddr.BackColor = System.Drawing.Color.LightYellow;
            this.cmb1553SubAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb1553SubAddr.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmb1553SubAddr.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cmb1553SubAddr.Location = new System.Drawing.Point(415, 40);
            this.cmb1553SubAddr.Name = "cmb1553SubAddr";
            this.cmb1553SubAddr.Size = new System.Drawing.Size(60, 23);
            this.cmb1553SubAddr.TabIndex = 6;
            // 
            // lbl1553Bus
            // 
            this.lbl1553Bus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553Bus.ForeColor = System.Drawing.Color.Black;
            this.lbl1553Bus.Location = new System.Drawing.Point(488, 42);
            this.lbl1553Bus.Name = "lbl1553Bus";
            this.lbl1553Bus.Size = new System.Drawing.Size(40, 20);
            this.lbl1553Bus.TabIndex = 7;
            this.lbl1553Bus.Text = "Bus :";
            // 
            // cmb1553Bus
            // 
            this.cmb1553Bus.BackColor = System.Drawing.Color.LightYellow;
            this.cmb1553Bus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb1553Bus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmb1553Bus.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cmb1553Bus.Location = new System.Drawing.Point(528, 40);
            this.cmb1553Bus.Name = "cmb1553Bus";
            this.cmb1553Bus.Size = new System.Drawing.Size(55, 23);
            this.cmb1553Bus.TabIndex = 8;
            // 
            // btn1553Connect
            // 
            this.btn1553Connect.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn1553Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1553Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1553Connect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn1553Connect.ForeColor = System.Drawing.Color.White;
            this.btn1553Connect.Location = new System.Drawing.Point(598, 30);
            this.btn1553Connect.Name = "btn1553Connect";
            this.btn1553Connect.Size = new System.Drawing.Size(120, 32);
            this.btn1553Connect.TabIndex = 9;
            this.btn1553Connect.Text = "Test Connect";
            this.btn1553Connect.UseVisualStyleBackColor = false;
            this.btn1553Connect.Click += new System.EventHandler(this.btn1553Connect_Click);
            // 
            // btn1553Disconnect
            // 
            this.btn1553Disconnect.BackColor = System.Drawing.Color.Crimson;
            this.btn1553Disconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1553Disconnect.Enabled = false;
            this.btn1553Disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1553Disconnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn1553Disconnect.ForeColor = System.Drawing.Color.White;
            this.btn1553Disconnect.Location = new System.Drawing.Point(728, 30);
            this.btn1553Disconnect.Name = "btn1553Disconnect";
            this.btn1553Disconnect.Size = new System.Drawing.Size(110, 32);
            this.btn1553Disconnect.TabIndex = 10;
            this.btn1553Disconnect.Text = "Disconnect";
            this.btn1553Disconnect.UseVisualStyleBackColor = false;
            this.btn1553Disconnect.Click += new System.EventHandler(this.btn1553Disconnect_Click);
            // 
            // lbl1553StatusTitle
            // 
            this.lbl1553StatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553StatusTitle.ForeColor = System.Drawing.Color.Black;
            this.lbl1553StatusTitle.Location = new System.Drawing.Point(855, 42);
            this.lbl1553StatusTitle.Name = "lbl1553StatusTitle";
            this.lbl1553StatusTitle.Size = new System.Drawing.Size(55, 20);
            this.lbl1553StatusTitle.TabIndex = 11;
            this.lbl1553StatusTitle.Text = "Status :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbl1553Status);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(6, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1120, 80);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DDC Card Info";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(40, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Model Num :";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightYellow;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox2.Location = new System.Drawing.Point(120, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 23);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "BU-67103U200L-JLO";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(420, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(530, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(648, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Status :";
            // 
            // lbl1553Status
            // 
            this.lbl1553Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl1553Status.ForeColor = System.Drawing.Color.Red;
            this.lbl1553Status.Location = new System.Drawing.Point(708, 38);
            this.lbl1553Status.Name = "lbl1553Status";
            this.lbl1553Status.Size = new System.Drawing.Size(180, 20);
            this.lbl1553Status.TabIndex = 12;
            this.lbl1553Status.Text = "Disconnected";
            // 
            // lblMainStatus
            // 
            this.lblMainStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.lblMainStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMainStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblMainStatus.Location = new System.Drawing.Point(6, 540);
            this.lblMainStatus.Name = "lblMainStatus";
            this.lblMainStatus.Size = new System.Drawing.Size(1120, 35);
            this.lblMainStatus.TabIndex = 6;
            this.lblMainStatus.Text = "Status : Ready - Please Connect Equipment";
            this.lblMainStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.grpBWScal);
            this.tabPage2.Controls.Add(this.lblSigGenConnInfo);
            this.tabPage2.Controls.Add(this.grpTCPowerSelect);
            this.tabPage2.Controls.Add(this.grpSigGenPowerSweep);
            this.tabPage2.Controls.Add(this.grpSigGenParams);
            this.tabPage2.Controls.Add(this.grp_powerLimit);
            this.tabPage2.Controls.Add(this.grpLiveOutput);
            this.tabPage2.Controls.Add(this.btnStart);
            this.tabPage2.Controls.Add(this.btnStop);
            this.tabPage2.Controls.Add(this.lblOutFreq);
            this.tabPage2.Controls.Add(this.txtOutFreq);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1140, 584);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Operation ";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(367, 443);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 30;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cmbBand
            // 
            this.cmbBand.FormattingEnabled = true;
            this.cmbBand.Items.AddRange(new object[] {
            "NarrowBand",
            "WideBand"});
            this.cmbBand.Location = new System.Drawing.Point(96, 53);
            this.cmbBand.Name = "cmbBand";
            this.cmbBand.Size = new System.Drawing.Size(189, 23);
            this.cmbBand.TabIndex = 29;
            this.cmbBand.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // grpBWScal
            // 
            this.grpBWScal.BackColor = System.Drawing.Color.White;
            this.grpBWScal.Controls.Add(this.lblPowUnit);
            this.grpBWScal.Controls.Add(this.lbl_ipPow);
            this.grpBWScal.Controls.Add(this.txtbwPow);
            this.grpBWScal.Controls.Add(this.lblBwUnit);
            this.grpBWScal.Controls.Add(this.lblipBw);
            this.grpBWScal.Controls.Add(this.txtBW);
            this.grpBWScal.Controls.Add(this.lblFrequnit);
            this.grpBWScal.Controls.Add(this.lbl_ipFreq);
            this.grpBWScal.Controls.Add(this.txt_bwfreq);
            this.grpBWScal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpBWScal.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.grpBWScal.Location = new System.Drawing.Point(6, 241);
            this.grpBWScal.Name = "grpBWScal";
            this.grpBWScal.Size = new System.Drawing.Size(565, 145);
            this.grpBWScal.TabIndex = 15;
            this.grpBWScal.TabStop = false;
            this.grpBWScal.Text = "Bandwidth Scaling";
            this.grpBWScal.Visible = false;
            // 
            // lblPowUnit
            // 
            this.lblPowUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPowUnit.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPowUnit.Location = new System.Drawing.Point(467, 34);
            this.lblPowUnit.Name = "lblPowUnit";
            this.lblPowUnit.Size = new System.Drawing.Size(35, 22);
            this.lblPowUnit.TabIndex = 13;
            this.lblPowUnit.Text = "dBm";
            // 
            // lbl_ipPow
            // 
            this.lbl_ipPow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_ipPow.ForeColor = System.Drawing.Color.Black;
            this.lbl_ipPow.Location = new System.Drawing.Point(273, 34);
            this.lbl_ipPow.Name = "lbl_ipPow";
            this.lbl_ipPow.Size = new System.Drawing.Size(102, 22);
            this.lbl_ipPow.TabIndex = 12;
            this.lbl_ipPow.Text = "I/P Power (dBm) : ";
            // 
            // txtbwPow
            // 
            this.txtbwPow.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtbwPow.Location = new System.Drawing.Point(381, 31);
            this.txtbwPow.Name = "txtbwPow";
            this.txtbwPow.Size = new System.Drawing.Size(80, 23);
            this.txtbwPow.TabIndex = 11;
            this.txtbwPow.Text = "7";
            // 
            // lblBwUnit
            // 
            this.lblBwUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBwUnit.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBwUnit.Location = new System.Drawing.Point(196, 67);
            this.lblBwUnit.Name = "lblBwUnit";
            this.lblBwUnit.Size = new System.Drawing.Size(35, 22);
            this.lblBwUnit.TabIndex = 10;
            this.lblBwUnit.Text = "KHz";
            // 
            // lblipBw
            // 
            this.lblipBw.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblipBw.ForeColor = System.Drawing.Color.Black;
            this.lblipBw.Location = new System.Drawing.Point(10, 67);
            this.lblipBw.Name = "lblipBw";
            this.lblipBw.Size = new System.Drawing.Size(94, 22);
            this.lblipBw.TabIndex = 9;
            this.lblipBw.Text = "I/P BW (KHz) :";
            // 
            // txtBW
            // 
            this.txtBW.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtBW.Location = new System.Drawing.Point(110, 64);
            this.txtBW.Name = "txtBW";
            this.txtBW.Size = new System.Drawing.Size(80, 23);
            this.txtBW.TabIndex = 8;
            this.txtBW.Text = "7";
            // 
            // lblFrequnit
            // 
            this.lblFrequnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFrequnit.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblFrequnit.Location = new System.Drawing.Point(195, 34);
            this.lblFrequnit.Name = "lblFrequnit";
            this.lblFrequnit.Size = new System.Drawing.Size(35, 22);
            this.lblFrequnit.TabIndex = 7;
            this.lblFrequnit.Text = "GHz";
            // 
            // lbl_ipFreq
            // 
            this.lbl_ipFreq.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_ipFreq.ForeColor = System.Drawing.Color.Black;
            this.lbl_ipFreq.Location = new System.Drawing.Point(10, 34);
            this.lbl_ipFreq.Name = "lbl_ipFreq";
            this.lbl_ipFreq.Size = new System.Drawing.Size(95, 22);
            this.lbl_ipFreq.TabIndex = 6;
            this.lbl_ipFreq.Text = "I/P Freqs (Hz) :";
            // 
            // txt_bwfreq
            // 
            this.txt_bwfreq.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_bwfreq.Location = new System.Drawing.Point(109, 31);
            this.txt_bwfreq.Name = "txt_bwfreq";
            this.txt_bwfreq.Size = new System.Drawing.Size(80, 23);
            this.txt_bwfreq.TabIndex = 5;
            this.txt_bwfreq.Text = "7";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(349, 550);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "VNA_Send";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblSigGenConnInfo
            // 
            this.lblSigGenConnInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSigGenConnInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSigGenConnInfo.Location = new System.Drawing.Point(6, 8);
            this.lblSigGenConnInfo.Name = "lblSigGenConnInfo";
            this.lblSigGenConnInfo.Size = new System.Drawing.Size(700, 22);
            this.lblSigGenConnInfo.TabIndex = 0;
            this.lblSigGenConnInfo.Text = "Signal Generator : Not Connected";
            this.lblSigGenConnInfo.Visible = false;
            // 
            // grpSigGenPowerSweep
            // 
            this.grpSigGenPowerSweep.BackColor = System.Drawing.Color.White;
            this.grpSigGenPowerSweep.Controls.Add(this.lblSigGenPowerStart);
            this.grpSigGenPowerSweep.Controls.Add(this.txtSigGenPowerStart);
            this.grpSigGenPowerSweep.Controls.Add(this.lblSigGenPowerStartUnit);
            this.grpSigGenPowerSweep.Controls.Add(this.lblSigGenPowerStop);
            this.grpSigGenPowerSweep.Controls.Add(this.txtSigGenPowerStop);
            this.grpSigGenPowerSweep.Controls.Add(this.lblSigGenPowerStopUnit);
            this.grpSigGenPowerSweep.Controls.Add(this.lblSigGenPowerStep);
            this.grpSigGenPowerSweep.Controls.Add(this.txtSigGenPowerStep);
            this.grpSigGenPowerSweep.Controls.Add(this.lblSigGenPowerStepUnit);
            this.grpSigGenPowerSweep.Controls.Add(this.label1);
            this.grpSigGenPowerSweep.Controls.Add(this.lblPower);
            this.grpSigGenPowerSweep.Controls.Add(this.txtPower);
            this.grpSigGenPowerSweep.Controls.Add(this.lblOutPower);
            this.grpSigGenPowerSweep.Controls.Add(this.txtOutPower);
            this.grpSigGenPowerSweep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSigGenPowerSweep.ForeColor = System.Drawing.Color.DarkRed;
            this.grpSigGenPowerSweep.Location = new System.Drawing.Point(6, 241);
            this.grpSigGenPowerSweep.Name = "grpSigGenPowerSweep";
            this.grpSigGenPowerSweep.Size = new System.Drawing.Size(565, 145);
            this.grpSigGenPowerSweep.TabIndex = 1;
            this.grpSigGenPowerSweep.TabStop = false;
            this.grpSigGenPowerSweep.Text = "  Power Sweep (Input Signal Power)";
            this.grpSigGenPowerSweep.Visible = false;
            // 
            // lblSigGenPowerStart
            // 
            this.lblSigGenPowerStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenPowerStart.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenPowerStart.Location = new System.Drawing.Point(10, 30);
            this.lblSigGenPowerStart.Name = "lblSigGenPowerStart";
            this.lblSigGenPowerStart.Size = new System.Drawing.Size(100, 22);
            this.lblSigGenPowerStart.TabIndex = 0;
            this.lblSigGenPowerStart.Text = "Start Power :";
            // 
            // txtSigGenPowerStart
            // 
            this.txtSigGenPowerStart.BackColor = System.Drawing.Color.MistyRose;
            this.txtSigGenPowerStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSigGenPowerStart.Location = new System.Drawing.Point(115, 28);
            this.txtSigGenPowerStart.Name = "txtSigGenPowerStart";
            this.txtSigGenPowerStart.Size = new System.Drawing.Size(70, 23);
            this.txtSigGenPowerStart.TabIndex = 1;
            this.txtSigGenPowerStart.Text = "-55";
            // 
            // lblSigGenPowerStartUnit
            // 
            this.lblSigGenPowerStartUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSigGenPowerStartUnit.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSigGenPowerStartUnit.Location = new System.Drawing.Point(192, 30);
            this.lblSigGenPowerStartUnit.Name = "lblSigGenPowerStartUnit";
            this.lblSigGenPowerStartUnit.Size = new System.Drawing.Size(35, 22);
            this.lblSigGenPowerStartUnit.TabIndex = 2;
            this.lblSigGenPowerStartUnit.Text = "dBm";
            // 
            // lblSigGenPowerStop
            // 
            this.lblSigGenPowerStop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenPowerStop.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenPowerStop.Location = new System.Drawing.Point(10, 65);
            this.lblSigGenPowerStop.Name = "lblSigGenPowerStop";
            this.lblSigGenPowerStop.Size = new System.Drawing.Size(100, 22);
            this.lblSigGenPowerStop.TabIndex = 3;
            this.lblSigGenPowerStop.Text = "Stop Power :";
            // 
            // txtSigGenPowerStop
            // 
            this.txtSigGenPowerStop.BackColor = System.Drawing.Color.MistyRose;
            this.txtSigGenPowerStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSigGenPowerStop.Location = new System.Drawing.Point(115, 63);
            this.txtSigGenPowerStop.Name = "txtSigGenPowerStop";
            this.txtSigGenPowerStop.Size = new System.Drawing.Size(70, 23);
            this.txtSigGenPowerStop.TabIndex = 4;
            this.txtSigGenPowerStop.Text = "-10";
            // 
            // lblSigGenPowerStopUnit
            // 
            this.lblSigGenPowerStopUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSigGenPowerStopUnit.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSigGenPowerStopUnit.Location = new System.Drawing.Point(192, 65);
            this.lblSigGenPowerStopUnit.Name = "lblSigGenPowerStopUnit";
            this.lblSigGenPowerStopUnit.Size = new System.Drawing.Size(35, 22);
            this.lblSigGenPowerStopUnit.TabIndex = 5;
            this.lblSigGenPowerStopUnit.Text = "dBm";
            // 
            // lblSigGenPowerStep
            // 
            this.lblSigGenPowerStep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenPowerStep.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenPowerStep.Location = new System.Drawing.Point(240, 30);
            this.lblSigGenPowerStep.Name = "lblSigGenPowerStep";
            this.lblSigGenPowerStep.Size = new System.Drawing.Size(50, 22);
            this.lblSigGenPowerStep.TabIndex = 6;
            this.lblSigGenPowerStep.Text = "Step :";
            // 
            // txtSigGenPowerStep
            // 
            this.txtSigGenPowerStep.BackColor = System.Drawing.Color.MistyRose;
            this.txtSigGenPowerStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSigGenPowerStep.Location = new System.Drawing.Point(295, 28);
            this.txtSigGenPowerStep.Name = "txtSigGenPowerStep";
            this.txtSigGenPowerStep.Size = new System.Drawing.Size(70, 23);
            this.txtSigGenPowerStep.TabIndex = 7;
            this.txtSigGenPowerStep.Text = "5";
            // 
            // lblSigGenPowerStepUnit
            // 
            this.lblSigGenPowerStepUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSigGenPowerStepUnit.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSigGenPowerStepUnit.Location = new System.Drawing.Point(372, 30);
            this.lblSigGenPowerStepUnit.Name = "lblSigGenPowerStepUnit";
            this.lblSigGenPowerStepUnit.Size = new System.Drawing.Size(35, 22);
            this.lblSigGenPowerStepUnit.TabIndex = 8;
            this.lblSigGenPowerStepUnit.Text = "dBm";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(372, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "dBm";
            // 
            // lblPower
            // 
            this.lblPower.ForeColor = System.Drawing.Color.Black;
            this.lblPower.Location = new System.Drawing.Point(240, 65);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(50, 22);
            this.lblPower.TabIndex = 10;
            this.lblPower.Text = "Power:";
            // 
            // txtPower
            // 
            this.txtPower.BackColor = System.Drawing.Color.MistyRose;
            this.txtPower.Location = new System.Drawing.Point(295, 63);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(70, 23);
            this.txtPower.TabIndex = 11;
            // 
            // lblOutPower
            // 
            this.lblOutPower.Location = new System.Drawing.Point(10, 100);
            this.lblOutPower.Name = "lblOutPower";
            this.lblOutPower.Size = new System.Drawing.Size(100, 22);
            this.lblOutPower.TabIndex = 12;
            this.lblOutPower.Text = "Out Power:";
            // 
            // txtOutPower
            // 
            this.txtOutPower.Location = new System.Drawing.Point(115, 98);
            this.txtOutPower.Name = "txtOutPower";
            this.txtOutPower.Size = new System.Drawing.Size(80, 23);
            this.txtOutPower.TabIndex = 13;
            // 
            // grpTCPowerSelect
            // 
            this.grpTCPowerSelect.BackColor = System.Drawing.Color.White;
            this.grpTCPowerSelect.Controls.Add(this.lblTCPowerSelect);
            this.grpTCPowerSelect.Controls.Add(this.cmbPower);
            this.grpTCPowerSelect.Controls.Add(this.lblGainStart);
            this.grpTCPowerSelect.Controls.Add(this.txtGainStart);
            this.grpTCPowerSelect.Controls.Add(this.lblGainStop);
            this.grpTCPowerSelect.Controls.Add(this.txtGainStop);
            this.grpTCPowerSelect.Controls.Add(this.lblGainStep);
            this.grpTCPowerSelect.Controls.Add(this.txtGainStep);
            this.grpTCPowerSelect.Controls.Add(this.lblGainDelay);
            this.grpTCPowerSelect.Controls.Add(this.txtGainDelay);
            this.grpTCPowerSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTCPowerSelect.ForeColor = System.Drawing.Color.DarkOrange;
            this.grpTCPowerSelect.Location = new System.Drawing.Point(6, 241);
            this.grpTCPowerSelect.Name = "grpTCPowerSelect";
            this.grpTCPowerSelect.Size = new System.Drawing.Size(565, 145);
            this.grpTCPowerSelect.TabIndex = 2;
            this.grpTCPowerSelect.TabStop = false;
            this.grpTCPowerSelect.Text = "  TC Gain - Power & Gain Loop Settings";
            this.grpTCPowerSelect.Visible = false;
            // 
            // lblTCPowerSelect
            // 
            this.lblTCPowerSelect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTCPowerSelect.ForeColor = System.Drawing.Color.Black;
            this.lblTCPowerSelect.Location = new System.Drawing.Point(10, 28);
            this.lblTCPowerSelect.Name = "lblTCPowerSelect";
            this.lblTCPowerSelect.Size = new System.Drawing.Size(120, 22);
            this.lblTCPowerSelect.TabIndex = 0;
            this.lblTCPowerSelect.Text = "Input Power Level :";
            // 
            // cmbPower
            // 
            this.cmbPower.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cmbPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPower.Location = new System.Drawing.Point(135, 26);
            this.cmbPower.Name = "cmbPower";
            this.cmbPower.Size = new System.Drawing.Size(80, 23);
            this.cmbPower.TabIndex = 1;
            this.cmbPower.SelectedIndexChanged += new System.EventHandler(this.cmbPower_SelectedIndexChanged);
            // 
            // lblGainStart
            // 
            this.lblGainStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGainStart.ForeColor = System.Drawing.Color.Black;
            this.lblGainStart.Location = new System.Drawing.Point(10, 65);
            this.lblGainStart.Name = "lblGainStart";
            this.lblGainStart.Size = new System.Drawing.Size(75, 22);
            this.lblGainStart.TabIndex = 2;
            this.lblGainStart.Text = "Gain Start :";
            // 
            // txtGainStart
            // 
            this.txtGainStart.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtGainStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGainStart.Location = new System.Drawing.Point(90, 63);
            this.txtGainStart.Name = "txtGainStart";
            this.txtGainStart.Size = new System.Drawing.Size(50, 23);
            this.txtGainStart.TabIndex = 3;
            this.txtGainStart.Text = "0";
            // 
            // lblGainStop
            // 
            this.lblGainStop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGainStop.ForeColor = System.Drawing.Color.Black;
            this.lblGainStop.Location = new System.Drawing.Point(155, 65);
            this.lblGainStop.Name = "lblGainStop";
            this.lblGainStop.Size = new System.Drawing.Size(70, 22);
            this.lblGainStop.TabIndex = 4;
            this.lblGainStop.Text = "Gain Stop :";
            // 
            // txtGainStop
            // 
            this.txtGainStop.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtGainStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGainStop.Location = new System.Drawing.Point(228, 63);
            this.txtGainStop.Name = "txtGainStop";
            this.txtGainStop.Size = new System.Drawing.Size(50, 23);
            this.txtGainStop.TabIndex = 5;
            this.txtGainStop.Text = "45";
            // 
            // lblGainStep
            // 
            this.lblGainStep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGainStep.ForeColor = System.Drawing.Color.Black;
            this.lblGainStep.Location = new System.Drawing.Point(292, 65);
            this.lblGainStep.Name = "lblGainStep";
            this.lblGainStep.Size = new System.Drawing.Size(65, 22);
            this.lblGainStep.TabIndex = 6;
            this.lblGainStep.Text = "Gain Step :";
            // 
            // txtGainStep
            // 
            this.txtGainStep.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtGainStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGainStep.Location = new System.Drawing.Point(360, 63);
            this.txtGainStep.Name = "txtGainStep";
            this.txtGainStep.Size = new System.Drawing.Size(50, 23);
            this.txtGainStep.TabIndex = 7;
            this.txtGainStep.Text = "1";
            // 
            // lblGainDelay
            // 
            this.lblGainDelay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGainDelay.ForeColor = System.Drawing.Color.Black;
            this.lblGainDelay.Location = new System.Drawing.Point(10, 103);
            this.lblGainDelay.Name = "lblGainDelay";
            this.lblGainDelay.Size = new System.Drawing.Size(80, 22);
            this.lblGainDelay.TabIndex = 8;
            this.lblGainDelay.Text = "Delay (ms) :";
            // 
            // txtGainDelay
            // 
            this.txtGainDelay.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtGainDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGainDelay.Location = new System.Drawing.Point(95, 101);
            this.txtGainDelay.Name = "txtGainDelay";
            this.txtGainDelay.Size = new System.Drawing.Size(60, 23);
            this.txtGainDelay.TabIndex = 9;
            this.txtGainDelay.Text = "500";
            // 
            // grpSigGenParams
            // 
            this.grpSigGenParams.BackColor = System.Drawing.Color.White;
            this.grpSigGenParams.Controls.Add(this.cmbMode);
            this.grpSigGenParams.Controls.Add(this.lblFreq);
            this.grpSigGenParams.Controls.Add(this.txtFreq);
            this.grpSigGenParams.Controls.Add(this.lblSigGenCenterFreqUnit);
            this.grpSigGenParams.Controls.Add(this.lblSigGenCarrCount);
            this.grpSigGenParams.Controls.Add(this.txtCarrCount);
            this.grpSigGenParams.Controls.Add(this.lblSigGenToneFreqs);
            this.grpSigGenParams.Controls.Add(this.txtCarrFreqs);
            this.grpSigGenParams.Controls.Add(this.lblSigGenMeasType);
            this.grpSigGenParams.Controls.Add(this.cmbMeasurement);
            this.grpSigGenParams.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSigGenParams.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpSigGenParams.Location = new System.Drawing.Point(6, 35);
            this.grpSigGenParams.Name = "grpSigGenParams";
            this.grpSigGenParams.Size = new System.Drawing.Size(565, 191);
            this.grpSigGenParams.TabIndex = 0;
            this.grpSigGenParams.TabStop = false;
            this.grpSigGenParams.Text = "  Signal Generator Parameters";
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Main",
            "Redundant"});
            this.cmbMode.Location = new System.Drawing.Point(417, 34);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(121, 23);
            this.cmbMode.TabIndex = 9;
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // lblFreq
            // 
            this.lblFreq.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFreq.ForeColor = System.Drawing.Color.Black;
            this.lblFreq.Location = new System.Drawing.Point(10, 32);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(130, 22);
            this.lblFreq.TabIndex = 0;
            this.lblFreq.Text = "Center Freq :";
            // 
            // txtFreq
            // 
            this.txtFreq.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtFreq.Location = new System.Drawing.Point(148, 30);
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.Size = new System.Drawing.Size(100, 23);
            this.txtFreq.TabIndex = 1;
            this.txtFreq.Text = "2000000000";
            // 
            // lblSigGenCenterFreqUnit
            // 
            this.lblSigGenCenterFreqUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSigGenCenterFreqUnit.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSigGenCenterFreqUnit.Location = new System.Drawing.Point(255, 32);
            this.lblSigGenCenterFreqUnit.Name = "lblSigGenCenterFreqUnit";
            this.lblSigGenCenterFreqUnit.Size = new System.Drawing.Size(30, 22);
            this.lblSigGenCenterFreqUnit.TabIndex = 2;
            this.lblSigGenCenterFreqUnit.Text = "Hz";
            // 
            // lblSigGenCarrCount
            // 
            this.lblSigGenCarrCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenCarrCount.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenCarrCount.Location = new System.Drawing.Point(10, 68);
            this.lblSigGenCarrCount.Name = "lblSigGenCarrCount";
            this.lblSigGenCarrCount.Size = new System.Drawing.Size(130, 22);
            this.lblSigGenCarrCount.TabIndex = 3;
            this.lblSigGenCarrCount.Text = "Carrier Count :";
            // 
            // txtCarrCount
            // 
            this.txtCarrCount.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtCarrCount.Location = new System.Drawing.Point(148, 66);
            this.txtCarrCount.Name = "txtCarrCount";
            this.txtCarrCount.Size = new System.Drawing.Size(80, 23);
            this.txtCarrCount.TabIndex = 4;
            this.txtCarrCount.Text = "7";
            // 
            // lblSigGenToneFreqs
            // 
            this.lblSigGenToneFreqs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenToneFreqs.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenToneFreqs.Location = new System.Drawing.Point(10, 104);
            this.lblSigGenToneFreqs.Name = "lblSigGenToneFreqs";
            this.lblSigGenToneFreqs.Size = new System.Drawing.Size(130, 22);
            this.lblSigGenToneFreqs.TabIndex = 5;
            this.lblSigGenToneFreqs.Text = "Freqs (Hz) :";
            // 
            // txtCarrFreqs
            // 
            this.txtCarrFreqs.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtCarrFreqs.Location = new System.Drawing.Point(148, 102);
            this.txtCarrFreqs.Name = "txtCarrFreqs";
            this.txtCarrFreqs.Size = new System.Drawing.Size(400, 23);
            this.txtCarrFreqs.TabIndex = 6;
            this.txtCarrFreqs.Text = "\r\n2578.6,\r\n2579.1,\r\n2579.6,\r\n2580.1,\r\n2580.6,\r\n2581.1,\r\n2577.475";
            // 
            // lblSigGenMeasType
            // 
            this.lblSigGenMeasType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSigGenMeasType.ForeColor = System.Drawing.Color.Black;
            this.lblSigGenMeasType.Location = new System.Drawing.Point(10, 142);
            this.lblSigGenMeasType.Name = "lblSigGenMeasType";
            this.lblSigGenMeasType.Size = new System.Drawing.Size(130, 22);
            this.lblSigGenMeasType.TabIndex = 7;
            this.lblSigGenMeasType.Text = "Measurement Type :";
            // 
            // cmbMeasurement
            // 
            this.cmbMeasurement.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cmbMeasurement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasurement.Location = new System.Drawing.Point(148, 140);
            this.cmbMeasurement.Name = "cmbMeasurement";
            this.cmbMeasurement.Size = new System.Drawing.Size(200, 23);
            this.cmbMeasurement.TabIndex = 8;
            this.cmbMeasurement.SelectedIndexChanged += new System.EventHandler(this.cmbMeasurement_SelectedIndexChanged);
            // 
            // grp_powerLimit
            // 
            this.grp_powerLimit.BackColor = System.Drawing.Color.White;
            this.grp_powerLimit.Controls.Add(this.lblBandTitle);
            this.grp_powerLimit.Controls.Add(this.grp_pwlimitcase2);
            this.grp_powerLimit.Controls.Add(this.cmbBand);
            this.grp_powerLimit.Controls.Add(this.lbl_powerlimit);
            this.grp_powerLimit.Controls.Add(this.PwrLimtunit);
            this.grp_powerLimit.Controls.Add(this.lblLimiter);
            this.grp_powerLimit.Controls.Add(this.cmbLimiterMode);
            this.grp_powerLimit.Controls.Add(this.txtLimiterPower);
            this.grp_powerLimit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grp_powerLimit.ForeColor = System.Drawing.Color.DarkOrange;
            this.grp_powerLimit.Location = new System.Drawing.Point(6, 243);
            this.grp_powerLimit.Name = "grp_powerLimit";
            this.grp_powerLimit.Size = new System.Drawing.Size(565, 143);
            this.grp_powerLimit.TabIndex = 3;
            this.grp_powerLimit.TabStop = false;
            this.grp_powerLimit.Text = "Limiter Functionality";
            this.grp_powerLimit.Visible = false;
            // 
            // grp_pwlimitcase2
            // 
            this.grp_pwlimitcase2.BackColor = System.Drawing.Color.Transparent;
            this.grp_pwlimitcase2.Controls.Add(this.txtlmtStep);
            this.grp_pwlimitcase2.Controls.Add(this.txtlmtDelay);
            this.grp_pwlimitcase2.Controls.Add(this.lbl_pwrlmtStart);
            this.grp_pwlimitcase2.Controls.Add(this.txtlmtStop);
            this.grp_pwlimitcase2.Controls.Add(this.lbl_pwrlmtdel);
            this.grp_pwlimitcase2.Controls.Add(this.lbl_pwrlmtStop);
            this.grp_pwlimitcase2.Controls.Add(this.lbl_pwrlmtStep);
            this.grp_pwlimitcase2.Controls.Add(this.txtlmtStart);
            this.grp_pwlimitcase2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grp_pwlimitcase2.ForeColor = System.Drawing.Color.DarkRed;
            this.grp_pwlimitcase2.Location = new System.Drawing.Point(6, 80);
            this.grp_pwlimitcase2.Name = "grp_pwlimitcase2";
            this.grp_pwlimitcase2.Size = new System.Drawing.Size(545, 54);
            this.grp_pwlimitcase2.TabIndex = 28;
            this.grp_pwlimitcase2.TabStop = false;
            this.grp_pwlimitcase2.Text = "Power Limit";
            this.grp_pwlimitcase2.Visible = false;
            // 
            // txtlmtStep
            // 
            this.txtlmtStep.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtlmtStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlmtStep.Location = new System.Drawing.Point(316, 20);
            this.txtlmtStep.Name = "txtlmtStep";
            this.txtlmtStep.Size = new System.Drawing.Size(50, 23);
            this.txtlmtStep.TabIndex = 23;
            this.txtlmtStep.Text = "1";
            // 
            // txtlmtDelay
            // 
            this.txtlmtDelay.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtlmtDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlmtDelay.Location = new System.Drawing.Point(477, 22);
            this.txtlmtDelay.Name = "txtlmtDelay";
            this.txtlmtDelay.Size = new System.Drawing.Size(52, 23);
            this.txtlmtDelay.TabIndex = 20;
            this.txtlmtDelay.Text = "500";
            // 
            // lbl_pwrlmtStart
            // 
            this.lbl_pwrlmtStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_pwrlmtStart.ForeColor = System.Drawing.Color.Black;
            this.lbl_pwrlmtStart.Location = new System.Drawing.Point(16, 21);
            this.lbl_pwrlmtStart.Name = "lbl_pwrlmtStart";
            this.lbl_pwrlmtStart.Size = new System.Drawing.Size(47, 22);
            this.lbl_pwrlmtStart.TabIndex = 14;
            this.lbl_pwrlmtStart.Text = "Start :";
            // 
            // txtlmtStop
            // 
            this.txtlmtStop.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtlmtStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlmtStop.Location = new System.Drawing.Point(189, 20);
            this.txtlmtStop.Name = "txtlmtStop";
            this.txtlmtStop.Size = new System.Drawing.Size(50, 23);
            this.txtlmtStop.TabIndex = 17;
            this.txtlmtStop.Text = "45";
            // 
            // lbl_pwrlmtdel
            // 
            this.lbl_pwrlmtdel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_pwrlmtdel.ForeColor = System.Drawing.Color.Black;
            this.lbl_pwrlmtdel.Location = new System.Drawing.Point(396, 22);
            this.lbl_pwrlmtdel.Name = "lbl_pwrlmtdel";
            this.lbl_pwrlmtdel.Size = new System.Drawing.Size(80, 22);
            this.lbl_pwrlmtdel.TabIndex = 19;
            this.lbl_pwrlmtdel.Text = "Delay (ms) :";
            // 
            // lbl_pwrlmtStop
            // 
            this.lbl_pwrlmtStop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_pwrlmtStop.ForeColor = System.Drawing.Color.Black;
            this.lbl_pwrlmtStop.Location = new System.Drawing.Point(134, 22);
            this.lbl_pwrlmtStop.Name = "lbl_pwrlmtStop";
            this.lbl_pwrlmtStop.Size = new System.Drawing.Size(49, 22);
            this.lbl_pwrlmtStop.TabIndex = 16;
            this.lbl_pwrlmtStop.Text = " Stop :";
            // 
            // lbl_pwrlmtStep
            // 
            this.lbl_pwrlmtStep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_pwrlmtStep.ForeColor = System.Drawing.Color.Black;
            this.lbl_pwrlmtStep.Location = new System.Drawing.Point(266, 23);
            this.lbl_pwrlmtStep.Name = "lbl_pwrlmtStep";
            this.lbl_pwrlmtStep.Size = new System.Drawing.Size(49, 22);
            this.lbl_pwrlmtStep.TabIndex = 18;
            this.lbl_pwrlmtStep.Text = "Step :";
            // 
            // txtlmtStart
            // 
            this.txtlmtStart.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtlmtStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlmtStart.Location = new System.Drawing.Point(69, 20);
            this.txtlmtStart.Name = "txtlmtStart";
            this.txtlmtStart.Size = new System.Drawing.Size(50, 23);
            this.txtlmtStart.TabIndex = 15;
            this.txtlmtStart.Text = "0";
            // 
            // lbl_powerlimit
            // 
            this.lbl_powerlimit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl_powerlimit.ForeColor = System.Drawing.Color.Black;
            this.lbl_powerlimit.Location = new System.Drawing.Point(296, 27);
            this.lbl_powerlimit.Name = "lbl_powerlimit";
            this.lbl_powerlimit.Size = new System.Drawing.Size(80, 22);
            this.lbl_powerlimit.TabIndex = 6;
            this.lbl_powerlimit.Text = "Power Limit :";
            // 
            // PwrLimtunit
            // 
            this.PwrLimtunit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PwrLimtunit.ForeColor = System.Drawing.Color.Black;
            this.PwrLimtunit.Location = new System.Drawing.Point(439, 28);
            this.PwrLimtunit.Name = "PwrLimtunit";
            this.PwrLimtunit.Size = new System.Drawing.Size(40, 22);
            this.PwrLimtunit.TabIndex = 5;
            this.PwrLimtunit.Text = "dBm";
            // 
            // lblLimiter
            // 
            this.lblLimiter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLimiter.ForeColor = System.Drawing.Color.Black;
            this.lblLimiter.Location = new System.Drawing.Point(10, 25);
            this.lblLimiter.Name = "lblLimiter";
            this.lblLimiter.Size = new System.Drawing.Size(80, 22);
            this.lblLimiter.TabIndex = 0;
            this.lblLimiter.Text = "Limiter Mode :";
            // 
            // cmbLimiterMode
            // 
            this.cmbLimiterMode.Location = new System.Drawing.Point(95, 23);
            this.cmbLimiterMode.Name = "cmbLimiterMode";
            this.cmbLimiterMode.Size = new System.Drawing.Size(190, 23);
            this.cmbLimiterMode.TabIndex = 1;
            this.cmbLimiterMode.SelectedIndexChanged += new System.EventHandler(this.cmbLimiterMode_SelectedIndexChanged);
            // 
            // txtLimiterPower
            // 
            this.txtLimiterPower.Enabled = false;
            this.txtLimiterPower.Location = new System.Drawing.Point(382, 24);
            this.txtLimiterPower.Name = "txtLimiterPower";
            this.txtLimiterPower.Size = new System.Drawing.Size(51, 23);
            this.txtLimiterPower.TabIndex = 2;
            this.txtLimiterPower.Text = "-18";
            this.txtLimiterPower.TextChanged += new System.EventHandler(this.txtLimiterPower_TextChanged);
            // 
            // grpLiveOutput
            // 
            this.grpLiveOutput.BackColor = System.Drawing.Color.White;
            this.grpLiveOutput.Controls.Add(this.lblCurrBW);
            this.grpLiveOutput.Controls.Add(this.lblCurrBWTitle);
            this.grpLiveOutput.Controls.Add(this.lbloPBw);
            this.grpLiveOutput.Controls.Add(this.lbloP_BwTitle);
            this.grpLiveOutput.Controls.Add(this.txt1553Output_1);
            this.grpLiveOutput.Controls.Add(this.label14);
            this.grpLiveOutput.Controls.Add(this.lbl1553power);
            this.grpLiveOutput.Controls.Add(this.lbl1553PowerTitle);
            this.grpLiveOutput.Controls.Add(this.lblCurrentPowerLmt);
            this.grpLiveOutput.Controls.Add(this.lblcurrPwrLmtTitle);
            this.grpLiveOutput.Controls.Add(this.progressBar1);
            this.grpLiveOutput.Controls.Add(this.lblProgressText);
            this.grpLiveOutput.Controls.Add(this.lblCurrentFreqTitle);
            this.grpLiveOutput.Controls.Add(this.lblCurrentFreq);
            this.grpLiveOutput.Controls.Add(this.lblCurrentPowerTitle);
            this.grpLiveOutput.Controls.Add(this.lblCurrentPower);
            this.grpLiveOutput.Controls.Add(this.lblCurrentGainTitle);
            this.grpLiveOutput.Controls.Add(this.lblCurrentGain);
            this.grpLiveOutput.Controls.Add(this.lbl1553StatusLive);
            this.grpLiveOutput.Controls.Add(this.txt1553StatusLive);
            this.grpLiveOutput.Controls.Add(this.label5);
            this.grpLiveOutput.Controls.Add(this.spectrum_output);
            this.grpLiveOutput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpLiveOutput.ForeColor = System.Drawing.Color.DarkGreen;
            this.grpLiveOutput.Location = new System.Drawing.Point(578, 35);
            this.grpLiveOutput.Name = "grpLiveOutput";
            this.grpLiveOutput.Size = new System.Drawing.Size(550, 543);
            this.grpLiveOutput.TabIndex = 10;
            this.grpLiveOutput.TabStop = false;
            this.grpLiveOutput.Text = "  Live Measurement Output";
            // 
            // lblCurrBW
            // 
            this.lblCurrBW.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrBW.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCurrBW.Location = new System.Drawing.Point(158, 195);
            this.lblCurrBW.Name = "lblCurrBW";
            this.lblCurrBW.Size = new System.Drawing.Size(350, 25);
            this.lblCurrBW.TabIndex = 24;
            this.lblCurrBW.Text = "---";
            // 
            // lblCurrBWTitle
            // 
            this.lblCurrBWTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrBWTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCurrBWTitle.Location = new System.Drawing.Point(12, 197);
            this.lblCurrBWTitle.Name = "lblCurrBWTitle";
            this.lblCurrBWTitle.Size = new System.Drawing.Size(162, 22);
            this.lblCurrBWTitle.TabIndex = 23;
            this.lblCurrBWTitle.Text = "Curr BW(1553) :";
            // 
            // lbloPBw
            // 
            this.lbloPBw.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbloPBw.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbloPBw.Location = new System.Drawing.Point(158, 255);
            this.lbloPBw.Name = "lbloPBw";
            this.lbloPBw.Size = new System.Drawing.Size(350, 25);
            this.lbloPBw.TabIndex = 22;
            this.lbloPBw.Text = "---";
            // 
            // lbloP_BwTitle
            // 
            this.lbloP_BwTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbloP_BwTitle.ForeColor = System.Drawing.Color.Black;
            this.lbloP_BwTitle.Location = new System.Drawing.Point(12, 257);
            this.lbloP_BwTitle.Name = "lbloP_BwTitle";
            this.lbloP_BwTitle.Size = new System.Drawing.Size(140, 22);
            this.lbloP_BwTitle.TabIndex = 21;
            this.lbloP_BwTitle.Text = "1553 O/p BW";
            // 
            // txt1553Output_1
            // 
            this.txt1553Output_1.Location = new System.Drawing.Point(162, 381);
            this.txt1553Output_1.Multiline = true;
            this.txt1553Output_1.Name = "txt1553Output_1";
            this.txt1553Output_1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt1553Output_1.Size = new System.Drawing.Size(351, 99);
            this.txt1553Output_1.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 384);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 15);
            this.label14.TabIndex = 19;
            this.label14.Text = "Status RT->BC";
            // 
            // lbl1553power
            // 
            this.lbl1553power.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl1553power.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl1553power.Location = new System.Drawing.Point(158, 227);
            this.lbl1553power.Name = "lbl1553power";
            this.lbl1553power.Size = new System.Drawing.Size(350, 25);
            this.lbl1553power.TabIndex = 17;
            this.lbl1553power.Text = "---";
            // 
            // lbl1553PowerTitle
            // 
            this.lbl1553PowerTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553PowerTitle.ForeColor = System.Drawing.Color.Black;
            this.lbl1553PowerTitle.Location = new System.Drawing.Point(12, 229);
            this.lbl1553PowerTitle.Name = "lbl1553PowerTitle";
            this.lbl1553PowerTitle.Size = new System.Drawing.Size(140, 22);
            this.lbl1553PowerTitle.TabIndex = 16;
            this.lbl1553PowerTitle.Text = "1553 O/p Power";
            // 
            // lblCurrentPowerLmt
            // 
            this.lblCurrentPowerLmt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPowerLmt.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCurrentPowerLmt.Location = new System.Drawing.Point(158, 169);
            this.lblCurrentPowerLmt.Name = "lblCurrentPowerLmt";
            this.lblCurrentPowerLmt.Size = new System.Drawing.Size(350, 25);
            this.lblCurrentPowerLmt.TabIndex = 15;
            this.lblCurrentPowerLmt.Text = "---";
            this.lblCurrentPowerLmt.Click += new System.EventHandler(this.lblCurrentPowerLmt_Click);
            // 
            // lblcurrPwrLmtTitle
            // 
            this.lblcurrPwrLmtTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblcurrPwrLmtTitle.ForeColor = System.Drawing.Color.Black;
            this.lblcurrPwrLmtTitle.Location = new System.Drawing.Point(12, 171);
            this.lblcurrPwrLmtTitle.Name = "lblcurrPwrLmtTitle";
            this.lblcurrPwrLmtTitle.Size = new System.Drawing.Size(162, 22);
            this.lblcurrPwrLmtTitle.TabIndex = 14;
            this.lblcurrPwrLmtTitle.Text = "Curr Power Limit(1553) :";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(520, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // lblProgressText
            // 
            this.lblProgressText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgressText.ForeColor = System.Drawing.Color.DarkGray;
            this.lblProgressText.Location = new System.Drawing.Point(12, 56);
            this.lblProgressText.Name = "lblProgressText";
            this.lblProgressText.Size = new System.Drawing.Size(520, 20);
            this.lblProgressText.TabIndex = 1;
            this.lblProgressText.Text = "0 / 0";
            this.lblProgressText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentFreqTitle
            // 
            this.lblCurrentFreqTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentFreqTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentFreqTitle.Location = new System.Drawing.Point(12, 90);
            this.lblCurrentFreqTitle.Name = "lblCurrentFreqTitle";
            this.lblCurrentFreqTitle.Size = new System.Drawing.Size(140, 22);
            this.lblCurrentFreqTitle.TabIndex = 2;
            this.lblCurrentFreqTitle.Text = "Current Frequency :";
            // 
            // lblCurrentFreq
            // 
            this.lblCurrentFreq.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentFreq.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblCurrentFreq.Location = new System.Drawing.Point(158, 88);
            this.lblCurrentFreq.Name = "lblCurrentFreq";
            this.lblCurrentFreq.Size = new System.Drawing.Size(250, 25);
            this.lblCurrentFreq.TabIndex = 3;
            this.lblCurrentFreq.Text = "---";
            // 
            // lblCurrentPowerTitle
            // 
            this.lblCurrentPowerTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentPowerTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentPowerTitle.Location = new System.Drawing.Point(12, 118);
            this.lblCurrentPowerTitle.Name = "lblCurrentPowerTitle";
            this.lblCurrentPowerTitle.Size = new System.Drawing.Size(140, 22);
            this.lblCurrentPowerTitle.TabIndex = 4;
            this.lblCurrentPowerTitle.Text = "Current Power :";
            // 
            // lblCurrentPower
            // 
            this.lblCurrentPower.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPower.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCurrentPower.Location = new System.Drawing.Point(158, 116);
            this.lblCurrentPower.Name = "lblCurrentPower";
            this.lblCurrentPower.Size = new System.Drawing.Size(250, 25);
            this.lblCurrentPower.TabIndex = 5;
            this.lblCurrentPower.Text = "---";
            // 
            // lblCurrentGainTitle
            // 
            this.lblCurrentGainTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentGainTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentGainTitle.Location = new System.Drawing.Point(12, 146);
            this.lblCurrentGainTitle.Name = "lblCurrentGainTitle";
            this.lblCurrentGainTitle.Size = new System.Drawing.Size(140, 22);
            this.lblCurrentGainTitle.TabIndex = 6;
            this.lblCurrentGainTitle.Text = "Current Gain (1553) :";
            // 
            // lblCurrentGain
            // 
            this.lblCurrentGain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentGain.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCurrentGain.Location = new System.Drawing.Point(158, 140);
            this.lblCurrentGain.Name = "lblCurrentGain";
            this.lblCurrentGain.Size = new System.Drawing.Size(350, 25);
            this.lblCurrentGain.TabIndex = 7;
            this.lblCurrentGain.Text = "---";
            // 
            // lbl1553StatusLive
            // 
            this.lbl1553StatusLive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553StatusLive.ForeColor = System.Drawing.Color.Black;
            this.lbl1553StatusLive.Location = new System.Drawing.Point(12, 338);
            this.lbl1553StatusLive.Name = "lbl1553StatusLive";
            this.lbl1553StatusLive.Size = new System.Drawing.Size(140, 22);
            this.lbl1553StatusLive.TabIndex = 8;
            this.lbl1553StatusLive.Text = "1553 Send Status :";
            // 
            // txt1553StatusLive
            // 
            this.txt1553StatusLive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txt1553StatusLive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1553StatusLive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt1553StatusLive.Location = new System.Drawing.Point(162, 338);
            this.txt1553StatusLive.Name = "txt1553StatusLive";
            this.txt1553StatusLive.ReadOnly = true;
            this.txt1553StatusLive.Size = new System.Drawing.Size(370, 23);
            this.txt1553StatusLive.TabIndex = 9;
            this.txt1553StatusLive.Text = "Idle";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Spectrum Output :";
            // 
            // spectrum_output
            // 
            this.spectrum_output.BackColor = System.Drawing.Color.Black;
            this.spectrum_output.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.spectrum_output.ForeColor = System.Drawing.Color.Lime;
            this.spectrum_output.Location = new System.Drawing.Point(162, 289);
            this.spectrum_output.Name = "spectrum_output";
            this.spectrum_output.ReadOnly = true;
            this.spectrum_output.Size = new System.Drawing.Size(200, 28);
            this.spectrum_output.TabIndex = 11;
            this.spectrum_output.Text = "--- dBm";
            this.spectrum_output.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(6, 540);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 40);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "▶  START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Crimson;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(166, 540);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 40);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "⏹  STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblOutFreq
            // 
            this.lblOutFreq.Location = new System.Drawing.Point(61, 515);
            this.lblOutFreq.Name = "lblOutFreq";
            this.lblOutFreq.Size = new System.Drawing.Size(70, 22);
            this.lblOutFreq.TabIndex = 13;
            this.lblOutFreq.Text = "Out Freq:";
            // 
            // txtOutFreq
            // 
            this.txtOutFreq.Location = new System.Drawing.Point(136, 513);
            this.txtOutFreq.Name = "txtOutFreq";
            this.txtOutFreq.Size = new System.Drawing.Size(120, 20);
            this.txtOutFreq.TabIndex = 14;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.grp1553Info);
            this.tabPage5.Controls.Add(this.grp1553Params);
            this.tabPage5.Controls.Add(this.lbl1553LogTitle);
            this.tabPage5.Controls.Add(this.btn1553ClearLog);
            this.tabPage5.Controls.Add(this.rtb1553Log);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1140, 584);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "  DDC 1553  ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // grp1553Info
            // 
            this.grp1553Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.grp1553Info.Controls.Add(this.lbl1553ConnInfo);
            this.grp1553Info.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grp1553Info.ForeColor = System.Drawing.Color.DarkRed;
            this.grp1553Info.Location = new System.Drawing.Point(6, 8);
            this.grp1553Info.Name = "grp1553Info";
            this.grp1553Info.Size = new System.Drawing.Size(1120, 50);
            this.grp1553Info.TabIndex = 0;
            this.grp1553Info.TabStop = false;
            this.grp1553Info.Text = "  DDC 1553 Connection Info";
            // 
            // lbl1553ConnInfo
            // 
            this.lbl1553ConnInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl1553ConnInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl1553ConnInfo.Location = new System.Drawing.Point(10, 20);
            this.lbl1553ConnInfo.Name = "lbl1553ConnInfo";
            this.lbl1553ConnInfo.Size = new System.Drawing.Size(1100, 22);
            this.lbl1553ConnInfo.TabIndex = 0;
            this.lbl1553ConnInfo.Text = "DDC 1553 : Not Tested - Please Test from Connection Tab";
            // 
            // grp1553Params
            // 
            this.grp1553Params.BackColor = System.Drawing.Color.White;
            this.grp1553Params.Controls.Add(this.label15);
            this.grp1553Params.Controls.Add(this.txt1553BW);
            this.grp1553Params.Controls.Add(this.label16);
            this.grp1553Params.Controls.Add(this.txt1553bwstatus);
            this.grp1553Params.Controls.Add(this.lbl1553DeviceTitle);
            this.grp1553Params.Controls.Add(this.lbl1553RTTitle);
            this.grp1553Params.Controls.Add(this.lbl1553SubTitle);
            this.grp1553Params.Controls.Add(this.lbl1553BusTitle);
            this.grp1553Params.Controls.Add(this.lbl1553CurrentGain);
            this.grp1553Params.Controls.Add(this.txt1553CurrentGain);
            this.grp1553Params.Controls.Add(this.lbl1553LastStatus);
            this.grp1553Params.Controls.Add(this.txt1553LastStatus);
            this.grp1553Params.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grp1553Params.ForeColor = System.Drawing.Color.DarkRed;
            this.grp1553Params.Location = new System.Drawing.Point(6, 68);
            this.grp1553Params.Name = "grp1553Params";
            this.grp1553Params.Size = new System.Drawing.Size(1120, 130);
            this.grp1553Params.TabIndex = 1;
            this.grp1553Params.TabStop = false;
            this.grp1553Params.Text = "  1553 Live Status";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(12, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 22);
            this.label15.TabIndex = 8;
            this.label15.Text = "Last Gain Sent :";
            // 
            // txt1553BW
            // 
            this.txt1553BW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.txt1553BW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1553BW.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txt1553BW.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt1553BW.Location = new System.Drawing.Point(128, 103);
            this.txt1553BW.Name = "txt1553BW";
            this.txt1553BW.ReadOnly = true;
            this.txt1553BW.Size = new System.Drawing.Size(210, 23);
            this.txt1553BW.TabIndex = 9;
            this.txt1553BW.Text = "---";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(355, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 22);
            this.label16.TabIndex = 10;
            this.label16.Text = "Send Result :";
            // 
            // txt1553bwstatus
            // 
            this.txt1553bwstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txt1553bwstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1553bwstatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt1553bwstatus.Location = new System.Drawing.Point(445, 103);
            this.txt1553bwstatus.Name = "txt1553bwstatus";
            this.txt1553bwstatus.ReadOnly = true;
            this.txt1553bwstatus.Size = new System.Drawing.Size(300, 23);
            this.txt1553bwstatus.TabIndex = 11;
            this.txt1553bwstatus.Text = "Idle";
            // 
            // lbl1553DeviceTitle
            // 
            this.lbl1553DeviceTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553DeviceTitle.ForeColor = System.Drawing.Color.Black;
            this.lbl1553DeviceTitle.Location = new System.Drawing.Point(12, 30);
            this.lbl1553DeviceTitle.Name = "lbl1553DeviceTitle";
            this.lbl1553DeviceTitle.Size = new System.Drawing.Size(75, 22);
            this.lbl1553DeviceTitle.TabIndex = 0;
            this.lbl1553DeviceTitle.Text = "Device ID :";
            // 
            // lbl1553RTTitle
            // 
            this.lbl1553RTTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553RTTitle.ForeColor = System.Drawing.Color.Black;
            this.lbl1553RTTitle.Location = new System.Drawing.Point(200, 30);
            this.lbl1553RTTitle.Name = "lbl1553RTTitle";
            this.lbl1553RTTitle.Size = new System.Drawing.Size(80, 22);
            this.lbl1553RTTitle.TabIndex = 1;
            this.lbl1553RTTitle.Text = "RT Address :";
            // 
            // lbl1553SubTitle
            // 
            this.lbl1553SubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553SubTitle.ForeColor = System.Drawing.Color.Black;
            this.lbl1553SubTitle.Location = new System.Drawing.Point(400, 30);
            this.lbl1553SubTitle.Name = "lbl1553SubTitle";
            this.lbl1553SubTitle.Size = new System.Drawing.Size(85, 22);
            this.lbl1553SubTitle.TabIndex = 2;
            this.lbl1553SubTitle.Text = "Sub Address :";
            // 
            // lbl1553BusTitle
            // 
            this.lbl1553BusTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553BusTitle.ForeColor = System.Drawing.Color.Black;
            this.lbl1553BusTitle.Location = new System.Drawing.Point(600, 30);
            this.lbl1553BusTitle.Name = "lbl1553BusTitle";
            this.lbl1553BusTitle.Size = new System.Drawing.Size(40, 22);
            this.lbl1553BusTitle.TabIndex = 3;
            this.lbl1553BusTitle.Text = "Bus :";
            // 
            // lbl1553CurrentGain
            // 
            this.lbl1553CurrentGain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553CurrentGain.ForeColor = System.Drawing.Color.Black;
            this.lbl1553CurrentGain.Location = new System.Drawing.Point(12, 70);
            this.lbl1553CurrentGain.Name = "lbl1553CurrentGain";
            this.lbl1553CurrentGain.Size = new System.Drawing.Size(110, 22);
            this.lbl1553CurrentGain.TabIndex = 4;
            this.lbl1553CurrentGain.Text = "Last Gain Sent :";
            // 
            // txt1553CurrentGain
            // 
            this.txt1553CurrentGain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.txt1553CurrentGain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1553CurrentGain.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txt1553CurrentGain.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt1553CurrentGain.Location = new System.Drawing.Point(128, 68);
            this.txt1553CurrentGain.Name = "txt1553CurrentGain";
            this.txt1553CurrentGain.ReadOnly = true;
            this.txt1553CurrentGain.Size = new System.Drawing.Size(210, 23);
            this.txt1553CurrentGain.TabIndex = 5;
            this.txt1553CurrentGain.Text = "---";
            // 
            // lbl1553LastStatus
            // 
            this.lbl1553LastStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbl1553LastStatus.ForeColor = System.Drawing.Color.Black;
            this.lbl1553LastStatus.Location = new System.Drawing.Point(355, 70);
            this.lbl1553LastStatus.Name = "lbl1553LastStatus";
            this.lbl1553LastStatus.Size = new System.Drawing.Size(85, 22);
            this.lbl1553LastStatus.TabIndex = 6;
            this.lbl1553LastStatus.Text = "Send Result :";
            // 
            // txt1553LastStatus
            // 
            this.txt1553LastStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.txt1553LastStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt1553LastStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt1553LastStatus.Location = new System.Drawing.Point(445, 68);
            this.txt1553LastStatus.Name = "txt1553LastStatus";
            this.txt1553LastStatus.ReadOnly = true;
            this.txt1553LastStatus.Size = new System.Drawing.Size(300, 23);
            this.txt1553LastStatus.TabIndex = 7;
            this.txt1553LastStatus.Text = "Idle";
            // 
            // lbl1553LogTitle
            // 
            this.lbl1553LogTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl1553LogTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl1553LogTitle.Location = new System.Drawing.Point(6, 208);
            this.lbl1553LogTitle.Name = "lbl1553LogTitle";
            this.lbl1553LogTitle.Size = new System.Drawing.Size(150, 22);
            this.lbl1553LogTitle.TabIndex = 2;
            this.lbl1553LogTitle.Text = "1553 Command Log :";
            // 
            // btn1553ClearLog
            // 
            this.btn1553ClearLog.BackColor = System.Drawing.Color.DimGray;
            this.btn1553ClearLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1553ClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1553ClearLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn1553ClearLog.ForeColor = System.Drawing.Color.White;
            this.btn1553ClearLog.Location = new System.Drawing.Point(165, 205);
            this.btn1553ClearLog.Name = "btn1553ClearLog";
            this.btn1553ClearLog.Size = new System.Drawing.Size(100, 26);
            this.btn1553ClearLog.TabIndex = 3;
            this.btn1553ClearLog.Text = "Clear Log";
            this.btn1553ClearLog.UseVisualStyleBackColor = false;
            this.btn1553ClearLog.Click += new System.EventHandler(this.btn1553ClearLog_Click);
            // 
            // rtb1553Log
            // 
            this.rtb1553Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.rtb1553Log.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.rtb1553Log.ForeColor = System.Drawing.Color.Lime;
            this.rtb1553Log.Location = new System.Drawing.Point(6, 238);
            this.rtb1553Log.Name = "rtb1553Log";
            this.rtb1553Log.ReadOnly = true;
            this.rtb1553Log.Size = new System.Drawing.Size(1120, 335);
            this.rtb1553Log.TabIndex = 4;
            this.rtb1553Log.Text = "";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.pnlRTSimMain);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1140, 584);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "RT Simulator";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // pnlRTSimMain
            // 
            this.pnlRTSimMain.AutoScroll = true;
            this.pnlRTSimMain.Controls.Add(this.grpRTSimConfig);
            this.pnlRTSimMain.Controls.Add(this.grpRTSimPatterns);
            this.pnlRTSimMain.Controls.Add(this.grpRTSimData);
            this.pnlRTSimMain.Controls.Add(this.grpRTSimInstructions);
            this.pnlRTSimMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRTSimMain.Location = new System.Drawing.Point(0, 0);
            this.pnlRTSimMain.Name = "pnlRTSimMain";
            this.pnlRTSimMain.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRTSimMain.Size = new System.Drawing.Size(1140, 584);
            this.pnlRTSimMain.TabIndex = 0;
            // 
            // grpRTSimConfig
            // 
            this.grpRTSimConfig.Controls.Add(this.pnlRTSimWarning);
            this.grpRTSimConfig.Controls.Add(this.lblRTSimDeviceId);
            this.grpRTSimConfig.Controls.Add(this.txtRTSimDeviceId);
            this.grpRTSimConfig.Controls.Add(this.lblRTSimRTAddr);
            this.grpRTSimConfig.Controls.Add(this.cmbRTSimRTAddr);
            this.grpRTSimConfig.Controls.Add(this.lblRTSimSubAddr);
            this.grpRTSimConfig.Controls.Add(this.cmbRTSimSubAddr);
            this.grpRTSimConfig.Controls.Add(this.lblRTSimBus);
            this.grpRTSimConfig.Controls.Add(this.cmbRTSimBus);
            this.grpRTSimConfig.Controls.Add(this.pnlRTSimStatusBorder);
            this.grpRTSimConfig.Controls.Add(this.btnRTSimStart);
            this.grpRTSimConfig.Controls.Add(this.btnRTSimStop);
            this.grpRTSimConfig.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Bold);
            this.grpRTSimConfig.ForeColor = System.Drawing.Color.Navy;
            this.grpRTSimConfig.Location = new System.Drawing.Point(10, 10);
            this.grpRTSimConfig.Name = "grpRTSimConfig";
            this.grpRTSimConfig.Size = new System.Drawing.Size(950, 280);
            this.grpRTSimConfig.TabIndex = 0;
            this.grpRTSimConfig.TabStop = false;
            this.grpRTSimConfig.Text = "RT Simulator Configuration";
            // 
            // pnlRTSimWarning
            // 
            this.pnlRTSimWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(220)))));
            this.pnlRTSimWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRTSimWarning.Controls.Add(this.lblRTSimWarningTitle);
            this.pnlRTSimWarning.Controls.Add(this.lblRTSimWarningMsg);
            this.pnlRTSimWarning.Location = new System.Drawing.Point(10, 25);
            this.pnlRTSimWarning.Name = "pnlRTSimWarning";
            this.pnlRTSimWarning.Size = new System.Drawing.Size(920, 70);
            this.pnlRTSimWarning.TabIndex = 0;
            // 
            // lblRTSimWarningTitle
            // 
            this.lblRTSimWarningTitle.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblRTSimWarningTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.lblRTSimWarningTitle.Location = new System.Drawing.Point(10, 5);
            this.lblRTSimWarningTitle.Name = "lblRTSimWarningTitle";
            this.lblRTSimWarningTitle.Size = new System.Drawing.Size(900, 20);
            this.lblRTSimWarningTitle.TabIndex = 0;
            this.lblRTSimWarningTitle.Text = "⚠ IMPORTANT: Start RT Simulator BEFORE using RT→BC tab!";
            // 
            // lblRTSimWarningMsg
            // 
            this.lblRTSimWarningMsg.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.lblRTSimWarningMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblRTSimWarningMsg.Location = new System.Drawing.Point(10, 28);
            this.lblRTSimWarningMsg.Name = "lblRTSimWarningMsg";
            this.lblRTSimWarningMsg.Size = new System.Drawing.Size(900, 35);
            this.lblRTSimWarningMsg.TabIndex = 1;
            this.lblRTSimWarningMsg.Text = "The DDC card will act as an RT device responding to BC requests.\r\nYou can update " +
    "response data LIVE without stopping the simulator.";
            // 
            // lblRTSimDeviceId
            // 
            this.lblRTSimDeviceId.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblRTSimDeviceId.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimDeviceId.Location = new System.Drawing.Point(20, 105);
            this.lblRTSimDeviceId.Name = "lblRTSimDeviceId";
            this.lblRTSimDeviceId.Size = new System.Drawing.Size(200, 20);
            this.lblRTSimDeviceId.TabIndex = 1;
            this.lblRTSimDeviceId.Text = "Device ID:";
            // 
            // txtRTSimDeviceId
            // 
            this.txtRTSimDeviceId.Font = new System.Drawing.Font("Lucida Sans", 11F);
            this.txtRTSimDeviceId.Location = new System.Drawing.Point(20, 130);
            this.txtRTSimDeviceId.Name = "txtRTSimDeviceId";
            this.txtRTSimDeviceId.Size = new System.Drawing.Size(200, 25);
            this.txtRTSimDeviceId.TabIndex = 2;
            this.txtRTSimDeviceId.Text = "0";
            this.txtRTSimDeviceId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRTSimRTAddr
            // 
            this.lblRTSimRTAddr.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblRTSimRTAddr.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimRTAddr.Location = new System.Drawing.Point(240, 105);
            this.lblRTSimRTAddr.Name = "lblRTSimRTAddr";
            this.lblRTSimRTAddr.Size = new System.Drawing.Size(200, 20);
            this.lblRTSimRTAddr.TabIndex = 3;
            this.lblRTSimRTAddr.Text = "RT Address:";
            // 
            // cmbRTSimRTAddr
            // 
            this.cmbRTSimRTAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRTSimRTAddr.Font = new System.Drawing.Font("Lucida Sans", 11F);
            this.cmbRTSimRTAddr.FormattingEnabled = true;
            this.cmbRTSimRTAddr.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbRTSimRTAddr.Location = new System.Drawing.Point(240, 130);
            this.cmbRTSimRTAddr.Name = "cmbRTSimRTAddr";
            this.cmbRTSimRTAddr.Size = new System.Drawing.Size(200, 25);
            this.cmbRTSimRTAddr.TabIndex = 4;
            // 
            // lblRTSimSubAddr
            // 
            this.lblRTSimSubAddr.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblRTSimSubAddr.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimSubAddr.Location = new System.Drawing.Point(460, 105);
            this.lblRTSimSubAddr.Name = "lblRTSimSubAddr";
            this.lblRTSimSubAddr.Size = new System.Drawing.Size(200, 20);
            this.lblRTSimSubAddr.TabIndex = 5;
            this.lblRTSimSubAddr.Text = "Sub Address:";
            // 
            // cmbRTSimSubAddr
            // 
            this.cmbRTSimSubAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRTSimSubAddr.Font = new System.Drawing.Font("Lucida Sans", 11F);
            this.cmbRTSimSubAddr.FormattingEnabled = true;
            this.cmbRTSimSubAddr.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbRTSimSubAddr.Location = new System.Drawing.Point(460, 130);
            this.cmbRTSimSubAddr.Name = "cmbRTSimSubAddr";
            this.cmbRTSimSubAddr.Size = new System.Drawing.Size(200, 25);
            this.cmbRTSimSubAddr.TabIndex = 6;
            // 
            // lblRTSimBus
            // 
            this.lblRTSimBus.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblRTSimBus.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimBus.Location = new System.Drawing.Point(680, 105);
            this.lblRTSimBus.Name = "lblRTSimBus";
            this.lblRTSimBus.Size = new System.Drawing.Size(200, 20);
            this.lblRTSimBus.TabIndex = 7;
            this.lblRTSimBus.Text = "1553 Bus:";
            // 
            // cmbRTSimBus
            // 
            this.cmbRTSimBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRTSimBus.Font = new System.Drawing.Font("Lucida Sans", 11F);
            this.cmbRTSimBus.FormattingEnabled = true;
            this.cmbRTSimBus.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cmbRTSimBus.Location = new System.Drawing.Point(680, 130);
            this.cmbRTSimBus.Name = "cmbRTSimBus";
            this.cmbRTSimBus.Size = new System.Drawing.Size(200, 25);
            this.cmbRTSimBus.TabIndex = 8;
            // 
            // pnlRTSimStatusBorder
            // 
            this.pnlRTSimStatusBorder.BackColor = System.Drawing.Color.Gray;
            this.pnlRTSimStatusBorder.Controls.Add(this.lblRTSimStatus);
            this.pnlRTSimStatusBorder.Location = new System.Drawing.Point(320, 170);
            this.pnlRTSimStatusBorder.Name = "pnlRTSimStatusBorder";
            this.pnlRTSimStatusBorder.Size = new System.Drawing.Size(280, 35);
            this.pnlRTSimStatusBorder.TabIndex = 9;
            // 
            // lblRTSimStatus
            // 
            this.lblRTSimStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRTSimStatus.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Bold);
            this.lblRTSimStatus.ForeColor = System.Drawing.Color.White;
            this.lblRTSimStatus.Location = new System.Drawing.Point(0, 0);
            this.lblRTSimStatus.Name = "lblRTSimStatus";
            this.lblRTSimStatus.Size = new System.Drawing.Size(280, 35);
            this.lblRTSimStatus.TabIndex = 0;
            this.lblRTSimStatus.Text = "⚫ RT SIMULATOR STOPPED";
            this.lblRTSimStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRTSimStart
            // 
            this.btnRTSimStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnRTSimStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimStart.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.btnRTSimStart.ForeColor = System.Drawing.Color.White;
            this.btnRTSimStart.Location = new System.Drawing.Point(280, 220);
            this.btnRTSimStart.Name = "btnRTSimStart";
            this.btnRTSimStart.Size = new System.Drawing.Size(180, 40);
            this.btnRTSimStart.TabIndex = 10;
            this.btnRTSimStart.Text = "▶  Start RT Simulator";
            this.btnRTSimStart.UseVisualStyleBackColor = false;
            this.btnRTSimStart.Click += new System.EventHandler(this.RTSim_Start_Click);
            // 
            // btnRTSimStop
            // 
            this.btnRTSimStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnRTSimStop.Enabled = false;
            this.btnRTSimStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimStop.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.btnRTSimStop.ForeColor = System.Drawing.Color.White;
            this.btnRTSimStop.Location = new System.Drawing.Point(470, 220);
            this.btnRTSimStop.Name = "btnRTSimStop";
            this.btnRTSimStop.Size = new System.Drawing.Size(180, 40);
            this.btnRTSimStop.TabIndex = 11;
            this.btnRTSimStop.Text = "⏹  Stop RT Simulator";
            this.btnRTSimStop.UseVisualStyleBackColor = false;
            this.btnRTSimStop.Click += new System.EventHandler(this.RTSim_Stop_Click);
            // 
            // grpRTSimPatterns
            // 
            this.grpRTSimPatterns.Controls.Add(this.lblRTSimPatternInfo);
            this.grpRTSimPatterns.Controls.Add(this.flowRTSimPatterns);
            this.grpRTSimPatterns.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Bold);
            this.grpRTSimPatterns.ForeColor = System.Drawing.Color.Navy;
            this.grpRTSimPatterns.Location = new System.Drawing.Point(10, 300);
            this.grpRTSimPatterns.Name = "grpRTSimPatterns";
            this.grpRTSimPatterns.Size = new System.Drawing.Size(950, 130);
            this.grpRTSimPatterns.TabIndex = 1;
            this.grpRTSimPatterns.TabStop = false;
            this.grpRTSimPatterns.Text = "Quick Test Patterns";
            // 
            // lblRTSimPatternInfo
            // 
            this.lblRTSimPatternInfo.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.lblRTSimPatternInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblRTSimPatternInfo.Location = new System.Drawing.Point(10, 25);
            this.lblRTSimPatternInfo.Name = "lblRTSimPatternInfo";
            this.lblRTSimPatternInfo.Size = new System.Drawing.Size(920, 20);
            this.lblRTSimPatternInfo.TabIndex = 0;
            this.lblRTSimPatternInfo.Text = "Click any pattern to load it into the data box below, then click \"Update RT Data\"" +
    " to apply it.";
            // 
            // flowRTSimPatterns
            // 
            this.flowRTSimPatterns.Controls.Add(this.btnRTSimPattern0);
            this.flowRTSimPatterns.Controls.Add(this.btnRTSimPattern1);
            this.flowRTSimPatterns.Controls.Add(this.btnRTSimPattern2);
            this.flowRTSimPatterns.Controls.Add(this.btnRTSimPattern3);
            this.flowRTSimPatterns.Controls.Add(this.btnRTSimPattern4);
            this.flowRTSimPatterns.Controls.Add(this.btnRTSimPattern5);
            this.flowRTSimPatterns.Controls.Add(this.btnRTSimClear);
            this.flowRTSimPatterns.Location = new System.Drawing.Point(10, 50);
            this.flowRTSimPatterns.Name = "flowRTSimPatterns";
            this.flowRTSimPatterns.Size = new System.Drawing.Size(920, 70);
            this.flowRTSimPatterns.TabIndex = 1;
            // 
            // btnRTSimPattern0
            // 
            this.btnRTSimPattern0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnRTSimPattern0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimPattern0.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.btnRTSimPattern0.ForeColor = System.Drawing.Color.White;
            this.btnRTSimPattern0.Location = new System.Drawing.Point(3, 3);
            this.btnRTSimPattern0.Name = "btnRTSimPattern0";
            this.btnRTSimPattern0.Size = new System.Drawing.Size(118, 44);
            this.btnRTSimPattern0.TabIndex = 0;
            this.btnRTSimPattern0.Text = "Default\r\n(1234..89AB)";
            this.btnRTSimPattern0.UseVisualStyleBackColor = false;
            this.btnRTSimPattern0.Click += new System.EventHandler(this.RTSim_LoadDefault_Click);
            // 
            // btnRTSimPattern1
            // 
            this.btnRTSimPattern1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnRTSimPattern1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimPattern1.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.btnRTSimPattern1.ForeColor = System.Drawing.Color.White;
            this.btnRTSimPattern1.Location = new System.Drawing.Point(127, 3);
            this.btnRTSimPattern1.Name = "btnRTSimPattern1";
            this.btnRTSimPattern1.Size = new System.Drawing.Size(118, 44);
            this.btnRTSimPattern1.TabIndex = 1;
            this.btnRTSimPattern1.Text = "Pattern 1\r\n(0001→0020)";
            this.btnRTSimPattern1.UseVisualStyleBackColor = false;
            this.btnRTSimPattern1.Click += new System.EventHandler(this.RTSim_LoadTestData1_Click);
            // 
            // btnRTSimPattern2
            // 
            this.btnRTSimPattern2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnRTSimPattern2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimPattern2.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.btnRTSimPattern2.ForeColor = System.Drawing.Color.White;
            this.btnRTSimPattern2.Location = new System.Drawing.Point(251, 3);
            this.btnRTSimPattern2.Name = "btnRTSimPattern2";
            this.btnRTSimPattern2.Size = new System.Drawing.Size(118, 44);
            this.btnRTSimPattern2.TabIndex = 2;
            this.btnRTSimPattern2.Text = "Pattern 2\r\n(AA55/55AA)";
            this.btnRTSimPattern2.UseVisualStyleBackColor = false;
            this.btnRTSimPattern2.Click += new System.EventHandler(this.RTSim_LoadTestData2_Click);
            // 
            // btnRTSimPattern3
            // 
            this.btnRTSimPattern3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnRTSimPattern3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimPattern3.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.btnRTSimPattern3.ForeColor = System.Drawing.Color.White;
            this.btnRTSimPattern3.Location = new System.Drawing.Point(375, 3);
            this.btnRTSimPattern3.Name = "btnRTSimPattern3";
            this.btnRTSimPattern3.Size = new System.Drawing.Size(118, 44);
            this.btnRTSimPattern3.TabIndex = 3;
            this.btnRTSimPattern3.Text = "Pattern 3\r\n(All 0000)";
            this.btnRTSimPattern3.UseVisualStyleBackColor = false;
            this.btnRTSimPattern3.Click += new System.EventHandler(this.RTSim_LoadTestData3_Click);
            // 
            // btnRTSimPattern4
            // 
            this.btnRTSimPattern4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnRTSimPattern4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimPattern4.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.btnRTSimPattern4.ForeColor = System.Drawing.Color.White;
            this.btnRTSimPattern4.Location = new System.Drawing.Point(499, 3);
            this.btnRTSimPattern4.Name = "btnRTSimPattern4";
            this.btnRTSimPattern4.Size = new System.Drawing.Size(118, 44);
            this.btnRTSimPattern4.TabIndex = 4;
            this.btnRTSimPattern4.Text = "Pattern 4\r\n(All FFFF)";
            this.btnRTSimPattern4.UseVisualStyleBackColor = false;
            this.btnRTSimPattern4.Click += new System.EventHandler(this.RTSim_LoadTestData4_Click);
            // 
            // btnRTSimPattern5
            // 
            this.btnRTSimPattern5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnRTSimPattern5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimPattern5.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.btnRTSimPattern5.ForeColor = System.Drawing.Color.White;
            this.btnRTSimPattern5.Location = new System.Drawing.Point(623, 3);
            this.btnRTSimPattern5.Name = "btnRTSimPattern5";
            this.btnRTSimPattern5.Size = new System.Drawing.Size(118, 44);
            this.btnRTSimPattern5.TabIndex = 5;
            this.btnRTSimPattern5.Text = "Pattern 5\r\n(DEAD/BEEF)";
            this.btnRTSimPattern5.UseVisualStyleBackColor = false;
            this.btnRTSimPattern5.Click += new System.EventHandler(this.RTSim_LoadTestData5_Click);
            // 
            // btnRTSimClear
            // 
            this.btnRTSimClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.btnRTSimClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimClear.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.btnRTSimClear.ForeColor = System.Drawing.Color.White;
            this.btnRTSimClear.Location = new System.Drawing.Point(747, 3);
            this.btnRTSimClear.Name = "btnRTSimClear";
            this.btnRTSimClear.Size = new System.Drawing.Size(118, 44);
            this.btnRTSimClear.TabIndex = 6;
            this.btnRTSimClear.Text = "Clear Data\r\n(Empty)";
            this.btnRTSimClear.UseVisualStyleBackColor = false;
            this.btnRTSimClear.Click += new System.EventHandler(this.RTSim_ClearData_Click);
            // 
            // grpRTSimData
            // 
            this.grpRTSimData.Controls.Add(this.pnlRTSimDataInfo);
            this.grpRTSimData.Controls.Add(this.lblRTSimDataPrompt);
            this.grpRTSimData.Controls.Add(this.lblRTSimWordCountStatic);
            this.grpRTSimData.Controls.Add(this.lblRTSimWordCount);
            this.grpRTSimData.Controls.Add(this.lblRTSimWordMax);
            this.grpRTSimData.Controls.Add(this.txtRTSimResponseData);
            this.grpRTSimData.Controls.Add(this.pnlRTSimValidation);
            this.grpRTSimData.Controls.Add(this.pnlRTSimWorkflow);
            this.grpRTSimData.Controls.Add(this.btnRTSimUpdateData);
            this.grpRTSimData.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Bold);
            this.grpRTSimData.ForeColor = System.Drawing.Color.Navy;
            this.grpRTSimData.Location = new System.Drawing.Point(10, 440);
            this.grpRTSimData.Name = "grpRTSimData";
            this.grpRTSimData.Size = new System.Drawing.Size(950, 320);
            this.grpRTSimData.TabIndex = 2;
            this.grpRTSimData.TabStop = false;
            this.grpRTSimData.Text = "RT Response Data — Manual Entry & Live Update";
            // 
            // pnlRTSimDataInfo
            // 
            this.pnlRTSimDataInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlRTSimDataInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRTSimDataInfo.Controls.Add(this.lblRTSimDataInfoTitle);
            this.pnlRTSimDataInfo.Controls.Add(this.lblRTSimDataInfoMsg);
            this.pnlRTSimDataInfo.Location = new System.Drawing.Point(10, 25);
            this.pnlRTSimDataInfo.Name = "pnlRTSimDataInfo";
            this.pnlRTSimDataInfo.Size = new System.Drawing.Size(920, 60);
            this.pnlRTSimDataInfo.TabIndex = 0;
            // 
            // lblRTSimDataInfoTitle
            // 
            this.lblRTSimDataInfoTitle.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblRTSimDataInfoTitle.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimDataInfoTitle.Location = new System.Drawing.Point(40, 5);
            this.lblRTSimDataInfoTitle.Name = "lblRTSimDataInfoTitle";
            this.lblRTSimDataInfoTitle.Size = new System.Drawing.Size(870, 20);
            this.lblRTSimDataInfoTitle.TabIndex = 0;
            this.lblRTSimDataInfoTitle.Text = "📝 How to enter data manually:";
            // 
            // lblRTSimDataInfoMsg
            // 
            this.lblRTSimDataInfoMsg.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.lblRTSimDataInfoMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblRTSimDataInfoMsg.Location = new System.Drawing.Point(40, 28);
            this.lblRTSimDataInfoMsg.Name = "lblRTSimDataInfoMsg";
            this.lblRTSimDataInfoMsg.Size = new System.Drawing.Size(870, 27);
            this.lblRTSimDataInfoMsg.TabIndex = 1;
            this.lblRTSimDataInfoMsg.Text = "Type HEX words (4 hex digits each) separated by spaces.\r\nExample: 1234 5678 ABCD " +
    "EF01 (up to 32 words max)";
            // 
            // lblRTSimDataPrompt
            // 
            this.lblRTSimDataPrompt.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblRTSimDataPrompt.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimDataPrompt.Location = new System.Drawing.Point(10, 95);
            this.lblRTSimDataPrompt.Name = "lblRTSimDataPrompt";
            this.lblRTSimDataPrompt.Size = new System.Drawing.Size(500, 20);
            this.lblRTSimDataPrompt.TabIndex = 1;
            this.lblRTSimDataPrompt.Text = "Enter HEX data below (space-separated, max 32 words):";
            // 
            // lblRTSimWordCountStatic
            // 
            this.lblRTSimWordCountStatic.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.lblRTSimWordCountStatic.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimWordCountStatic.Location = new System.Drawing.Point(760, 95);
            this.lblRTSimWordCountStatic.Name = "lblRTSimWordCountStatic";
            this.lblRTSimWordCountStatic.Size = new System.Drawing.Size(60, 20);
            this.lblRTSimWordCountStatic.TabIndex = 2;
            this.lblRTSimWordCountStatic.Text = "Words:";
            // 
            // lblRTSimWordCount
            // 
            this.lblRTSimWordCount.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold);
            this.lblRTSimWordCount.ForeColor = System.Drawing.Color.Navy;
            this.lblRTSimWordCount.Location = new System.Drawing.Point(820, 95);
            this.lblRTSimWordCount.Name = "lblRTSimWordCount";
            this.lblRTSimWordCount.Size = new System.Drawing.Size(40, 20);
            this.lblRTSimWordCount.TabIndex = 3;
            this.lblRTSimWordCount.Text = "32";
            // 
            // lblRTSimWordMax
            // 
            this.lblRTSimWordMax.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.lblRTSimWordMax.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimWordMax.Location = new System.Drawing.Point(860, 95);
            this.lblRTSimWordMax.Name = "lblRTSimWordMax";
            this.lblRTSimWordMax.Size = new System.Drawing.Size(40, 20);
            this.lblRTSimWordMax.TabIndex = 4;
            this.lblRTSimWordMax.Text = "/ 32";
            // 
            // txtRTSimResponseData
            // 
            this.txtRTSimResponseData.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtRTSimResponseData.Location = new System.Drawing.Point(10, 120);
            this.txtRTSimResponseData.Multiline = true;
            this.txtRTSimResponseData.Name = "txtRTSimResponseData";
            this.txtRTSimResponseData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRTSimResponseData.Size = new System.Drawing.Size(920, 80);
            this.txtRTSimResponseData.TabIndex = 5;
            this.txtRTSimResponseData.Text = "1234 5678 ABCD EF01 2345 6789 BCDE F012 3456 789A CDEF 0123 4567 89AB CDEF 0123 4" +
    "567 89AB CDEF 0123 4567 89AB CDEF 0123 4567 89AB CDEF 0123 4567 89AB";
            this.txtRTSimResponseData.TextChanged += new System.EventHandler(this.RTSim_DataTextBox_TextChanged);
            // 
            // pnlRTSimValidation
            // 
            this.pnlRTSimValidation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.pnlRTSimValidation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRTSimValidation.Controls.Add(this.lblRTSimValidation);
            this.pnlRTSimValidation.Location = new System.Drawing.Point(10, 210);
            this.pnlRTSimValidation.Name = "pnlRTSimValidation";
            this.pnlRTSimValidation.Size = new System.Drawing.Size(920, 30);
            this.pnlRTSimValidation.TabIndex = 6;
            // 
            // lblRTSimValidation
            // 
            this.lblRTSimValidation.Font = new System.Drawing.Font("Lucida Sans", 9F);
            this.lblRTSimValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblRTSimValidation.Location = new System.Drawing.Point(10, 7);
            this.lblRTSimValidation.Name = "lblRTSimValidation";
            this.lblRTSimValidation.Size = new System.Drawing.Size(900, 16);
            this.lblRTSimValidation.TabIndex = 0;
            this.lblRTSimValidation.Text = "✔ Data looks valid — ready to update.";
            // 
            // pnlRTSimWorkflow
            // 
            this.pnlRTSimWorkflow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlRTSimWorkflow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRTSimWorkflow.Controls.Add(this.lblRTSimWorkflow);
            this.pnlRTSimWorkflow.Location = new System.Drawing.Point(10, 250);
            this.pnlRTSimWorkflow.Name = "pnlRTSimWorkflow";
            this.pnlRTSimWorkflow.Size = new System.Drawing.Size(720, 55);
            this.pnlRTSimWorkflow.TabIndex = 7;
            // 
            // lblRTSimWorkflow
            // 
            this.lblRTSimWorkflow.Font = new System.Drawing.Font("Lucida Sans", 8F);
            this.lblRTSimWorkflow.ForeColor = System.Drawing.Color.Black;
            this.lblRTSimWorkflow.Location = new System.Drawing.Point(10, 5);
            this.lblRTSimWorkflow.Name = "lblRTSimWorkflow";
            this.lblRTSimWorkflow.Size = new System.Drawing.Size(700, 45);
            this.lblRTSimWorkflow.TabIndex = 0;
            this.lblRTSimWorkflow.Text = "Workflow:\r\n1. Type/paste/select pattern above\r\n2. Click \"Update RT Data\"\r\n3. Go t" +
    "o RT→BC tab and Receive";
            // 
            // btnRTSimUpdateData
            // 
            this.btnRTSimUpdateData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRTSimUpdateData.Enabled = false;
            this.btnRTSimUpdateData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRTSimUpdateData.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Bold);
            this.btnRTSimUpdateData.ForeColor = System.Drawing.Color.White;
            this.btnRTSimUpdateData.Location = new System.Drawing.Point(750, 250);
            this.btnRTSimUpdateData.Name = "btnRTSimUpdateData";
            this.btnRTSimUpdateData.Size = new System.Drawing.Size(170, 55);
            this.btnRTSimUpdateData.TabIndex = 8;
            this.btnRTSimUpdateData.Text = "🔄 Update RT Data\r\n(Live)";
            this.btnRTSimUpdateData.UseVisualStyleBackColor = false;
            this.btnRTSimUpdateData.Click += new System.EventHandler(this.RTSim_UpdateData_Click);
            // 
            // grpRTSimInstructions
            // 
            this.grpRTSimInstructions.Controls.Add(this.pnlRTSimInstLeft);
            this.grpRTSimInstructions.Font = new System.Drawing.Font("Lucida Sans", 11F, System.Drawing.FontStyle.Bold);
            this.grpRTSimInstructions.ForeColor = System.Drawing.Color.Navy;
            this.grpRTSimInstructions.Location = new System.Drawing.Point(10, 770);
            this.grpRTSimInstructions.Name = "grpRTSimInstructions";
            this.grpRTSimInstructions.Size = new System.Drawing.Size(950, 340);
            this.grpRTSimInstructions.TabIndex = 3;
            this.grpRTSimInstructions.TabStop = false;
            this.grpRTSimInstructions.Text = "How to Use RT Simulator";
            // 
            // pnlRTSimInstLeft
            // 
            this.pnlRTSimInstLeft.Location = new System.Drawing.Point(10, 25);
            this.pnlRTSimInstLeft.Name = "pnlRTSimInstLeft";
            this.pnlRTSimInstLeft.Size = new System.Drawing.Size(450, 300);
            this.pnlRTSimInstLeft.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(6, 622);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1148, 148);
            this.dataGridView1.TabIndex = 1;
            // 
            // lblBandTitle
            // 
            this.lblBandTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBandTitle.ForeColor = System.Drawing.Color.Black;
            this.lblBandTitle.Location = new System.Drawing.Point(10, 54);
            this.lblBandTitle.Name = "lblBandTitle";
            this.lblBandTitle.Size = new System.Drawing.Size(80, 22);
            this.lblBandTitle.TabIndex = 30;
            this.lblBandTitle.Text = "Band Type :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Integrated Test System - Equipment + DDC 1553";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.grpSigGenConn.ResumeLayout(false);
            this.grpSigGenConn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSigGenStatus)).EndInit();
            this.grpSpectrumConn.ResumeLayout(false);
            this.grpSpectrumConn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpectrumStatus)).EndInit();
            this.grpVNAConn.ResumeLayout(false);
            this.grpVNAConn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVNAStatus)).EndInit();
            this.grp1553Conn.ResumeLayout(false);
            this.grp1553Conn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1553Status)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grpBWScal.ResumeLayout(false);
            this.grpBWScal.PerformLayout();
            this.grpSigGenPowerSweep.ResumeLayout(false);
            this.grpSigGenPowerSweep.PerformLayout();
            this.grpTCPowerSelect.ResumeLayout(false);
            this.grpTCPowerSelect.PerformLayout();
            this.grpSigGenParams.ResumeLayout(false);
            this.grpSigGenParams.PerformLayout();
            this.grp_powerLimit.ResumeLayout(false);
            this.grp_powerLimit.PerformLayout();
            this.grp_pwlimitcase2.ResumeLayout(false);
            this.grp_pwlimitcase2.PerformLayout();
            this.grpLiveOutput.ResumeLayout(false);
            this.grpLiveOutput.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.grp1553Info.ResumeLayout(false);
            this.grp1553Params.ResumeLayout(false);
            this.grp1553Params.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.pnlRTSimMain.ResumeLayout(false);
            this.grpRTSimConfig.ResumeLayout(false);
            this.grpRTSimConfig.PerformLayout();
            this.pnlRTSimWarning.ResumeLayout(false);
            this.pnlRTSimStatusBorder.ResumeLayout(false);
            this.grpRTSimPatterns.ResumeLayout(false);
            this.flowRTSimPatterns.ResumeLayout(false);
            this.grpRTSimData.ResumeLayout(false);
            this.grpRTSimData.PerformLayout();
            this.pnlRTSimDataInfo.ResumeLayout(false);
            this.pnlRTSimValidation.ResumeLayout(false);
            this.pnlRTSimWorkflow.ResumeLayout(false);
            this.grpRTSimInstructions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox grp_pwlimitcase2;
        private System.Windows.Forms.TextBox txtlmtStep;
        private System.Windows.Forms.TextBox txtlmtDelay;
        private System.Windows.Forms.Label lbl_pwrlmtStart;
        private System.Windows.Forms.TextBox txtlmtStop;
        private System.Windows.Forms.Label lbl_pwrlmtdel;
        private System.Windows.Forms.Label lbl_pwrlmtStop;
        private System.Windows.Forms.Label lbl_pwrlmtStep;
        private System.Windows.Forms.TextBox txtlmtStart;
        private System.Windows.Forms.Label lbl_powerlimit;
        private System.Windows.Forms.Label PwrLimtunit;
        private System.Windows.Forms.Label lblCurrentPowerLmt;
        private System.Windows.Forms.Label lblcurrPwrLmtTitle;
        private System.Windows.Forms.Label lbl1553power;
        private System.Windows.Forms.Label lbl1553PowerTitle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRTDeviceId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbtxt1553DeviceId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt1553Output_1;
        private System.Windows.Forms.Label lbloPBw;
        private System.Windows.Forms.Label lbloP_BwTitle;
        private System.Windows.Forms.GroupBox grpBWScal;
        private System.Windows.Forms.Label lblPowUnit;
        private System.Windows.Forms.Label lbl_ipPow;
        private System.Windows.Forms.TextBox txtbwPow;
        private System.Windows.Forms.Label lblBwUnit;
        private System.Windows.Forms.Label lblipBw;
        private System.Windows.Forms.TextBox txtBW;
        private System.Windows.Forms.Label lblFrequnit;
        private System.Windows.Forms.Label lbl_ipFreq;
        private System.Windows.Forms.TextBox txt_bwfreq;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt1553BW;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt1553bwstatus;
        private System.Windows.Forms.Label lblCurrBW;
        private System.Windows.Forms.Label lblCurrBWTitle;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cmbBand;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label lblBandTitle;
    }
}