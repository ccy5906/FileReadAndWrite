using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileReadAndWrite
{
    public partial class FormFile : Form
    {
        public FormFile()
        {
            InitializeComponent();
        }
        


        private void btnReadFileSelect_Click(object sender, EventArgs e)
        {   //파일 읽기 탭에서 파일 선택 버튼
            DialogResult result = this.openFileDlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    this.txtReadFile.Text = this.openFileDlg.FileName;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소하셨습니다", "알림");
                    break;
            }
        }

        private void btnReadText_Click(object sender, EventArgs e)
        {  //파일 읽기 탭에서 불러오기 버튼
            if (txtReadFile.Text == "")
            {
                MessageBox.Show("읽을 파일을 선택해 주세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(txtReadFile.Text))  //있는지 없는지 체크
            {
                MessageBox.Show("읽을 파일이 없습니다", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (StreamReader sr = new StreamReader(this.txtReadFile.Text))  //해당 파일 불러오기
            {  //using을 사용하면 안의 코드가 끝나면 자동으로 닫히게 됨
                this.txtReadText.Text = sr.ReadToEnd();
            }

        }

        private void btnWriteFileSelect_Click(object sender, EventArgs e)
        {   //파일 쓰기에서 파일 선택 버튼 
            DialogResult result = this.saveFileDlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    this.txtWriteFile.Text = this.saveFileDlg.FileName;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소하셨습니다", "알림");
                    break;
            }
        }

        private void btnWriteText_Click(object sender, EventArgs e)
        { //파일 쓰기 탭에서 저장하기 클릭
            if (txtWriteFile.Text == "")
            {
                MessageBox.Show("저장할 파일을 선택해 주세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(this.txtWriteFile.Text))
                {
                    sw.WriteLine(this.txtWriteText.Text);
                }
                MessageBox.Show("파일 저장 성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("파일 저장에 실패했습니다", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
