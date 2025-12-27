using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyuiu.KislayaVA.Sprint7.Project.V4
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        // Если нажать на картинку покажут сообщение про крутого скелета
        
        private void pictureBoxCoolSkeleton_KVA_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("До чего крутой скелет!", "Крутой скелет", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }
    }
}
