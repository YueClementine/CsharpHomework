﻿
using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm {
  public partial class FormMain : Form {
    OrderService orderService;
    BindingSource fieldsBS = new BindingSource();
    public String Keyword { get; set; }

    public FormMain() {
      InitializeComponent();
      orderService = new OrderService();
      Order order = new Order(1, new Customer("1", "同济医院"), new List<OrderItem>());
      order.AddItem(new OrderItem(1, new Goods("1", "医用外科口罩", 20),20000));
      order.AddItem(new OrderItem(2, new Goods("2", "N95口罩", 30), 260));
      order.AddItem(new OrderItem(3, new Goods("4", "生活日用品", 200.0), 120));
      order.AddItem(new OrderItem(4, new Goods("6", "呼吸机", 3000.0), 500));
      order.AddItem(new OrderItem(5, new Goods("7", "食品", 70.0), 30));
            orderService.AddOrder(order);
      Order order2 = new Order(2, new Customer("2", "协和医院"), new List<OrderItem>());
      order2.AddItem(new OrderItem(1, new Goods("1", "医用外科口罩", 20), 4800));
      order2.AddItem(new OrderItem(2, new Goods("3", "防护服", 280.0), 220));
      order2.AddItem(new OrderItem(3, new Goods("4", "生活日用品", 200.0), 872));
      order2.AddItem(new OrderItem(4, new Goods("5", "防护眼镜", 40.0), 1222));
      order2.AddItem(new OrderItem(5, new Goods("7", "食品", 70.0), 5438));
      orderService.AddOrder(order2);
      orderBindingSource.DataSource = orderService.Orders;
      cbField.SelectedIndex = 0;
      txtValue.DataBindings.Add("Text", this, "Keyword");
    }

    private void btnAdd_Click(object sender, EventArgs e) {
      FormEdit form2 = new FormEdit(new Order());
      if (form2.ShowDialog() == DialogResult.OK) {
        orderService.AddOrder(form2.CurrentOrder);
        QueryAll();
      }
    }

    private void QueryAll() {
      orderBindingSource.DataSource = orderService.Orders;
      orderBindingSource.ResetBindings(false);
    }

    private void btnModify_Click(object sender, EventArgs e) {
      EditOrder();
    }
    private void dbvOrders_DoubleClick(object sender, EventArgs e) {
      EditOrder();
    }
    private void EditOrder() {
      Order order = orderBindingSource.Current as Order;
      if (order == null) {
        MessageBox.Show("请选择一个订单进行修改");
        return;
      }
      FormEdit form2 = new FormEdit(order, true);
      if (form2.ShowDialog() == DialogResult.OK) {
        orderService.UpdateOrder(form2.CurrentOrder);
        QueryAll();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e) {
      Order order = orderBindingSource.Current as Order;
      if (order == null) {
        MessageBox.Show("请选择一个订单进行删除");
        return;
      }
      orderService.RemoveOrder(order.OrderId);
      QueryAll();
    }

    private void btnExport_Click(object sender, EventArgs e) {
      DialogResult result = saveFileDialog1.ShowDialog();
      if (result.Equals(DialogResult.OK)) {
        String fileName = saveFileDialog1.FileName;
        orderService.Export(fileName);
      }
    }

    private void btnImport_Click(object sender, EventArgs e) {
      DialogResult result = openFileDialog1.ShowDialog();
      if (result.Equals(DialogResult.OK)) {
        String fileName = openFileDialog1.FileName;
        orderService.Import(fileName);
        QueryAll();
      }
    }

    private void btnQuery_Click(object sender, EventArgs e) {
      switch (cbField.SelectedIndex) {
        case 0://所有订单
          orderBindingSource.DataSource =orderService.Orders;
          break;
        case 1://根据ID查询
          int.TryParse(Keyword, out int id);
          Order order = orderService.GetOrder((uint)id);
          List<Order> result = new List<Order>();
          if (order != null) result.Add(order);
          orderBindingSource.DataSource = result;
          break;
        case 2://根据客户查询
          orderBindingSource.DataSource =orderService.QueryOrdersByCustomerName(Keyword);
          break;
        case 3://根据货物查询
          orderBindingSource.DataSource =orderService.QueryOrdersByGoodsName(Keyword);
          break;
        case 4://根据总价格查询（大于某个总价）
          float.TryParse(Keyword,  out float totalPrice);
          orderBindingSource.DataSource =
                 orderService.QueryByTotalAmount(totalPrice);
          break;
      }
      orderBindingSource.ResetBindings(true);

    }

        private void cbField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dbvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
