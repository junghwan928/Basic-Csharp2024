using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Threading;
using System.ComponentModel;

namespace ex18_winControlApp
{
    public partial class FrmMain : Form
    {
        Random rand = new Random(); // Ʈ���� ����̸����� ����� ������

        public FrmMain()
        {
            InitializeComponent(); // �����̳ʿ��� ������ ȭ�鱸�� �ʱ�ȭ

            LsvDummy.Columns.Add("�̸�");
            LsvDummy.Columns.Add("����");

            GrbEditor.Text = "�ؽ�Ʈ ������"; //�ڵ�����ε� ������ ����
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // ���� OS���� ��ġ�� ��Ʈ�� �ٰ�����
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }
        }

        // ����ü, ����, ���Ÿ����� �����ϴ� �޼���
        void ChangeFont()
        {
            if (CboFonts.SelectedIndex < 0) // �ƹ��͵� ���þȵ�
                return;

            FontStyle style = FontStyle.Regular; // �Ϲ� ����(����X, ���Ÿ�X)�� �ʱ�ȭ

            if (ChkBold.Checked)  // ���� üũ�ڽ��� üũ�ϸ�
                style |= FontStyle.Bold;

            if (ChkItalic.Checked) // ���Ÿ� üũ�ڽ��� üũ�ϸ�
                style |= FontStyle.Italic;

            TxtSampleText.Font = new Font((string)CboFonts.SelectedItem, 12, style);
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear();
            foreach (TreeNode node in TrvDummy.Nodes)
            {
                TreeToList(node);
            }
        }

        private void TreeToList(TreeNode node)
        {
            //throw new NotImplementedException();
            LsvDummy.Items.Add( // ����Ʈ�信 ������ �߰�
                new ListViewItem(
                    new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }
                    )
                );

            foreach (TreeNode subNode in node.Nodes)
            {
                TreeToList(subNode);
            }
        }

        private void CboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        // Ʈ���� ��ũ�� �̺�Ʈ�ڵ鷯
        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PrgDummy.Value = TrbDummy.Value; // Ʈ���� �����͸� �ű�� ���α׷����� ���� ���� ����
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form FrmModal = new Form();
            FrmModal.Text = "���â";
            FrmModal.Width = 300;
            FrmModal.Height = 100;
            FrmModal.BackColor = Color.Red;
            FrmModal.StartPosition = FormStartPosition.CenterParent;
            FrmModal.ShowDialog(); // ���â ����
        }

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form FrmModaless = new Form();
            FrmModaless.Text = "��޸���â";
            FrmModaless.Width = 300;
            FrmModaless.Height = 100;
            FrmModaless.BackColor = Color.Green;
            // ��޸���â�� �θ� ���߾ӿ� ��ġ�� ���� �Ʒ��� ���� �۾� �ؾ���
            FrmModaless.StartPosition = FormStartPosition.Manual;
            FrmModaless.Location = new Point(this.Location.X + (this.Width - FrmModaless.Width) / 2,
                                             this.Location.Y + (this.Height - FrmModaless.Height) / 2);
            FrmModaless.Show(); // ��޸���â ����
        }

        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            // �⺻���� �޽����ڽ� ����
            MessageBox.Show(TxtSampleText.Text, "�޽����ڽ�", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void BtnQuestion_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("����?", "����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("����!");
            }
            else if (res == DialogResult.No)
            {
                MessageBox.Show("�Ⱦ�!!!!");
            }
        }

        // ������ �����ư�� Ŭ�������� �߻��ϴ� �̺�Ʈ�ڵ鷯
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("���� �����Ͻðڽ��ϱ�?", "���Ῡ��", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (res == DialogResult.No) e.Cancel = true;
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rand.Next().ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode == null)
            { // �θ��带 �������� ������ 
                MessageBox.Show("������ ��尡 ����.", "���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // ���̻� ������� �޼��� ����
            }
            TrvDummy.SelectedNode.Nodes.Add(rand.Next().ToString());
            TrvDummy.SelectedNode.Expand();
            TreeToList(); // ����Ʈ�並 �ٽ� �׷��ش�.
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            DlgOpenImage.Title = "�̹��� ����";
            // Filter�� Ȯ���ڸ� �̹����θ� ����
            DlgOpenImage.Filter = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            var res = DlgOpenImage.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                //MessageBox.Show(DlgOpenImage.FileName.ToString());
                PicNormal.Image = Bitmap.FromFile(DlgOpenImage.FileName);
            }
        }

        private void PicNormal_Click(object sender, EventArgs e)
        {
            if (PicNormal.SizeMode == PictureBoxSizeMode.Normal)
            {
                PicNormal.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PicNormal.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        // �ؽ�Ʈ���� �ε� �̺�Ʈ �ڵ鷯

        private void BtnFileLoad_Click(object sender, EventArgs e)
        {
            // openFileDialog ��Ʈ���� �����ο��� ���� ���� �ʰ� ���� �ϴ� ���
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Multiselect = false; // ������ ���� ������ ����
            Dialog.Filter = "Text Files(*.txt;, *.cs;, *.py)|*.txt;, *.cs;, *.py ";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                // UTF-8�� �ѱ��� ����. EUC-KR(WINDOW 949), UTF-8(BOM)�� �ѱ��� ���� ����.
                RtxEditor.LoadFile(Dialog.FileName, RichTextBoxStreamType.PlainText);
            }

        }

        // �ؽ�Ʈ���� ���� �̺�Ʈ �ڵ鷯
        private void BtnFileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "RichText Files(*.rft)|*.rft";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RtxEditor.SaveFile(dialog.FileName, RichTextBoxStreamType.RichNoOleObjs);
            }

        }

        private void btnNoThread_Click(object sender, EventArgs e)
        {
            //���α׷��� �� ����
            var maxValue = 100;
            var currValue = 0;
            prgProcess.Minimum = 0;
            prgProcess.Maximum = maxValue;
            prgProcess.Value = currValue; // 0���� �ʱ�ȭ

            btnThread.Enabled = false;
            btnNoThread.Enabled = false;
            btnStop.Enabled = true;

            // �ݺ� ����
            for (var i = 0; i <= maxValue; i++)
            {
                // ���������� �����ϰ� �ð��� ���� �ɸ��� �۾�
                currValue = i;
                prgProcess.Value = currValue;
                txtLog.AppendText($"���� ���� : {currValue}\r\n");
                Thread.Sleep(500); //1000ms = 1�� , 500ms = 0.5��

            }

            btnThread.Enabled = btnNoThread.Enabled = true;
            btnStop.Enabled = false;

        }

        private void btnThread_Click(object sender, EventArgs e)
        {
            var maxValue = 100;
            prgProcess.Minimum = 0;
            prgProcess.Maximum = maxValue;
            prgProcess.Value = 0; // 0���� �ʱ�ȭ

            btnThread.Enabled = btnNoThread.Enabled = false;
            btnStop.Enabled = true;

            BgwProgress.WorkerReportsProgress = true; //������� ����Ʈ Ȱ��ȭ
            BgwProgress.WorkerSupportsCancellation = true; // ��׶��� ��Ŀ ��� Ȱ��ȭ
            BgwProgress.RunWorkerAsync(null); // ��׶����Ŀ ����

        }

        
        private void btnStop_Click(object sender, EventArgs e)
        {
            BgwProgress.CancelAsync(); // �񵿱�� ���
        }

        #region '��׶��� ��Ŀ �̺�Ʈ �ڵ鷯'

        private void DoRealWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var maxValue = 100;
            var currValue = 0;

            for (var i = 0; i <= maxValue; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // ���ڸ� ������Ű�� UI�� �ݿ�
                    currValue = i;
                    worker.ReportProgress((currValue * 100) / maxValue);
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
        // ���� ����
        private void BgwProgress_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DoRealWork((BackgroundWorker)sender, e);
            e.Result = null;
        }

        // ������� �ٲ�� �� ǥ��
        private void BgwProgress_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // ���� ���¸� ������Ʈ�ϰų� UI�� ǥ���ϴ� ���� �۾��� ������ �� �ֽ��ϴ�.
            // ���� ���, ���� ���¸� ���α׷��� �ٿ� �ݿ��� �� �ֽ��ϴ�.
            prgProcess.Value = e.ProgressPercentage;
            txtLog.AppendText($"����� : {prgProcess.Value} %\r\n");
        }

        //������ �Ϸ� �Ǹ� �� ���� ó��
        private void BgwProgress_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // �۾��� �Ϸ�Ǿ��� �� ������ �۾��� ������ �� �ֽ��ϴ�.
            if (e.Cancelled)
            {
                // �۾��� ��ҵǾ��� �� ������ �۾��� �����մϴ�.
                txtLog.AppendText($"�۾��� ��ҵǾ����ϴ�.\r\n");
            }
            else if (e.Error != null)
            {
                // �۾� �� ������ �߻����� �� ������ �۾��� �����մϴ�.
                MessageBox.Show($"������ �߻��߽��ϴ�: {e.Error.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // �۾��� ���������� �Ϸ�Ǿ��� �� ������ �۾��� �����մϴ�.
                txtLog.AppendText($"�۾��� �Ϸ�Ǿ����ϴ�.\r\n");
            }

            // �۾��� �Ϸ�Ǹ� ��ư ���� ���¸� �ٽ� ������ �� �ֽ��ϴ�.
            btnThread.Enabled = btnNoThread.Enabled = true;
            btnStop.Enabled = false;
        }

        #endregion
    }
}
