using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace iHRM.Win.Frm.MathEvaluator
{
    public partial class EvaluatorEditor : DevExpress.XtraEditors.XtraForm
    {
        public class lstItem
        {
            public string Name { get; set; }
            public double Value { get; set; }
            public string Usage { get; set; }
            public string Description { get; set; }
        }

        public string CalcText
        {
            get { return richTextBox1.Text; }
            set { richTextBox1.Text = value; }
        }

        static List<lstItem> lstFunc, lstOper, lstPara;

        public EvaluatorEditor()
        {
            InitializeComponent();
        }

        private void EvaluatorEditor_Load(object sender, EventArgs e)
        {
            if (lstFunc == null)
                lstFunc = LoadXml(Core.Properties.Resources.MathEvaluator_lstFunction);
            if (lstOper == null)
                lstOper = LoadXml(Core.Properties.Resources.MathEvaluator_lstOperator);
            if (lstPara == null)
                lstPara = LoadXml(Core.Properties.Resources.Luong_Parameter);

            listBoxControl1.Items.Clear();
            listBoxControl1.Items.AddRange(lstFunc.Select(i => i.Name).ToArray());
            listBoxControl2.Items.Clear();
            listBoxControl2.Items.AddRange(lstOper.Select(i => i.Name).ToArray());
            grd.DataSource = lstPara;
        }

        List<lstItem> LoadXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            var lst = new List<lstItem>();
            foreach (XmlNode n in doc.SelectNodes("func/item"))
            {
                lst.Add(new lstItem()
                {
                    Name = n.Attributes["Name"].Value,
                    Description = n.Attributes["Description"].Value,
                    Usage = n.Attributes["Usage"].Value
                });
            }

            return lst;
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = lstFunc.SingleOrDefault(i => i.Name == listBoxControl1.SelectedValue.ToString());
            if (n != null)
            {
                labelControl13.Text = n.Usage;
                labelControl14.Text = n.Description;
            }
        }

        private void listBoxControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var n = lstOper.SingleOrDefault(i => i.Name == listBoxControl2.SelectedValue.ToString());
            if (n != null)
            {
                labelControl15.Text = n.Description;
            }
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                NCalc.Expression exp = new NCalc.Expression(!string.IsNullOrWhiteSpace(richTextBox1.SelectedText) ? richTextBox1.SelectedText : richTextBox1.Text);
                foreach (var it in lstPara)
                    exp.Parameters.Add(it.Name, it.Value);

                if (!exp.HasErrors())
                    lblInfo.Text = exp.Evaluate().ToString();
                else
                    lblInfo.Text = exp.Error;
            }
            catch(Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        void InsertText(string txt)
        {
            richTextBox1.Select(richTextBox1.SelectionStart, 0);
            richTextBox1.SelectedText = txt;
            richTextBox1.Focus();
        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            InsertText(listBoxControl1.SelectedValue.ToString());
        }

        private void listBoxControl2_DoubleClick(object sender, EventArgs e)
        {
            InsertText(listBoxControl2.SelectedValue.ToString());
        }

        private void grv_DoubleClick(object sender, EventArgs e)
        {
            var n = grv.GetFocusedRow() as lstItem;
            if (n == null)
                return;

            InsertText("[" + n.Name + "]");
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
