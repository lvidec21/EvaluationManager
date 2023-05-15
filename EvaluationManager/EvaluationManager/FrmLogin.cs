using EvaluationManager.Models;
using EvaluationManager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationManager
{
    public partial class FrmLogin : Form {
        public FrmLogin() {
            InitializeComponent();
        }
        public static Teacher LoggedTeacher { get; set; }
        {

        }
        private void btnLogin_Click(object sender, EventArgs e) {
            //string username = txtUsername.Text;
            //string password = txtPassword.Text;
            LoggedTeacher = TeacherRepository.GetTeacher(txtUsername.Text)
            if (username == "" || password == "") 
            {
                MessageBox.Show("Popunite sva polja!", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else 
            if (LoggedTeacher != null && LoggedTeacher.CheckPassword(txtPassword.Text)) 
            {
       
            FrmStudents frmStudents = new FrmStudents();
            Hide();
            frmStudents.ShowDialog();
            Close();
            }
            else 
            {
                MessageBox.Show("Korisničko ime ili lozinka nisu ispravni!", "Neuspjela prijava", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
