﻿using System;
using System.Windows.Forms;
using ModuleSoanDe;

namespace ModuleThi
{
    public partial class FormThi : Form
    {
        QuestionCollection testQuestion = new QuestionCollection(new TestXMLExecuter());

        string filePath;

        Test currentTest;

        public FormThi()
        {
            InitializeComponent();
        }

        private void FormThi_Load(object sender, EventArgs e)
        {
            
        }

        private void btnChooseTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lbFilePath.Text = "File name: " + dialog.FileName;
                filePath = dialog.FileName;
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(filePath)) {
                return;
            }

            testQuestion.readXML(filePath);

            if(testQuestion.Size == 0 
                || String.IsNullOrEmpty(txtId.Text)
                || String.IsNullOrEmpty(txtName.Text)
                || String.IsNullOrEmpty(txtEmail.Text)
                || txtEmail.Text.Split('@').Length != 2)
            {
                return;
            }

            currentTest = new Test(new Employee(txtId.Text, txtName.Text, txtEmail.Text), testQuestion.Id);
            FormLamBai flb = new FormLamBai(testQuestion, currentTest);
            this.Hide();
            flb.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
