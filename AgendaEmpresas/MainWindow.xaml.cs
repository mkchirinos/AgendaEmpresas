using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace AgendaEmpresas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
                     
        }
       
        int indice = 0;
        static int maximo = 150;
        Persona[] personas = new Persona[maximo];

        string nombreFile = "agenda.txt";


        public void LeerDeFile()
        {
            StreamReader lector;

            if (File.Exists(nombreFile))
            {
                lector = new StreamReader(nombreFile);

                Persona person = new Persona();
                string linea0, linea1, linea2, linea3, linea4, linea5;
                do
                {
                    linea0 = lector.ReadLine();
                    if (linea0 == null)
                        break;
                    linea1 = lector.ReadLine();
                    linea2 = lector.ReadLine();
                    linea3 = lector.ReadLine();
                    linea4 = lector.ReadLine();
                    linea5 = lector.ReadLine();
                    if (indice < maximo - 1)
                    {
                        personas[indice] = new Persona(Convert.ToInt32(linea0), linea1, linea2, linea3, Convert.ToInt32(linea4), Convert.ToInt32(linea5));
                        listBox1.Items.Add(personas[indice].nombre);
                        
                        indice++;
                        
                    }
                }
                while (linea0 != null && linea1 != null && linea2 != null && linea3 != null && linea4 != null && linea5 != null);
                
                lector.Close();
               
            }
        }

       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            agregar WindAgregar = new agregar();
            WindAgregar.Owner = this;
            WindAgregar.Show();
            
        }

        


        private void listBox1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int id;

            id = Convert.ToInt32(listBox1.SelectedIndex);
            
            cambiar(id);
                
            
        }
        public void cambiar(int id)
        {
            txtNombre.Text = personas[id].nombre;
            txtApellido.Text = personas[id].apellido;
            txtDirec.Text = personas[id].direccion;
            txtEdad.Text = personas[id].edad.ToString();
            txtTelef.Text = personas[id].telefono.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LeerDeFile();
        }

        

        

       
    }
}
