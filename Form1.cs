using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПР2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label4.Visible = false;
            textBox4.Visible = false;
            label5.Visible = false;
            textBox5.Visible = false;
            try
            {
                Car car = new Car(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
                copyCar = car;

                if (Convert.ToDouble(textBox2.Text) <= 0)
                {
                    MessageBox.Show("Значения объема бака не может быть меньше нуля");
                    return;
                }
                if (Convert.ToDouble(textBox3.Text) <= 0)
                {
                    MessageBox.Show("Значения расхода топлива не может быть меньше нуля"); 
                    return;
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            label4.Visible = true;
            textBox4.Visible = true;
            label5.Visible = true;
            textBox5.Visible = true;
        }

        public Car copyCar;

        private void button2_Click(object sender, EventArgs e)
        {
            copyCar.Vivod();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double kolvoTopl = Convert.ToDouble(textBox4.Text);
                if (kolvoTopl <= 0) { MessageBox.Show("Количество топлива не может быть меньше нуля!"); return; }
                double rasst = Convert.ToDouble(textBox5.Text);
                if (rasst <= 0) { MessageBox.Show("Расстояние не может быть меньше нуля!"); return; }
                copyCar.Toplivo(kolvoTopl, rasst);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            copyCar.Max();
        }
    }

    public class Car
    {
        private string _model; //Модель
        private double _fuelCapacity; //Объем бака
        private double _fuelConsumption; //Расход (л/100км)

        public string model
        {
            set
            {
                if (value == "")
                {
                    MessageBox.Show("Пустое значение!");
                    return;
                }
                else
                {
                    _model = value;
                }

            }

            get
            {
                return _model;
            }
        }

        public double fuelCapacity
        {
            set
            {
                _fuelCapacity = value;
            }
            get { return _fuelCapacity; }
        }

        public double fuelConsumption
        {
            set
            {
                _fuelConsumption = value;
            }
            get { return _fuelConsumption; }
        }

        public Car(string model, double fuelCapacity, double fuelConsumption)
        {
            this.model = model;
            this.fuelCapacity = fuelCapacity;
            this.fuelConsumption = fuelConsumption;
        }

        public void Vivod()
        {
            MessageBox.Show
                ("Модель авто - " + _model +
                "\nОбъем бака - " + _fuelCapacity +
                "\nРасход топлива - " + _fuelConsumption + " /100 км");
        }

        public void Toplivo(double kolvoTopl, double rasst)
        {
            double ost = rasst - (kolvoTopl * (_fuelConsumption / 100));

            if (ost >= 0) { MessageBox.Show("Топлива хватит"); }
            else { MessageBox.Show("Топлива НЕ хватит"); }
        }

        public void Max()
        {
            double Maxrst = fuelCapacity / (fuelConsumption / 100);
            MessageBox.Show("Вы можете проехать " + Maxrst + " км");
        }


    }

}
