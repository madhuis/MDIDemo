using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private int _counter = 0;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childForm = new ChildForm();
            childForm.MdiParent = this;
            _counter += 1;
            childForm.Text = $"New Document {_counter}";
            childForm.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                //childForm.richTextBox1.
                childForm.DocumentTextBox.Undo();


            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Paste();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void close_click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {

                this.ActiveMdiChild.Close();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                var dialog = new SaveFileDialog();
                dialog.Filter = "Rich Text Files|*.rtf";
                dialog.AddExtension = true;
                var result = dialog.ShowDialog();
                if(result == DialogResult.OK)
                {
                    childForm.DocumentTextBox.SaveFile(dialog.FileName);
                    childForm.Text = dialog.FileName;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Rich Text Files|*.rtf";
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ChildForm child = new ChildForm();
                child.DocumentTextBox.LoadFile(dialog.FileName);
                child.Text = dialog.FileName;
                child.MdiParent = this;
                child.Show();
            }
        }
    }
}
