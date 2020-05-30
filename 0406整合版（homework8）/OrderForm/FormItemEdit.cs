using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderApp;

namespace OrderForm {
  public partial class FormItemEdit : Form {
    public OrderItem OrderItem { get; set; }

    public FormItemEdit() {
      InitializeComponent();
    }

    public FormItemEdit(OrderItem orderItem):this() {
      this.OrderItem = orderItem;
      this.ItemBindingSource.DataSource = orderItem;
            goodsBindingSource.Add(new Goods("1", "医用外科口罩", 20));
            goodsBindingSource.Add(new Goods("2", "N95口罩", 30));
            goodsBindingSource.Add(new Goods("3", "防护服", 280.0));
            goodsBindingSource.Add(new Goods("4", "生活日用品", 200.0));
            goodsBindingSource.Add(new Goods("5", "防护眼镜", 40.0));
            goodsBindingSource.Add(new Goods("6", "呼吸机", 3000.0));
            goodsBindingSource.Add(new Goods("7", "食品", 70.0));
            goodsBindingSource.Add(new Goods("8", "水", 3.0));
            goodsBindingSource.Add(new Goods("9", "书", 25.0));

        }

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

    }

    private void label4_Click(object sender, EventArgs e) {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      ItemBindingSource.ResetBindings(false);
    }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
