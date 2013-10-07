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
using System.Windows.Shapes;
using System.IO;

namespace AgendaEmpresas
{
    /// <summary>
    /// Interaction logic for agregar.xaml
    /// </summary>
    public partial class agregar : Window
    {
        public agregar()
        {
            
            InitializeComponent();
            LeerDeFile();
        }
        int indice=0;
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
                        indice++;

                    }
                }
                while (linea0 != null && linea1 != null && linea2 != null && linea3 != null && linea4 != null && linea5 != null);

                lector.Close();

            }
        }
         public void GuardarEnFile()
        {
            
           
            FileStream fs = new FileStream(nombreFile, FileMode.Open);
            StreamWriter escritor = new StreamWriter(fs);
            
            for (int i = 0; i < indice; i++)
            {
               
                escritor.WriteLine(personas[i].id);
                
                escritor.WriteLine(personas[i].nombre);
                escritor.WriteLine(personas[i].apellido);
                escritor.WriteLine(personas[i].direccion);
                escritor.WriteLine(personas[i].edad);
                escritor.WriteLine(personas[i].telefono);
            }
            escritor.Close();
        }

        public void guardar(string nombre, string apellido, string direccion, int edad, int telefono)
        {
            
            
            int id = indice;
            if (indice < maximo - 1)
            {

                personas[indice] = new Persona(id, nombre, apellido, direccion, edad, telefono);
                indice++;
                
               
                GuardarEnFile();
            }
            else
                Console.WriteLine("Base de datos llena");
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            guardar(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
            MainWindow Wind = new MainWindow();
            this.Close();
            Wind.Show();
            
            
        }
        
    }
}
