﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace OnlineBookStore
{
    class MagazinePanel:ProductPanel
    {
        public Label Issue;
        public Label Type;
        public Label Price1;
        public Label Price2;
        public Magazine magazine;
       

        public MagazinePanel(Magazine item)
        {
            magazine = item;
            this.BackColor =Color.Transparent;
            this.Size = new Size(290, 190);
            this.BorderStyle = BorderStyle.FixedSingle;
            

            picBox = new PictureBox();
            picBox.Size = new System.Drawing.Size(105, 160);
            picBox.BackgroundImage = item.image;
            picBox.BackgroundImageLayout = ImageLayout.Zoom;

            magnifier = new PictureBox();
            magnifier.Size = new Size(32, 32);
            magnifier.BackgroundImage = Properties.Resources.magnifier;
            magnifier.BackgroundImageLayout = ImageLayout.Zoom;
            magnifier.Cursor = Cursors.Hand;
            magnifier.Click += new EventHandler(panelClick);

            picAdd = new PictureBox();
            picAdd.Size = new Size(32, 32);
            picAdd.BackgroundImage = Properties.Resources.addcart;
            picAdd.BackgroundImageLayout = ImageLayout.Zoom;
            picAdd.Cursor = Cursors.Hand;
            picAdd.Click += new EventHandler(addCart);

            name = new Label();
            name.AutoSize = true;
            name.Text = item.name;
            name.TextAlign = ContentAlignment.MiddleLeft;
            name.Font = new Font("Microsoft Sans Serif", (float)9.75, FontStyle.Italic);
            this.Controls.Add(name);

            Issue = new Label();
            Issue.AutoSize = true;
            Issue.Text = item.Issue;
            Issue.Font = new Font("Microsoft Sans Serif", (float)8.25);
            this.Controls.Add(Issue);

            Type = new Label();
            Type.AutoSize = true;
            Type.Text = item.Category;
            Type.Font = new Font("Microsoft Sans Serif", (float)8.25);
            Type.ForeColor = Color.DarkGray;
            this.Controls.Add(Type);

            Price1 = new Label();
            Price1.AutoSize = true;
            if (item.Sale > 0 && item.Sale < 100)
                Price1.Text = item.price + "TL  %" + item.Sale;
            else
                Price1.Text = ""; Price1.Font = new Font("Microsoft Sans Serif", (float)11.25, FontStyle.Strikeout | FontStyle.Italic);
            Price1.ForeColor = Color.DarkGray;
            this.Controls.Add(Price1);

            Price2 = new Label();
            Price2.AutoSize = true;
            Price2.Text = item.discountedPrice + " TL";
            Price2.Font = new Font("Microsoft Sans Serif", (float)11.25, FontStyle.Bold);
            this.Controls.Add(Price2);

            this.Controls[0].Location = new Point(125, 20);// Name label 
            this.Controls[0].BringToFront();
            this.Controls[1].Location = new Point(125, 50);// Author label
            this.Controls[1].BringToFront();
            this.Controls[2].Location = new Point(125, 80);// Publisher label
            this.Controls[2].BringToFront();
            this.Controls[3].Location = new Point(125, 110);//  Price1 label
            this.Controls[3].BringToFront();
            this.Controls[4].Location = new Point(210, 110);// Price2 label
            this.Controls[4].BringToFront();
            this.Controls.Add(picBox);
            this.Controls[5].Location = new Point(10, 15); //Picturebox
            this.Controls.Add(magnifier);
            this.Controls[6].Location = new Point(170, 140);//Magnifier image
            this.Controls.Add(picAdd);
            this.Controls[7].Location = new Point(225, 140); //Add to cart image
        }

        private void panelClick(object sender, EventArgs e)
        {
            Logger.logger(magazine.name + " Panel Magnifier");
            magazine.ShowProperties();

        }
        void addCart(object sender, EventArgs e)
        {

            Logger.logger(magazine.name + " Panel Add Cart");
            foreach (var it in MainForm.shoppingCart.ItemsToPurchase)
            {
                if (it.Product == this.magazine)
                {
                    it.Quantity++;
                    MessageBox.Show(it.Product.name + " has been added to your shopping cart.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            ItemToPurchase item = new ItemToPurchase();
            item.Product = this.magazine;
            item.Quantity = 1;
            MainForm.shoppingCart.ItemsToPurchase.Add(item);
            MessageBox.Show(item.Product.name + " has been added to your shopping cart.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
