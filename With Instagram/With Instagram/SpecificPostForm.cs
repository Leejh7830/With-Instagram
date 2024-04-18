using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace With_Instagram
{
    public partial class SpecificPostForm : Form
    {
        // addr 속성을 추가하여 주소값을 저장할 수 있도록 함
        public string Address { get; private set; }

        public SpecificPostForm()
        {
            InitializeComponent();
        }

        private void btnEnter1_Click(object sender, EventArgs e)
        {
            // 텍스트박스에서 주소값을 가져와서 addr 속성에 저장
            Address = txtAddr1.Text;

            // 폼을 닫음
            this.Close();
        }
    }
}
